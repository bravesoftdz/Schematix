using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Schematix
{
    public partial class LibraryForm : Form
    {
        public bool bind = true;

        public LibraryForm()
        {
            InitializeComponent();
            Options.lvUsedObjects = lvObjects;
            Options.lvUsedLinks   = lvLinks;
            Options.lvUsedBoxes   = lvBoxes;
            // Initial setup
            var PObject = new xPObject();
            var PLink   = new xPLink();
            var PBox    = new xPBox();
            PObject.NodeName = "Dot";
            PLink.NodeName   = "Link";
            PBox.NodeName    = "Box";
            PObject.FileName = Options.RootObjects + "\\" + Options.RECORD_FILENAME;
            PLink.FileName   = Options.RootLinks   + "\\" + Options.RECORD_FILENAME;
            PBox.FileName    = Options.RootBoxes   + "\\" + Options.RECORD_FILENAME;
            PObject.isPrototype =
            PLink.isPrototype   =
            PBox.isPrototype    = true;
            tvObjects.SelectedNode = tvObjects.Nodes[0];
            tvLinks.SelectedNode   = tvLinks.Nodes[0];
            tvBoxes.SelectedNode   = tvBoxes.Nodes[0];
            PObject.tvNode = tvObjects.SelectedNode;
            PLink.tvNode   = tvLinks.SelectedNode;
            PBox.tvNode    = tvBoxes.SelectedNode;
            PObject.tvNode.Tag = PObject;
            PLink.tvNode.Tag   = PLink;
            PBox.tvNode.Tag    = PBox;
            SetText();
            // Load element trees
            LoadTree(tvObjects.Nodes[0], Options.RootObjects, MakeNodeObject);
            LoadTree(tvLinks.Nodes[0],   Options.RootLinks,   MakeNodeLink);
            LoadTree(tvBoxes.Nodes[0],   Options.RootBoxes,   MakeNodeBox);
        }

        public void StartInit()
        {
            tvElements_Select(tvObjects, btnObjectEdit, Options.rbObject);
            tvElements_Select(tvLinks, btnLinkEdit, Options.rbLink);
            tvElements_Select(tvBoxes, btnBoxEdit, Options.rbBox);
        }

        public void SetText()
        {
            toolTip.RemoveAll();
            // Hints
            toolTip.SetToolTip(btnObjectAdd, Options.LangCur.hLFAdd);
            toolTip.SetToolTip(btnObjectEdit, Options.LangCur.hLFEdit);
            toolTip.SetToolTip(btnLinkAdd, Options.LangCur.hLFAdd);
            toolTip.SetToolTip(btnLinkEdit, Options.LangCur.hLFEdit);
            toolTip.SetToolTip(btnBoxAdd, Options.LangCur.hLFAdd);
            toolTip.SetToolTip(btnBoxEdit, Options.LangCur.hLFEdit);
            toolTip.SetToolTip(btnUsedObjectEdit, Options.LangCur.hLFEdit);
            toolTip.SetToolTip(btnUsedLinkEdit, Options.LangCur.hLFEdit);
            toolTip.SetToolTip(btnUsedBoxEdit, Options.LangCur.hLFEdit);
            toolTip.SetToolTip(chkPin, (chkPin.Checked ? Options.LangCur.hLFPinDown : Options.LangCur.hLFPinUp));
            // Text
            Text = Options.LangCur.lLFTitle;
            lblObjectsCatalog.Text =
            lblLinksCatalog.Text =
            lblBoxesCatalog.Text = Options.LangCur.lLFCatalog;
            lblUsedObjects.Text =
            lblUsedLinks.Text =
            lblUsedBoxes.Text = Options.LangCur.lLFUsed;
            // Colums
            clmObjectName.Text =
            clmLinkName.Text =
            clmBoxName.Text = Options.LangCur.lLFColumName;
            clmObjectCatalog.Text =
            clmLinkCatalog.Text =
            clmBoxCatalog.Text = Options.LangCur.lLFColumCatalog;
            clmObjectLocation.Text =
            clmLinkLocation.Text =
            clmBoxLocation.Text = Options.LangCur.lLFColumLocation;
        }

        private void chkPin_CheckedChanged(object sender, EventArgs e)
        {
            chkPin.BackgroundImage = imageListPin.Images[chkPin.Checked ? 1 : 0];
            chkPin.BackColor = (chkPin.Checked ? Color.LightCyan : SystemColors.Control);
            toolTip.SetToolTip(chkPin, (chkPin.Checked ? Options.LangCur.hLFPinDown : Options.LangCur.hLFPinUp));
            TopMost = chkPin.Checked;
        }

        private void LibraryForm_Move(object sender, EventArgs e)
        {
            int x = Options.mainForm.Location.X + Options.mainForm.Width;
            int y = Options.mainForm.Location.Y;
            bind = (Math.Abs(x - Location.X) < 16) && (Math.Abs(y - Location.Y) < 16);
            if (bind)
                Options.mainForm.MoveLibraryForm();
        }

        private void LibraryForm_FormClosing(object sender, FormClosingEventArgs e)//Ok
        {
            e.Cancel = true;
            Hide();
        }

        #region Load Tree
        delegate xPrototype LoadTreeCallBack();

        private void LoadTree(TreeNode rootNode, String rootDir, LoadTreeCallBack MakeRecord)
        {
            if (MakeRecord == null)
                return;
            var dirs = Directory.GetDirectories(rootDir);
            foreach (var dir in dirs)
                LoadTree(rootNode.Nodes.Add(Path.GetDirectoryName(dir)), dir, MakeRecord);
            String fileName = rootDir + Options.RECORD_FILENAME;
            if (File.Exists(fileName))
            {
                xPrototype prototype = (rootNode.Tag == null) ? MakeRecord() : (rootNode.Tag as xPrototype);
                try
                {
                    prototype.LoadFromFile(fileName);
                }
                catch { }
                prototype.tvNode = rootNode;
                rootNode.Tag = prototype;
                Share.UpdateNodeName(prototype);
            }
        }

        private xPrototype MakeNodeObject()
        {
            var PObject = new xPObject();
            Options.PObjects.Add(PObject);
            return PObject;
        }

        private xPrototype MakeNodeLink()
        {
            var PLink = new xPLink();
            Options.PLinks.Add(PLink);
            return PLink;
        }

        private xPrototype MakeNodeBox()
        {
            var PBox = new xPBox();
            Options.PBoxes.Add(PBox);
            return PBox;
        }
        #endregion

        #region Catalog
        private void tvObjects_AfterSelect(object sender, TreeViewEventArgs e) =>
            tvElements_Select(tvObjects, btnObjectEdit, Options.rbObject);
        
        private void tvLinks_AfterSelect(object sender, TreeViewEventArgs e) =>
            tvElements_Select(tvLinks, btnLinkEdit, Options.rbLink);

        private void tvBoxes_AfterSelect(object sender, TreeViewEventArgs e) =>
            tvElements_Select(tvBoxes, btnBoxEdit, Options.rbBox);

        private void tvElements_Select(TreeView tv, Button btn, RadioButton rb)
        {
            rb.Tag = tv.SelectedNode?.Tag;
            btn.Enabled = (rb.Tag != null);
            Options.ToolTip.SetToolTip(rb, (rb.Tag == null) ? Options.LangCur.hMFNoElement : Options.LangCur.hMFElement + " \"" + (rb.Tag as xPrototype).Name + '"');
        }

        private void btnObjectAdd_Click(object sender, EventArgs e)//
        {
            if (tvObjects.SelectedNode?.Tag == null)
                return;
            var form = new ObjectEditForm(null, Path.GetDirectoryName((tvObjects.SelectedNode.Tag as xPrototype).FileName), false);
            if (form.ShowDialog() == DialogResult.OK)
            {
                form.PObject.tvNode = tvObjects.SelectedNode.Nodes.Add("");
                form.PObject.tvNode.Tag = form.PObject;
                Options.PObjects.Add(form.PObject);
                Share.UpdateNodeName(form.PObject);
            }
        }

        private void btnObjectEdit_Click(object sender, EventArgs e)
        {
            if (tvObjects.SelectedNode?.Tag == null)
                return;
            var form = new ObjectEditForm(tvObjects.SelectedNode.Tag as xPObject, "", (tvObjects.SelectedNode.Level == 0));
            if (form.ShowDialog() == DialogResult.OK)
            {
                //...
            }
        }

        private void btnLinkAdd_Click(object sender, EventArgs e)//
        {
            if (tvLinks.SelectedNode?.Tag == null)
                return;
            var form = new LinkEditForm(null, Path.GetDirectoryName((tvLinks.SelectedNode.Tag as xPrototype).FileName), false);
            if (form.ShowDialog() == DialogResult.OK)
            {
                form.PLink.tvNode = tvObjects.SelectedNode.Nodes.Add("");
                form.PLink.tvNode.Tag = form.PLink;
                Options.PLinks.Add(form.PLink);
                Share.UpdateNodeName(form.PLink);
            }
        }

        private void btnLinkEdit_Click(object sender, EventArgs e)
        {
            if (tvLinks.SelectedNode?.Tag == null)
                return;
            var form = new LinkEditForm(tvLinks.SelectedNode.Tag as xPLink, "", (tvLinks.SelectedNode.Level == 0));
            if (form.ShowDialog() == DialogResult.OK)
            {
                //...
            }
        }

        private void btnBoxAdd_Click(object sender, EventArgs e)//
        {
            if (tvBoxes.SelectedNode?.Tag == null)
                return;
            var form = new BoxEditForm(null, Path.GetDirectoryName((tvBoxes.SelectedNode.Tag as xPrototype).FileName), false);
            if (form.ShowDialog() == DialogResult.OK)
            {
                form.PBox.tvNode = tvObjects.SelectedNode.Nodes.Add("");
                form.PBox.tvNode.Tag = form.PBox;
                Options.PBoxes.Add(form.PBox);
                Share.UpdateNodeName(form.PBox);
            }
        }

        private void btnBoxEdit_Click(object sender, EventArgs e)
        {
            if (tvBoxes.SelectedNode?.Tag == null)
                return;
            var form = new BoxEditForm(tvBoxes.SelectedNode.Tag as xPBox, "", (tvBoxes.SelectedNode.Level == 0));
            if (form.ShowDialog() == DialogResult.OK)
            {
                //...
            }
        }
        #endregion

        #region Split containers
        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            splitContainer2.SplitterDistance = splitContainer1.SplitterDistance;
        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {
            splitContainer3.SplitterDistance = splitContainer2.SplitterDistance;
        }

        private void splitContainer3_SplitterMoved(object sender, SplitterEventArgs e)
        {
            splitContainer1.SplitterDistance = splitContainer3.SplitterDistance;
        }
        #endregion

        #region Used on map
        private void lvObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (0 < lvObjects.SelectedItems.Count)
                btnUsedObjectEdit.Enabled = (lvObjects.SelectedItems[0].Tag != null);
            else
                btnUsedObjectEdit.Enabled = false;
        }

        private void lvLinks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (0 < lvLinks.SelectedItems.Count)
                btnUsedLinkEdit.Enabled = (lvLinks.SelectedItems[0].Tag != null);
            else
                btnUsedLinkEdit.Enabled = false;
        }

        private void lvBoxes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (0 < lvBoxes.SelectedItems.Count)
                btnUsedBoxEdit.Enabled = (lvBoxes.SelectedItems[0].Tag != null);
            else
                btnUsedBoxEdit.Enabled = false;
        }

        private void btnUsedObjectEdit_Click(object sender, EventArgs e)
        {
            if (lvObjects.SelectedItems[0].Tag == null)
                return;
            var form = new ObjectOptionsForm(lvObjects.SelectedItems[0].Tag as xObject);
            if (form.ShowDialog() == DialogResult.OK)
            {
                //...
            }
        }

        private void btnUsedLinkEdit_Click(object sender, EventArgs e)
        {
            if (lvLinks.SelectedItems[0].Tag == null)
                return;
            var form = new LinkOptionsForm(lvLinks.SelectedItems[0].Tag as xLink);
            if (form.ShowDialog() == DialogResult.OK)
            {
                //...
            }
        }

        private void btnUsedBoxEdit_Click(object sender, EventArgs e)
        {
            if (lvBoxes.SelectedItems[0].Tag == null)
                return;
            var form = new BoxOptionsForm(lvBoxes.SelectedItems[0].Tag as xBox);
            if (form.ShowDialog() == DialogResult.OK)
            {
                //...
            }
        }
        #endregion
    }
}
