using System;
using System.Windows.Forms;

namespace Schematix
{
    public partial class LinkEditForm : Form
    {
        public LinkEditForm()
        {
            InitializeComponent();
            // Share
            lblNode.Text     = options.LangCur.lEENodeName;
            lblName.Text     = options.LangCur.lEEName;
            lblID.Text       = options.LangCur.lEEID;
            lblRevision.Text = options.LangCur.lEERevision;
            // Own
            lblLineThick.Text = options.LangCur.lEELineThick;
            lblLineStyle.Text = options.LangCur.lEELineStyle;
            toolTip.SetToolTip(btnColor, options.LangCur.hEEColorPick);
            if (false)
            {
                Text = options.LangCur.lEETitleEdit + " " + options.LangCur.lEETitleLink;
                //...
                //cbbStyle.SelectedIndex = 0;
            }
            else
            {
                Text = options.LangCur.lEETitleAdd + " " + options.LangCur.lEETitleLink;
                cbbStyle.SelectedIndex = 0;
            }
        }

        private void btnColor_Click(object sender, EventArgs e)//Ok
        {
            if (dlgColor.ShowDialog() == DialogResult.OK)
                (sender as Button).BackColor = dlgColor.Color;
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
