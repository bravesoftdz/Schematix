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
        Bitmap imageOriginal = new Bitmap(1, 1);
        Bitmap imageAlpha = null;

        public OptionsForm()
        {
            InitializeComponent();

            //# Main
            // Language
            tbLanguagePath.Text = Options.LangPath;
            cbbLanguage.Items.AddRange(Options.Langs.Select(l => l.Name).ToArray());
            cbbLanguage.Text = Options.LangName;
            if (cbbLanguage.SelectedIndex < 0)
                cbbLanguage.SelectedIndex = 0;
            SetText(Options.Langs[cbbLanguage.SelectedIndex]);

            // Behaiour
            cbbOnStart.SelectedIndex = Options.OnStart;
            cbbOnClose.SelectedIndex = Options.OnClose;
            if (Options.PingPeriod < 1)
                Options.PingPeriod = 1;
            chkPingPeriod.Checked = Options.PingOnn;
            nudPingPeriod.Maximum = Options.MAX_PING_PERIOD;
            nudPingCount.Maximum  = Options.MAX_PING_COUNT;
            nudPingPeriod.Value   = Options.PingPeriod;
            nudPingCount.Value    = Options.PingCount;
            // Folders
            tbRootMaps.Text    = Options.RootMaps;
            tbRootObjects.Text = Options.RootObjects;
            tbRootLinks.Text   = Options.RootLinks;
            tbRootBoxes.Text   = Options.RootBoxes;

            //# Map
            // Grid
            chkGridStore.Checked       = Options.Grid.StoreOwn;
            cbbGridStyle.SelectedIndex = (int)Options.Grid.Style;
            btnGridColor.BackColor     = Options.Grid.Pen.Color;
            nudGridStepX.Maximum       = Options.MAX_GRID_STEP;
            nudGridStepY.Maximum       = Options.MAX_GRID_STEP;
            nudGridThick.Maximum       = Options.MAX_GRID_THICK;
            nudGridStepX.Value         = Options.Grid.StepX;
            nudGridStepY.Value         = Options.Grid.StepY;
            nudGridThick.Value         = (int)Options.Grid.Pen.Width;
            chkGridAlign.Checked       = Options.Grid.Snap;
            // Background
            chkBackStore.Checked       = Options.Back.StoreOwn;
            cbbBackStyle.SelectedIndex      = (int)Options.Back.Style;
            cbbBackImageAlign.SelectedIndex = (int)Options.Back.Align;
            btnBackColor.BackColor          = Options.Back.Color;
            tbBackgImagePath.Text           = Options.Back.Path;
            chkTransparentColor.Checked     = Options.Back.UseAlphaColor;
            btnAlphaColor.BackColor         = Options.Back.AlphaColor;
            chkBackImageFloat.Checked       = Options.Back.Float;
            chkBackImageBuildIn.Checked     = Options.Back.BuildIn;
            // Redraw sample
            GotImage(Options.Back.Image);
        }

        private void SetText(LanguageRecord lang)//
        {
            int idx;
            toolTip.RemoveAll();
            Text = lang.lOFTitle;
            //# Main
            tpMain.Text = lang.lOFTabMain;
            // Language
            gbLanguage.Text      = lang.lOFMainLanguage;
            lblLanguagePath.Text = lang.lOFMainLanguagePath;
            toolTip.SetToolTip(btnGetLanguagePath, Options.LangCur.hOFMainRootGet);
            // Behaiour
            gbRoots.Text        = lang.lOFMainRoots;
            lblRootMaps.Text    = lang.lOFMainRootMaps;
            lblRootObjects.Text = lang.lOFMainRootObjects;
            lblRootLinks.Text   = lang.lOFMainRootLinks;
            lblRootBoxes.Text   = lang.lOFMainRootBoxes;
            toolTip.SetToolTip(btnGetRootMaps,    Options.LangCur.hOFMainRootGet);
            toolTip.SetToolTip(btnGetRootObjects, Options.LangCur.hOFMainRootGet);
            toolTip.SetToolTip(btnGetRootLinks,   Options.LangCur.hOFMainRootGet);
            toolTip.SetToolTip(btnGetRootBoxes,   Options.LangCur.hOFMainRootGet);
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
            lblPingCount.Text  = lang.lOFMainPingCount;

            //# Map
            tpMap.Text = lang.lOFTabMap;
            // Grid
            gbGrid.Text       = lang.lMOGrid;
            chkGridStore.Text = lang.lMOStoreInMap;
            idx = cbbGridStyle.SelectedIndex;
            cbbGridStyle.Items.Clear();
            cbbGridStyle.Items.Add(lang.lMOGridStyle0None);
            cbbGridStyle.Items.Add(lang.lMOGridStyle1Dots);
            cbbGridStyle.Items.Add(lang.lMOGridStyle2Corners);
            cbbGridStyle.Items.Add(lang.lMOGridStyle3Crosses);
            cbbGridStyle.Items.Add(lang.lMOGridStyle4Grid);
            cbbGridStyle.SelectedIndex = idx;
            toolTip.SetToolTip(btnGridColor, Options.LangCur.hEEColorPick);
            lblGridThick.Text = lang.lEELineThick;
            chkGridAlign.Text = lang.lMOGridAlign;
            // Background
            gbBack.Text       = lang.lMOBack;
            chkBackStore.Text = lang.lMOStoreInMap;
            idx = cbbBackStyle.SelectedIndex;
            cbbBackStyle.Items.Clear();
            cbbBackStyle.Items.Add(lang.lMOBackStyle0Color);
            cbbBackStyle.Items.Add(lang.lMOBackStyle1ImageAlign);
            cbbBackStyle.Items.Add(lang.lMOBackStyle2ImageTile);
            cbbBackStyle.Items.Add(lang.lMOBackStyle3ImageStrech);
            cbbBackStyle.Items.Add(lang.lMOBackStyle4ImageZInner);
            cbbBackStyle.Items.Add(lang.lMOBackStyle5ImageZOutter);
            cbbBackStyle.SelectedIndex = idx;
            toolTip.SetToolTip(btnBackColor,        Options.LangCur.hEEColorPick);
            toolTip.SetToolTip(btnAlphaColor, Options.LangCur.hEEColorPick);
            toolTip.SetToolTip(btnGetBackImage, Options.LangCur.hEEImageLoad);
            chkTransparentColor.Text = lang.lMOBackTransparentColor;
            lblBackgImagePath.Text   = lang.lEEImagePath;
            chkBackImageFloat.Text   = lang.lEEImageFloat;
            chkBackImageBuildIn.Text = lang.lEEImageBuildIn;
            lblBackImageAlign.Text   = lang.lEEAlign;
            lblBackImageBPP.Text     = lang.lEEImageBPP;
            idx = cbbBackImageAlign.SelectedIndex;
            cbbBackImageAlign.Items.Clear();
            cbbBackImageAlign.Items.Add(lang.lEEAlign0TL);
            cbbBackImageAlign.Items.Add(lang.lEEAlign1TC);
            cbbBackImageAlign.Items.Add(lang.lEEAlign2TR);
            cbbBackImageAlign.Items.Add(lang.lEEAlign3ML);
            cbbBackImageAlign.Items.Add(lang.lEEAlign4MC);
            cbbBackImageAlign.Items.Add(lang.lEEAlign5MR);
            cbbBackImageAlign.Items.Add(lang.lEEAlign6BL);
            cbbBackImageAlign.Items.Add(lang.lEEAlign7BC);
            cbbBackImageAlign.Items.Add(lang.lEEAlign8BR);
            cbbBackImageAlign.SelectedIndex = idx;
        }

        private void Path_TextChanged(object sender, EventArgs e)//Ok
        {
            (sender as TextBox).BackColor = (
                Directory.Exists((sender as TextBox).Text) 
                ? Color.White 
                : Color.MistyRose);
        }

        #region Get folder
        private void btnGetLanguagePath_Click(object sender, EventArgs e) => Share.GetFolder(tbLanguagePath);
        private void btnGetRootMaps_Click    (object sender, EventArgs e) => Share.GetFolder(tbRootMaps);
        private void btnGetRootObjects_Click (object sender, EventArgs e) => Share.GetFolder(tbRootObjects);
        private void btnGetRootLinks_Click   (object sender, EventArgs e) => Share.GetFolder(tbRootLinks);
        private void btnGetRootBoxes_Click   (object sender, EventArgs e) => Share.GetFolder(tbRootBoxes);
        #endregion

        #region Map tab
        private void PickColor_Click(object sender, EventArgs e)//Ok
        {
            if (dlgColor.ShowDialog() == DialogResult.OK)
                (sender as Button).BackColor = dlgColor.Color;
        }
        
        private void btnGetImage_Click(object sender, EventArgs e) => Share.GetImage(tbBackgImagePath, GotImage);//Ok

        private void GotImage(Bitmap img)//Ok
        {
            imageOriginal = img;
            RedrawSample(null, null);
        }

        private void RedrawSample(object sender, EventArgs e)//Ok
        {
            if (imageAlpha != null)
                imageAlpha.Dispose();
            imageAlpha = new Bitmap(imageOriginal);
            if (chkTransparentColor.Checked)
                imageAlpha.MakeTransparent(btnAlphaColor.BackColor);
            // Grid
            xGrid Grid;
            if (chkGridStore.Checked)
            {
                Grid = new xGrid();
                Grid.Style = (GridStyles)cbbGridStyle.SelectedIndex;
                Grid.Pen.Color = btnGridColor.BackColor;
                Grid.Pen.Width = (float)nudGridThick.Value;
                Grid.StepX = (Int16)nudGridStepX.Value;
                Grid.StepY = (Int16)nudGridStepY.Value;
            }
            else
                Grid = Options.Grid;
            // Back
            xBackground Back;
            if (chkBackStore.Checked)
            {
                Back = new xBackground();
                Back.Style = (BackgroundStyles)cbbBackStyle.SelectedIndex;
                Back.Color = btnBackColor.BackColor;
                Back.Align = (AlignTypes)cbbBackImageAlign.SelectedIndex;
                Back.Image = imageAlpha;
            }
            else
                Back = Options.Back;
            // Draw
            var bmap = new Bitmap(pbBackPreview.Width, pbBackPreview.Height);
            Share.DrawBack(Graphics.FromImage(bmap), Back, Grid, 0, 0, bmap.Width, bmap.Height, 0, 0, bmap.Width, bmap.Height);
            pbBackPreview.Image = bmap;
        }
        #endregion

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
                    Options.LangCur.mNoFolders + eStr + "\r\n" + Options.LangCur.mCreateThem, 
                    Options.LangCur.dOptionsSaving,
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
                        Options.LangCur.mErrorsOccurred + "\r\n" + eStr,
                        Options.LangCur.dOptionsSaving);
                    return;
                }
            }
            #endregion

            //# Main
            // Language
            Options.LangPath = tbLanguagePath.Text;
            Options.LangCur  = Options.Langs[cbbLanguage.SelectedIndex];
            Options.LangName = Options.LangCur.Name;
            // Behaiour
            Options.OnStart    = cbbOnStart.SelectedIndex;
            Options.OnClose    = cbbOnClose.SelectedIndex;
            Options.PingOnn    = chkPingPeriod.Checked;
            Options.PingPeriod = (int)nudPingPeriod.Value;
            Options.PingCount  = (int)nudPingCount.Value;
            // Folders
            Options.RootMaps    = tbRootMaps.Text;
            Options.RootObjects = tbRootObjects.Text;
            Options.RootLinks   = tbRootLinks.Text;
            Options.RootBoxes   = tbRootBoxes.Text;

            //# Map
            // Grid
            Options.Grid.StoreOwn  = chkGridStore.Checked;
            Options.Grid.Style     = (GridStyles)cbbGridStyle.SelectedIndex;
            Options.Grid.Pen.Color = btnGridColor.BackColor;
            Options.Grid.StepX     = (Int16)nudGridStepX.Value;
            Options.Grid.StepY     = (Int16)nudGridStepY.Value;
            Options.Grid.Pen.Width = (float)nudGridThick.Value;
            Options.Grid.Snap      = chkGridAlign.Checked;
            // Background
            Options.Back.StoreOwn      = chkBackStore.Checked;
            Options.Back.Style         = (BackgroundStyles)cbbBackStyle.SelectedIndex;
            Options.Back.Color         = btnBackColor.BackColor;
            Options.Back.Path          = tbBackgImagePath.Text;
            Options.Back.UseAlphaColor = chkTransparentColor.Checked;
            Options.Back.AlphaColor    = btnAlphaColor.BackColor;
            Options.Back.BuildIn       = chkBackImageBuildIn.Checked;
            Options.Back.Image         = imageAlpha;

            // Out
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
