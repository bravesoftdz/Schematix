using System;
using System.Windows.Forms;

namespace Schematix
{
    public partial class LinkEditForm : Form
    {
        xPLink PLink;

        public LinkEditForm(xPLink pLink)
        {
            InitializeComponent();
            if (pLink == null)
            {
                pLink = new xPLink();
                Text = options.LangCur.lEETitleAdd + " " + options.LangCur.lEETitleLink;
            }
            else
                Text = options.LangCur.lEETitleEdit + " " + options.LangCur.lEETitleLink;
            PLink = pLink;
            // Share
            lblNode.Text     = options.LangCur.lEENodeName;
            lblName.Text     = options.LangCur.lEEName;
            lblID.Text       = options.LangCur.lEEID;
            lblRevision.Text = options.LangCur.lEERevision;
            // Own
            lblLineThick.Text = options.LangCur.lEELineThick;
            lblLineStyle.Text = options.LangCur.lEELineStyle;
            toolTip.SetToolTip(btnColor, options.LangCur.hEEColorPick);
            // Fill
            //...
            cbbStyle.SelectedIndex = 0;
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
