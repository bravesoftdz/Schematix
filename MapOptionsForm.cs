using System;
using System.Drawing;
using System.Windows.Forms;

namespace Schematix
{
    public partial class MapOptionsForm : Form
    {
        Bitmap image = new Bitmap(1, 1);

        public MapOptionsForm()
        {
            int idx;
            InitializeComponent();
            Text = options.LangCur.lMOTitle;

            // Main
            lblName.Text     = options.LangCur.lMOName;
            lblSize.Text     = options.LangCur.lMOSize;
            chkSizeAuto.Text = options.LangCur.lMOAuto;

            // Background
            // Grid
            gbGrid.Text = options.LangCur.lOFMapGrid;
            idx = cbbGridStyle.SelectedIndex;
            cbbGridStyle.Items.Add(options.LangCur.lOFMapGridStyle0Default);
            cbbGridStyle.Items.Add(options.LangCur.lOFMapGridStyle1None);
            cbbGridStyle.Items.Add(options.LangCur.lOFMapGridStyle2Dots);
            cbbGridStyle.Items.Add(options.LangCur.lOFMapGridStyle3Corners);
            cbbGridStyle.Items.Add(options.LangCur.lOFMapGridStyle4Crosses);
            cbbGridStyle.Items.Add(options.LangCur.lOFMapGridStyle5Grid);
            cbbGridStyle.SelectedIndex = idx;
            toolTip.SetToolTip(btnGridColor, options.LangCur.hEEColorPick);
            lblGridThick.Text = options.LangCur.lEELineThick;
            chkGridAlign.Text = options.LangCur.lOFMapGridAlign;
            // Back image
            gbBack.Text       = options.LangCur.lOFMapBack;
            idx = cbbBackStyle.SelectedIndex;
            cbbGridStyle.Items.Add(options.LangCur.lOFMapBackStyle0Default);
            cbbBackStyle.Items.Add(options.LangCur.lOFMapBackStyle1Color);
            cbbBackStyle.Items.Add(options.LangCur.lOFMapBackStyle2ImageAlign);
            cbbBackStyle.Items.Add(options.LangCur.lOFMapBackStyle3ImageTile);
            cbbBackStyle.Items.Add(options.LangCur.lOFMapBackStyle4ImageStrech);
            cbbBackStyle.Items.Add(options.LangCur.lOFMapBackStyle5ImageZInner);
            cbbBackStyle.Items.Add(options.LangCur.lOFMapBackStyle6ImageZOutter);
            cbbBackStyle.SelectedIndex = idx;
            toolTip.SetToolTip(btnBackColor,    options.LangCur.hEEColorPick);
            toolTip.SetToolTip(btnGetBackImage, options.LangCur.hEEImageLoad);
            lblBackgImagePath.Text   = options.LangCur.lEEImagePath;
            chkBackImageFloat.Text   = options.LangCur.lEEImageFloat;
            chkBackImageBuildIn.Text = options.LangCur.lEEImageBuildIn;
            lblBackImageAlign.Text   = options.LangCur.lEEAlign;
            lblBackImageBPP.Text     = options.LangCur.lEEImageBPP;
            idx = cbbBackImageAlign.SelectedIndex;
            cbbBackImageAlign.Items.Add(options.LangCur.lEEAlign0TL);
            cbbBackImageAlign.Items.Add(options.LangCur.lEEAlign1TC);
            cbbBackImageAlign.Items.Add(options.LangCur.lEEAlign2TR);
            cbbBackImageAlign.Items.Add(options.LangCur.lEEAlign3ML);
            cbbBackImageAlign.Items.Add(options.LangCur.lEEAlign4MC);
            cbbBackImageAlign.Items.Add(options.LangCur.lEEAlign5MR);
            cbbBackImageAlign.Items.Add(options.LangCur.lEEAlign6BL);
            cbbBackImageAlign.Items.Add(options.LangCur.lEEAlign7BC);
            cbbBackImageAlign.Items.Add(options.LangCur.lEEAlign8BR);
            cbbBackImageAlign.SelectedIndex = idx;

            // Objects
            toolTip.SetToolTip(btnIPDelete, options.LangCur.hEOPrototypeDelete);
            clmObjectName.Text      = options.LangCur.lMOColumName;
            clmObjectLocation.Text  = options.LangCur.lMOColumLocation;
            clmObjectPrototype.Text = options.LangCur.lMOColumPrototype;
            clmObjectReference.Text = options.LangCur.lMOColumReference;
            //...

            // Links
            toolTip.SetToolTip(btnIPDelete, options.LangCur.hEOPrototypeDelete);
            clmLinkName.Text      = options.LangCur.lMOColumName;
            clmLinkLocation.Text  = options.LangCur.lMOColumLocation;
            clmLinkPrototype.Text = options.LangCur.lMOColumPrototype;
            clmLinkReference.Text = options.LangCur.lMOColumReference;
            //...

            // Boxes
            toolTip.SetToolTip(btnIPDelete, options.LangCur.hEOPrototypeDelete);
            clmBoxName.Text      = options.LangCur.lMOColumName;
            clmBoxLocation.Text  = options.LangCur.lMOColumLocation;
            clmBoxPrototype.Text = options.LangCur.lMOColumPrototype;
            clmBoxReference.Text = options.LangCur.lMOColumReference;
            //...

            // IPs
            toolTip.SetToolTip(btnIPDelete, options.LangCur.hOOIPDelete);
            clmIPAddress.Text   = options.LangCur.lOOColumIP;
            clmIPPeriod.Text    = options.LangCur.lOOColumPeriod;
            clmIPTimeLast.Text  = options.LangCur.lOOColumTimeLast;
            clmIPTimeNext.Text  = options.LangCur.lOOColumTimeNext;
            clmIPPing.Text      = options.LangCur.lOOColumPing;
            //...
        }

        private void cbbBackImageAlign_SelectedIndexChanged(object sender, EventArgs e)
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

        private void btnGetBackImage_Click(object sender, EventArgs e)
        {
            Share.GetImage(tbBackgImagePath, GotImage);
        }

        private void GotImage(Image img)//!!!
        {
            pbBackPreview.BackgroundImage = img;
            //...
        }

        private void btnObjectsDelete_Click(object sender, EventArgs e)
        {
            //
        }

        private void lvObjects_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var form = new ObjectOptionsForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
            }
        }

        private void btnLinkDelete_Click(object sender, EventArgs e)
        {
            //
        }

        private void lvLink_DoubleClick(object sender, EventArgs e)
        {
            var form = new LinkOptionsForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
            }
        }

        private void btnBoxDelete_Click(object sender, EventArgs e)
        {
            //
        }

        private void lvBox_DoubleClick(object sender, EventArgs e)
        {
            var form = new BoxOptionsForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
            }
        }

        private void btnIPDelete_Click(object sender, EventArgs e)
        {
            //
        }

        private void lvIPs_DoubleClick(object sender, EventArgs e)
        {
            var form = new IPEditForm(null);
            if (form.ShowDialog() == DialogResult.OK)
            {
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //...
            // Out
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
