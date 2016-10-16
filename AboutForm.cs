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
            Text               = options.LangCur.lAbout;
            lblAppName.Text    = options.LangCur.lAppName;
            lblAppVersion.Text = options.LangCur.lAppVersion;
            lblOwner.Text      = options.LangCur.lOwner;
            lblContact.Text    = options.LangCur.lContact;
            tbDescription.Text = options.LangCur.tDescription;
        }
    }
}
