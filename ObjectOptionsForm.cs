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
            Text = Options.LangCur.lEOTitle + " " + Options.LangCur.lEETitleObject;
            // Share
            lblReference.Text = Options.LangCur.lEOReference;
            lblName.Text      = Options.LangCur.lEOName;
            toolTip.SetToolTip(btnGetReference, Options.LangCur.hEOGetReference);
            // Own
            toolTip.SetToolTip(btnIPAdd,        Options.LangCur.hOOIPAdd);
            toolTip.SetToolTip(btnIPDelete,     Options.LangCur.hOOIPDelete);
            clmIP.Text        = Options.LangCur.lOOColumIP;
            clmPeriod.Text    = Options.LangCur.lOOColumPeriod;
            clmTimeLast.Text  = Options.LangCur.lOOColumTimeLast;
            clmTimeNext.Text  = Options.LangCur.lOOColumTimeNext;
            clmPing.Text      = Options.LangCur.lOOColumPing;
            // Store
            Object = obj;
            if (Object == null)
            {
                btnIPAdd.Enabled = false;
                btnOk.Enabled = false;
                return;
            }
            // Fill
            tbReference.Text   = Object.Reference;
            tbName.Text        = Object.Name;
            tbDescription.Text = Object.Description;
            // Fill IPs
            foreach (var IP in obj.IPs)
                Share.lvIPs_Add(lvIPs, IP, ref IP.Obj_lvItem);
        }

        private void btnGetReference_Click(object sender, EventArgs e) => Share.GetFile(tbReference);//Ok

        private void lvIPs_SelectedIndexChanged(object sender, EventArgs e) => btnIPDelete.Enabled = (0 < lvIPs.SelectedItems.Count);//O

        private void btnIPAdd_Click(object sender, EventArgs e)//O
        {
            var form = new IPEditForm(null, Object);
            if (form.ShowDialog() == DialogResult.OK)
                Share.lvIPs_Add(lvIPs, form.IP, ref form.IP.Obj_lvItem);
        }

        private void lvIPs_DoubleClick(object sender, EventArgs e) => Share.lvIPs_Edit(lvIPs);//O

        private void btnIPDelete_Click(object sender, EventArgs e) => Share.lvIPs_Delete(lvIPs);//O

        private void lvIPs_ItemChecked(object sender, ItemCheckedEventArgs e) => (e.Item.Tag as xIP).Onn = e.Item.Checked;//

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
                IP.Obj_lvItem = null;
                Object.AddIP(IP);                
            }

            // Out
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
