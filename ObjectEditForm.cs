using System;
using System.Drawing;
using System.Drawing.Imaging;
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
            // Main
            tpMain.Text      = options.LangCur.lOETabMain;
            lblNode.Text     = options.LangCur.lEENodeName;
            lblName.Text     = options.LangCur.lEEName;
            lblID.Text       = options.LangCur.lEEID;
            lblRevision.Text = options.LangCur.lEERevision;
            // Image
            tpImage.Text             = options.LangCur.lOETabImage;
            lblImageType.Text        = options.LangCur.lOEImageType;
            chkTransparentColor.Text = options.LangCur.lOETransparentColor;
            lblImagePath.Text        = options.LangCur.lEEImagePath;
            lblImageBPP.Text         = options.LangCur.lEEImageBPP;
            toolTip.SetToolTip(btnImageColor,   options.LangCur.hEEColorPick);
            toolTip.SetToolTip(btnGetImagePath, options.LangCur.hEEImageLoad);
            lblImageBackColor.Text = options.LangCur.lOEUseBackColor;
            cbbImageType.Items.Add(options.LangCur.lOEImageType0None);
            cbbImageType.Items.Add(options.LangCur.lOEImageType1Load);
            cbbImageType.Items.Add(options.LangCur.lOEImageType2Link);
            toolTip.SetToolTip(btnAlphaColor,   options.LangCur.hEEColorPick);
            // Nodes
            tpDotes.Text        = options.LangCur.lOETabDotes;
            lblDot.Text         = options.LangCur.lOEDot;
            lblDotName.Text     = options.LangCur.lOEDotName;
            lblDotLocation.Text = options.LangCur.lOEDotLocation;
            toolTip.SetToolTip(btnDotMoveUp,   options.LangCur.hOEDotMoveUp);
            toolTip.SetToolTip(btnDotMoveDown, options.LangCur.hOEDotMoveDown);
            toolTip.SetToolTip(btnDotAdd,      options.LangCur.hOEDotAdd);
            toolTip.SetToolTip(btnDotSave,     options.LangCur.hOEDotSave);
            toolTip.SetToolTip(btnDotDelete,   options.LangCur.hOEDotDelete);
            //
            if (false)
            {
                Text = options.LangCur.lEETitleEdit + " " + options.LangCur.lEETitleBox;
                //...
            }
            else
            {
                Text = options.LangCur.lEETitleAdd + " " + options.LangCur.lEETitleBox;
                cbbImageType.SelectedIndex = 0;
                cbbImageBPP.SelectedIndex = 0;
            }
            pbDotPicker.BackColor =
            pbImage.BackColor = btnImageColor.BackColor;

            nudDotX.Maximum = pbDotPicker.Width - 1;
            nudDotY.Maximum = pbDotPicker.Height - 1;

            cbbNodesRefill(0);
        }

        #region Nodes

        #region Node Dot
        private void nudNodeXY_ValueChanged(object sender, EventArgs e)//Ok
        {
            int x = (int)nudDotX.Value + BORDER_THICK;
            int y = (int)nudDotY.Value + BORDER_THICK;
            dotGraphics.Clear(Color.FromArgb(0, 0, 0, 0));
            pen.Color = Color.FromArgb(
                255,
                (255 - pbDotPicker.BackColor.R),
                (255 - pbDotPicker.BackColor.G),
                (255 - pbDotPicker.BackColor.B));
            dotGraphics.DrawRectangle(pen,
                BORDER_THICK - 1,
                BORDER_THICK - 1,
                pbDotPicker.BackgroundImage.Width  + 1,
                pbDotPicker.BackgroundImage.Height + 1);
            dotGraphics.DrawLine(pen, x, 0, x, y + BORDER_THICK - 1);
            dotGraphics.DrawLine(pen, 0, y, x + BORDER_THICK - 1, y);
            dotGraphics.DrawEllipse(pen, x - 3, y - 3, 5, 5);
            pbDotPicker.Image = dotBmap;
            btnDotSave.Enabled = true;
        }

        private void pbNodePicker_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int x = (e.X < 5) ? 0 : e.X - BORDER_THICK;
            int y = (e.Y < 5) ? 0 : e.Y - BORDER_THICK;
            nudDotX.Value = (nudDotX.Maximum < x) ? nudDotX.Maximum : x;
            nudDotY.Value = (nudDotY.Maximum < y) ? nudDotY.Maximum : y;
            nudNodeXY_ValueChanged(null, null);
        }
        #endregion

        #region Node Record
        private void cbbNodesRefill(int idx)
        {
            cbbDotes.Items.Clear();
            //...
            // Must be atleast 1 node
            if (cbbDotes.Items.Count < 1)
                cbbDotes.Items.Add("0 - \"\"");
            // Select asked node
            if (idx < 0)
                idx = 0;
            if (cbbDotes.Items.Count <= idx)
                idx = cbbDotes.Items.Count - 1;
            cbbDotes.SelectedIndex = idx;
            // Limit addition
            btnDotAdd.Enabled = (cbbDotes.Items.Count < 256);
            btnDotDelete.Enabled = (0 < cbbDotes.Items.Count);
        }

        private void cbbNodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //...
        }

        private void btnNodeAdd_Click(object sender, EventArgs e)
        {
            //...
            btnDotSave.Enabled = false;
            cbbNodesRefill(cbbDotes.Items.Count);
        }

        private void btnNodeMoveUp_Click(object sender, EventArgs e)
        {
            int idx = cbbDotes.SelectedIndex;
            if (0 < idx)
            {
                //...
                cbbNodesRefill(idx - 1);
            }
        }

        private void btnNodeMoveDown_Click(object sender, EventArgs e)
        {
            int idx = cbbDotes.SelectedIndex;
            if (idx + 1 < cbbDotes.Items.Count)
            {
                //...
                cbbNodesRefill(idx + 1);
            }
        }

        private void btnNodeDelete_Click(object sender, EventArgs e)
        {
            int idx = cbbDotes.SelectedIndex;
            if (idx < 0)
                return;
            //...
            cbbDotes.Items.RemoveAt(idx);
            btnDotSave.Enabled = false;
            cbbNodesRefill(idx);
        }

        private void Node_TextChanged(object sender, EventArgs e)//Ok
        {
            btnDotSave.Enabled = true;
        }

        private void btnNodeSave_EnabledChanged(object sender, EventArgs e)
        {
            btnDotMoveUp.Enabled =
            btnDotMoveDown.Enabled = !btnDotSave.Enabled;
        }

        private void btnNodeSave_Click(object sender, EventArgs e)
        {
            //...
            btnDotSave.Enabled = false;
        }
        #endregion

        #endregion

        private void btnImageColor_Click(object sender, EventArgs e)//
        {
            if (dlgColor.ShowDialog() == DialogResult.OK)
                pbDotPicker.BackColor =
                pbImage.BackColor =
                btnImageColor.BackColor = dlgColor.Color;
        }

        private void btnAlphaColor_Click(object sender, EventArgs e)//
        {
            if (dlgColor.ShowDialog() == DialogResult.OK)
                btnAlphaColor.BackColor = dlgColor.Color;
        }

        private void btnGetImagePath_Click(object sender, EventArgs e)//
        {
            Share.GetImage(tbImagePath, GotImage);
        }
        
        private void GotImage(Image img)//!!!
        {
            pbImage.Image = img;
            pbDotPicker.BackgroundImage = img;
            //...
        }

        private void pbNodePicker_BackgroundImageChanged(object sender, EventArgs e)
        {
            nudDotX.Maximum = pbDotPicker.BackgroundImage.Width  - 1;
            nudDotY.Maximum = pbDotPicker.BackgroundImage.Height - 1;
            dotBmap = new Bitmap(
                pbDotPicker.BackgroundImage.Width  + BORDER_THICK * 2,
                pbDotPicker.BackgroundImage.Height + BORDER_THICK * 2,
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
