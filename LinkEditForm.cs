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
                Text = options.LangCur.lEETitleAdd + " " + options.LangCur.lEETitleLink;
            }
            else
                Text = options.LangCur.lEETitleEdit + " " + options.LangCur.lEETitleLink;
            PLink = pLink;
            // Share
            lblNode.Text        = options.LangCur.lEENodeName;
            chkIsPrototype.Text = options.LangCur.lEEPrototype;
            lblName.Text        = options.LangCur.lEEName;
            lblID.Text          = options.LangCur.lEEID;
            lblRevision.Text    = options.LangCur.lEERevision;
            // Fill
            tbNode.Text            = PLink.NodeName;
            chkIsPrototype.Checked = PLink.isPrototype;
            tbName.Text            = PLink.Name;
            tbID.Text              = PLink.ID.ToString();
            tbRevision.Text        = PLink.Revision.ToString(options.TIME_FORMAT);
            tbDescription.Text     = PLink.Description;
            // Own
            lblLineThick.Text = options.LangCur.lEELineThick;
            lblLineStyle.Text = options.LangCur.lEELineStyle;
            toolTip.SetToolTip(btnLineColor, options.LangCur.hEEColorPick);
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
            PLink.Revision    = DateTime.Now;
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
