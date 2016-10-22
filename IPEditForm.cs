using System;
using System.Windows.Forms;

namespace Schematix
{
    public partial class IPEditForm : Form
    {
        public xIP IP;

        public IPEditForm(xIP ip, xObject owner)//Ok
        {
            InitializeComponent();
            lblAddress.Text  = options.LangCur.lIPAddress;
            lblName.Text     = options.LangCur.lEOName;
            lblPeriod.Text   = options.LangCur.lIPPeriod;
            lblTimeNext.Text = options.LangCur.lIPTimeNext;
            lblTimeOutGreen.Text  = options.LangCur.lIPTimeOutGreen;
            lblTimeOutYellow.Text = options.LangCur.lIPTimeOutYellow;
            lblTimeOutRed.Text    = options.LangCur.lIPTimeOutRed;
            if (ip == null)
            {
                Text = options.LangCur.lIPTitleAdd;
                ip = new xIP(owner);
            }
            else
                Text = options.LangCur.lIPTitleEdit;
            IP = ip;
            tbName.Text         = IP.Name;
            tbDescription.Text  = IP.Description;
            tbAddress.Text      = IP.Address;
            //
            nudTimeOutGreen.Value   = IP.TimeOutGreen;
            nudTimeOutYellow.Value  = IP.TimeOutYellow;
            nudTimeOutRed.Value     = IP.TimeOutRed;
            //
            dtpDateNext.Value   = IP.TimeNext;
            dtpDateNext.Checked = IP.Onn;
            nudPeriod.Value     = IP.Period;
        }

        private void btnOk_Click(object sender, EventArgs e)//Ok
        {
            IP.Name         = tbName.Text;
            IP.Description  = tbDescription.Text;
            IP.Address      = tbAddress.Text;
            //
            IP.TimeOutGreen  = (int)nudTimeOutGreen.Value;
            IP.TimeOutYellow = (int)nudTimeOutYellow.Value;
            IP.TimeOutRed    = (int)nudTimeOutRed.Value;
            //
            IP.TimeNext = dtpDateNext.Value;
            IP.Onn      = dtpDateNext.Checked;
            IP.Period   = (int)nudPeriod.Value;
            // Out
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
