using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Schematix
{
    public partial class ObjectEditForm : Form
    {
        const int DOT_PICKER_PADDING = 5;
        static Bitmap dotBmap = new Bitmap(7, 7, PixelFormat.Format32bppArgb); // (3+ 7 +3)x(3+ 7 +3)
        Graphics dotGraphics = Graphics.FromImage(dotBmap);
        Pen pen = new Pen(Color.Black);
        Bitmap loadedBitmap = new Bitmap(7, 7);

        public xPObject PObject;

        public ObjectEditForm(xPObject pObject)
        {
            InitializeComponent();
            if (pObject == null)
            {
                pObject = new xPObject();
                Text = options.LangCur.lEETitleAdd + " " + options.LangCur.lEETitleBox;
            }
            else
                Text = options.LangCur.lEETitleEdit + " " + options.LangCur.lEETitleBox;
            PObject = pObject;
            // Main
            tpMain.Text         = options.LangCur.lOETabMain;
            chkIsPrototype.Text = options.LangCur.lEEPrototype;
            lblNode.Text        = options.LangCur.lEENodeName;
            lblName.Text        = options.LangCur.lEEName;
            lblID.Text          = options.LangCur.lEEID;
            lblRevision.Text    = options.LangCur.lEERevision;
            // Fill
            tbNode.Text            = PObject.NodeName;
            chkIsPrototype.Checked = PObject.isPrototype;
            tbName.Text            = PObject.Name;
            tbID.Text              = PObject.ID.ToString();
            tbRevision.Text        = PObject.Revision.ToString(options.TIME_FORMAT);
            tbDescription.Text     = PObject.Description;

            // Image
            tpImage.Text             = options.LangCur.lOETabImage;
            lblImageType.Text        = options.LangCur.lOEImageType;
            chkTransparentColor.Text = options.LangCur.lOETransparentColor;
            lblImagePath.Text        = options.LangCur.lEEImagePath;
            lblImageBPP.Text         = options.LangCur.lEEImageBPP;
            lblImageBackColor.Text   = options.LangCur.lOEUseBackColor;
            toolTip.SetToolTip(btnBackColor,    options.LangCur.hEEColorPick);
            toolTip.SetToolTip(btnGetImagePath, options.LangCur.hEEImageLoad);
            toolTip.SetToolTip(btnAlphaColor,   options.LangCur.hEEColorPick);
            cbbImageType.Items.Add(options.LangCur.lOEImageType0None);
            cbbImageType.Items.Add(options.LangCur.lOEImageType1Load);
            cbbImageType.Items.Add(options.LangCur.lOEImageType2Link);
            // Fill
            GotImage(new Bitmap(PObject.ImageCanva));
            cbbImageType.SelectedIndex  = (int)PObject.ImageType;
            btnAlphaColor.BackColor     = PObject.AlphaColor;
            chkTransparentColor.Checked = PObject.UseAlphaColor;
            tbImagePath.Text            = PObject.ImagePath;
            cbbImageBPP.SelectedIndex   = (int)PObject.ImageBPP;
            btnBackColor.BackColor      = PObject.BackColor;

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
            // Fill
            cbbNodesRefill(0);
        }

        #region Image
        private void btnGetImagePath_Click(object sender, EventArgs e)//
        {
            Share.GetImage(tbImagePath, GotImage);
        }
        
        private void GotImage(Bitmap img)
        {
            loadedBitmap = img;
            chkTransparentColor_CheckedChanged(null, null);
        }

        private void btnColor_Click(object sender, EventArgs e)//Ok
        {
            if (dlgColor.ShowDialog() != DialogResult.OK)
                return;
            (sender as Button).BackColor = dlgColor.Color;
        }

        private void btnBackColor_BackColorChanged(object sender, EventArgs e)//Ok
        {
            pbDotPicker.BackColor =
            pbImage.BackColor = btnBackColor.BackColor;
        }

        private void chkTransparentColor_CheckedChanged(object sender, EventArgs e)
        {
            Bitmap bmap = new Bitmap(loadedBitmap);
            if (chkTransparentColor.Checked)
                bmap.MakeTransparent(btnAlphaColor.BackColor);
            pbImage.Image =
            pbDotPicker.BackgroundImage = bmap;
        }
        #endregion

        #region Dots
        private void pbDotPicker_BackgroundImageChanged(object sender, EventArgs e)//
        {
            nudDotX.Maximum = loadedBitmap.Width  - 1;
            nudDotY.Maximum = loadedBitmap.Height - 1;
            dotBmap = new Bitmap(
                loadedBitmap.Width  + DOT_PICKER_PADDING * 2,
                loadedBitmap.Height + DOT_PICKER_PADDING * 2,
                PixelFormat.Format32bppArgb);
            dotGraphics = Graphics.FromImage(dotBmap);
            nudNodeXY_ValueChanged(null, null);
        }

        private void pbNodePicker_MouseDoubleClick(object sender, MouseEventArgs e)//
        {
            int x = (e.X < 5) ? 0 : e.X - DOT_PICKER_PADDING;
            int y = (e.Y < 5) ? 0 : e.Y - DOT_PICKER_PADDING;
            nudDotX.Value = (nudDotX.Maximum < x) ? nudDotX.Maximum : x;
            nudDotY.Value = (nudDotY.Maximum < y) ? nudDotY.Maximum : y;
            nudNodeXY_ValueChanged(null, null);
        }

        private void nudNodeXY_ValueChanged(object sender, EventArgs e)//Ok
        {
            int x = (int)nudDotX.Value + DOT_PICKER_PADDING;
            int y = (int)nudDotY.Value + DOT_PICKER_PADDING;
            dotGraphics.Clear(Color.FromArgb(0, 0, 0, 0));
            pen.Color = Color.FromArgb(
                255,
                (pbDotPicker.BackColor.R) ^ 128,
                (pbDotPicker.BackColor.G) ^ 128,
                (pbDotPicker.BackColor.B) ^ 128);
            dotGraphics.DrawRectangle(pen,
                DOT_PICKER_PADDING - 1,
                DOT_PICKER_PADDING - 1,
                pbDotPicker.BackgroundImage.Width  + 1,
                pbDotPicker.BackgroundImage.Height + 1);
            dotGraphics.DrawLine(pen, x, 0, x, y + DOT_PICKER_PADDING - 1);
            dotGraphics.DrawLine(pen, 0, y, x + DOT_PICKER_PADDING - 1, y);
            dotGraphics.DrawEllipse(pen, x - 3, y - 3, 5, 5);
            pbDotPicker.Image = dotBmap;
            btnDotSave.Enabled = true;
        }
        
        private void cbbNodesRefill(int idx)//
        {
            cbbDots.Items.Clear();
            int i = 0;
            foreach (var Dot in PObject.Dots)
                cbbDots.Items.Add((i++).ToString() + " - [" + Dot.X + ", " + Dot.Y + "] \"" + Dot.Name + "\"");
            // Select asked node
            if (idx < 0)
                idx = 0;
            if (cbbDots.Items.Count <= idx)
                idx = cbbDots.Items.Count - 1;
            cbbDots.SelectedIndex = idx;
            // Limit addition
            btnDotAdd.Enabled = (cbbDots.Items.Count < 256);
        }

        private void cbbDots_SelectedIndexChanged(object sender, EventArgs e)//
        {
            int idx = cbbDots.SelectedIndex;
            if (idx < 0)
                return;
            else
            {
                tbDotName.Text     = PObject.Dots[idx].Name;
                tbDescription.Text = PObject.Dots[idx].Description;
                nudDotX.Value = PObject.Dots[idx].X;
                nudDotY.Value = PObject.Dots[idx].Y;
            }
            btnDotSave.Enabled = false;
        }

        private void btnNodeAdd_Click(object sender, EventArgs e)//
        {
            PObject.Dots.Add(new xDot(PObject));
            cbbNodesRefill(cbbDots.Items.Count);
        }

        private void btnNodeMoveUp_Click(object sender, EventArgs e)//Ok
        {
            int idx = cbbDots.SelectedIndex;
            if (0 < idx)
            {
                xDot d = PObject.Dots[idx];
                PObject.Dots[idx] = PObject.Dots[idx - 1];
                PObject.Dots[idx - 1] = d;
                cbbNodesRefill(idx - 1);
            }
        }

        private void btnNodeMoveDown_Click(object sender, EventArgs e)//Ok
        {
            int idx = cbbDots.SelectedIndex;
            if (idx + 1 < cbbDots.Items.Count)
            {
                xDot d = PObject.Dots[idx];
                PObject.Dots[idx] = PObject.Dots[idx + 1];
                PObject.Dots[idx + 1] = d;
                cbbNodesRefill(idx + 1);
            }
        }

        private void btnNodeDelete_Click(object sender, EventArgs e)//Ok
        {
            int idx = cbbDots.SelectedIndex;
            if (idx < 0)
                return;
            cbbDots.Items.RemoveAt(idx);
            PObject.DeleteDot(PObject.Dots[idx]);
            cbbNodesRefill(idx);
        }

        private void Dot_TextChanged(object sender, EventArgs e)//Ok
        {
            btnDotSave.Enabled = true;
        }

        private void btnNodeSave_EnabledChanged(object sender, EventArgs e)//Ok
        {
            btnDotMoveUp.Enabled =
            btnDotMoveDown.Enabled = !btnDotSave.Enabled;
        }

        private void btnNodeSave_Click(object sender, EventArgs e)//Ok
        {
            int idx = cbbDots.SelectedIndex;
            if (idx < 0)
                return;
            PObject.Dots[idx].Name        = tbDotName.Text;
            PObject.Dots[idx].Description = tbDescription.Text;
            PObject.Dots[idx].X = (short)nudDotX.Value;
            PObject.Dots[idx].Y = (short)nudDotY.Value;
            cbbNodesRefill(idx);
        }
        #endregion

        private void btnOk_Click(object sender, EventArgs e)
        {
            // Main
            PObject.NodeName    = tbNode.Text;
            PObject.isPrototype = chkIsPrototype.Checked;
            PObject.Revision    = DateTime.Now;
            PObject.Name        = tbName.Text;
            PObject.Description = tbDescription.Text;
            // Image
            PObject.ImageType     = (ImageTypes)cbbImageType.SelectedIndex;
            PObject.AlphaColor    = btnAlphaColor.BackColor;
            PObject.UseAlphaColor = chkTransparentColor.Checked;
            PObject.ImagePath     = tbImagePath.Text;
            PObject.ImageBPP      = (ImageBPPs)cbbImageBPP.SelectedIndex;
            PObject.BackColor     = btnBackColor.BackColor;
            PObject.ImageCanva    = loadedBitmap;

            // Out
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
