using System;
using System.Drawing;
using System.Windows.Forms;

namespace Schematix
{
    public partial class MapOptionsForm : Form
    {
        public xMap Map;
        Bitmap imageOriginal = new Bitmap(1, 1);
        Bitmap imageAlpha = null;

        public MapOptionsForm(xMap map)
        {
            InitializeComponent();
            if (map == null)
                map = new xMap();
            Map = map;
            Text = Options.LangCur.lMOTitle;

            #region Main
            tpMain.Text = Options.LangCur.lMOTabMain;
            lblName.Text     = Options.LangCur.lMOName;
            lblSize.Text     = Options.LangCur.lMOSize;
            chkSizeAuto.Text = Options.LangCur.lMOAuto;
            // Fill
            tbName.Text         = Map.Name;
            nudSizeW.Value      = Map.Width;
            nudSizeH.Value      = Map.Height;
            tbDescription.Text  = Map.Description;
            chkSizeAuto.Checked = Map.AutoSize;
            #endregion

            #region Background
            tpBack.Text = Options.LangCur.lMOTabBack;
            // Grid
            gbGrid.Text = Options.LangCur.lMOGrid;
            cbbGridStyle.Items.Add(Options.LangCur.lMOGridStyle0None);
            cbbGridStyle.Items.Add(Options.LangCur.lMOGridStyle1Dots);
            cbbGridStyle.Items.Add(Options.LangCur.lMOGridStyle2Corners);
            cbbGridStyle.Items.Add(Options.LangCur.lMOGridStyle3Crosses);
            cbbGridStyle.Items.Add(Options.LangCur.lMOGridStyle4Grid);
            toolTip.SetToolTip(btnGridColor, Options.LangCur.hEEColorPick);
            lblGridThick.Text     = Options.LangCur.lEELineThick;
            chkGridSnap.Text      = Options.LangCur.lMOGridAlign;
            btnAlignElements.Text = Options.LangCur.lMOGridAlignNow;
            // Fill
            chkGridStore.Checked       = Map.Grid.StoreOwn;
            cbbGridStyle.SelectedIndex = (int)Map.Grid.Style;
            btnGridColor.BackColor     = Map.Grid.Pen.Color;
            nudGridStepX.Value         = Map.Grid.StepX;
            nudGridStepY.Value         = Map.Grid.StepY;
            nudGridThick.Value         = (int)Map.Grid.Pen.Width;
            chkGridSnap.Checked        = Map.Grid.Snap;
            // Back image
            gbBack.Text = Options.LangCur.lMOBack;
            cbbBackStyle.Items.Add(Options.LangCur.lMOBackStyle0Color);
            cbbBackStyle.Items.Add(Options.LangCur.lMOBackStyle1ImageAlign);
            cbbBackStyle.Items.Add(Options.LangCur.lMOBackStyle2ImageTile);
            cbbBackStyle.Items.Add(Options.LangCur.lMOBackStyle3ImageStrech);
            cbbBackStyle.Items.Add(Options.LangCur.lMOBackStyle4ImageZInner);
            cbbBackStyle.Items.Add(Options.LangCur.lMOBackStyle5ImageZOutter);
            toolTip.SetToolTip(btnBackColor,    Options.LangCur.hEEColorPick);
            toolTip.SetToolTip(btnGetBackImage, Options.LangCur.hEEImageLoad);
            lblBackgImagePath.Text   = Options.LangCur.lEEImagePath;
            chkTransparentColor.Text = Options.LangCur.lOETransparentColor;
            chkBackImageFloat.Text   = Options.LangCur.lEEImageFloat;
            chkBackImageBuildIn.Text = Options.LangCur.lEEImageBuildIn;
            lblBackImageAlign.Text   = Options.LangCur.lEEAlign;
            lblBackImageBPP.Text     = Options.LangCur.lEEImageBPP;
            cbbBackImageAlign.Items.Add(Options.LangCur.lEEAlign0TL);
            cbbBackImageAlign.Items.Add(Options.LangCur.lEEAlign1TC);
            cbbBackImageAlign.Items.Add(Options.LangCur.lEEAlign2TR);
            cbbBackImageAlign.Items.Add(Options.LangCur.lEEAlign3ML);
            cbbBackImageAlign.Items.Add(Options.LangCur.lEEAlign4MC);
            cbbBackImageAlign.Items.Add(Options.LangCur.lEEAlign5MR);
            cbbBackImageAlign.Items.Add(Options.LangCur.lEEAlign6BL);
            cbbBackImageAlign.Items.Add(Options.LangCur.lEEAlign7BC);
            cbbBackImageAlign.Items.Add(Options.LangCur.lEEAlign8BR);
            // Fill
            chkBackStore.Checked            = Map.Back.StoreOwn;
            cbbBackStyle.SelectedIndex      = (int)Map.Back.Style;
            btnBackColor.BackColor          = Map.Back.Color;
            tbBackgImagePath.Text           = Map.Back.Path;
            chkTransparentColor.Checked     = Map.Back.UseAlphaColor;
            btnAlphaColor.BackColor         = Map.Back.AlphaColor;
            chkBackImageFloat.Checked       = Map.Back.Float;
            cbbBackImageAlign.SelectedIndex = (int)Map.Back.Align;
            chkBackImageBuildIn.Checked     = Map.Back.BuildIn;
            cbbBackImageBPP.SelectedIndex   = (int)Map.Back.BPP;
            // Redraw sample
            GotImage(Map.Back.Image);
            #endregion

            #region Objects
            tpObjects.Text = Options.LangCur.lMOTabObjects;
            toolTip.SetToolTip(btnIPDelete, Options.LangCur.hEOPrototypeDelete);
            clmObjectName.Text      = Options.LangCur.lMOColumName;
            clmObjectLocation.Text  = Options.LangCur.lMOColumLocation;
            clmObjectPrototype.Text = Options.LangCur.lMOColumPrototype;
            clmObjectReference.Text = Options.LangCur.lMOColumReference;
            // Fill
            foreach (xObject obj in Map.Objects)
            {
                var item = lvObjects.Items.Add(obj.Name);
                item.SubItems.Add("");
                item.SubItems.Add("");
                item.SubItems.Add("");
                item.Tag = obj;
                UpdateObjectNode(item, obj);
                // Fill IPs
                foreach (var IP in obj.IPs)
                    Share.lvIPs_Add(lvIPs, IP, ref IP.Map_lvItem);
            }
            #endregion

            #region Links
            tpLinks.Text = Options.LangCur.lMOTabLinks;
            toolTip.SetToolTip(btnIPDelete, Options.LangCur.hEOPrototypeDelete);
            clmLinkName.Text      = Options.LangCur.lMOColumName;
            clmLinkLocation.Text  = Options.LangCur.lMOColumLocation;
            clmLinkPrototype.Text = Options.LangCur.lMOColumPrototype;
            clmLinkReference.Text = Options.LangCur.lMOColumReference;
            // Fill
            foreach (xLink Link in Map.Links)
            {
                var item = lvLinks.Items.Add(Link.Name);
                item.SubItems.Add("");
                item.SubItems.Add("");
                item.SubItems.Add("");
                item.Tag = Link;
                UpdateLinkNode(item, Link);
            }
            #endregion

            #region Boxes
            tpBoxes.Text = Options.LangCur.lMOTabBoxes;
            toolTip.SetToolTip(btnIPDelete, Options.LangCur.hEOPrototypeDelete);
            clmBoxName.Text      = Options.LangCur.lMOColumName;
            clmBoxLocation.Text  = Options.LangCur.lMOColumLocation;
            clmBoxPrototype.Text = Options.LangCur.lMOColumPrototype;
            clmBoxReference.Text = Options.LangCur.lMOColumReference;
            // Fill
            foreach (xBox Box in Map.Boxes)
            {
                var item = lvBoxes.Items.Add(Box.Name);
                item.SubItems.Add("");
                item.SubItems.Add("");
                item.SubItems.Add("");
                item.SubItems.Add("");
                item.Tag = Box;
                UpdateBoxNode(item, Box);
            }
            #endregion

            // IPs
            tpIPs.Text = Options.LangCur.lMOTabIPs;
            toolTip.SetToolTip(btnIPDelete, Options.LangCur.hOOIPDelete);
            clmIPAddress.Text    = Options.LangCur.lOOColumIP;
            clmIPPeriod.Text     = Options.LangCur.lOOColumPeriod;
            clmIPTimeLast.Text   = Options.LangCur.lOOColumTimeLast;
            clmIPTimeNext.Text   = Options.LangCur.lOOColumTimeNext;
            clmIPLastResult.Text = Options.LangCur.lOOColumResult;
        }

