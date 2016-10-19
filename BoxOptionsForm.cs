using System;
using System.Windows.Forms;

namespace Schematix
{
    public partial class BoxOptionsForm : Form
    {
        public BoxOptionsForm()
        {
            InitializeComponent();
            Text = options.LangCur.lEOTitle + " " + options.LangCur.lEETitleBox;
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
