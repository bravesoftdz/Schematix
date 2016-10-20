using System;
using System.Windows.Forms;

namespace Schematix
{
    public partial class ObjectOptionsForm : Form
    {
        public ObjectOptionsForm()
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
        }

        private void btnGetReference_Click(object sender, EventArgs e)//Ok
        {
            Share.GetFile(tbReference);
        }

        private void lvIPs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvIPs_DoubleClick(object sender, EventArgs e)
        {
            var form = new IPEditForm(null);
            if (form.ShowDialog() == DialogResult.OK)
            {
                //...
            }
        }

        private void btnIPAdd_Click(object sender, EventArgs e)
        {
            var form = new IPEditForm(null);
            if (form.ShowDialog() == DialogResult.OK)
            {
                //...
            }
        }

        private void btnIPDelete_Click(object sender, EventArgs e)
        {
            //...
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
