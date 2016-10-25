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

        public MainForm()//!
        {
            InitializeComponent();
            options.mainForm = this;
            //options.Init();

            //Loads
            String eStr = "";
            options.Load();
            // Check folders
            if (Directory.Exists(options.LangPath))
            {
                eStr = options.LoadLanguages(options.LangPath);
                options.SelectLanguage(options.LangName);
                if (eStr != "")
                    MessageBox.Show(
                        options.LangCur.mErrorsOccurred + "\r\n" + eStr,
                        options.LangCur.dLanguagesLoading);
            }
            else
                eStr += "\r\n" + options.LangPath;
            if (!Directory.Exists(options.RootMaps))
                eStr += "\r\n" + options.RootMaps;
            if (!Directory.Exists(options.RootObjects))
                eStr += "\r\n" + options.RootObjects;
            if (!Directory.Exists(options.RootLinks))
                eStr += "\r\n" + options.RootLinks;
            if (!Directory.Exists(options.RootBoxes))
                eStr += "\r\n" + options.RootBoxes;
            if (eStr != "")
                MessageBox.Show(
                    options.LangCur.mNoFolders + eStr, 
                    options.LangCur.dOptionsLoading);
            SetText();
            //
            Map = new xMap();
            Map.Tab = tcMaps.TabPages[0];
            Map.Tab.Tag = Map;
            Maps.Add(Map);
            MainForm_ResizeEnd(null, null);
        }

        #region Main
        private void SetText()//Ok
        {
            toolTip.RemoveAll();
            //# Maps panel
            toolTip.SetToolTip(tabPageAddNew, options.LangCur.hMFTabNew);
            toolTip.SetToolTip(btnCloseMap,   options.LangCur.hMFTabClose);
            toolTip.SetToolTip(btnOptions,    options.LangCur.hMFOptions);
            toolTip.SetToolTip(btnLibrary,    options.LangCur.hMFLibrary);
            //# Map
            toolTip.SetToolTip(pnlMapOptions, options.LangCur.hMFMapOptions);
            // Context menu
            tsmiMapOptions.Text = options.LangCur.lMFMapCMOptions;
            tsmiMapSave.Text    = options.LangCur.lMFMapCMSave;
            tsmiMapLoad.Text    = options.LangCur.lMFMapCMLoad;
            tsmiMapReload.Text  = options.LangCur.lMFMapCMReload;
            tsmiMapClose.Text   = options.LangCur.lMFMapCMClose;
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
            options.Save();
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
            int idx = tcMaps.SelectedIndex;
            Map = AddMap(idx, "New " + i);
            Map.DoAutoSize();
            // Select new tab
            tcMaps.SelectedTab = Map.Tab;
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

        private void tcMaps_Selected(object sender, TabControlEventArgs e)//!
        {
            Map = tcMaps.SelectedTab.Tag as xMap;
            if (Map == null)
                return;
            CheckScrollers();
            DrawMap();
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
                Map.DoAutoSize();
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
            LoadMap(options.LangCur.dMapLoading, "");
        }

        private void tsmiMapReload_Click(object sender, EventArgs e)//Ok
        {
            LoadMap(options.LangCur.dMapLoading, Map.FileName);
        }

        private void LoadMap(String actionTitle, String fileName)//
        {
            if (Map.Changed)
            {
                var res = MessageBox.Show(options.LangCur.mMapHasChanges, actionTitle, MessageBoxButtons.YesNoCancel);
                if (res == DialogResult.Cancel)
                    return;
                if (res == DialogResult.OK)
                    Map.SaveToFile(Map.FileName);
            }
            Map.Clear();
            Map.LoadFromFile(fileName);
            Map.DoAutoSize();
            Map.ReDraw();
            CheckScrollers();
            DrawMap();
            Map.Changed = false;
        }

        private void tsmiMapClose_Click(object sender, EventArgs e)//
        {
            if (Map.Changed)
            {
                var res = MessageBox.Show(options.LangCur.mMapHasChanges, options.LangCur.dMapClosing, MessageBoxButtons.YesNoCancel);
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
        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            options.WindowW = ClientSize.Width  - 2;
            options.WindowH = ClientSize.Height - 2;
            if (Map == null)
                return;
            Map.DoAutoSize();
            Map.ReDraw();
            CheckScrollers();
            DrawMap();
        }

        private void CheckScrollers()
        {
            hScrollBar.LargeChange = options.WindowW;
            vScrollBar.LargeChange = options.WindowH;
            if (Map == null)
                return;
            if (Map.Width  < Map.ScrollX + options.WindowW)
                Map.ScrollX = (Map.Width  < options.WindowW) ? 0 : Map.Width  - options.WindowW;
            if (Map.Height < Map.ScrollY + options.WindowH)
                Map.ScrollY = (Map.Height < options.WindowH) ? 0 : Map.Height - options.WindowH;
            hScrollBar.Maximum = Map.Width;
            vScrollBar.Maximum = Map.Height;
            hScrollBar.Value = Map.ScrollX;
            vScrollBar.Value = Map.ScrollY;
        }

        private void ScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            Map.ScrollX = hScrollBar.Value;
            Map.ScrollY = vScrollBar.Value;
            DrawMap();
        }

        private void DrawMap()
        {
            if (Map == null)
                return;
            // Canvas
            int w = (options.WindowW < Map.Width ) ? options.WindowW : Map.Width,
                h = (options.WindowH < Map.Height) ? options.WindowH : Map.Height;
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
        }

        private void pbMap_MouseUp(object sender, MouseEventArgs e)//!!!
        {
            //
            pbMap.Cursor = Cursors.Default;
        }

        private void pbMap_MouseMove(object sender, MouseEventArgs e)//!!!
        {
            // ...
        }

        private void pbMap_MouseDoubleClick(object sender, MouseEventArgs e)//!!!
        {
            if (Map.Selected == null)
                tsmiMapOptions_Click(null, null);
            else
            {
                MessageBox.Show(Map.Selected.GetType().ToString(), Map.Selected.ToString());
            }
            //
        }

        private void pbMap_MouseClick(object sender, MouseEventArgs e)//!!!
        {
            //
        }
        #endregion
    }
}
