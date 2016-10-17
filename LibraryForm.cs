using System;
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
        #endregion

        #region Split containers
        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            splitContainer3.SplitterDistance =
            splitContainer2.SplitterDistance = splitContainer1.SplitterDistance;
        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {
            splitContainer3.SplitterDistance =
            splitContainer1.SplitterDistance = splitContainer2.SplitterDistance;
        }

        private void splitContainer3_SplitterMoved(object sender, SplitterEventArgs e)
        {
            splitContainer1.SplitterDistance =
            splitContainer2.SplitterDistance = splitContainer3.SplitterDistance;
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
        #endregion

        private void LibraryForm_Move(object sender, EventArgs e)
        {
            int x = options.mainForm.Location.X + options.mainForm.Width;
            int y = options.mainForm.Location.Y;
            bind = (Math.Abs(x - Location.X) < 16) && (Math.Abs(y - Location.Y) < 16);
            if (bind)
                options.mainForm.MainForm_Move(null, null);
        }
    }
}
