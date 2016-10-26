using System;
using System.Reflection;
using System.Windows.Forms;

namespace Schematix
{
    partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            Text               = Options.LangCur.lAbout;
            lblAppName.Text    = Options.LangCur.lAppName;
            lblAppVersion.Text = Options.LangCur.lAppVersion;
            lblOwner.Text      = Options.LangCur.lOwner;
            lblContact.Text    = Options.LangCur.lContact;
            tbDescription.Text = Options.LangCur.tDescription;
        }
    }
}
