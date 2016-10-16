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

            //# Main
            // Language
            tbLanguagePath.Text = options.LangPath;
            cbbLanguage.Items.AddRange(options.Langs.Select(l => l.Name).ToArray());
            cbbLanguage.Text = options.LangName;
            if (cbbLanguage.SelectedIndex < 0)
                cbbLanguage.SelectedIndex = 0;
            SetText(options.Langs[cbbLanguage.SelectedIndex]);
            // Behaiour
            cbbOnStart.Items.Add("-//-");
            cbbOnClose.Items.Add("-//-");
            cbbOnStart.SelectedIndex = options.OnStart;
            cbbOnClose.SelectedIndex = options.OnClose;
            if (options.PingPeriod < 1)
                options.PingPeriod = 1;
            chkPingPeriod.Checked = options.PingOnn;
            nudPingPeriod.Maximum = options.MAX_PING_PERIOD;
            nudPingCount.Maximum  = options.MAX_PING_COUNT;
            nudPingPeriod.Value   = options.PingPeriod;
            nudPingCount.Value    = options.PingCount;
            // Folders
            tbRootMaps.Text    = options.RootMaps;
            tbRootObjects.Text = options.RootObjects;
            tbRootLinks.Text   = options.RootLinks;
            tbRootBoxes.Text   = options.RootBoxes;

            //# Map
            // Grid
            cbbGridStyle.Items.Add("-//-");
            chkGridStore.Checked       = options.GridStoreOwn;
            cbbGridStyle.SelectedIndex = options.GridStyle;
            pnlGridColor.BackColor     = options.GridColor;
            nudGridStepX.Maximum       = options.MAX_GRID_STEP;
            nudGridStepY.Maximum       = options.MAX_GRID_STEP;
            nudGridThick.Maximum       = options.MAX_GRID_THICK;
            nudGridStepX.Value         = options.GridStepX;
            nudGridStepY.Value         = options.GridStepY;
            nudGridThick.Value         = options.GridThick;
            chkGridAlign.Checked       = options.GridAlign;
            // Background
            cbbBackgroundStyle.Items.Add("-//-");
            chkBackgroundStore.Checked          = options.BackgroundStoreOwn;
            cbbBackgroundStyle.SelectedIndex    = options.BackgroundStyle;
            pnlBackgroundColor.BackColor        = options.BackgroundColor;
            tbBackgroundImagePath.Text          = options.BackgroundImagePath;
            pbBackgroundPreview.BackgroundImage = options.BackgroundImage;
        }

        private void SetText(LanguageRecord lang)//!!!
        {
            toolTip.RemoveAll();
            //# Main
            //gbLanguage.Text = lang;
            //toolTip.SetToolTip(btnOptions, lang.hintOptions);
        }

        private void btnSave_Click(object sender, EventArgs e)//
        {
            bool cantsave = false;
            if (!Directory.Exists(tbLanguagePath.Text))
            {
                tbLanguagePath.ForeColor = Color.Brown;
                cantsave = true;
            }
            else
                tbLanguagePath.ForeColor = Color.Black;
            if (!Directory.Exists(tbRootMaps.Text))
            {
                tbRootMaps.ForeColor = Color.Brown;
                cantsave = true;
            }
            else
                tbRootMaps.ForeColor = Color.Black;
            if (!Directory.Exists(tbRootObjects.Text))
            {
                tbRootObjects.ForeColor = Color.Brown;
                cantsave = true;
            }
            else
                tbRootObjects.ForeColor = Color.Black;
            if (!Directory.Exists(tbRootLinks.Text))
            {
                tbRootLinks.ForeColor = Color.Brown;
                cantsave = true;
            }
            else
                tbRootLinks.ForeColor = Color.Black;
            if (!Directory.Exists(tbRootBoxes.Text))
            {
                tbRootBoxes.ForeColor = Color.Brown;
                cantsave = true;
            }
            else
                tbRootBoxes.ForeColor = Color.Black;
            if (cantsave)
            {
                MessageBox.Show("Some of folders doesn't exists", "Save options");
                return;
            }
            //# Main
            // Language
            options.LangPath = tbLanguagePath.Text;
            options.LangCur = options.Langs[cbbLanguage.SelectedIndex];
            options.LangName = options.LangCur.Name;
            // Behaiour
            options.OnStart = cbbOnStart.SelectedIndex;
            options.OnClose = cbbOnClose.SelectedIndex;
            options.PingOnn = chkPingPeriod.Checked;
            options.PingPeriod = (int)nudPingPeriod.Value;
            options.PingCount = (int)nudPingCount.Value;
            // Folders
            options.RootMaps = tbRootMaps.Text;
            options.RootObjects = tbRootObjects.Text;
            options.RootLinks = tbRootLinks.Text;
            options.RootBoxes = tbRootBoxes.Text;

            //# Map
            // Grid
            options.GridStoreOwn = chkGridStore.Checked;
            options.GridStyle = cbbGridStyle.SelectedIndex;
            options.GridColor = pnlGridColor.BackColor;
            options.GridStepX = (int)nudGridStepX.Value;
            options.GridStepY = (int)nudGridStepY.Value;
            options.GridThick = (int)nudGridThick.Value;
            options.GridAlign = chkGridAlign.Checked;
            // Background
            options.BackgroundStoreOwn = chkBackgroundStore.Checked;
            options.BackgroundStyle = cbbBackgroundStyle.SelectedIndex;
            options.BackgroundColor = pnlBackgroundColor.BackColor;
            options.BackgroundImagePath = tbBackgroundImagePath.Text;
            options.BackgroundImage = new Bitmap(pbBackgroundPreview.BackgroundImage);

            // Out
            DialogResult = DialogResult.OK;
            Close();
        }

        #region Get folder
        private void btnGetRootLanguage_Click(object sender, EventArgs e)//O
        {
            GetRoot(tbLanguagePath);
        }

        private void btnGetRootMaps_Click(object sender, EventArgs e)//O
        {
            GetRoot(tbRootMaps);
        }

        private void btnGetRootObjects_Click(object sender, EventArgs e)//O
        {
            GetRoot(tbRootObjects);
        }

        private void btnGetRootLinks_Click(object sender, EventArgs e)//O
        {
            GetRoot(tbRootLinks);
        }

        private void btnGetRootBoxes_Click(object sender, EventArgs e)//O
        {
            GetRoot(tbRootBoxes);
        }

        private void GetRoot(TextBox target)//O
        {
            if (target.Text == "")
                target.Text = Directory.GetCurrentDirectory();
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

        private void cbbBackgroundStyle_SelectedIndexChanged(object sender, EventArgs e)//!!!
        {
            pbBackgroundPreview.BackgroundImageLayout = (ImageLayout)cbbBackgroundStyle.SelectedIndex;
        }

        private void btnGetImage_Click(object sender, EventArgs e)//
        {
            if (tbBackgroundImagePath.Text == "")
                tbBackgroundImagePath.Text = Directory.GetCurrentDirectory();
            if (dlgOpen.ShowDialog() == DialogResult.OK)
                tbBackgroundImagePath.Text = dlgOpen.FileName;
            pbBackgroundPreview.BackgroundImage = new Bitmap(dlgOpen.FileName);
        }
        #endregion
    }
}
