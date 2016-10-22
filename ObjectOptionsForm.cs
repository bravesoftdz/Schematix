using System;
using System.Windows.Forms;

namespace Schematix
{
    public partial class ObjectOptionsForm : Form
    {
        xObject Object;

        public ObjectOptionsForm(xObject obj)
        {
            InitializeComponent();
            Text = options.LangCur.lEOTitle + " " + options.LangCur.lEETitleObject;
            // Share
            lblName.Text      = options.LangCur.lEOName;
            lblReference.Text = options.LangCur.lEOReference;
            toolTip.SetToolTip(btnGetReference, options.LangCur.hEOGetReference);
            // Own
            toolTip.SetToolTip(btnIPAdd,        options.LangCur.hOOIPAdd);
            toolTip.SetToolTip(btnIPDelete,     options.LangCur.hOOIPDelete);
            clmIP.Text        = options.LangCur.lOOColumIP;
            clmPeriod.Text    = options.LangCur.lOOColumPeriod;
            clmTimeLast.Text  = options.LangCur.lOOColumTimeLast;
            clmTimeNext.Text  = options.LangCur.lOOColumTimeNext;
            clmPing.Text      = options.LangCur.lOOColumPing;
            // Fill
            Object = obj;
            if (Object == null)
            {
                btnIPAdd.Enabled = false;
                btnOk.Enabled = false;
                return;
            }
            tbReference.Text   = Object.Reference;
            tbName.Text        = Object.Name;
            tbDescription.Text = Object.Description;
            // Fill IPs
            foreach (var IP in obj.IPs)
                Share.lvIPs_AddIP(lvIPs, IP);
        }

        private void btnGetReference_Click(object sender, EventArgs e)//Ok
        {
            Share.GetFile(tbReference);
        }

        private void lvIPs_SelectedIndexChanged(object sender, EventArgs e)//O
        {
            btnIPDelete.Enabled = (0 < lvIPs.SelectedItems.Count);
        }

        private void btnIPAdd_Click(object sender, EventArgs e)//O
        {
            var form = new IPEditForm(null, Object);
            if (form.ShowDialog() == DialogResult.OK)
                Share.lvIPs_AddIP(lvIPs, form.IP);
        }

        private void lvIPs_DoubleClick(object sender, EventArgs e)//O
        {
            Share.lvIPs_Edit(lvIPs);
        }

        private void btnIPDelete_Click(object sender, EventArgs e)//O
        {
            Share.lvIPs_Delete(lvIPs);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Object != null)
            {
                Object.Reference   = tbReference.Text;
                Object.Name        = tbName.Text;
                Object.Description = tbDescription.Text;
            }
            // Register IPs
            foreach (ListViewItem lvi in lvIPs.Items)
            {
                xIP IP = (lvi.Tag as xIP);
                if (IP == null)
                    continue;
                IP.lvItem = null;
                Object.AddIP(IP);                
            }

            // Out
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
