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
            clmIP.Text         = Options.LangCur.lOOColumIP;
            clmPeriod.Text     = Options.LangCur.lOOColumPeriod;
            clmLastResult.Text = Options.LangCur.lOOColumTimeLast;
            clmTimeNext.Text   = Options.LangCur.lOOColumTimeNext;
            clmLastResult.Text = Options.LangCur.lOOColumResult;
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

        private void btnIPAdd_Click(object sender, EventArgs e)//Ok
        {
            var form = new IPEditForm(null, Object);
            if (form.ShowDialog() == DialogResult.OK)
                Share.lvIPs_Add(lvIPs, form.IP, ref form.IP.Obj_lvItem);
        }

        private void btnIPEdit_Click(object sender, EventArgs e) => Share.lvIPs_Edit(lvIPs);

        private void btnIPDelete_Click(object sender, EventArgs e) => Share.lvIPs_Delete(lvIPs);//Ok

        private void lvIPs_SelectedIndexChanged(object sender, EventArgs e) => btnIPDelete.Enabled = (0 < lvIPs.SelectedItems.Count);//Ok

        private void lvIPs_ItemChecked(object sender, ItemCheckedEventArgs e)//Ok
        {
            if (e.Item.Tag != null)
                (e.Item.Tag as xIP).Onn = e.Item.Checked;
        }

        private void lvIPs_DoubleClick(object sender, EventArgs e)//
        {
            (sender as ListView).SelectedItems[0].Checked = !(sender as ListView).SelectedItems[0].Checked;
            btnIPEdit_Click(null, null);
        }

        private void ObjectOptionsForm_FormClosing(object sender, FormClosingEventArgs e)//Ok
        {
            // Clear backtrack
            foreach (ListViewItem lvItem in lvIPs.Items)
                (lvItem.Tag as xIP).Obj_lvItem = null;
        }

        private void btnOk_Click(object sender, EventArgs e)//Ok
        {
            Object.Reference   = tbReference.Text;
            Object.Name        = tbName.Text;
            Object.Description = tbDescription.Text;
            // Register IPs
            foreach (ListViewItem lvItem in lvIPs.Items)
                Object.AddIP((lvItem.Tag as xIP));

            // Out
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
