﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Schematix
{
    public partial class LibraryForm : Form
    {
        public bool bind = true;

        public LibraryForm()
        {
            InitializeComponent();
            SetText();
            // Make initial elements
            var PObject = new xPObject();
            var PLink   = new xPLink();
            var PBox    = new xPBox();
            PObject.Canvas = Share.GetDotImage();
            PObject.Dots[0].X = (Int16)(PObject.Canvas.Width  / 2);
            PObject.Dots[0].Y = (Int16)(PObject.Canvas.Height / 2);
            PObject.ID =
            PLink.ID   =
            PBox.ID    = 1;
            PObject.Revision =
            PLink.Revision   =
            PBox.Revision    = 1;
            PObject.NodeName = "Dot";
            PLink.NodeName   = "Link";
            PBox.NodeName    = "Box";
            PObject.FileName = Options.RootObjects + (Options.RootObjects != "" ? "\\" : "") + "1" + Options.RECORD_EXT_OBJECT;
            PLink.FileName   = Options.RootLinks   + (Options.RootLinks   != "" ? "\\" : "") + "1" + Options.RECORD_EXT_LINK;
            PBox.FileName    = Options.RootBoxes   + (Options.RootBoxes   != "" ? "\\" : "") + "1" + Options.RECORD_EXT_BOX;
            PObject.isPrototype =
            PLink.isPrototype   =
            PBox.isPrototype    = true;
            // Register elements
            Options.PObjects.Add(PObject);
            Options.PLinks.Add(PLink);
            Options.PBoxes.Add(PBox);
            // Load elements trees
            LoadElements(Options.RootObjects, "*" + Options.RECORD_EXT_OBJECT, Options.PObjects, () => new xPObject());
            LoadElements(Options.RootLinks,   "*" + Options.RECORD_EXT_LINK,   Options.PLinks,   () => new xPLink());
            LoadElements(Options.RootBoxes,   "*" + Options.RECORD_EXT_BOX,    Options.PBoxes,   () => new xPBox());
            // Make trees
            BuildTree(tvObjects, Options.PObjects);
            BuildTree(tvLinks,   Options.PLinks);
            BuildTree(tvBoxes,   Options.PBoxes);
            // Select roots
            tvObjects.SelectedNode = tvObjects.Nodes[0];
            tvLinks.SelectedNode   = tvLinks.Nodes[0];
            tvBoxes.SelectedNode   = tvBoxes.Nodes[0];
        }

        internal void StartInit()//
        {
            tvElements_Select(tvObjects, btnObjectEdit, Options.mainForm.rbObject);
            tvElements_Select(tvLinks,   btnLinkEdit,   Options.mainForm.rbLink);
            tvElements_Select(tvBoxes,   btnBoxEdit,    Options.mainForm.rbBox);
        }

        internal void SetText()//
        {
            toolTip.RemoveAll();
            // Hints
            toolTip.SetToolTip(btnObjectAdd, Options.LangCur.hLFAdd);
            toolTip.SetToolTip(btnLinkAdd,   Options.LangCur.hLFAdd);
            toolTip.SetToolTip(btnBoxAdd,    Options.LangCur.hLFAdd);
            toolTip.SetToolTip(btnObjectEdit, Options.LangCur.hLFEdit);
            toolTip.SetToolTip(btnLinkEdit,   Options.LangCur.hLFEdit);
            toolTip.SetToolTip(btnBoxEdit,    Options.LangCur.hLFEdit);
            toolTip.SetToolTip(btnUsedObjectEdit, Options.LangCur.hLFEdit);
            toolTip.SetToolTip(btnUsedLinkEdit,   Options.LangCur.hLFEdit);
            toolTip.SetToolTip(btnUsedBoxEdit,    Options.LangCur.hLFEdit);
            toolTip.SetToolTip(chkPin, (chkPin.Checked ? Options.LangCur.hLFPinDown : Options.LangCur.hLFPinUp));
            // Tabs
            tpObjects.Text = Options.LangCur.lLFTabObjects;
            tpLinks.Text   = Options.LangCur.lLFTabLinks;
            tpBoxes.Text   = Options.LangCur.lLFTabBoxes;
            // Text
            Text = Options.LangCur.lLFTitle;
            lblObjectsCatalog.Text =
            lblLinksCatalog.Text   =
            lblBoxesCatalog.Text   = Options.LangCur.lLFCatalog;
            lblUsedObjects.Text =
            lblUsedLinks.Text   =
            lblUsedBoxes.Text   = Options.LangCur.lLFUsed;
            // Colums
            clmObjectName.Text =
            clmLinkName.Text   =
            clmBoxName.Text    = Options.LangCur.lLFColumName;
            clmObjectLocation.Text =
            clmLinkLocation.Text   =
            clmBoxLocation.Text    = Options.LangCur.lLFColumLocation;
        }

        private void chkPin_CheckedChanged(object sender, EventArgs e)//
        {
            chkPin.BackgroundImage = imageListPin.Images[chkPin.Checked ? 1 : 0];
            chkPin.BackColor = (chkPin.Checked ? Color.LightCyan : SystemColors.Control);
            toolTip.SetToolTip(chkPin, (chkPin.Checked ? Options.LangCur.hLFPinDown : Options.LangCur.hLFPinUp));
            TopMost = chkPin.Checked;
        }

        private void LibraryForm_Move(object sender, EventArgs e)//
        {
            int x = Options.mainForm.Location.X + Options.mainForm.Width;
            int y = Options.mainForm.Location.Y;
            if (ActiveForm != this)
                return;
            bind = (Math.Abs(x - Location.X) < 16) && (Math.Abs(y - Location.Y) < 16);
            if (bind)
                Options.mainForm.MoveLibraryForm();
        }

        private void LibraryForm_FormClosing(object sender, FormClosingEventArgs e)//Ok
        {
            e.Cancel = true;
            Hide();
        }

        internal void SelectTab(int v) => tcCatalog.SelectedIndex = v;//

        #region Load Tree
        delegate xPrototype LoadElements_Make();

        private void LoadElements(String rootDir, String filePattern, List<xPrototype> Prototypes, LoadElements_Make MakeRecord)//
        {
            if (MakeRecord == null)
                return;
            // Call to subfolders
            var dirNames = Directory.GetDirectories(rootDir);
            foreach (var dirName in dirNames)
                LoadElements(dirName, filePattern, Prototypes, MakeRecord);
            // Load files
            int idx;
            xPrototype prototype;
            var fileNames = Directory.GetFiles(rootDir, filePattern);
            foreach (var fileName in fileNames)
                try
                {
                    prototype = MakeRecord();
                    //If loaded
                    if (prototype.LoadFromFile(fileName))
                    {
                        idx = Prototypes.FindIndex(PE => PE.ID == prototype.ID);
                        // Add new
                        if (idx < 0)
                            Prototypes.Add(prototype);
                        // Update
                        else
                            Prototypes[idx] = prototype;
                    }
                }
                catch { }
        }

        private void BuildTree(TreeView tv, List<xPrototype> Prototypes)//
        {
            xPrototype Parent;
            foreach (var Prototype in Prototypes)
            {
                Prototype.tvNode = new TreeNode();
                Prototype.tvNode.Tag = Prototype;
                Parent = Prototypes.Find(xP => xP.ID == Prototype.NodeParent);
                if (Parent == null)
                    tv.Nodes.Add(Prototype.tvNode);
                else
                    Parent.tvNode.Nodes.Add(Prototype.tvNode);
                Share.Library_UpdateNodeName(Prototype);
            }
        }
        #endregion

        #region Catalog
        private void tvObjects_AfterSelect(object sender, TreeViewEventArgs e) => tvElements_Select(tvObjects, btnObjectEdit, Options.mainForm.rbObject);//
        private void tvLinks_AfterSelect  (object sender, TreeViewEventArgs e) => tvElements_Select(tvLinks,   btnLinkEdit,   Options.mainForm.rbLink);//
        private void tvBoxes_AfterSelect  (object sender, TreeViewEventArgs e) => tvElements_Select(tvBoxes,   btnBoxEdit,    Options.mainForm.rbBox);//

        private void tvElements_Select(TreeView tv, Button btn, RadioButton rb)//
        {
            rb.Tag = tv.SelectedNode?.Tag;
            btn.Enabled = (rb.Tag != null);
            if (btn.Enabled)
                if (!(rb.Tag as xPrototype).isPrototype)
                    rb.Tag = null;
            if (rb.Tag != null)
            {
                rb.BackColor = SystemColors.Control;
                Options.mainForm.toolTip.SetToolTip(rb, Options.LangCur.hMFElement + " \"" + (rb.Tag as xPrototype).Name + '"');
            }
            else
            {
                rb.BackColor = Color.Brown;
                Options.mainForm.toolTip.SetToolTip(rb, Options.LangCur.hMFNoElement);
                // Reset to default tool if this button was active
                if (rb.Checked)
                    Options.mainForm.rbDefault.Checked = true;
            }
        }

        private void btnObjectAdd_Click(object sender, EventArgs e)//
        {
            if (tvObjects.SelectedNode?.Tag == null)
                return;
            var form = new ObjectEditForm(null, (tvObjects.SelectedNode.Tag as xPrototype).ID);
            if (form.ShowDialog() == DialogResult.OK)
            {
                form.PObject.tvNode = tvObjects.SelectedNode.Nodes.Add("");
                form.PObject.tvNode.Tag = form.PObject;
                Options.PObjects.Add(form.PObject);
                Share.Library_UpdateNodeName(form.PObject);
            }
        }

        private void btnObjectEdit_Click(object sender, EventArgs e)//
        {
            if (tvObjects.SelectedNode?.Tag == null)
                return;
            var form = new ObjectEditForm(tvObjects.SelectedNode.Tag as xPObject);
            if (form.ShowDialog() == DialogResult.OK)
            {
                Share.Library_UpdateNodeName(form.PObject);
                Options.mainForm.RenewMaps();
            }
        }

        private void btnLinkAdd_Click(object sender, EventArgs e)//
        {
            if (tvLinks.SelectedNode?.Tag == null)
                return;
            var form = new LinkEditForm(null, (tvLinks.SelectedNode.Tag as xPrototype).ID);
            if (form.ShowDialog() == DialogResult.OK)
            {
                form.PLink.tvNode = tvLinks.SelectedNode.Nodes.Add("");
                form.PLink.tvNode.Tag = form.PLink;
                Options.PLinks.Add(form.PLink);
                Share.Library_UpdateNodeName(form.PLink);
            }
        }

        private void btnLinkEdit_Click(object sender, EventArgs e)//
        {
            if (tvLinks.SelectedNode?.Tag == null)
                return;
            var form = new LinkEditForm(tvLinks.SelectedNode.Tag as xPLink);
            if (form.ShowDialog() == DialogResult.OK)
            {
                Share.Library_UpdateNodeName(form.PLink);
                Options.mainForm.RenewMaps();
            }
        }

        private void btnBoxAdd_Click(object sender, EventArgs e)//
        {
            if (tvBoxes.SelectedNode?.Tag == null)
                return;
            var form = new BoxEditForm(null, (tvBoxes.SelectedNode.Tag as xPrototype).ID);
            if (form.ShowDialog() == DialogResult.OK)
            {
                form.PBox.tvNode = tvBoxes.SelectedNode.Nodes.Add("");
                form.PBox.tvNode.Tag = form.PBox;
                Options.PBoxes.Add(form.PBox);
                Share.Library_UpdateNodeName(form.PBox);
            }
        }

        private void btnBoxEdit_Click(object sender, EventArgs e)//
        {
            if (tvBoxes.SelectedNode?.Tag == null)
                return;
            var form = new BoxEditForm(tvBoxes.SelectedNode.Tag as xPBox);
            if (form.ShowDialog() == DialogResult.OK)
            {
                Share.Library_UpdateNodeName(form.PBox);
                Options.mainForm.RenewMaps();
            }
        }
        #endregion

        #region Split containers
        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e) => splitContainer2.SplitterDistance = splitContainer1.SplitterDistance;
        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e) => splitContainer3.SplitterDistance = splitContainer2.SplitterDistance;
        private void splitContainer3_SplitterMoved(object sender, SplitterEventArgs e) => splitContainer1.SplitterDistance = splitContainer3.SplitterDistance;
        #endregion

        #region Used on map
        private void lvObjects_SelectedIndexChanged(object sender, EventArgs e) => lvUsed_SelectedIndexChanged(lvUsedObjects, btnUsedObjectEdit);
        private void lvLinks_SelectedIndexChanged  (object sender, EventArgs e) => lvUsed_SelectedIndexChanged(lvUsedLinks,   btnUsedLinkEdit);
        private void lvBoxes_SelectedIndexChanged  (object sender, EventArgs e) => lvUsed_SelectedIndexChanged(lvUsedBoxes,   btnUsedBoxEdit);

        private void lvUsed_SelectedIndexChanged(ListView lv, Button btn) => btn.Enabled = (0 < lv.SelectedItems.Count) ? (lv.SelectedItems[0].Tag != null) : false;

        private void btnUsedObjectEdit_Click(object sender, EventArgs e)
        {
            if (lvUsedObjects.SelectedItems[0].Tag == null)
                return;
            var form = new ObjectEditForm(lvUsedObjects.SelectedItems[0].Tag as xPObject);
            if (form.ShowDialog() == DialogResult.OK)
            {
                Share.Library_UpdateNodeName(form.PObject);
                Options.mainForm.RenewMaps();
            }
        }

        private void btnUsedLinkEdit_Click(object sender, EventArgs e)
        {
            if (lvUsedLinks.SelectedItems[0].Tag == null)
                return;
            var form = new LinkEditForm(lvUsedLinks.SelectedItems[0].Tag as xPLink);
            if (form.ShowDialog() == DialogResult.OK)
            {
                Share.Library_UpdateNodeName(form.PLink);
                Options.mainForm.RenewMaps();
            }
        }

        private void btnUsedBoxEdit_Click(object sender, EventArgs e)
        {
            if (lvUsedBoxes.SelectedItems[0].Tag == null)
                return;
            var form = new BoxEditForm(lvUsedBoxes.SelectedItems[0].Tag as xPBox);
            if (form.ShowDialog() == DialogResult.OK)
            {
                Share.Library_UpdateNodeName(form.PBox);
                Options.mainForm.RenewMaps();
            }
        }
        #endregion
    }
}
