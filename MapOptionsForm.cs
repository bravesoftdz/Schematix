using System;
using System.Drawing;
using System.Windows.Forms;

namespace Schematix
{
    public partial class MapOptionsForm : Form
    {
        public xMap Map;
        Bitmap image = new Bitmap(1, 1);

        public MapOptionsForm(xMap map)
        {
            InitializeComponent();
            if (map == null)
                map = new xMap();
            Map = map;
            Text = options.LangCur.lMOTitle;

            // Main
            tpMain.Text = options.LangCur.lMOTabMain;
            lblName.Text     = options.LangCur.lMOName;
            lblSize.Text     = options.LangCur.lMOSize;
            chkSizeAuto.Text = options.LangCur.lMOAuto;
            // Fill
            tbName.Text         = Map.Name;
            nudSizeW.Value      = Map.Width;
            nudSizeH.Value      = Map.Height;
            tbDescription.Text  = Map.Description;
            chkSizeAuto.Checked = Map.AutoSize;

            // Background
            tpBack.Text = options.LangCur.lMOTabBack;
            // Grid
            gbGrid.Text = options.LangCur.lMOGrid;
            cbbGridStyle.Items.Add(options.LangCur.lMOGridStyle0None);
            cbbGridStyle.Items.Add(options.LangCur.lMOGridStyle1Dots);
            cbbGridStyle.Items.Add(options.LangCur.lMOGridStyle2Corners);
            cbbGridStyle.Items.Add(options.LangCur.lMOGridStyle3Crosses);
            cbbGridStyle.Items.Add(options.LangCur.lMOGridStyle4Grid);
            toolTip.SetToolTip(btnGridColor, options.LangCur.hEEColorPick);
            lblGridThick.Text = options.LangCur.lEELineThick;
            chkGridAlign.Text = options.LangCur.lMOGridAlign;
            // Fill
            chkGridStore.Checked       = Map.Grid.StoreOwn;
            cbbGridStyle.SelectedIndex = (int)Map.Grid.Style;
            btnGridColor.BackColor     = Map.Grid.Color;
            nudGridStepX.Value         = Map.Grid.StepX;
            nudGridStepY.Value         = Map.Grid.StepY;
            nudGridThick.Value         = Map.Grid.Thick;
            chkGridAlign.Checked       = Map.Grid.Align;
            // Back image
            gbBack.Text = options.LangCur.lMOBack;
            cbbBackStyle.Items.Add(options.LangCur.lMOBackStyle0Color);
            cbbBackStyle.Items.Add(options.LangCur.lMOBackStyle1ImageAlign);
            cbbBackStyle.Items.Add(options.LangCur.lMOBackStyle2ImageTile);
            cbbBackStyle.Items.Add(options.LangCur.lMOBackStyle3ImageStrech);
            cbbBackStyle.Items.Add(options.LangCur.lMOBackStyle4ImageZInner);
            cbbBackStyle.Items.Add(options.LangCur.lMOBackStyle5ImageZOutter);
            toolTip.SetToolTip(btnBackColor,    options.LangCur.hEEColorPick);
            toolTip.SetToolTip(btnGetBackImage, options.LangCur.hEEImageLoad);
            lblBackgImagePath.Text   = options.LangCur.lEEImagePath;
            chkBackImageFloat.Text   = options.LangCur.lEEImageFloat;
            chkBackImageBuildIn.Text = options.LangCur.lEEImageBuildIn;
            lblBackImageAlign.Text   = options.LangCur.lEEAlign;
            lblBackImageBPP.Text     = options.LangCur.lEEImageBPP;
            cbbBackImageAlign.Items.Add(options.LangCur.lEEAlign0TL);
            cbbBackImageAlign.Items.Add(options.LangCur.lEEAlign1TC);
            cbbBackImageAlign.Items.Add(options.LangCur.lEEAlign2TR);
            cbbBackImageAlign.Items.Add(options.LangCur.lEEAlign3ML);
            cbbBackImageAlign.Items.Add(options.LangCur.lEEAlign4MC);
            cbbBackImageAlign.Items.Add(options.LangCur.lEEAlign5MR);
            cbbBackImageAlign.Items.Add(options.LangCur.lEEAlign6BL);
            cbbBackImageAlign.Items.Add(options.LangCur.lEEAlign7BC);
            cbbBackImageAlign.Items.Add(options.LangCur.lEEAlign8BR);
            // Fill
            chkBackStore.Checked            = Map.Back.StoreOwn;
            cbbBackStyle.SelectedIndex      = (int)Map.Back.Style;
            btnBackColor.BackColor          = Map.Back.Color;
            tbBackgImagePath.Text           = Map.Back.Path;
            chkBackImageFloat.Checked       = Map.Back.Float;
            cbbBackImageAlign.SelectedIndex = (int)Map.Back.Align;
            chkBackImageBuildIn.Checked     = Map.Back.BuildIn;
            cbbBackImageBPP.SelectedIndex   = (int)Map.Back.BPP;
            //
            image = Map.Back.Image;
            GotImage(image);

            // Objects
            tpObjects.Text = options.LangCur.lMOTabObjects;
            toolTip.SetToolTip(btnIPDelete, options.LangCur.hEOPrototypeDelete);
            clmObjectName.Text      = options.LangCur.lMOColumName;
            clmObjectLocation.Text  = options.LangCur.lMOColumLocation;
            clmObjectPrototype.Text = options.LangCur.lMOColumPrototype;
            clmObjectReference.Text = options.LangCur.lMOColumReference;
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
                    Share.lvIPs_AddIP(lvIPs, IP);
            }

