using System;
using System.Reflection;
using System.Windows.Forms;

namespace Schematix
{
    partial class AboutForm : Form
    {
        public AboutForm(LanguageRecord lang)
        {
            InitializeComponent();
            Text               = lang.lAbout;
            lblAppName.Text    = lang.lAppName;
            lblAppVersion.Text = lang.lAppVersion;
            lblOwner.Text      = lang.lOwner;
            lblContact.Text    = lang.lContact;
            tbDescription.Text = lang.tDescription;
        }
    }
}
