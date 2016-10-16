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
            chkBackgroundStore.Checked            = options.BackgroundStoreOwn;
            cbbBackgroundStyle.SelectedIndex      = options.BackgroundStyle;
            pnlBackgroundColor.BackColor          = options.BackgroundColor;
            tbBackgroundImagePath.Text            = options.BackgroundImagePath;
            cbbBackgroundImageAlign.SelectedIndex = options.BackgroundImageAlign;
            chkBackgroundImageFloat.Checked       = options.BackgroundImageFloat;
            chkBackgroundImageBuildIn.Checked     = options.BackgroundImageBuildIn;
            pbBackgroundPreview.BackgroundImage   = options.BackgroundImage;
        }

        private void SetText(LanguageRecord lang)//!!!
        {
            int idx;
            toolTip.RemoveAll();
            Text = lang.lOFTitle;
            //# Main
            tpMain.Text = lang.lOFMainTab;
            // Language
            gbLanguage.Text = lang.lOFMainLanguage;
            lblLanguagePath.Text = lang.lOFMainLanguagePath;
            toolTip.SetToolTip(btnGetLanguagePath, options.LangCur.hOFMainRootGet);
            // Behaiour
            gbRoots.Text = lang.lOFMainRoots;
            lblRootMaps.Text = lang.lOFMainRootMaps;
            lblRootObjects.Text = lang.lOFMainRootObjects;
            lblRootLinks.Text = lang.lOFMainRootLinks;
            lblRootBoxes.Text = lang.lOFMainRootBoxes;
            toolTip.SetToolTip(btnGetRootMaps,    options.LangCur.hOFMainRootGet);
            toolTip.SetToolTip(btnGetRootObjects, options.LangCur.hOFMainRootGet);
            toolTip.SetToolTip(btnGetRootLinks,   options.LangCur.hOFMainRootGet);
            toolTip.SetToolTip(btnGetRootBoxes,   options.LangCur.hOFMainRootGet);
            // Folders
            idx = cbbOnStart.SelectedIndex;
            cbbOnStart.Items.Clear();
            cbbOnStart.Items.Add(lang.lOFMainOnStart0Empty);
            cbbOnStart.Items.Add(lang.lOFMainOnStart1Ask);
            cbbOnStart.Items.Add(lang.lOFMainOnStart2Load);
            cbbOnStart.SelectedIndex = idx;
            idx = cbbOnClose.SelectedIndex;
            cbbOnClose.Items.Clear();
            cbbOnClose.Items.Add(lang.lOFMainOnClose0Exit);
            cbbOnClose.Items.Add(lang.lOFMainOnClose1Ask);
            cbbOnClose.Items.Add(lang.lOFMainOnClose2Save);
            cbbOnClose.SelectedIndex = idx;
            gbBehaiour.Text = lang.lOFMainBehaiour;
            lblOnStart.Text = lang.lOFMainOnStart;
            lblOnClose.Text = lang.lOFMainOnClose;
            chkPingPeriod.Text = lang.lOFMainPingPeriod;
            lblPingCount.Text = lang.lOFMainPingCount;

            //# Map
            tpMap.Text = lang.lOFMapTab;
            // Grid
            gbGrid.Text = lang.lOFMapGrid;
            chkGridStore.Text = lang.lOFMapStore;
            idx = cbbGridStyle.SelectedIndex;
            cbbGridStyle.Items.Clear();
            cbbGridStyle.Items.Add(lang.lOFMapGridStyle0None);
            cbbGridStyle.Items.Add(lang.lOFMapGridStyle1Dots);
            cbbGridStyle.Items.Add(lang.lOFMapGridStyle2Corners);
            cbbGridStyle.Items.Add(lang.lOFMapGridStyle3Crosses);
            cbbGridStyle.Items.Add(lang.lOFMapGridStyle4Grid);
            cbbGridStyle.SelectedIndex = idx;
            toolTip.SetToolTip(pnlGridColor, options.LangCur.hOFMapGridColor);
            lblGridThick.Text = lang.lOFMapGridThick;
            chkGridAlign.Text = lang.lOFMapGridAlign;
            // Background
            gbBackground.Text = lang.lOFMapBack;
            chkBackgroundStore.Text = lang.lOFMapStore;
            idx = cbbBackgroundStyle.SelectedIndex;
            cbbBackgroundStyle.Items.Clear();
            cbbBackgroundStyle.Items.Add(lang.lOFMapBackStyle0Color);
            cbbBackgroundStyle.Items.Add(lang.lOFMapBackStyle1ImageAlign);
            cbbBackgroundStyle.Items.Add(lang.lOFMapBackStyle2ImageTile);
            cbbBackgroundStyle.Items.Add(lang.lOFMapBackStyle3ImageStrech);
            cbbBackgroundStyle.Items.Add(lang.lOFMapBackStyle4ImageZInner);
            cbbBackgroundStyle.Items.Add(lang.lOFMapBackStyle5ImageZOutter);
            cbbBackgroundStyle.SelectedIndex = idx;
            toolTip.SetToolTip(pnlBackgroundColor, options.LangCur.hOFMapBackColor);
            lblBackgroundImagePath.Text = lang.lOFMapBackImagePath;
            toolTip.SetToolTip(btnGetBackgroundImage, options.LangCur.hOFMapBackImageLoad);
            lblBackgroundImageAlign.Text = lang.lOFMapBackImageAlign;
            idx = cbbBackgroundImageAlign.SelectedIndex;
            cbbBackgroundImageAlign.Items.Clear();
            cbbBackgroundImageAlign.Items.Add(lang.lOFMapBackImageAlign0TL);
            cbbBackgroundImageAlign.Items.Add(lang.lOFMapBackImageAlign1T);
            cbbBackgroundImageAlign.Items.Add(lang.lOFMapBackImageAlign2TR);
            cbbBackgroundImageAlign.Items.Add(lang.lOFMapBackImageAlign3L);
            cbbBackgroundImageAlign.Items.Add(lang.lOFMapBackImageAlign4C);
            cbbBackgroundImageAlign.Items.Add(lang.lOFMapBackImageAlign5R);
            cbbBackgroundImageAlign.Items.Add(lang.lOFMapBackImageAlign6BL);
            cbbBackgroundImageAlign.Items.Add(lang.lOFMapBackImageAlign7B);
            cbbBackgroundImageAlign.Items.Add(lang.lOFMapBackImageAlign8BR);
            cbbBackgroundImageAlign.SelectedIndex = idx;
            chkBackgroundImageFloat.Text = lang.lOFMapBackImageFloat;
            chkBackgroundImageBuildIn.Text = lang.lOFMapBackImageBuildIn;
        }

        private void Path_TextChanged(object sender, EventArgs e)
        {
            (sender as TextBox).BackColor = (
                Directory.Exists((sender as TextBox).Text) 
                ? Color.White 
                : Color.MistyRose);
        }

        private void btnSave_Click(object sender, EventArgs e)//
        {
            // Check existence
            String eStr = "";
            if (!Directory.Exists(tbLanguagePath.Text))
                eStr += "\r\n" + tbLanguagePath.Text;
            if (!Directory.Exists(tbRootMaps.Text))
                eStr += "\r\n" + tbRootMaps.Text;
            if (!Directory.Exists(tbRootObjects.Text))
                eStr += "\r\n" + tbRootObjects.Text;
            if (!Directory.Exists(tbRootLinks.Text))
                eStr += "\r\n" + tbRootLinks.Text;
            if (!Directory.Exists(tbRootBoxes.Text))
                eStr += "\r\n" + tbRootBoxes.Text;
            // Some missing
            if (eStr != "")
            {
                if (DialogResult.Cancel == MessageBox.Show(
                    options.LangCur.mNoFolders + eStr + "\r\n" + options.LangCur.mCreateThem, 
                    options.LangCur.dOptionsSaving,
                    MessageBoxButtons.OKCancel))
                    return;
                // Try to create
                eStr = "";
                if (!Directory.Exists(tbLanguagePath.Text))
                    try
                    {
                        Directory.CreateDirectory(tbLanguagePath.Text);
                    }
                    catch (Exception ex)
                    {
                        eStr += "\r\n" + ex.Message;
                    }
                if (!Directory.Exists(tbRootMaps.Text))
                    try
                    {
                        Directory.CreateDirectory(tbRootMaps.Text);
                    }
                    catch (Exception ex)
                    {
                        eStr += "\r\n" + ex.Message;
                    }
                if (!Directory.Exists(tbRootObjects.Text))
                    try
                    {
                        Directory.CreateDirectory(tbRootObjects.Text);
                    }
                    catch (Exception ex)
                    {
                        eStr += "\r\n" + ex.Message;
                    }
                if (!Directory.Exists(tbRootLinks.Text))
                    try
                    {
                        Directory.CreateDirectory(tbRootLinks.Text);
                    }
                    catch (Exception ex)
                    {
                        eStr += "\r\n" + ex.Message;
                    }
                if (!Directory.Exists(tbRootBoxes.Text))
                    try
                    {
                        Directory.CreateDirectory(tbRootBoxes.Text);
                    }
                    catch (Exception ex)
                    {
                        eStr += "\r\n" + ex.Message;
                    }
                // Where errors
                if (eStr != "")
                {
                    MessageBox.Show(
                        options.LangCur.mErrorsOccurred + "\r\n" + eStr,
                        options.LangCur.dOptionsSaving);
                    return;
                }
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
            options.BackgroundImageBuildIn = chkBackgroundImageBuildIn.Checked;

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
