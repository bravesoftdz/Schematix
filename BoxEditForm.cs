using System;
using System.Drawing;
using System.Windows.Forms;

namespace Schematix
{
    public partial class BoxEditForm : Form
    {
        public BoxEditForm()
        {
            InitializeComponent();
            // Share
            lblNode.Text     = options.LangCur.lEENode;
            lblName.Text     = options.LangCur.lEEName;
            lblID.Text       = options.LangCur.lEEID;
            lblRevision.Text = options.LangCur.lEERevision;
            // Own
            lblType.Text  = options.LangCur.lBEType;
            lblThick.Text = options.LangCur.lEEThick;
            lblStyle.Text = options.LangCur.lBEStyle;
            lblText.Text  = options.LangCur.lBEText;
            lblAlign.Text = options.LangCur.lEEAlign;
            // Fill CBB
            cbbType.Items.Add(options.LangCur.lBEType0Text);
            cbbType.Items.Add(options.LangCur.lBEType1Rectangle);
            cbbType.Items.Add(options.LangCur.lBEType2Ellipse);
            //
            cbbAlign.Items.Add(options.LangCur.lEEAlign0TL);
            cbbAlign.Items.Add(options.LangCur.lEEAlign1T);
            cbbAlign.Items.Add(options.LangCur.lEEAlign2TR);
            cbbAlign.Items.Add(options.LangCur.lEEAlign3L);
            cbbAlign.Items.Add(options.LangCur.lEEAlign4C);
            cbbAlign.Items.Add(options.LangCur.lEEAlign5R);
            cbbAlign.Items.Add(options.LangCur.lEEAlign6BL);
            cbbAlign.Items.Add(options.LangCur.lEEAlign7B);
            cbbAlign.Items.Add(options.LangCur.lEEAlign8BR);
            if (false)
            {
                Text = options.LangCur.lEETitleEdit + " " + options.LangCur.lEEBox;
                //...
                //cbbType.SelectedIndex = 0;
                //cbbStyle.SelectedIndex = 0;
                //cbbAlign.SelectedIndex = 0;
                //ShowFont(btnFont.Font);
            }
            else
            {
                Text = options.LangCur.lEETitleAdd + " " + options.LangCur.lEEBox;
                cbbType.SelectedIndex = 0;
                cbbStyle.SelectedIndex = 0;
                cbbAlign.SelectedIndex = 0;
                ShowFont(btnFont.Font);
            }
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
            btnFont.Text = font.Size + "em, " + font.Name;
            btnFont.Font = new Font(font.Name, 8.25f, font.Style);
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
