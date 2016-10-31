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
        List<xMap> Maps = new List<xMap>();
        xMap Map = null;
        int msX, msY;

        public MainForm()//!
        {
            InitializeComponent();
            Options.mainForm = this;
            Options.rbObject = rbObject;
            Options.rbLink   = rbLink;
            Options.rbBox    = rbBox;
            Options.ToolTip  = toolTip;

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
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            Map = new xMap();
            Map.Tab = tcMaps.TabPages[0];
            Map.Tab.Tag = Map;
            Maps.Add(Map);
            MainForm_ResizeEnd(null, null);
            //
            libraryForm.StartInit();
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
                {
                    (Tab.Tag as xMap)?.DoAutoSize();
                    (Tab.Tag as xMap)?.ReDraw();
                }
                CheckScrollers();
                DrawMap();
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)//Ok
        {
            new AboutForm().ShowDialog();
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

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)//!!!
        {
            //...
            Options.Save();
        }
        #endregion

        #region Tools Pull/Push
        private void PullMaps_Over(object sender, EventArgs e)//Ok
        {
            PullControl(pnlMaps, TOOLS_HIDE_DELAY * 2);
        }
        
        private void PullVScroll_Over(object sender, EventArgs e)//Ok
        {
            PullControl(vScrollBar, TOOLS_HIDE_DELAY);
        }

        private void PullHScroll_Over(object sender, EventArgs e)//Ok
        {
            PullControl(hScrollBar, TOOLS_HIDE_DELAY);
        }

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
            Map.ReDraw();
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
            Maps.Add(Map);
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
            // Case new
            Map = tcMaps.SelectedTab.Tag as xMap;
            if (Map == null)
                return;
            CheckScrollers();
            DrawMap();
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
                Map.ReDraw();
                CheckScrollers();
                DrawMap();
                Map.Changed = true;
            }
        }

        private void tsmiMapSave_Click(object sender, EventArgs e)//Ok
        {
            Map.SaveToFile(Map.FileName);
            Map.Changed = false;
        }

        private void tsmiMapLoad_Click(object sender, EventArgs e)//Ok
        {
            LoadMap(Options.LangCur.dMapLoad, "");
        }

        private void tsmiMapReload_Click(object sender, EventArgs e)//Ok
        {
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
                    Map.SaveToFile(Map.FileName);
            }
            Map.LoadFromFile(fileName);
            CheckScrollers();
            DrawMap();
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
            Maps.Remove(Map);
            tcMaps.TabPages.Remove(Map.Tab);
        }
        #endregion

        #region Map pad
        private void MainForm_ResizeEnd(object sender, EventArgs e)//
        {
            Options.WindowW = ClientSize.Width  - 2; // -2 - PictureBox border
            Options.WindowH = ClientSize.Height - 2;
            if (Map == null)
                return;
            if (Map.DoAutoSize())
                Map.ReDraw();
            CheckScrollers();
            DrawMap();
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
            DrawMap();
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

        private void DrawMap()//
        {
            if (Map == null)
                return;
            // Canvas
            int w = (Options.WindowW < Map.Width ) ? Options.WindowW : Map.Width,
                h = (Options.WindowH < Map.Height) ? Options.WindowH : Map.Height;
            var image = new Bitmap(w, h);
            var gr = Graphics.FromImage(image);
            gr.DrawImage(Map.Canvas,
                new Rectangle(0, 0, w, h),
                Map.ScrollX, Map.ScrollY, w, h,
                GraphicsUnit.Pixel);
            pbMap.Image = image;
        }

        private void pbMap_MouseDown(object sender, MouseEventArgs e)//!
        {
            Map.SelectAt(e.X, e.Y);
            if (Map.Selected == null)
                pbMap.Cursor =
                    (hScrollBar.LargeChange < hScrollBar.Maximum || vScrollBar.LargeChange < vScrollBar.Maximum)
                    ? Cursors.NoMove2D
                    : Cursors.No;
            else
                pbMap.Cursor =  Cursors.SizeAll;
            // ...
            msX = e.X;
            msY = e.Y;
        }

        private void pbMap_MouseMove(object sender, MouseEventArgs e)//!!!
        {
            if (e.Button == MouseButtons.None)
            {
                pbMap.Cursor = (Map.AnythingAt(e.X + Map.ScrollX, e.Y + Map.ScrollY) == null) ? Cursors.Default : Cursors.Hand;
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
                    DrawMap();
                    msX = e.X;
                    msY = e.Y;
                }
                else
                {
                    //Map.Selected
                    // ...
                }
            }
        }

        private void pbMap_MouseUp(object sender, MouseEventArgs e)//!!!
        {
            //
            pbMap.Cursor = (Map.AnythingAt(e.X + Map.ScrollX, e.Y + Map.ScrollY) == null) ? Cursors.Default : Cursors.Hand;
        }

        private void pbMap_MouseDoubleClick(object sender, MouseEventArgs e)//!!!
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

        private void pbMap_MouseClick(object sender, MouseEventArgs e)//!!!
        {
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
                DrawMap();
            }
        }
        #endregion
    }
}
