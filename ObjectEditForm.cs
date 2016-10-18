using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schematix
{
    public partial class ObjectEditForm : Form
    {
        public ObjectEditForm()
        {
            InitializeComponent();
            //...
            cbbNodesRefill(0);
            nudNodeX.Maximum = pbNodePicker.Width  - 1;
            nudNodeY.Maximum = pbNodePicker.Height - 1;
        }

        #region Nodes

        #region Node Dot
        private void nudNodeXY_ValueChanged(object sender, EventArgs e)//Ok
        {
            pbNodeDot.Location = new Point((int)nudNodeX.Value + 1, (int)nudNodeY.Value + 1);
            if (!chkNodeGetXY.Checked)
                btnNodeSave.Enabled = true;
        }

        private void pbNodePicker_MouseMove(object sender, MouseEventArgs e)//Ok
        {
            if (!chkNodeGetXY.Checked)
                return;
            nudNodeX.Value = e.X;
            nudNodeY.Value = e.Y;
        }

        private void pbNodePicker_MouseDown(object sender, MouseEventArgs e)//Ok
        {
            chkNodeGetXY.Checked = false;
            pbNodeDot.Visible = true;
            btnNodeSave.Enabled = true;
        }

        private void chkNodeGetXY_CheckedChanged(object sender, EventArgs e)//Ok
        {
            pbNodeDot.Visible = false;
            nudNodeX.BackColor =
            nudNodeY.BackColor = (chkNodeGetXY.Checked ? Color.LightCyan : SystemColors.Window);
        }
        #endregion

        #region Node Record
        private void cbbNodesRefill(int idx)
        {
            cbbNodes.Items.Clear();
            //...
            // Must be atleast 1 node
            if (cbbNodes.Items.Count < 1)
                cbbNodes.Items.Add("0 - \"\"");
            // Select asked node
            if (idx < 0)
                idx = 0;
            if (cbbNodes.Items.Count <= idx)
                idx = cbbNodes.Items.Count - 1;
            cbbNodes.SelectedIndex = idx;
            // Limit addition
            btnNodeAdd.Enabled = (cbbNodes.Items.Count < 256);
            btnNodeDelete.Enabled = (0 < cbbNodes.Items.Count);
        }

        private void cbbNodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //...
        }

        private void btnNodeAdd_Click(object sender, EventArgs e)
        {
            //...
            cbbNodesRefill(cbbNodes.Items.Count);
        }

        private void btnNodeMoveUp_Click(object sender, EventArgs e)
        {
            int idx = cbbNodes.SelectedIndex;
            if (0 < idx)
            {
                //...
                cbbNodesRefill(idx - 1);
            }
        }

        private void btnNodeMoveDown_Click(object sender, EventArgs e)
        {
            int idx = cbbNodes.SelectedIndex;
            if (idx + 1 < cbbNodes.Items.Count)
            {
                //...
                cbbNodesRefill(idx + 1);
            }
        }

        private void btnNodeDelete_Click(object sender, EventArgs e)
        {
            int idx = cbbNodes.SelectedIndex;
            if (idx < 0)
                return;
            //...
            cbbNodes.Items.RemoveAt(idx);
            cbbNodesRefill(idx);
        }

        private void Node_TextChanged(object sender, EventArgs e)//Ok
        {
            btnNodeSave.Enabled = true;
        }

        private void btnNodeSave_Click(object sender, EventArgs e)
        {
            //...
            btnNodeSave.Enabled = false;
        }
        #endregion

        #endregion
    }
}
