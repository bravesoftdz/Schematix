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

        public ObjectEditForm(xPObject pObject, String rootPath)
        {
            InitializeComponent();
            if (pObject == null)
            {
                pObject = new xPObject();
                pObject.FileName = rootPath + "\\" + pObject.ID.ToString() + "\\" + Options.RECORD_FILENAME;
                Text = Options.LangCur.lEETitleAdd + " " + Options.LangCur.lEETitleBox;
            }
            else
                Text = Options.LangCur.lEETitleEdit + " " + Options.LangCur.lEETitleBox;
            PObject = pObject;
            // Main
            tpMain.Text         = Options.LangCur.lOETabMain;
            chkIsPrototype.Text = Options.LangCur.lEEPrototype;
            lblNode.Text        = Options.LangCur.lEENodeName;
            lblName.Text        = Options.LangCur.lEEName;
            lblID.Text          = Options.LangCur.lEEID;
            lblRevision.Text    = Options.LangCur.lEERevision;
            // Fill
            tbNode.Text            = PObject.NodeName;
            chkIsPrototype.Checked = PObject.isPrototype;
            tbName.Text            = PObject.Name;
            tbID.Text              = PObject.ID.ToString();
            tbRevision.Text        = DateTime.FromBinary(PObject.Revision).ToString(Options.TIME_FORMAT);
            tbDescription.Text     = PObject.Description;

            // Image
            tpImage.Text             = Options.LangCur.lOETabImage;
            lblImageType.Text        = Options.LangCur.lOEImageType;
            chkTransparentColor.Text = Options.LangCur.lOETransparentColor;
            lblImagePath.Text        = Options.LangCur.lEEImagePath;
            lblImageBPP.Text         = Options.LangCur.lEEImageBPP;
            lblImageBackColor.Text   = Options.LangCur.lOEUseBackColor;
            toolTip.SetToolTip(btnBackColor,    Options.LangCur.hEEColorPick);
            toolTip.SetToolTip(btnGetImagePath, Options.LangCur.hEEImageLoad);
            toolTip.SetToolTip(btnAlphaColor,   Options.LangCur.hEEColorPick);
            cbbImageType.Items.Add(Options.LangCur.lOEImageType0None);
            cbbImageType.Items.Add(Options.LangCur.lOEImageType1Load);
            cbbImageType.Items.Add(Options.LangCur.lOEImageType2Link);
            // Fill
            GotImage(new Bitmap(PObject.Canvas));
            cbbImageType.SelectedIndex  = (int)PObject.ImageType;
            btnAlphaColor.BackColor     = PObject.AlphaColor;
            chkTransparentColor.Checked = PObject.UseAlphaColor;
            tbImagePath.Text            = PObject.ImagePath;
            cbbImageBPP.SelectedIndex   = (int)PObject.ImageBPP;
            btnBackColor.BackColor      = PObject.BackColor;

            // Nodes
            tpDotes.Text        = Options.LangCur.lOETabDotes;
            lblDot.Text         = Options.LangCur.lOEDot;
            lblDotName.Text     = Options.LangCur.lOEDotName;
            lblDotLocation.Text = Options.LangCur.lOEDotLocation;
            toolTip.SetToolTip(btnDotMoveUp,   Options.LangCur.hOEDotMoveUp);
            toolTip.SetToolTip(btnDotMoveDown, Options.LangCur.hOEDotMoveDown);
            toolTip.SetToolTip(btnDotAdd,      Options.LangCur.hOEDotAdd);
            toolTip.SetToolTip(btnDotSave,     Options.LangCur.hOEDotSave);
            toolTip.SetToolTip(btnDotDelete,   Options.LangCur.hOEDotDelete);
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
            PObject.Revision    = DateTime.Now.ToBinary();
            PObject.Name        = tbName.Text;
            PObject.Description = tbDescription.Text;
            // Image
            PObject.ImageType     = (ImageTypes)cbbImageType.SelectedIndex;
            PObject.AlphaColor    = btnAlphaColor.BackColor;
            PObject.UseAlphaColor = chkTransparentColor.Checked;
            PObject.ImagePath     = tbImagePath.Text;
            PObject.ImageBPP      = (ImageBPPs)cbbImageBPP.SelectedIndex;
            PObject.BackColor     = btnBackColor.BackColor;
            PObject.Canvas        = loadedBitmap;

            PObject.SaveToFile(PObject.FileName);
            Share.UpdateNodeName(PObject);
            // Out
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
