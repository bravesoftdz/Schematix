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
            Text = Options.LangCur.lEOTitle + " " + Options.LangCur.lEETitleBox;
            // Share
            lblReference.Text = Options.LangCur.lEOReference;
            lblName.Text      = Options.LangCur.lEOName;
            toolTip.SetToolTip(btnGetReference, Options.LangCur.hEOGetReference);
            // Own
            lblText.Text      = Options.LangCur.lBOText;
            lblSize.Text      = Options.LangCur.lBOSize;
            // Store
            Box = box;
            if (Box == null)
            {
                btnOk.Enabled = false;
                return;
            }
            // Fill
            tbReference.Text    = Box.Reference;
            tbName.Text         = Box.Name;
            tbDescription.Text  = Box.Description;
            tbText.Text         = Box.Text;
            nudSizeWidth.Value  = Box.Width;
            nudSizeHeight.Value = Box.Height;
        }

        private void btnGetReference_Click(object sender, EventArgs e) => Share.GetFile(tbReference);

        private void btnOk_Click(object sender, EventArgs e)
        {
            Box.Reference   = tbReference.Text;
            Box.Name        = tbName.Text;
            Box.Description = tbDescription.Text;
            Box.Text        = tbText.Text;
            Box.Width       = (int)nudSizeWidth.Value;
            Box.Height      = (int)nudSizeHeight.Value;
            // Out
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
