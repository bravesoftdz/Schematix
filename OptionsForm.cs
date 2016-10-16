using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Schematix
{
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();
        }

        private void SetText(LanguageRecord lang)//!!!
        {
            //toolTip.RemoveAll();
            //Main
            //tpFiles.Text = lang.lblFiles;
            //toolTip.SetToolTip(btnOptions, lang.hintOptions);
        }

        #region Main
        private void btnGetRootMaps_Click(object sender, EventArgs e)//O
        {
            GetRoot(tbRootMaps, "\\Maps");
        }

        private void btnGetRootObjects_Click(object sender, EventArgs e)//O
        {
            GetRoot(tbRootObjects, "\\Objects");
        }

        private void btnGetRootLinks_Click(object sender, EventArgs e)//O
        {
            GetRoot(tbRootLinks, "\\Links");
        }

        private void btnGetRootBoxes_Click(object sender, EventArgs e)//O
        {
            GetRoot(tbRootBoxes, "\\Boxes");
        }

        private void GetRoot(TextBox target, String root)//O
        {
            if (target.Text == "")
                target.Text = Directory.GetCurrentDirectory() + root;
            dlgFolder.SelectedPath = target.Text;
            if (dlgFolder.ShowDialog() == DialogResult.OK)
                target.Text = dlgFolder.SelectedPath;
        }
        #endregion

        #region New map
        private void pnlColor_Click(object sender, EventArgs e)//Ok
        {
            if (dlgColor.ShowDialog() == DialogResult.OK)
                (sender as Panel).BackColor = dlgColor.Color;
            if (sender == pnlBackgroundColor)
                pbBackgroundPreview.BackColor = dlgColor.Color;
        }

        private void btnGetImage_Click(object sender, EventArgs e)//
        {
            if (tbBackgroundImage.Text == "")
                tbBackgroundImage.Text = Directory.GetCurrentDirectory();
            if (dlgOpen.ShowDialog() == DialogResult.OK)
                tbBackgroundImage.Text = dlgOpen.FileName;
            pbBackgroundPreview.BackgroundImage = new Bitmap(dlgOpen.FileName);
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            //
        }

        private void cbbBackgroundStyle_SelectedIndexChanged(object sender, EventArgs e)//!!!
        {
            pbBackgroundPreview.BackgroundImageLayout = (ImageLayout)cbbBackgroundStyle.SelectedIndex;
        }

        private void btnGetRootLanguage_Click(object sender, EventArgs e)
        {
            GetRoot(tbLanguagePath, "\\Languages");
        }
    }
}
