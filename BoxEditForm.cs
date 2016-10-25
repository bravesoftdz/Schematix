using System;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            lblNodeName.Text    = options.LangCur.lEENodeName;
            chkIsPrototype.Text = options.LangCur.lEEPrototype;
            lblName.Text        = options.LangCur.lEEName;
            lblID.Text          = options.LangCur.lEEID;
            lblRevision.Text    = options.LangCur.lEERevision;
            // Fill
            tbNode.Text            = PBox.NodeName;
            chkIsPrototype.Checked = PBox.isPrototype;
            tbName.Text            = PBox.Name;
            tbID.Text              = PBox.ID.ToString();
            tbRevision.Text        = PBox.Revision.ToString(options.TIME_FORMAT);
            tbDescription.Text     = PBox.Description;

            // Own
            lblType.Text      = options.LangCur.lBEType;
            lblLineThick.Text = options.LangCur.lEELineThick;
            lblLineStyle.Text = options.LangCur.lEELineStyle;
            lblText.Text      = options.LangCur.lBEText;
            lblTextAlign.Text = options.LangCur.lEEAlign;
            toolTip.SetToolTip(btnLineColor, options.LangCur.hEEColorPick);
            toolTip.SetToolTip(btnFont,      options.LangCur.hEEColorPick);
            // Fill CBB Type
            cbbType.Items.Add(options.LangCur.lBEType0Text);
            cbbType.Items.Add(options.LangCur.lBEType1Rectangle);
            cbbType.Items.Add(options.LangCur.lBEType2Ellipse);
            // Fill CBB Align
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
            cbbType.SelectedIndex  = (int)PBox.BoxType;
            nudThick.Value         = (int)PBox.Pen.Width;
            btnLineColor.BackColor = PBox.Pen.Color;
            cbbStyle.SelectedIndex = (int)PBox.Pen.DashStyle;
            tbText.Text            = PBox.Text;
            cbbAlign.SelectedIndex = (int)PBox.TextAlign;
            btnFont.BackColor      = PBox.TextColor;
            SetAndShowFont(PBox.Font);
        }

        private void PickColor_Click(object sender, EventArgs e)//Ok
        {
            if (dlgColor.ShowDialog() == DialogResult.OK)
                (sender as Button).BackColor = dlgColor.Color;
        }

        private void btnFont_Click(object sender, EventArgs e)//Ok
        {
            dlgFont.Font = btnFont.Font;
            if (dlgFont.ShowDialog() == DialogResult.OK)
                SetAndShowFont(dlgFont.Font);
        }

        private void SetAndShowFont(Font font)//Ok
        {
            btnFont.Text = font.Size + "em, " + font.Name;
            btnFont.Font = new Font(font.Name, 8.25f, font.Style);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            // Share
            PBox.NodeName    = tbNode.Text;
            PBox.isPrototype = chkIsPrototype.Checked;
            PBox.Revision    = DateTime.Now;
            PBox.Name        = tbName.Text;
            PBox.Description = tbDescription.Text;
            // Own
            PBox.BoxType       = (BoxTypes)cbbType.SelectedIndex;
            PBox.Pen.Width     = (int)nudThick.Value;
            PBox.Pen.Color     = btnLineColor.BackColor;
            PBox.Pen.DashStyle = (DashStyle)cbbStyle.SelectedIndex;
            PBox.Text          = tbText.Text;
            PBox.TextAlign     = (AlignTypes)cbbAlign.SelectedIndex;
            PBox.TextColor     = btnFont.BackColor;
            PBox.Font      = btnFont.Font;

            // Out
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
