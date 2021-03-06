﻿using System;
using System.Windows.Forms;

namespace Schematix
{
    public partial class LinkOptionsForm : Form
    {
        xLink Link;

        public LinkOptionsForm(xLink link)
        {
            InitializeComponent();
            Text = Options.LangCur.lEOTitle + " " + Options.LangCur.lEETitleLink;
            // Share
            lblReference.Text = Options.LangCur.lEOReference;
            lblName.Text      = Options.LangCur.lEOName;
            toolTip.SetToolTip(btnGetReference, Options.LangCur.hEOGetReference);
            // Store
            Link = link;
            if (Link == null)
            {
                btnOk.Enabled = false;
                return;
            }
            // Fill
            tbReference.Text   = Link.Reference;
            tbName.Text        = Link.Name;
            tbDescription.Text = Link.Description;
        }

        private void btnGetReference_Click(object sender, EventArgs e) => Share.GetFile(tbReference);

        private void btnOk_Click(object sender, EventArgs e)
        {
            Link.Reference   = tbReference.Text;
            Link.Name        = tbName.Text;
            Link.Description = tbDescription.Text;
            // Out
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
