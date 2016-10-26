﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Schematix
{
    public partial class LibraryForm : Form
    {
        public bool bind = true;

        public LibraryForm()
        {
            InitializeComponent();
            tvObjects.SelectedNode = tvObjects.Nodes[0];
            tvLinks.SelectedNode = tvLinks.Nodes[0];
            tvBoxes.SelectedNode = tvBoxes.Nodes[0];
            SetText();
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

        #region Catalog
        private void tvObjects_AfterSelect(object sender, TreeViewEventArgs e)
        {
            btnObjectEdit.Enabled = (tvObjects.SelectedNode?.Tag != null);
        }

        private void tvLinks_AfterSelect(object sender, TreeViewEventArgs e)
        {
            btnLinkEdit.Enabled = (tvLinks.SelectedNode?.Tag != null);
        }

        private void tvBoxes_AfterSelect(object sender, TreeViewEventArgs e)
        {
            btnBoxEdit.Enabled = (tvBoxes.SelectedNode?.Tag != null);
        }

        private void btnObjectAdd_Click(object sender, EventArgs e)
        {
            var form = new ObjectEditForm(null);
            if (form.ShowDialog() == DialogResult.OK)
            {
                //...
            }
        }

        private void btnObjectEdit_Click(object sender, EventArgs e)
        {
            if (tvObjects.SelectedNode?.Tag == null)
                return;
            var form = new ObjectEditForm(tvObjects.SelectedNode.Tag as xPObject);
            if (form.ShowDialog() == DialogResult.OK)
            {
                //...
            }
        }

        private void btnLinkAdd_Click(object sender, EventArgs e)
        {
            var form = new LinkEditForm(null);
            if (form.ShowDialog() == DialogResult.OK)
            {
                //...
            }
        }

        private void btnLinkEdit_Click(object sender, EventArgs e)
        {
            if (tvLinks.SelectedNode?.Tag == null)
                return;
            var form = new LinkEditForm(tvLinks.SelectedNode.Tag as xPLink);
            if (form.ShowDialog() == DialogResult.OK)
            {
                //...
            }
        }

        private void btnBoxAdd_Click(object sender, EventArgs e)
        {
            var form = new BoxEditForm(null);
            if (form.ShowDialog() == DialogResult.OK)
            {
                //...
            }
        }

        private void btnBoxEdit_Click(object sender, EventArgs e)
        {
            if (tvBoxes.SelectedNode?.Tag == null)
                return;
            var form = new BoxEditForm(tvBoxes.SelectedNode.Tag as xPBox);
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
