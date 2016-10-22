using System;
using System.Windows.Forms;

namespace Schematix
{
    public partial class BoxOptionsForm : Form
    {
        xBox Box;

        public BoxOptionsForm(xBox box)
        {
            InitializeComponent();
            Text = options.LangCur.lEOTitle + " " + options.LangCur.lEETitleBox;
            Box = box;
            if (Box == null)
            {
                btnOk.Enabled = false;
                return;
            }
            tbReference.Text   = Box.Reference;
            tbName.Text        = Box.Name;
            tbDescription.Text = Box.Description;
            tbText.Text        = Box.Text;
        }

        private void btnGetReference_Click(object sender, EventArgs e)
        {
            Share.GetFile(tbReference);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Box != null)
            {
                Box.Reference   = tbReference.Text;
                Box.Name        = tbName.Text;
                Box.Description = tbDescription.Text;
                Box.Text        = tbText.Text;
            }

            // Out
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
