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
            //Main
            lblAddress.Text  = Options.LangCur.lIPAddress;
            lblName.Text     = Options.LangCur.lEOName;
            lblPeriod.Text   = Options.LangCur.lIPPeriod;
            lblTimeNext.Text = Options.LangCur.lIPTimeNext;
            lblTimeOutGreen.Text  = Options.LangCur.lIPTimeOutGreen;
            lblTimeOutYellow.Text = Options.LangCur.lIPTimeOutYellow;
            lblTimeOutRed.Text    = Options.LangCur.lIPTimeOutRed;
            // Fill
            if (ip == null)
            {
                Text = Options.LangCur.lIPTitleAdd;
                ip = new xIP(owner);
            }
            else
                Text = Options.LangCur.lIPTitleEdit;
            IP = ip;
            tbName.Text        = IP.Name;
            tbDescription.Text = IP.Description;
            tbAddress.Text     = IP.Address;
            //
            nudTimeOutGreen.Value  = IP.TimeOutGreen;
            nudTimeOutYellow.Value = IP.TimeOutYellow;
            nudTimeOutRed.Value    = IP.TimeOutRed;
            //
            dtpDateNext.Value   = IP.TimeNext;
            dtpDateNext.Checked = IP.Onn;
            nudPeriod.Value     = IP.Period;

            // Pings
            clmSendTime.Text = Options.LangCur.lIPColumSendTime;
            clmState.Text    = Options.LangCur.lIPColumState;
            clmTripTime.Text = Options.LangCur.lIPColumTripTime;
            toolTip.SetToolTip(btnClearPings, Options.LangCur.hIPClearPings);
            // Fill
            for (int i = 0; i < IP.PingsCount; i++)
                if(IP.Pings[i].State != PingStates.NotSend)
                    Share.lvPings_Add(lvPings, IP, IP.Pings[i]);
            IP.Pings_lv = lvPings;

            // Push window sizes
            tabControl.Width = tlpTimers.Width + 16;
        }

        private void btnClearPings_Click(object sender, EventArgs e)
        {
            lvPings.Items.Clear();
            IP.ClearPings();
        }

        private void IPEditForm_FormClosing(object sender, FormClosingEventArgs e) => IP.Pings_lv = null;

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
