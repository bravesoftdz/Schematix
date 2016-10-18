using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Schematix
{
    public partial class ObjectEditForm : Form
    {
        const int BORDER_THICK = 5;
        static Bitmap dotBmap = new Bitmap(7, 7, PixelFormat.Format32bppArgb); // (3+ 7 +3)x(3+ 7 +3)
        static Graphics dotGraphics = Graphics.FromImage(dotBmap);
        static Pen pen = new Pen(Color.Black);

        public ObjectEditForm()
        {
            InitializeComponent();
            //...
            cbbNodesRefill(0);
            nudNodeX.Maximum = pbNodePicker.Width  - 1;
            nudNodeY.Maximum = pbNodePicker.Height - 1;

            pbNodePicker.BackColor =
            pbImage.BackColor = btnImageColor.BackColor;
        }

        #region Nodes

        #region Node Dot
        private void nudNodeXY_ValueChanged(object sender, EventArgs e)//Ok
        {
            int x = (int)nudNodeX.Value + BORDER_THICK;
            int y = (int)nudNodeY.Value + BORDER_THICK;
            dotGraphics.Clear(Color.FromArgb(0, 0, 0, 0));
            pen.Color = Color.FromArgb(
                255,
                (255 - pbNodePicker.BackColor.R),
                (255 - pbNodePicker.BackColor.G),
                (255 - pbNodePicker.BackColor.B));
            dotGraphics.DrawRectangle(pen,
                BORDER_THICK - 1,
                BORDER_THICK - 1,
                pbNodePicker.BackgroundImage.Width  + 1,
                pbNodePicker.BackgroundImage.Height + 1);
            dotGraphics.DrawLine(pen, x, 0, x, y + BORDER_THICK - 1);
            dotGraphics.DrawLine(pen, 0, y, x + BORDER_THICK - 1, y);
            dotGraphics.DrawEllipse(pen, x - 3, y - 3, 5, 5);
            pbNodePicker.Image = dotBmap;
            btnNodeSave.Enabled = true;
        }

        private void pbNodePicker_MouseDown(object sender, MouseEventArgs e)//Ok
        {
            btnNodeSave.Enabled = true;
            nudNodeXY_ValueChanged(null, null);
        }

        private void pbNodePicker_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int x = (e.X < 5) ? 0 : e.X - BORDER_THICK;
            int y = (e.Y < 5) ? 0 : e.Y - BORDER_THICK;
            nudNodeX.Value = (nudNodeX.Maximum < x) ? nudNodeX.Maximum : x;
            nudNodeY.Value = (nudNodeY.Maximum < y) ? nudNodeY.Maximum : y;
            nudNodeXY_ValueChanged(null, null);
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
            btnNodeSave.Enabled = false;
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
            btnNodeSave.Enabled = false;
            cbbNodesRefill(idx);
        }

        private void Node_TextChanged(object sender, EventArgs e)//Ok
        {
            btnNodeSave.Enabled = true;
        }

        private void btnNodeSave_EnabledChanged(object sender, EventArgs e)
        {
            btnNodeMoveUp.Enabled =
            btnNodeMoveDown.Enabled = !btnNodeSave.Enabled;
        }

        private void btnNodeSave_Click(object sender, EventArgs e)
        {
            //...
            btnNodeSave.Enabled = false;
        }
        #endregion

        #endregion

        private void btnImageColor_Click(object sender, EventArgs e)//
        {
            if (dlgColor.ShowDialog() == DialogResult.OK)
                pbImage.BackColor =
                pbNodePicker.BackColor =
                btnImageColor.BackColor = dlgColor.Color;
        }

        private void btnAlphaColor_Click(object sender, EventArgs e)//
        {
            if (dlgColor.ShowDialog() == DialogResult.OK)
                pbAlpha.BackColor =
                btnAlphaColor.BackColor = dlgColor.Color;
        }

        private void btnGetImagePath_Click(object sender, EventArgs e)//
        {
            Share.GetImage(tbImagePath, GotImage);
        }
        
        private void GotImage(Image img)//!!!
        {
            pbImage.Image = img;
            pbNodePicker.BackgroundImage = img;
            //...
        }

        private void btnGetAlphaImage_Click(object sender, EventArgs e)//
        {
            Share.GetImage(tbAlphaPath, GotAlpha);
        }

        private void GotAlpha(Image img)//!!!
        {
            pbAlpha.Image = img;
        }

        private void pbNodePicker_BackgroundImageChanged(object sender, EventArgs e)
        {
            nudNodeX.Maximum = pbNodePicker.BackgroundImage.Width  - 1;
            nudNodeY.Maximum = pbNodePicker.BackgroundImage.Height - 1;
            dotBmap = new Bitmap(
                pbNodePicker.BackgroundImage.Width  + BORDER_THICK * 2,
                pbNodePicker.BackgroundImage.Height + BORDER_THICK * 2,
                PixelFormat.Format32bppArgb);
            dotGraphics = Graphics.FromImage(dotBmap);
            nudNodeXY_ValueChanged(null, null);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //...

            // Out
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
