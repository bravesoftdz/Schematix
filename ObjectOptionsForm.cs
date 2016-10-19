using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schematix
{
    public partial class ObjectOptionsForm : Form
    {
        public ObjectOptionsForm()
        {
            InitializeComponent();
        }

        private void lvIPs_DoubleClick(object sender, EventArgs e)
        {
            var form = new IPEditForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                //...
            }
        }

        private void btnIPAdd_Click(object sender, EventArgs e)
        {
            var form = new IPEditForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                //...
            }
        }

        private void btnIPDelete_Click(object sender, EventArgs e)
        {
            //...
        }

        private void btnGetReference_Click(object sender, EventArgs e)//Ok
        {
            var dlgOpen = new OpenFileDialog();
            if (tbReference.Text == "")
                dlgOpen.InitialDirectory = Directory.GetCurrentDirectory();
            else
                dlgOpen.InitialDirectory = Path.GetDirectoryName(tbReference.Text);
            dlgOpen.FileName = Path.GetFileName(tbReference.Text);
            if (dlgOpen.ShowDialog() == DialogResult.OK)
                tbReference.Text = dlgOpen.FileName;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //...
            // Out
            DialogResult = DialogResult.OK;
            Close();
        }

        private void lvIPs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