        private void btnColor_Click(object sender, EventArgs e)//Ok
        {
            if (dlgColor.ShowDialog() != DialogResult.OK)
                return;
            (sender as Button).BackColor = dlgColor.Color;
            RedrawSample(null, null);
        }

        private void btnAlignElements_Click(object sender, EventArgs e)//Ok
        {
            if (chkGridStore.Checked)
                Map.AlignToGridAll((int)nudGridStepX.Value, (int)nudGridStepY.Value);
            else
                Map.AlignToGridAll(Options.Grid.StepX, Options.Grid.StepY);
            Map.Draw();
            Options.mainForm.Invalidate();
        }
        
        private void btnGetBackImage_Click(object sender, EventArgs e) => Share.GetImage(tbBackgImagePath, GotImage);//Ok

        private void GotImage(Bitmap img)//Ok
        {
            imageOriginal = img;
            RedrawSample(null, null);
        }
        
        private void RedrawSample(object sender, EventArgs e)//Ok
        {
            if (imageAlpha != null)
                imageAlpha.Dispose();
            imageAlpha = new Bitmap(imageOriginal);
            if (chkTransparentColor.Checked)
                imageAlpha.MakeTransparent(btnAlphaColor.BackColor);
            // Grid
            xGrid Grid;
            if (chkGridStore.Checked)
            {
                Grid = new xGrid();
                Grid.Style = (GridStyles)cbbGridStyle.SelectedIndex;
                Grid.Pen.Color = btnGridColor.BackColor;
                Grid.Pen.Width = (float)nudGridThick.Value;
                Grid.StepX = (Int16)nudGridStepX.Value;
                Grid.StepY = (Int16)nudGridStepY.Value;
            }
            else
                Grid = Options.Grid;
            // Back
            xBackground Back;
            if (chkBackStore.Checked)
            {
                Back = new xBackground();
                Back.Style = (BackgroundStyles)cbbBackStyle.SelectedIndex;
                Back.Color = btnBackColor.BackColor;
                Back.Align = (AlignTypes)cbbBackImageAlign.SelectedIndex;
                Back.Image = imageAlpha;
            }
            else
                Back = Options.Back;
            // Draw
            var bmap = new Bitmap(pbBackPreview.Width, pbBackPreview.Height);
            Share.DrawBack(Graphics.FromImage(bmap), Back, Grid, 0, 0, bmap.Width, bmap.Height, 0, 0, bmap.Width, bmap.Height);
            pbBackPreview.Image = bmap;
        }

