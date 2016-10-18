using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Schematix
{
    public partial class OptionsForm : Form
    {
        Bitmap image = new Bitmap(1,1);

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
            btnGridColor.BackColor     = options.GridColor;
            nudGridStepX.Maximum       = options.MAX_GRID_STEP;
            nudGridStepY.Maximum       = options.MAX_GRID_STEP;
            nudGridThick.Maximum       = options.MAX_GRID_THICK;
            nudGridStepX.Value         = options.GridStepX;
            nudGridStepY.Value         = options.GridStepY;
            nudGridThick.Value         = options.GridThick;
            chkGridAlign.Checked       = options.GridAlign;
            // Background
            chkBackStore.Checked            = options.BackgroundStoreOwn;
            //
            image = new Bitmap(options.BackgroundImage);
            if (cbbBackStyle.SelectedIndex != 0)
                pbBackPreview.BackgroundImage = image;
            cbbBackStyle.SelectedIndex      = options.BackgroundStyle;
            //
            cbbBackImageAlign.SelectedIndex = options.BackgroundImageAlign;
            btnBackColor.BackColor          = options.BackgroundColor;
            tbBackgImagePath.Text           = options.BackgroundImagePath;
            chkBackImageFloat.Checked       = options.BackgroundImageFloat;
            chkBackImageBuildIn.Checked     = options.BackgroundImageBuildIn;
        }

        private void SetText(LanguageRecord lang)//
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
            toolTip.SetToolTip(btnGridColor, options.LangCur.hOFMapGridColor);
            lblGridThick.Text = lang.lOFMapGridThick;
            chkGridAlign.Text = lang.lOFMapGridAlign;
            // Background
            gbBack.Text = lang.lOFMapBack;
            chkBackStore.Text = lang.lOFMapStore;
            idx = cbbBackStyle.SelectedIndex;
            cbbBackStyle.Items.Clear();
            cbbBackStyle.Items.Add(lang.lOFMapBackStyle0Color);
            cbbBackStyle.Items.Add(lang.lOFMapBackStyle1ImageAlign);
            cbbBackStyle.Items.Add(lang.lOFMapBackStyle2ImageTile);
            cbbBackStyle.Items.Add(lang.lOFMapBackStyle3ImageStrech);
            cbbBackStyle.Items.Add(lang.lOFMapBackStyle4ImageZInner);
            cbbBackStyle.Items.Add(lang.lOFMapBackStyle5ImageZOutter);
            cbbBackStyle.SelectedIndex = idx;
            toolTip.SetToolTip(btnBackColor, options.LangCur.hOFMapBackColor);
            lblBackgImagePath.Text = lang.lOFMapBackImagePath;
            toolTip.SetToolTip(btnGetBackImage, options.LangCur.hOFMapBackImageLoad);
            lblBackImageAlign.Text = lang.lOFMapBackImageAlign;
            idx = cbbBackImageAlign.SelectedIndex;
            cbbBackImageAlign.Items.Clear();
            cbbBackImageAlign.Items.Add(lang.lEEAlign0TL);
            cbbBackImageAlign.Items.Add(lang.lEEAlign1T);
            cbbBackImageAlign.Items.Add(lang.lEEAlign2TR);
            cbbBackImageAlign.Items.Add(lang.lEEAlign3L);
            cbbBackImageAlign.Items.Add(lang.lEEAlign4C);
            cbbBackImageAlign.Items.Add(lang.lEEAlign5R);
            cbbBackImageAlign.Items.Add(lang.lEEAlign6BL);
            cbbBackImageAlign.Items.Add(lang.lEEAlign7B);
            cbbBackImageAlign.Items.Add(lang.lEEAlign8BR);
            cbbBackImageAlign.SelectedIndex = idx;
            chkBackImageFloat.Text = lang.lOFMapBackImageFloat;
            chkBackImageBuildIn.Text = lang.lOFMapBackImageBuildIn;
        }

        private void Path_TextChanged(object sender, EventArgs e)//Ok
        {
            (sender as TextBox).BackColor = (
                Directory.Exists((sender as TextBox).Text) 
                ? Color.White 
                : Color.MistyRose);
        }

        private void btnSave_Click(object sender, EventArgs e)//
        {
            #region Check folders existence
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
                #region Try to create
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
                #endregion
                // Where errors
                if (eStr != "")
                {
                    MessageBox.Show(
                        options.LangCur.mErrorsOccurred + "\r\n" + eStr,
                        options.LangCur.dOptionsSaving);
                    return;
                }
            }
            #endregion

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
            options.GridColor = btnGridColor.BackColor;
            options.GridStepX = (int)nudGridStepX.Value;
            options.GridStepY = (int)nudGridStepY.Value;
            options.GridThick = (int)nudGridThick.Value;
            options.GridAlign = chkGridAlign.Checked;
            // Background
            options.BackgroundStoreOwn = chkBackStore.Checked;
            options.BackgroundStyle = cbbBackStyle.SelectedIndex;
            options.BackgroundColor = btnBackColor.BackColor;
            options.BackgroundImagePath = tbBackgImagePath.Text;
            options.BackgroundImage = new Bitmap(pbBackPreview.BackgroundImage);
            options.BackgroundImageBuildIn = chkBackImageBuildIn.Checked;

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

        #region Map tab
        private void PickColor_Click(object sender, EventArgs e)//Ok
        {
            if (dlgColor.ShowDialog() == DialogResult.OK)
                (sender as Panel).BackColor = dlgColor.Color;
        }

        private void btnBackgroundColor_BackColorChanged(object sender, EventArgs e)//Ok
        {
            pbBackPreview.BackColor = btnBackColor.BackColor;
        }

        private void cbbBackgroundStyle_SelectedIndexChanged(object sender, EventArgs e)//!
        {
            if (cbbBackStyle.SelectedIndex == 0 && pbBackPreview.BackgroundImage != null)
                pbBackPreview.BackgroundImage = null;
            if (cbbBackStyle.SelectedIndex != 0 && pbBackPreview.BackgroundImage == null)
                pbBackPreview.BackgroundImage = image;
            switch (cbbBackStyle.SelectedIndex)
            {
                case 1:
                    pbBackPreview.BackgroundImageLayout = ImageLayout.None;
                    break;
                case 2:
                    pbBackPreview.BackgroundImageLayout = ImageLayout.Tile;
                    break;
                case 3:
                    pbBackPreview.BackgroundImageLayout = ImageLayout.Stretch;
                    break;
                case 4:
                    pbBackPreview.BackgroundImageLayout = ImageLayout.Zoom;
                    break;
                case 5:
                    pbBackPreview.BackgroundImageLayout = ImageLayout.Zoom;
                    break;
            }
        }

        private void btnGetImage_Click(object sender, EventArgs e)//Ok
        {
            if (tbBackgImagePath.Text == "")
                dlgOpen.InitialDirectory = Directory.GetCurrentDirectory();
            else
                dlgOpen.InitialDirectory = Path.GetDirectoryName(tbBackgImagePath.Text);
            dlgOpen.FileName = Path.GetFileName(tbBackgImagePath.Text);
            if (dlgOpen.ShowDialog() == DialogResult.OK)
                try
                {
                    image = new Bitmap(dlgOpen.FileName);
                    tbBackgImagePath.Text = dlgOpen.FileName;
                    pbBackPreview.BackgroundImage = image;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        options.LangCur.mErrorsOccurred + "\r\n" + ex.Message + "\r\n" + dlgOpen.FileName,
                        options.LangCur.dImageLoading);
                }
        }
        #endregion
    }
}
