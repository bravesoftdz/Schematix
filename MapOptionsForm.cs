using System;
using System.Drawing;
using System.Windows.Forms;

namespace Schematix
{
    public partial class MapOptionsForm : Form
    {
        public xMap Map;
        Bitmap imageOriginal = new Bitmap(1, 1);
        Bitmap imageAlpha;

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
            chkBackImageFloat.Checked       = Map.Back.Float;
            cbbBackImageAlign.SelectedIndex = (int)Map.Back.Align;
            chkBackImageBuildIn.Checked     = Map.Back.BuildIn;
            cbbBackImageBPP.SelectedIndex   = (int)Map.Back.BPP;
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
            foreach (var obj in Map.Objects)
            {
                var item = new ListViewItem(obj.Name);
                item.SubItems.Add(obj.X + ", " + obj.Y);
                item.SubItems.Add(obj.Prototype.Name);
                item.SubItems.Add(obj.Reference);
                lvObjects.Items.Add(item);
                item.Tag = obj;
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
            foreach (var link in Map.Links)
            {
                var item = new ListViewItem(link.Name);
                item.SubItems.Add(link.XA + ", " + link.YA + " -> " + link.XB + ", " + link.YB);
                item.SubItems.Add(link.Prototype.Name);
                item.SubItems.Add(link.Reference);
                lvObjects.Items.Add(item);
                item.Tag = link;
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
            foreach (var box in Map.Boxes)
            {
                var item = new ListViewItem(box.Name);
                item.SubItems.Add(box.Left + ", " + box.Top + " : " + box.Width + ", " + box.Height);
                item.SubItems.Add(box.Prototype.Name);
                item.SubItems.Add(box.Reference);
                lvObjects.Items.Add(item);
                item.Tag = box;
            }
            #endregion

            // IPs
            tpIPs.Text = Options.LangCur.lMOTabIPs;
            toolTip.SetToolTip(btnIPDelete, Options.LangCur.hOOIPDelete);
            clmIPAddress.Text   = Options.LangCur.lOOColumIP;
            clmIPPeriod.Text    = Options.LangCur.lOOColumPeriod;
            clmIPTimeLast.Text  = Options.LangCur.lOOColumTimeLast;
            clmIPTimeNext.Text  = Options.LangCur.lOOColumTimeNext;
            clmIPPing.Text      = Options.LangCur.lOOColumPing;
        }

        private void btnColor_Click(object sender, EventArgs e)//Ok
        {
            if (dlgColor.ShowDialog() != DialogResult.OK)
                return;
            (sender as Button).BackColor = dlgColor.Color;
        }

        private void cbbBackImageAlign_SelectedIndexChanged(object sender, EventArgs e)//!!!
        {
            if (cbbBackStyle.SelectedIndex == 0 && pbBackPreview.BackgroundImage != null)
                pbBackPreview.BackgroundImage = null;
            if (cbbBackStyle.SelectedIndex != 0 && pbBackPreview.BackgroundImage == null)
                pbBackPreview.BackgroundImage = imageAlpha;
            switch (cbbBackStyle.SelectedIndex)
            {
                case 1:
                    pbBackPreview.BackgroundImageLayout = ImageLayout.None;
                    break;
                case 2:
                    pbBackPreview.BackgroundImageLayout = ImageLayout.Tile;
                    break;
                case 3:
                    pbBackPreview.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 4:
                    pbBackPreview.BackgroundImageLayout = ImageLayout.Zoom;
                    break;
                case 5:
                    pbBackPreview.BackgroundImageLayout = ImageLayout.Zoom;
                    break;
            }
        }

        private void btnGetBackImage_Click(object sender, EventArgs e)//!!!
        {
            Share.GetImage(tbBackgImagePath, GotImage);
        }

        private void GotImage(Bitmap img)//!
        {
            imageOriginal = img;
            Alpha_Changed(null, null);
        }

        private void Alpha_Changed(object sender, EventArgs e)
        {
            imageAlpha = new Bitmap(imageOriginal);
            if (chkTransparentColor.Checked)
                imageAlpha.MakeTransparent(btnAlphaColor.BackColor);
            pbBackPreview.BackgroundImage = imageAlpha;
        }

        private void btnBackColor_BackColorChanged(object sender, EventArgs e)
        {
            pbBackPreview.BackColor = btnBackColor.BackColor;
        }

        #region Elements Tabs
        private void btnObjectsDelete_Click(object sender, EventArgs e)//
        {
            for (int i = lvObjects.SelectedItems.Count - 1; 0 <= i; i--)
            {
                (lvObjects.SelectedItems[i].Tag as xObject)?.Delete();
                lvObjects.Items.RemoveAt(i);
            }
        }
        
        private void lvObjects_DoubleClick(object sender, EventArgs e)//
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
            // Return IPs in list
            foreach (var IP in obj.IPs)
                Share.lvIPs_Add(lvIPs, IP, ref IP.Map_lvItem);
        }

