using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Schematix
{
    public partial class MainForm : Form
    {
        const int TOOLS_HIDE_DELAY = 500; // mseconds
        LibraryForm libraryForm = new LibraryForm();
        xMap Map = null;
        int msX, msY;

        public MainForm()//!
        {
            InitializeComponent();
            Options.mainForm = this;
            Options.rbDefault = rbDefault;
            Options.rbObject  = rbObject;
            Options.rbLink    = rbLink;
            Options.rbBox     = rbBox;
            Options.ToolTip   = toolTip;

            //Loads
            String eStr = "";
            Options.Load();
            // Check folders
            if (Directory.Exists(Options.LangPath))
            {
                eStr = Options.LoadLanguages(Options.LangPath);
                Options.SelectLanguage(Options.LangName);
                if (eStr != "")
                    MessageBox.Show(
                        Options.LangCur.mErrorsOccurred + "\r\n" + eStr,
                        Options.LangCur.dLanguagesLoading);
            }
            else
                eStr += "\r\n" + Options.LangPath;
            if (!Directory.Exists(Options.RootMaps))
                eStr += "\r\n" + Options.RootMaps;
            if (!Directory.Exists(Options.RootObjects))
                eStr += "\r\n" + Options.RootObjects;
            if (!Directory.Exists(Options.RootLinks))
                eStr += "\r\n" + Options.RootLinks;
            if (!Directory.Exists(Options.RootBoxes))
                eStr += "\r\n" + Options.RootBoxes;
            if (eStr != "")
                MessageBox.Show(
                    Options.LangCur.mNoFolders + eStr, 
                    Options.LangCur.dOptionsLoading);
            SetText();
            // Ping timer
            timerPing.Tick += Options.timerPing_Tick;
            timerPing.Interval = Options.PingPeriod;
            timerPing.Enabled = Options.PingOnn;
        }

        #region Main
        private void SetText()//Ok
        {
            toolTip.RemoveAll();
            //# Maps panel
            toolTip.SetToolTip(tabPageAddNew, Options.LangCur.hMFTabNew);
            toolTip.SetToolTip(btnCloseMap,   Options.LangCur.hMFTabClose);
            toolTip.SetToolTip(btnOptions,    Options.LangCur.hMFOptions);
            toolTip.SetToolTip(btnLibrary,    Options.LangCur.hMFLibrary);
            //# Map
            toolTip.SetToolTip(pnlMapOptions, Options.LangCur.hMFMapOptions);
            // Context menu
            tsmiMapOptions.Text = Options.LangCur.lMFMapCMOptions;
            tsmiMapSave.Text    = Options.LangCur.lMFMapCMSave;
            tsmiMapLoad.Text    = Options.LangCur.lMFMapCMLoad;
            tsmiMapReload.Text  = Options.LangCur.lMFMapCMReload;
            tsmiMapClose.Text   = Options.LangCur.lMFMapCMClose;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            MainForm_Resize(null, null);
            Map = new xMap();
            Map.Tab = tcMaps.TabPages[0];
            Map.Tab.Tag = Map;
            Options.Maps.Add(Map);
            Map.DoAutoSize();
            CheckScrollers();
            Map.Draw();
            //
            libraryForm.StartInit();
            //
            if (0 < Options.OnStart && 0 < Options.MapFiles.Count)
            {
                if (Options.OnStart == 1)
                    if (MessageBox.Show(Options.LangCur.hMFOpenLastMaps, Options.LangCur.hMFLoading, MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                        return;
                foreach (var MapFile in Options.MapFiles)
                    if (File.Exists(MapFile))
                        if (Map.LoadFromFile(MapFile))
                            tcMaps.SelectedTab = tabPageAddNew;
                //...
                Options.MapFiles.Clear();
            }
        }

        private void MainForm_Move(object sender, EventArgs e)
        {
            MoveLibraryForm();
        }

        public void MoveLibraryForm()
        {
            if (libraryForm.Visible && libraryForm.bind)
                libraryForm.Location = new Point(Location.X + Width, Location.Y);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)//!
        {
            bool changes = false;
            if (0 < Options.OnClose)
                foreach (var Map in Options.Maps)
                    if (Map.Changed)
                        changes = true;
            if (Options.OnClose == 1 && changes)
            {
                var res = MessageBox.Show(Options.LangCur.hMFSaveOpenedMaps, Options.LangCur.hMFClosing, MessageBoxButtons.YesNoCancel);
                if (res == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
                changes = (res != DialogResult.No);
            }
            if (changes)
                foreach (var Map in Options.Maps)
                    if (Map.Changed)
                        Map.SaveToFile(Map.FileName);
            Options.Save();
        }
        #endregion

        #region Tools
        private void rbTool_Click(object sender, EventArgs e)//
        {
            (sender as RadioButton).Click -= btnLibrary_Click;
            if ((sender as RadioButton).Checked)
                (sender as RadioButton).Click += btnLibrary_Click;
        }

        private void rbTool_CheckedChanged(object sender, EventArgs e)//
        {
            // Switch tab to current tool
            if ((sender as RadioButton).Checked)
            {
                libraryForm.SelectTab(
                    sender == rbObject ? 0 :
                    sender == rbLink ? 1 : 2);
                Focus();
            }
            // Remove event on deactivating
            else
                (sender as RadioButton).Click -= btnLibrary_Click;
        }

        private void btnLibrary_Click(object sender, EventArgs e)//!!!
        {
            if (libraryForm.Visible)
                libraryForm.Hide();
            else
            {
                libraryForm.Show();
                libraryForm.bind = true;
                MainForm_Move(null, null);
            }
        }

        private void btnOptions_Click(object sender, EventArgs e)//!
        {
            var form = new OptionsForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                SetText();
                if (libraryForm.Visible)
                    libraryForm.SetText();
                foreach (TabPage Tab in tcMaps.TabPages)
                    if (Tab.Tag != null)
                    {
                        (Tab.Tag as xMap).DoAutoSize();
                        (Tab.Tag as xMap).Draw();
                    }
                CheckScrollers();
                Invalidate();
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)//Ok
        {
            new AboutForm().ShowDialog();
        }
        #endregion

        #region Tools Pull/Push
        private void PullMaps_Over(object sender, EventArgs e)    => PullControl(pnlMaps,    TOOLS_HIDE_DELAY * 2);//Ok
        private void PullTools_Over(object sender, EventArgs e)   => PullControl(pnlTools,   TOOLS_HIDE_DELAY);//Ok
        private void PullVScroll_Over(object sender, EventArgs e) => PullControl(vScrollBar, TOOLS_HIDE_DELAY);//Ok
        private void PullHScroll_Over(object sender, EventArgs e) => PullControl(hScrollBar, TOOLS_HIDE_DELAY);//Ok

        private void PullControl(Control control, int time)//Ok
        {
            if (timerTools.Tag != control)
            {
                // Hide last control
                if (timerTools.Tag != null)
                    (timerTools.Tag as Control).Visible = false;
                if (control != null)
                {
                    // Show new control
                    control.Visible = true;
                    // Remember new control
                    timerTools.Tag = control;
                    control.Tag = time;
                    // Start timer
                    timerTools.Enabled = true;
                }
            }
        }

        private void timerTools_Tick(object sender, EventArgs e)//Ok
        {
            var control = timerTools.Tag as Control;
            // Has control
            if (control != null)
            {
                // Mouse out of control
                var p = control.PointToClient(MousePosition);
                if (p.X < 0 || control.Width  < p.X || p.Y < 0 || control.Height < p.Y)
                {
                    // Dec time
                    if (control.Tag != null)
                    {
                        control.Tag = (int)control.Tag - timerTools.Interval;
                        // Time is out
                        if ((int)control.Tag < 1)
                            control.Tag = null;
                    }
                    // Hide control
                    if (control.Tag == null)
                    {
                        timerTools.Tag = null;
                        control.Visible = false;
                    }
                }
            }
            // Turn off timer
            if (timerTools.Tag == null)
                timerTools.Enabled = false;
        }
        #endregion

        #region Map tabs
        private void tabPageAddNew_Enter(object sender, EventArgs e)//
        {
            // Get appendix number
            int i = (tabPageAddNew.Tag != null) ? (int)tabPageAddNew.Tag : 2;
            tabPageAddNew.Tag = i + 1;
            // Add new tab
            Map = AddMap(tcMaps.SelectedIndex, "New " + i);
            Map.DoAutoSize();
            Map.Draw();
            // Select new tab
            tcMaps.SelectTab(Map.Tab);
        }

        private xMap AddMap(int TabIdx, String MapName)
        {
            if (tcMaps.TabCount <= TabIdx)
                TabIdx = tcMaps.TabCount - 1;
            // Add new tab
            var page = new TabPage(MapName);
            var Map = new xMap();
            page.Tag = Map;
            Map.Tab = page;
            tcMaps.TabPages.Insert(TabIdx, page);
            Options.Maps.Add(Map);
            return Map;
        }

        private void tcMaps_Selected(object sender, TabControlEventArgs e)//
        {
            // Remove last map info
            if (Map != null)
            {
                foreach (ListViewItem lvItem in Options.lvUsedObjects.Items)
                    (lvItem.Tag as xPrototype).lvItemUsed = null;
                foreach (ListViewItem lvItem in Options.lvUsedLinks.Items)
                    (lvItem.Tag as xPrototype).lvItemUsed = null;
                foreach (ListViewItem lvItem in Options.lvUsedBoxes.Items)
                    (lvItem.Tag as xPrototype).lvItemUsed = null;
                Options.lvUsedObjects.Items.Clear();
                Options.lvUsedLinks.Items.Clear();
                Options.lvUsedBoxes.Items.Clear();
                Map.lv_PObjects = null;
                Map.lv_PLinks   = null;
                Map.lv_PBoxes   = null;
            }
            // Case new not "add new tab"
            Map = (tcMaps.SelectedTab == tabPageAddNew)
                ? null
                : (tcMaps.SelectedTab.Tag as xMap);
            if (Map == null)
                return;
            // Draw
            if (Map.DoAutoSize())
                Map.Draw();
            CheckScrollers();
            Invalidate();
            // Add current map info
            Options.lvUsedObjects.BeginUpdate();
            Options.lvUsedLinks.BeginUpdate();
            Options.lvUsedBoxes.BeginUpdate();
            foreach (var PObject in Map.PObjects)
            {
                PObject.lvItemUsed = Options.lvUsedObjects.Items.Add("");
                Share.UpdateNodeName(PObject);
            }
            foreach (var PLink in Map.PLinks)
            {
                PLink.lvItemUsed = Options.lvUsedLinks.Items.Add("");
                Share.UpdateNodeName(PLink);
            }
            foreach (var PBox in Map.PBoxes)
            {
                PBox.lvItemUsed = Options.lvUsedBoxes.Items.Add("");
                Share.UpdateNodeName(PBox);
            }
            Options.lvUsedObjects.EndUpdate();
            Options.lvUsedLinks.EndUpdate();
            Options.lvUsedBoxes.EndUpdate();
            Map.lv_PObjects = Options.lvUsedObjects;
            Map.lv_PLinks   = Options.lvUsedLinks;
            Map.lv_PBoxes   = Options.lvUsedBoxes;
        }
        #endregion

        #region Context menu
        private void cmsMap_Opening(object sender, CancelEventArgs e)//
        {
            tsmiMapReload.Visible = ((tcMaps.SelectedTab.Tag as xMap).FileName != "");
        }

        private void tsmiMapOptions_Click(object sender, EventArgs e)//
        {
            var mapOptionsForm = new MapOptionsForm(Map);
            if (mapOptionsForm.ShowDialog() == DialogResult.OK)
            {
                if (Map.AutoSize)
                    Map.DoAutoSize();
                else
                    Map.SetSize(Map.Width, Map.Height);
                CheckScrollers();
                Map.Draw();
                Map.Changed = true;
                Map.UpdateTabName();
                Invalidate();
            }
        }

        private void tsmiMapSave_Click(object sender, EventArgs e)//Ok
        {
            if (!Map.SaveToFile(Map.FileName))
                return;
            Map.Changed = false;
            Map.UpdateTabName();
        }

        private void tsmiMapLoad_Click(object sender, EventArgs e)//Ok
        {
            LoadMap(Options.LangCur.dMapLoad, "");
        }

        private void tsmiMapReload_Click(object sender, EventArgs e)//Ok
        {
            Map.Changed = false;
            LoadMap(Options.LangCur.dMapReload, Map.FileName);
        }

        private void LoadMap(String actionTitle, String fileName)//
        {
            if (Map.Changed)
            {
                var res = MessageBox.Show(Options.LangCur.mMapHasChanges, actionTitle, MessageBoxButtons.YesNoCancel);
                if (res == DialogResult.Cancel)
                    return;
                if (res == DialogResult.OK)
                    if (!Map.SaveToFile(Map.FileName))
                        return;
            }
            Map.LoadFromFile(fileName);
            Map.UpdateTabName();
            CheckScrollers();
            Map.Draw();
            Invalidate();
        }

        private void tsmiMapClose_Click(object sender, EventArgs e)//
        {
            if (Map.Changed)
            {
                var res = MessageBox.Show(Options.LangCur.mMapHasChanges, Options.LangCur.dMapClosing, MessageBoxButtons.YesNoCancel);
                if (res == DialogResult.Cancel)
                    return;
                if (res == DialogResult.OK)
                    Map.SaveToFile(Map.FileName);
            }
            CloseMap(Map);
        }

        private void CloseMap(xMap Map)//
        {
            int idx = tcMaps.SelectedIndex;
            if (tcMaps.TabPages.IndexOf(Map.Tab) <= idx)
                if (0 < idx)
                    idx--;
            tcMaps.SelectedIndex = idx;
            Map.Clear();
            Options.Maps.Remove(Map);
            tcMaps.TabPages.Remove(Map.Tab);
        }
        #endregion

        #region Map pad drawings
        private void MainForm_Resize(object sender, EventArgs e)
        {
            Options.WindowW = ClientSize.Width;
            Options.WindowH = ClientSize.Height;
            if (Map != null)
                CheckScrollers();
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)//
        {
            if (Map.DoAutoSize())
            {
                CheckScrollers();
                Map.Draw();
            }
            Invalidate();
        }

        private void CheckScrollers()//Ok
        {
            hScrollBar.LargeChange = Options.WindowW;
            vScrollBar.LargeChange = Options.WindowH;
            if (Map.ScrollX < 0)
                Map.ScrollX = 0;
            if (Map.ScrollY < 0)
                Map.ScrollY = 0;
            if (Map.Width   < Map.ScrollX + Options.WindowW)
                Map.ScrollX = (Map.Width  < Options.WindowW) ? 0 : Map.Width  - Options.WindowW;
            if (Map.Height  < Map.ScrollY + Options.WindowH)
                Map.ScrollY = (Map.Height < Options.WindowH) ? 0 : Map.Height - Options.WindowH;
            hScrollBar.Maximum = Map.Width;
            vScrollBar.Maximum = Map.Height;
            hScrollBar.Value = Map.ScrollX;
            vScrollBar.Value = Map.ScrollY;
            // Scroll bar icons
            pbPullHScroll.Visible = (Options.WindowW < Map.Width );
            pbPullVScroll.Visible = (Options.WindowH < Map.Height);
            CheckScrollSquar();
        }

        private void ScrollBar_Scroll(object sender, ScrollEventArgs e)//Ok
        {
            Map.ScrollX = hScrollBar.Value;
            Map.ScrollY = vScrollBar.Value;
            CheckScrollSquar();
            Invalidate();
        }

        private void CheckScrollSquar()//Ok
        {
            int cw = pnlMapOptions.ClientSize.Width,
                ch = pnlMapOptions.ClientSize.Height;
            // Top-left
            pnlMapFrame.Left = cw * Map.ScrollX / Map.Width;
            pnlMapFrame.Top  = ch * Map.ScrollY / Map.Height;
            // Width-height based on bottom-right corner
            pnlMapFrame.Width  = (int)Math.Round(cw * (double)(Map.ScrollX + Options.WindowW) / Map.Width  - pnlMapFrame.Left);
            pnlMapFrame.Height = (int)Math.Round(ch * (double)(Map.ScrollY + Options.WindowH) / Map.Height - pnlMapFrame.Top );
            if (cw < pnlMapFrame.Left + pnlMapFrame.Width )
                pnlMapFrame.Width  = cw - pnlMapFrame.Left;
            if (ch < pnlMapFrame.Top  + pnlMapFrame.Height)
                pnlMapFrame.Height = ch - pnlMapFrame.Top;
        }
        
        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            if (Map == null)
                return;
            // Canvas
            int w = (Options.WindowW < Map.Width ) ? Options.WindowW : Map.Width,
                h = (Options.WindowH < Map.Height) ? Options.WindowH : Map.Height;
            e.Graphics.DrawImage(Map.Canvas,
                e.ClipRectangle,
                e.ClipRectangle.Left + Map.ScrollX,
                e.ClipRectangle.Top  + Map.ScrollY,
                e.ClipRectangle.Width,
                e.ClipRectangle.Height,
                GraphicsUnit.Pixel);
        }
        #endregion

        #region Map pad action
        private void MainForm_MouseDown(object sender, MouseEventArgs e)//!
        {
            Map.SelectAt(e.X, e.Y);
            if (Map.Selected == null)
            {
                if (hScrollBar.LargeChange < hScrollBar.Maximum)
                    if (vScrollBar.LargeChange < vScrollBar.Maximum)
                        Cursor = Cursors.NoMove2D;
                    else
                        Cursor = Cursors.NoMoveHoriz;
                else
                    if (vScrollBar.LargeChange < vScrollBar.Maximum)
                        Cursor = Cursors.NoMoveVert;
                    else
                        Cursor = Cursors.No;
            }
            else
                Cursor =  Cursors.SizeAll;
            // ...
            msX = e.X;
            msY = e.Y;
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)//!!!
        {
            if (e.Button == MouseButtons.None)
            {
                Cursor = (Map.AnythingAt(e.X + Map.ScrollX, e.Y + Map.ScrollY) == null) ? Cursors.Default : Cursors.Hand;
                // ...
            }
            else
            {
                // ...
                if (Map.AnythingAt(e.X + Map.ScrollX, e.Y + Map.ScrollY) == null)
                {
                    Map.ScrollX += msX - e.X;
                    Map.ScrollY += msY - e.Y;
                    CheckScrollers();
                    msX = e.X;
                    msY = e.Y;
                    Invalidate();
                }
                else
                {
                    //Map.Selected
                    // ...
                }
            }
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)//!!!
        {
            //
            Cursor = (Map.AnythingAt(e.X + Map.ScrollX, e.Y + Map.ScrollY) == null) ? Cursors.Default : Cursors.Hand;
        }
        
        private void MainForm_MouseClick(object sender, MouseEventArgs e)//!!!
        {
            //
        }

        private void MainForm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Map.Selected == null)
                tsmiMapOptions_Click(null, null);
            else
            {
                if (Map.Selected.IsObject)
                    new ObjectOptionsForm(Map.Selected as xObject).ShowDialog();
                else if (Map.Selected.IsLink)
                    new LinkOptionsForm(Map.Selected as xLink).ShowDialog();
                else if (Map.Selected.IsBox)
                    new BoxOptionsForm(Map.Selected as xBox).ShowDialog();
            }
            //
        }

        private void pnlMapOptions_MouseAction(object sender, MouseEventArgs e)//Ok
        {
            if (e.Button == MouseButtons.Right)
                tsmiMapOptions_Click(null, null);
            if (e.Button == MouseButtons.Left)
            {
                int x = e.X,
                    y = e.Y;
                if (sender == pnlMapFrame)
                {
                    x += pnlMapFrame.Left;
                    y += pnlMapFrame.Top;
                }
                Map.ScrollX = (Map.Width  - Options.WindowW) * x / (pnlMapOptions.ClientSize.Width  - 1);
                Map.ScrollY = (Map.Height - Options.WindowH) * y / (pnlMapOptions.ClientSize.Height - 1);
                CheckScrollers();
                Invalidate();
            }
        }
        #endregion
    }
}
