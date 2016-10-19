using System;
using System.Windows.Forms;

namespace Schematix
{
    public partial class IPEditForm : Form
    {
        public IPEditForm()
        {
            InitializeComponent();
            lblAddress.Text  = options.LangCur.lIPAddress;
            lblName.Text     = options.LangCur.lEOName;
            lblPeriod.Text   = options.LangCur.lIPPeriod;
            lblTimeOut.Text  = options.LangCur.lIPTimeOut;
            lblTimeNext.Text = options.LangCur.lIPTimeNext;
            if (false)
            {
                Text = options.LangCur.lIPTitleEdit;
                //...
            }
            else
            {
                Text = options.LangCur.lIPTitleAdd;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //...
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