        #region Elements Tabs
        private void btnObjectsDelete_Click(object sender, EventArgs e)//Ok
        {
            for (int i = lvObjects.SelectedItems.Count - 1; 0 <= i; i--)
            {
                (lvObjects.SelectedItems[i].Tag as xObject)?.Delete();
                lvObjects.Items.RemoveAt(i);
            }
            Map.Draw();
            Options.mainForm.Invalidate();
        }
        
        private void btnObjectEdit_Click(object sender, EventArgs e)//Ok
        {
            if (lvObjects.SelectedItems.Count < 1)
                return;
            xObject obj = (lvObjects.SelectedItems[0].Tag as xObject);
            if (obj == null)
                return;
            // Remove IPs
            foreach (var IP in obj.IPs)
            {
                IP.Map_lvItem.Remove();
                IP.Map_lvItem = null;
            }
            // Edit
            new ObjectOptionsForm(obj).ShowDialog();
            UpdateObjectNode(lvObjects.SelectedItems[0], obj);
            // Return IPs in list
            foreach (var IP in obj.IPs)
                Share.lvIPs_Add(lvIPs, IP, ref IP.Map_lvItem);
        }

        private void UpdateObjectNode(ListViewItem lvItem, xObject Object)//Ok
        {
            lvItem.SubItems[0].Text = '"' + Object.Name + '"';
            lvItem.SubItems[1].Text = Object.X + ", " + Object.Y;
            lvItem.SubItems[2].Text = '"' + Object.Prototype.Name + '"';
            lvItem.SubItems[3].Text = '"' + Object.Reference + '"';
        }

        private void btnLinksDelete_Click(object sender, EventArgs e)//Ok
        {
            for (int i = lvLinks.SelectedItems.Count - 1; 0 <= i; i--)
            {
                (lvLinks.SelectedItems[i].Tag as xLink)?.Delete();
                lvLinks.Items.RemoveAt(i);
            }
            Map.Draw();
            Options.mainForm.Invalidate();
        }

        private void btnLinkEdit_Click(object sender, EventArgs e)//Ok
        {
            if (lvLinks.SelectedItems.Count < 1)
                return;
            xLink link = (lvLinks.SelectedItems[0].Tag as xLink);
            if (link == null)
                return;
            new LinkOptionsForm(link).ShowDialog();
            UpdateLinkNode(lvLinks.SelectedItems[0], link);
        }