            // Links
            tpLinks.Text = options.LangCur.lMOTabLinks;
            toolTip.SetToolTip(btnIPDelete, options.LangCur.hEOPrototypeDelete);
            clmLinkName.Text      = options.LangCur.lMOColumName;
            clmLinkLocation.Text  = options.LangCur.lMOColumLocation;
            clmLinkPrototype.Text = options.LangCur.lMOColumPrototype;
            clmLinkReference.Text = options.LangCur.lMOColumReference;
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

            // Boxes
            tpBoxes.Text = options.LangCur.lMOTabBoxes;
            toolTip.SetToolTip(btnIPDelete, options.LangCur.hEOPrototypeDelete);
            clmBoxName.Text      = options.LangCur.lMOColumName;
            clmBoxLocation.Text  = options.LangCur.lMOColumLocation;
            clmBoxPrototype.Text = options.LangCur.lMOColumPrototype;
            clmBoxReference.Text = options.LangCur.lMOColumReference;
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

            // IPs
            tpIPs.Text = options.LangCur.lMOTabIPs;
            toolTip.SetToolTip(btnIPDelete, options.LangCur.hOOIPDelete);
            clmIPAddress.Text   = options.LangCur.lOOColumIP;
            clmIPPeriod.Text    = options.LangCur.lOOColumPeriod;
            clmIPTimeLast.Text  = options.LangCur.lOOColumTimeLast;
            clmIPTimeNext.Text  = options.LangCur.lOOColumTimeNext;
            clmIPPing.Text      = options.LangCur.lOOColumPing;
        }

        private void cbbBackImageAlign_SelectedIndexChanged(object sender, EventArgs e)//!!!
        {
            if (cbbBackStyle.SelectedIndex == 0 && pbBackPreview.BackgroundImage != null)
                pbBackPreview.BackgroundImage = null;
            if (cbbBackStyle.SelectedIndex != 0 && pbBackPreview.BackgroundImage == null)
                pbBackPreview.BackgroundImage = image;
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

        private void GotImage(Image img)//!!!
        {
            pbBackPreview.BackgroundImage = img;
            //...
        }

        private void btnObjectsDelete_Click(object sender, EventArgs e)//
        {
            for (int i = lvObjects.SelectedItems.Count - 1; 0 <= i; i--)
            {
                xObject obj = (lvObjects.SelectedItems[i].Tag as xObject);
                if (obj != null)
                {
                    foreach (var IP in obj.IPs)
                        if (IP.lvItem != null)
                            IP.lvItem.Remove();
                    obj.Map.DeleteObject(obj);
                }
                lvObjects.Items.RemoveAt(i);
            }
        }

        private void lvObjects_MouseDoubleClick(object sender, MouseEventArgs e)//(?)
        {
            if (lvObjects.SelectedItems.Count < 1)
                return;
            xObject obj = (lvObjects.SelectedItems[0].Tag as xObject);
            if (obj == null)
                return;
            // Remove IPs
            foreach (var IP in obj.IPs)
                if (IP.lvItem != null)
                {
                    IP.lvItem.Remove();
                    IP.lvItem = null;
                }
            // Edit
            new ObjectOptionsForm(obj).ShowDialog();
            // Return IPs in list
            foreach (var IP in obj.IPs)
                Share.lvIPs_AddIP(lvIPs, IP);
        }

        private void btnLinkDelete_Click(object sender, EventArgs e)//O
        {
            for (int i = lvLinks.SelectedItems.Count - 1; 0 <= i; i--)
            {
                xLink link = (lvLinks.SelectedItems[i].Tag as xLink);
                if (link != null)
                    link.Map.DeleteLink(link);
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
                xBox box = (lvBoxes.SelectedItems[i].Tag as xBox);
                if (box != null)
                    box.Map.DeleteBox(box);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Main
            Map.Name = tbName.Text;
            Map.Width  = (int)nudSizeW.Value;
            Map.Height = (int)nudSizeH.Value;
            Map.Description = tbDescription.Text;
            Map.AutoSize    = chkSizeAuto.Checked;            
            // Grid
            Map.Grid.StoreOwn = chkGridStore.Checked;
            Map.Grid.Style = (GridStyles)cbbGridStyle.SelectedIndex;
            Map.Grid.Color = btnGridColor.BackColor;
            Map.Grid.StepX = (int)nudGridStepX.Value;
            Map.Grid.StepY = (int)nudGridStepY.Value;
            Map.Grid.Thick = (int)nudGridThick.Value;
            Map.Grid.Align = chkGridAlign.Checked;
            // Back image
            Map.Back.StoreOwn = chkBackStore.Checked;
            Map.Back.Style    = (BackStyles)cbbBackStyle.SelectedIndex;
            Map.Back.Color    = btnBackColor.BackColor;
            Map.Back.Path     = tbBackgImagePath.Text;
            Map.Back.Float    = chkBackImageFloat.Checked;
            Map.Back.Align    = (AlignTypes)cbbBackImageAlign.SelectedIndex;
            Map.Back.BuildIn  = chkBackImageBuildIn.Checked;
            Map.Back.BPP      = (ImageBPPs)cbbBackImageBPP.SelectedIndex;
            //...
            Map.Back.Image    = image;
            // Clear backtrack
            foreach (ListViewItem lvi in lvIPs.Items)
                if (lvi.Tag != null)
                    (lvi.Tag as xIP).lvItem = null;
            // Out
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
