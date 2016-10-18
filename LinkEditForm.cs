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
            lblNode.Text     = options.LangCur.lEENode;
            lblName.Text     = options.LangCur.lEEName;
            lblID.Text       = options.LangCur.lEEID;
            lblRevision.Text = options.LangCur.lEERevision;
            // Own
            lblThick.Text = options.LangCur.lEEThick;
            if (false)
            {
                Text = options.LangCur.lEETitleEdit + " " + options.LangCur.lEEBox;
                //...
                //cbbStyle.SelectedIndex = 0;
            }
            else
            {
                Text = options.LangCur.lEETitleAdd + " " + options.LangCur.lEEBox;
                cbbStyle.SelectedIndex = 0;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //...
            // Out
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnColor_Click(object sender, EventArgs e)//Ok
        {
            if (dlgColor.ShowDialog() == DialogResult.OK)
                (sender as Button).BackColor = dlgColor.Color;
        }
    }
}