        private void UpdateLinkNode(ListViewItem lvItem, xLink Link)//Ok
        {
            lvItem.SubItems[0].Text = '"' + Link.Name + '"';
            lvItem.SubItems[1].Text = Link.XA + ", " + Link.YA + " -> " + Link.XB + ", " + Link.YB;
            lvItem.SubItems[2].Text = '"' + Link.Prototype.Name + '"';
            lvItem.SubItems[3].Text = '"' + Link.Reference + '"';
        }

        private void btnBoxesDelete_Click(object sender, EventArgs e)//Ok
        {
            for (int i = lvBoxes.SelectedItems.Count - 1; 0 <= i; i--)
            {
                (lvBoxes.SelectedItems[i].Tag as xBox)?.Delete();
                lvBoxes.Items.RemoveAt(i);
            }
            Map.Draw();
            Options.mainForm.Invalidate();
        }

        private void btnBoxEdit_Click(object sender, EventArgs e)//Ok
        {
            if (lvBoxes.SelectedItems.Count < 1)
                return;
            xBox box = (lvBoxes.SelectedItems[0].Tag as xBox);
            if (box == null)
                return;
            if (new BoxOptionsForm(box).ShowDialog() == DialogResult.OK)
            {
                Map.Draw();
                Options.mainForm.Invalidate();
            }
            UpdateBoxNode(lvBoxes.SelectedItems[0], box);
        }

        private void UpdateBoxNode(ListViewItem lvItem, xBox Box)//Ok
        {
            lvItem.SubItems[0].Text = '"' + Box.Name + '"';
            lvItem.SubItems[1].Text = Box.Left + ", " + Box.Top + " : " + Box.Width + ", " + Box.Height;
            lvItem.SubItems[2].Text = '"' + Box.Prototype.Name + '"';
            lvItem.SubItems[3].Text = '"' + Box.Reference + '"';
            lvItem.SubItems[4].Text = '"' + Box.Text + '"';
        }

        private void btnIPsDelete_Click(object sender, EventArgs e) => Share.lvIPs_Delete(lvIPs);//Ok

        private void btnIPEdit_Click(object sender, EventArgs e) => Share.lvIPs_Edit(lvIPs);//Ok

        private void lvIPs_DoubleClick(object sender, EventArgs e)
        {
            (sender as ListView).SelectedItems[0].Checked = !(sender as ListView).SelectedItems[0].Checked;
            btnIPEdit_Click(null, null);
        }

        private void lvIPs_ItemChecked(object sender, ItemCheckedEventArgs e)//Ok
        {
            if (e.Item.Tag != null)
                (e.Item.Tag as xIP).Onn = e.Item.Checked;
        }
        #endregion

        private void MapOptionsForm_FormClosing(object sender, FormClosingEventArgs e)//Ok
        {
            // Clear backtrack
            foreach (ListViewItem lvi in lvIPs.Items)
                if (lvi.Tag != null)
                    (lvi.Tag as xIP).Map_lvItem = null;
        }

        private void btnSave_Click(object sender, EventArgs e)//Ok
        {
            // Main
            Map.Name        = tbName.Text;
            Map.Width       = (int)nudSizeW.Value;
            Map.Height      = (int)nudSizeH.Value;
            Map.Description = tbDescription.Text;
            Map.AutoSize    = chkSizeAuto.Checked;
            // Grid
            Map.Grid.StoreOwn  = chkGridStore.Checked;
            Map.Grid.Style     = (GridStyles)cbbGridStyle.SelectedIndex;
            Map.Grid.Pen.Color = btnGridColor.BackColor;
            Map.Grid.StepX     = (Int16)nudGridStepX.Value;
            Map.Grid.StepY     = (Int16)nudGridStepY.Value;
            Map.Grid.Pen.Width = (float)nudGridThick.Value;
            Map.Grid.Snap      = chkGridSnap.Checked;
            // Back image
            Map.Back.StoreOwn      = chkBackStore.Checked;
            Map.Back.Style         = (BackgroundStyles)cbbBackStyle.SelectedIndex;
            Map.Back.UseAlphaColor = chkTransparentColor.Checked;
            Map.Back.AlphaColor    = btnAlphaColor.BackColor;
            Map.Back.Color         = btnBackColor.BackColor;
            Map.Back.Path          = tbBackgImagePath.Text;
            Map.Back.Float         = chkBackImageFloat.Checked;
            Map.Back.Align         = (AlignTypes)cbbBackImageAlign.SelectedIndex;
            Map.Back.BuildIn       = chkBackImageBuildIn.Checked;
            Map.Back.BPP           = (ImageBPPs)cbbBackImageBPP.SelectedIndex;
            Map.Back.Image         = imageAlpha;

            // Out
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
