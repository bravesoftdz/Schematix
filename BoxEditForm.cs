using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Schematix
{
    public partial class BoxEditForm : Form
    {
        public xPBox PBox;
        bool IsRoot;

        public BoxEditForm(xPBox pBox, String rootPath, bool isRoot)
        {
            InitializeComponent();
            if (pBox == null)
            {
                pBox = new xPBox();
                pBox.FileName = rootPath + "\\" + pBox.ID.ToString() + "\\" + Options.RECORD_FILENAME;
                Text = Options.LangCur.lEETitleAdd + " " + Options.LangCur.lEETitleBox;
            }
            else
                Text = Options.LangCur.lEETitleEdit + " " + Options.LangCur.lEETitleBox;
            PBox = pBox;
            IsRoot = isRoot;

            // Share
            chkIsPrototype.Enabled =
            tbNode.Enabled = !isRoot;
            //
            lblNode.Text    = Options.LangCur.lEENodeName;
            chkIsPrototype.Text = Options.LangCur.lEEPrototype;
            lblName.Text        = Options.LangCur.lEEName;
            lblID.Text          = Options.LangCur.lEEID;
            lblRevision.Text    = Options.LangCur.lEERevision;
            // Fill
            tbNode.Text            = PBox.NodeName;
            chkIsPrototype.Checked = PBox.isPrototype;
            tbName.Text            = PBox.Name;
            tbID.Text              = PBox.ID.ToString();
            tbRevision.Text        = DateTime.FromBinary(PBox.Revision).ToString(Options.TIME_FORMAT);
            tbDescription.Text     = PBox.Description;

            // Own
            lblType.Text      = Options.LangCur.lBEType;
            lblLineThick.Text = Options.LangCur.lEELineThick;
            lblLineStyle.Text = Options.LangCur.lEELineStyle;
            lblText.Text      = Options.LangCur.lBEText;
            lblTextAlign.Text = Options.LangCur.lEEAlign;
            toolTip.SetToolTip(btnLineColor, Options.LangCur.hEEColorPick);
            toolTip.SetToolTip(btnFont,      Options.LangCur.hEEColorPick);
            // Fill CBB Type
            cbbType.Items.Add(Options.LangCur.lBEType0Text);
            cbbType.Items.Add(Options.LangCur.lBEType1Rectangle);
            cbbType.Items.Add(Options.LangCur.lBEType2Ellipse);
            // Fill CBB Align
            cbbAlign.Items.Add(Options.LangCur.lEEAlign0TL);
            cbbAlign.Items.Add(Options.LangCur.lEEAlign1TC);
            cbbAlign.Items.Add(Options.LangCur.lEEAlign2TR);
            cbbAlign.Items.Add(Options.LangCur.lEEAlign3ML);
            cbbAlign.Items.Add(Options.LangCur.lEEAlign4MC);
            cbbAlign.Items.Add(Options.LangCur.lEEAlign5MR);
            cbbAlign.Items.Add(Options.LangCur.lEEAlign6BL);
            cbbAlign.Items.Add(Options.LangCur.lEEAlign7BC);
            cbbAlign.Items.Add(Options.LangCur.lEEAlign8BR);
            // Fill
            cbbType.SelectedIndex  = (int)PBox.BoxType;
            nudThick.Value         = (int)PBox.Pen.Width;
            btnLineColor.BackColor = PBox.Pen.Color;
            cbbStyle.SelectedIndex = (int)PBox.Pen.DashStyle;
            tbText.Text            = PBox.Text;
            cbbAlign.SelectedIndex = (int)PBox.TextAlign;
            btnFontColor.BackColor = PBox.TextColor;
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
            if (tbNode.Text == "" && tbName.Text == "")
            {
                MessageBox.Show(Options.LangCur.mElementHasNoName, Options.LangCur.dFileSaving);
                return;
            }
            if (!PBox.SaveToFileCheck(ref PBox.FileName))
                return;
            // Share
            PBox.NodeName    = tbNode.Text;
            PBox.isPrototype = chkIsPrototype.Checked;
            PBox.Revision    = DateTime.Now.ToBinary();
            PBox.Name        = tbName.Text;
            PBox.Description = tbDescription.Text;
            // Own
            PBox.BoxType       = (BoxTypes)cbbType.SelectedIndex;
            PBox.Pen.Width     = (int)nudThick.Value;
            PBox.Pen.Color     = btnLineColor.BackColor;
            PBox.Pen.DashStyle = (DashStyle)cbbStyle.SelectedIndex;
            PBox.Text          = tbText.Text;
            PBox.TextAlign     = (AlignTypes)cbbAlign.SelectedIndex;
            PBox.TextColor     = btnFontColor.BackColor;
            PBox.Font          = btnFont.Font;

            if (!PBox.SaveToFile(PBox.FileName))
                return;
            Share.UpdateNodeName(PBox);
            // Out
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
