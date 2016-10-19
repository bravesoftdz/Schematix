using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schematix
{
    public partial class IPEditForm : Form
    {
        public IPEditForm()
        {
            InitializeComponent();
            lblName.Text = options.LangCur.lEEName;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //...
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
