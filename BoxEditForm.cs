using System;
using System.Drawing;
using System.Windows.Forms;

namespace Schematix
{
    public partial class BoxEditForm : Form
    {
        xPBox PBox;

        public BoxEditForm(xPBox pBox)
        {
            InitializeComponent();
            if (pBox == null)
            {
                pBox = new xPBox();
                Text = options.LangCur.lEETitleAdd + " " + options.LangCur.lEETitleBox;
            }
            else
                Text = options.LangCur.lEETitleEdit + " " + options.LangCur.lEETitleBox;
            PBox = pBox;
            // Share
            lblNodeName.Text = options.LangCur.lEENodeName;
            lblName.Text     = options.LangCur.lEEName;
            lblID.Text       = options.LangCur.lEEID;
            lblRevision.Text = options.LangCur.lEERevision;
            // Own
            lblType.Text      = options.LangCur.lBEType;
            lblLineThick.Text = options.LangCur.lEELineThick;
            lblLineStyle.Text = options.LangCur.lEELineStyle;
            lblText.Text      = options.LangCur.lBEText;
            lblTextAlign.Text = options.LangCur.lEEAlign;
            toolTip.SetToolTip(btnLineColor, options.LangCur.hEEColorPick);
            toolTip.SetToolTip(btnFontColor, options.LangCur.hEEColorPick);
            // Fill CBB
            cbbType.Items.Add(options.LangCur.lBEType0Text);
            cbbType.Items.Add(options.LangCur.lBEType1Rectangle);
            cbbType.Items.Add(options.LangCur.lBEType2Ellipse);
            //
            cbbAlign.Items.Add(options.LangCur.lEEAlign0TL);
            cbbAlign.Items.Add(options.LangCur.lEEAlign1TC);
            cbbAlign.Items.Add(options.LangCur.lEEAlign2TR);
            cbbAlign.Items.Add(options.LangCur.lEEAlign3ML);
            cbbAlign.Items.Add(options.LangCur.lEEAlign4MC);
            cbbAlign.Items.Add(options.LangCur.lEEAlign5MR);
            cbbAlign.Items.Add(options.LangCur.lEEAlign6BL);
            cbbAlign.Items.Add(options.LangCur.lEEAlign7BC);
            cbbAlign.Items.Add(options.LangCur.lEEAlign8BR);
            // Fill
            //...
            cbbType.SelectedIndex = 0;
            cbbStyle.SelectedIndex = 0;
            cbbAlign.SelectedIndex = 0;
            ShowFont(btnFontColor.Font);
        }

        private void PickColor_Click(object sender, EventArgs e)//Ok
        {
            if (dlgColor.ShowDialog() == DialogResult.OK)
                (sender as Button).BackColor = dlgColor.Color;
        }

        private void btnStyle_Click(object sender, EventArgs e)
        {
            if (dlgFont.ShowDialog() == DialogResult.OK)
            {
                //...
                ShowFont(dlgFont.Font);
            }
        }

        private void ShowFont(Font font)
        {
            btnFontColor.Text = font.Size + "em, " + font.Name;
            btnFontColor.Font = new Font(font.Name, 8.25f, font.Style);
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
