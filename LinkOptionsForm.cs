using System;
using System.Windows.Forms;

namespace Schematix
{
    public partial class LinkOptionsForm : Form
    {
        public LinkOptionsForm()
        {
            InitializeComponent();
            Text = options.LangCur.lEOTitle + " " + options.LangCur.lEETitleLink;
        }

        private void btnGetReference_Click(object sender, EventArgs e)
        {
            Share.GetFile(tbReference);
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
