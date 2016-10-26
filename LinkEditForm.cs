using System;
using System.Drawing.Drawing2D;
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
                Text = Options.LangCur.lEETitleAdd + " " + Options.LangCur.lEETitleLink;
            }
            else
                Text = Options.LangCur.lEETitleEdit + " " + Options.LangCur.lEETitleLink;
            PLink = pLink;
            // Share
            lblNode.Text        = Options.LangCur.lEENodeName;
            chkIsPrototype.Text = Options.LangCur.lEEPrototype;
            lblName.Text        = Options.LangCur.lEEName;
            lblID.Text          = Options.LangCur.lEEID;
            lblRevision.Text    = Options.LangCur.lEERevision;
            // Fill
            tbNode.Text            = PLink.NodeName;
            chkIsPrototype.Checked = PLink.isPrototype;
            tbName.Text            = PLink.Name;
            tbID.Text              = PLink.ID.ToString();
            tbRevision.Text        = DateTime.FromBinary(PLink.Revision).ToString(Options.TIME_FORMAT);
            tbDescription.Text     = PLink.Description;
            // Own
            lblLineThick.Text = Options.LangCur.lEELineThick;
            lblLineStyle.Text = Options.LangCur.lEELineStyle;
            toolTip.SetToolTip(btnLineColor, Options.LangCur.hEEColorPick);
            // Fill
            nudThick.Value         = (int)PLink.Pen.Width;
            btnLineColor.BackColor = PLink.Pen.Color;
            cbbStyle.SelectedIndex = (int)PLink.Pen.DashStyle;
        }

        private void btnColor_Click(object sender, EventArgs e)//Ok
        {
            if (dlgColor.ShowDialog() == DialogResult.OK)
                (sender as Button).BackColor = dlgColor.Color;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            // Share
            PLink.NodeName    = tbNode.Text;
            PLink.isPrototype = chkIsPrototype.Checked;
            PLink.Revision    = DateTime.Now.ToBinary();
            PLink.Name        = tbName.Text;
            PLink.Description = tbDescription.Text;
            // Own
            PLink.Pen.Width     = (int)nudThick.Value;
            PLink.Pen.Color     = btnLineColor.BackColor;
            PLink.Pen.DashStyle = (DashStyle)cbbStyle.SelectedIndex;

            // Out
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