        private void btnLinkDelete_Click(object sender, EventArgs e)//O
        {
            for (int i = lvLinks.SelectedItems.Count - 1; 0 <= i; i--)
            {
                (lvLinks.SelectedItems[i].Tag as xLink)?.Delete();
                lvLinks.Items.RemoveAt(i);
            }
        }

        private void lvLinks_DoubleClick(object sender, EventArgs e)//Ok
        {
            if (lvLinks.SelectedItems.Count < 1)
                return;
            xLink link = (lvLinks.SelectedItems[0].Tag as xLink);
            if (link == null)
                return;
            new LinkOptionsForm(link).ShowDialog();
        }

        private void btnBoxDelete_Click(object sender, EventArgs e)//O
        {
            for (int i = lvBoxes.SelectedItems.Count - 1; 0 <= i; i--)
            {
                (lvBoxes.SelectedItems[i].Tag as xBox)?.Delete();
                lvBoxes.Items.RemoveAt(i);
            }
        }

        private void lvBoxes_DoubleClick(object sender, EventArgs e)//Ok
        {
            if (lvBoxes.SelectedItems.Count < 1)
                return;
            xBox box = (lvBoxes.SelectedItems[0].Tag as xBox);
            if (box == null)
                return;
            new BoxOptionsForm(box).ShowDialog();
        }

        private void btnIPDelete_Click(object sender, EventArgs e)//O
        {
            Share.lvIPs_Delete(lvIPs);
        }

        private void lvIPs_DoubleClick(object sender, EventArgs e)//O
        {
            Share.lvIPs_Edit(lvIPs);
        }
        #endregion

        private void btnAlignElements_Click(object sender, EventArgs e)//O
        {
            Map.AlignToGridAll((int)nudGridStepX.Value, (int)nudGridStepX.Value);
        }

        private void lvIPs_ItemChecked(object sender, ItemCheckedEventArgs e)//
        {
            if (e?.Item.Tag == null)
                return;
            (e.Item.Tag as xIP).Onn = e.Item.Checked;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Main
            Map.Name = tbName.Text;
            Map.Width  = (int)nudSizeW.Value;
            Map.Height = (int)nudSizeH.Value;
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
            Map.Back.StoreOwn = chkBackStore.Checked;
            Map.Back.Style    = (BackgroundStyles)cbbBackStyle.SelectedIndex;
            Map.Back.Color    = btnBackColor.BackColor;
            Map.Back.Path     = tbBackgImagePath.Text;
            Map.Back.Float    = chkBackImageFloat.Checked;
            Map.Back.Align    = (AlignTypes)cbbBackImageAlign.SelectedIndex;
            Map.Back.BuildIn  = chkBackImageBuildIn.Checked;
            Map.Back.BPP      = (ImageBPPs)cbbBackImageBPP.SelectedIndex;
            Map.Back.Image    = imageAlpha;
            // Clear backtrack
            foreach (ListViewItem lvi in lvIPs.Items)
                if (lvi.Tag != null)
                    (lvi.Tag as xIP).Map_lvItem = null;

            // Out
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
