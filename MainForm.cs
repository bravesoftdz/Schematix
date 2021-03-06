﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Schematix
{
    struct xFrame
    {
        public bool Visible, Active;
        public int X, Y, W, H;
        public Cursor Cursor;
    }

    public partial class MainForm : Form
    {
        const int FRAME_PADDING = 3;
        const int TOOLS_HIDE_DELAY = 500; // mseconds
        LibraryForm libraryForm = new LibraryForm();
        xMap Map = null;
        int msXLast, msXnLast,
            msYLast, msYnLast;
        xFrame Selection, MoverA, MoverB;
        Pen FramePen = new Pen(Color.Black);

        public MainForm()//
        {
            MoverA.W =
            MoverA.H = FRAME_PADDING * 2 + 1;
            MoverA.Cursor =
            Selection.Cursor = Cursors.SizeAll;
            MoverB = MoverA;
            InitializeComponent();
            Options.mainForm = this;

            // Loads
            String eStr = "";
            Options.Init();
            Options.Load();

            // Check folders
            if (Options.LangPath != "")
                if (!Directory.Exists(Options.LangPath))
                    eStr += "\r\n\"" + Options.LangPath + '"';
            if (eStr == "")
            {
                // Load languages
                eStr = Options.LoadLanguages(Options.LangPath);
                Options.SelectLanguage(Options.LangName);
                if (eStr != "")
                {
                    MessageBox.Show(
                        Options.LangCur.mErrorsOccurred + "\r\n" + eStr,
                        Options.LangCur.dLanguagesLoading);
                    eStr = "";
                }
            }
            if (Options.RootMaps != "")
                if (!Directory.Exists(Options.RootMaps))
                    eStr += "\r\n\"" + Options.RootMaps + '"';
            if (Options.RootObjects != "")
                if (!Directory.Exists(Options.RootObjects))
                    eStr += "\r\n\"" + Options.RootObjects + '"';
            if (Options.RootLinks != "")
                if (!Directory.Exists(Options.RootLinks))
                    eStr += "\r\n\"" + Options.RootLinks + '"';
            if (Options.RootBoxes != "")
                if (!Directory.Exists(Options.RootBoxes))
                    eStr += "\r\n\"" + Options.RootBoxes + '"';
            if (eStr != "")
                MessageBox.Show(
                    Options.LangCur.mNoFolders + eStr, 
                    Options.LangCur.dOptionsLoading);

            libraryForm.SetText();
            SetText();
        }

        #region Main
        private void SetText()//Ok
        {
            toolTip.RemoveAll();
            //# Maps panel
            toolTip.SetToolTip(tabPage1, Options.LangCur.hMFTabNew);
            toolTip.SetToolTip(btnCloseMap,   Options.LangCur.hMFTabClose);
            toolTip.SetToolTip(btnOptions,    Options.LangCur.hMFOptions);
            toolTip.SetToolTip(btnLibrary,    Options.LangCur.hMFLibrary);
            //# Map
            toolTip.SetToolTip(pnlMapOptions, Options.LangCur.hMFMapOptions);
            toolTip.SetToolTip(pnlMapFrame,   Options.LangCur.hMFMapOptions);
            // Map context menu
            tsmiMapOptions.Text = Options.LangCur.lMFMapCMOptions;
            tsmiMapSave.Text    = Options.LangCur.lMFMapCMSave;
            tsmiMapLoad.Text    = Options.LangCur.lMFMapCMLoad;
            tsmiMapReload.Text  = Options.LangCur.lMFMapCMReload;
            tsmiMapClose.Text   = Options.LangCur.lMFMapCMClose;
            // Element context menu
            tsmiElementOptions.Text       = Options.LangCur.lMFElementCMOptions;
            tsmiElementDelete.Text        = Options.LangCur.lMFElementCMDelete;
            tsmiElementOpenReference.Text = Options.LangCur.lMFElementCMOpenReference;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (Options.MainFormXY)
            {
                Left = Options.MainFormX;
                Top  = Options.MainFormY;
            }
            if (Options.MainFormWH)
            {
                Width  = Options.MainFormW;
                Height = Options.MainFormH;
            }
            MainForm_Resize(null, null);
            libraryForm.StartInit();
            //
            if (0 < Options.OnStart && 0 < Options.MapFiles.Count)
            {
                if (Options.OnStart == 1)
                    if (MessageBox.Show(Options.LangCur.hMFOpenLastMaps, Options.LangCur.hMFLoading, MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                        return;
                foreach (var MapFile in Options.MapFiles)
                    if (File.Exists(MapFile))
                    {
                        if (Map == null)
                            Map = AddMap(Path.GetFileNameWithoutExtension(MapFile));
                        if (Map.LoadFromFile(MapFile))
                        {
                            Map.UpdateTabName();
                            Map = null;
                        }
                    }
                //...
                Options.MapFiles.Clear();
            }
            if (tcMaps.TabCount < 2)
                AddMap("New");
            tcMaps_Selected(null, null);
            // Ping timer
            timerPing.Tick    += Options.timerPing_Tick;
            timerPing.Interval = Options.PingPeriod;
            timerPing.Enabled  = Options.PingOnn;
        }

        private void MainForm_Move(object sender, EventArgs e) => MoveLibraryForm();

        public void MoveLibraryForm()
        {
            if (libraryForm.Visible && libraryForm.bind)
                libraryForm.Location = new Point(Location.X + Width, Location.Y);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)//
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

        private void btnLibrary_Click(object sender, EventArgs e)//
        {
            if (libraryForm.Visible)
                libraryForm.Hide();
            else
            {
                libraryForm.Show();
                MoveLibraryForm();
            }
        }

        private void btnOptions_Click(object sender, EventArgs e)//
        {
            var form = new OptionsForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                SetText();
                libraryForm.SetText();
                foreach (TabPage Tab in tcMaps.TabPages)
                    if (Tab.Tag != null)
                    {
                        (Tab.Tag as xMap).DoAutoSize();
                        (Tab.Tag as xMap).Draw();
                    }
                timerPing.Interval = Options.PingPeriod;
                timerPing.Enabled  = Options.PingOnn;
                CheckScrollers();
                Invalidate();
            }
        }

        private void btnAbout_Click(object sender, EventArgs e) => new AboutForm().ShowDialog();//Ok

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
        #endregion

        #region Tools Pull/Push
        private void PullMaps_Over(object sender, EventArgs e)    => PullControl(pnlMaps,    TOOLS_HIDE_DELAY);//Ok
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
        private void tpAddNew_Enter(object sender, EventArgs e) => AddMap("");

        private xMap AddMap(String MapName)//
        {
            var page = tcMaps.TabPages[tcMaps.TabCount - 1];
            // Get appendix number
            if (MapName == "")
            {
                tcMaps.Tag = ((tcMaps.Tag != null) ? (int)tcMaps.Tag : 1) + 1;
                MapName = "New " + (int)tcMaps.Tag;
            }
            // Make as map tab
            var map = new xMap();
            Options.Maps.Add(map);
            page.Enter -= tpAddNew_Enter;
            page.Text = MapName;
            page.Tag = map;
            map.Tab = page;
            map.DoAutoSize();
            map.Draw();
            // Add new tab
            page = new TabPage("+");
            tcMaps.TabPages.Add(page);
            page.Enter += tpAddNew_Enter;
            return map;
        }

        private xMap InsertMap(int TabIdx, String MapName)//
        {
            if (tcMaps.TabCount <= TabIdx)
                TabIdx = tcMaps.TabCount - 1;
            // Add new tab
            var map = new xMap();
            Options.Maps.Add(map);
            var page = new TabPage(MapName);
            page.Tag = map;
            map.Tab = page;
            tcMaps.TabPages.Insert(TabIdx, page);
            return map;
        }

        private void tcMaps_SelectedIndexChanged(object sender, EventArgs e) => tcMaps_Selected(null, null);
        private void tcMaps_Selected(object sender, TabControlEventArgs e)
        {
            // Case new not "add new tab"
            xMap SelectedMap = (tcMaps.SelectedTab.Tag as xMap);
            if (SelectedMap == null || Map == SelectedMap)
                return;

            // Remove last map info
            if (Map != null)
            {
                foreach (ListViewItem lvItem in libraryForm.lvUsedObjects.Items)
                    (lvItem.Tag as xPrototype).lvItemUsed = null;
                foreach (ListViewItem lvItem in libraryForm.lvUsedLinks.Items)
                    (lvItem.Tag as xPrototype).lvItemUsed = null;
                foreach (ListViewItem lvItem in libraryForm.lvUsedBoxes.Items)
                    (lvItem.Tag as xPrototype).lvItemUsed = null;
                libraryForm.lvUsedObjects.Items.Clear();
                libraryForm.lvUsedLinks.Items.Clear();
                libraryForm.lvUsedBoxes.Items.Clear();
                Map.lv_PObjects =
                Map.lv_PLinks   =
                Map.lv_PBoxes   = null;
            }

            // Switching
            Map = SelectedMap;
            // Draw
            if (Map.DoAutoSize())
                Map.Draw();
            CheckScrollers();
            CheckFrames(true);
            Invalidate();
            // Add current map info
            libraryForm.lvUsedObjects.BeginUpdate();
            libraryForm.lvUsedLinks.BeginUpdate();
            libraryForm.lvUsedBoxes.BeginUpdate();
            foreach (var PObject in Map.PObjects)
            {
                PObject.lvItemUsed = libraryForm.lvUsedObjects.Items.Add("");
                PObject.lvItemUsed.SubItems.Add("");
                PObject.lvItemUsed.SubItems.Add("");
                PObject.lvItemUsed.Tag = PObject;
                Share.Library_UpdateNodeName(PObject);
            }
            foreach (var PLink in Map.PLinks)
            {
                PLink.lvItemUsed = libraryForm.lvUsedLinks.Items.Add("");
                PLink.lvItemUsed.SubItems.Add("");
                PLink.lvItemUsed.SubItems.Add("");
                PLink.lvItemUsed.Tag = PLink;
                Share.Library_UpdateNodeName(PLink);
            }
            foreach (var PBox in Map.PBoxes)
            {
                PBox.lvItemUsed = libraryForm.lvUsedBoxes.Items.Add("");
                PBox.lvItemUsed.SubItems.Add("");
                PBox.lvItemUsed.SubItems.Add("");
                PBox.lvItemUsed.Tag = PBox;
                Share.Library_UpdateNodeName(PBox);
            }
            libraryForm.lvUsedObjects.EndUpdate();
            libraryForm.lvUsedLinks.EndUpdate();
            libraryForm.lvUsedBoxes.EndUpdate();
            Map.lv_PObjects = libraryForm.lvUsedObjects;
            Map.lv_PLinks   = libraryForm.lvUsedLinks;
            Map.lv_PBoxes   = libraryForm.lvUsedBoxes;
        }
        
        private void CloseMap(xMap Map)//
        {
            int idx = tcMaps.SelectedIndex;
            if (idx + 2 < tcMaps.TabCount)
                idx++;
            else
                idx += (0 < idx) ? -1 : 1;
            tcMaps.SelectTab(idx);
            // Remove
            Map.Clear();
            Options.Maps.Remove(Map);
            tcMaps.TabPages.Remove(Map.Tab);
        }
        #endregion

        #region Map context menu
        private void cmsMap_Opening(object sender, CancelEventArgs e) => tsmiMapReload.Visible = (Map.FileName != "");

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

        private void tsmiMapSaveAs_Click(object sender, EventArgs e)//Ok
        {
            if (!Map.SaveToFile(""))
                return;
            Map.Changed = false;
            Map.UpdateTabName();
        }

        private void tsmiMapLoad_Click(object sender, EventArgs e) => LoadMap(Options.LangCur.dMapLoad, "");//Ok

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
            Invalidate();
        }

        private void tsmiMapClose_Click(object sender, EventArgs e)//Ok
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
        #endregion

        #region Element context menu
        private void cmsElement_Opening(object sender, CancelEventArgs e) => tsmiElementOpenReference.Visible = (Map.Selected.Reference != "");

        private void tsmiElementOptions_Click(object sender, EventArgs e)
        {
            if (Map.Selected == null)
                return;
            var r = DialogResult.Cancel;
            if (Map.Selected.IsObject)
                r = new ObjectOptionsForm(Map.Selected as xObject).ShowDialog();
            else if (Map.Selected.IsLink)
                r = new LinkOptionsForm(Map.Selected as xLink).ShowDialog();
            else if (Map.Selected.IsBox)
                r = new BoxOptionsForm(Map.Selected as xBox).ShowDialog();
            if (r != DialogResult.OK)
                return;
            Map.Draw();
            Map.Changed = true;
            Map.UpdateTabName();
            Invalidate();
        }

        private void tsmiElementDelete_Click(object sender, EventArgs e)
        {
            if (Map.Selected == null)
                return;
            (Map.Selected as xExemplar).Delete();
            Map.Draw();
            Map.Changed = true;
            Map.UpdateTabName();
            Invalidate();
            Selection.Visible =
            MoverA.Visible =
            MoverB.Visible = false;
        }

        private void tsmiElementOpenReference_Click(object sender, EventArgs e)
        {
            String path = Map.Selected.Reference;
            if (path != "")
                if (File.Exists(path) || Directory.Exists(path))
                    if (Path.GetExtension(path) == Options.RECORD_EXT_MAP)
                    {
                        foreach (TabPage Tab in tcMaps.TabPages)
                            if (Tab.Tag != null)
                                if ((Tab.Tag as xMap).FileName == path)
                                {
                                    tcMaps.SelectTab((Tab.Tag as xMap).Tab);
                                    return;
                                }
                        var map = InsertMap(tcMaps.TabPages.IndexOf(Map.Tab) + 1, Path.GetFileNameWithoutExtension(path));
                        map.LoadFromFile(path);
                        map.UpdateTabName();
                        // Select new tab
                        tcMaps.SelectTab(map.Tab);
                    }
                    else
                        Process.Start(path);
        }
        #endregion

        #region Map pad drawings
        internal void RenewMaps()
        {
            foreach (var Map in Options.Maps)
            {
                Map.CheckAll();
                Map.Draw();
            }
            CheckFrames();
            Invalidate();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            Options.PortW = ClientSize.Width;
            Options.PortH = ClientSize.Height;
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
            hScrollBar.LargeChange = Options.PortW;
            vScrollBar.LargeChange = Options.PortH;
            if (Map.ScrollX < 0)
                Map.ScrollX = 0;
            if (Map.ScrollY < 0)
                Map.ScrollY = 0;
            if (Map.Width   < Map.ScrollX + Options.PortW)
                Map.ScrollX = (Map.Width  < Options.PortW) ? 0 : Map.Width  - Options.PortW;
            if (Map.Height  < Map.ScrollY + Options.PortH)
                Map.ScrollY = (Map.Height < Options.PortH) ? 0 : Map.Height - Options.PortH;
            hScrollBar.Maximum = Map.Width;
            vScrollBar.Maximum = Map.Height;
            hScrollBar.Value = Map.ScrollX;
            vScrollBar.Value = Map.ScrollY;
            // Scroll bar icons
            pbPullHScroll.Visible = (Options.PortW < Map.Width );
            pbPullVScroll.Visible = (Options.PortH < Map.Height);
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
            pnlMapFrame.Width  = (int)Math.Round(cw * (double)(Map.ScrollX + Options.PortW) / Map.Width  - pnlMapFrame.Left);
            pnlMapFrame.Height = (int)Math.Round(ch * (double)(Map.ScrollY + Options.PortH) / Map.Height - pnlMapFrame.Top );
            if (cw < pnlMapFrame.Left + pnlMapFrame.Width )
                pnlMapFrame.Width  = cw - pnlMapFrame.Left;
            if (ch < pnlMapFrame.Top  + pnlMapFrame.Height)
                pnlMapFrame.Height = ch - pnlMapFrame.Top;
            CheckFrames();
            xBackground Back = Map.Back.StoreOwn ? Map.Back : Options.Back;
            if (Back.Style != BackgroundStyles.Color && Back.Float)
                Map.Draw(Map.ScrollX, Map.ScrollY, Options.PortW, Options.PortH);
        }
        
        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            if (Map == null)
                return;
            // Canvas
            e.Graphics.DrawImage(Map.Canvas,
                e.ClipRectangle,
                e.ClipRectangle.Left + Map.ScrollX,
                e.ClipRectangle.Top  + Map.ScrollY,
                e.ClipRectangle.Width,
                e.ClipRectangle.Height,
                GraphicsUnit.Pixel);
            // Frames
            if (Selection.Visible)
            {
                e.Graphics.DrawRectangle(FramePen,
                    Selection.X,     Selection.Y,
                    Selection.W - 1, Selection.H - 1);
                if (MoverA.Visible)
                    e.Graphics.DrawRectangle(FramePen,
                        MoverA.X,     MoverA.Y,
                        MoverA.W - 1, MoverA.H - 1);
                if (MoverB.Visible)
                    e.Graphics.DrawRectangle(FramePen,
                        MoverB.X,     MoverB.Y,
                        MoverB.W - 1, MoverB.H - 1);
            }
        }
        #endregion

        #region Map pad action
        private void MainForm_MouseDown(object sender, MouseEventArgs e)//
        {
            // Save action start point
            msXnLast = msXLast = e.X;
            msYnLast = msYLast = e.Y;
            Map.SnapXY(ref msXnLast, ref msYnLast);

            // Prevent senseless action
            if (rbObject.Checked && rbObject.Tag == null)
                rbDefault.Checked = true;
            else if (rbLink.Checked && rbLink.Tag == null)
                rbDefault.Checked = true;
            else if (rbBox.Checked && rbBox.Tag == null)
                rbDefault.Checked = true;

            #region Default tool
            if (rbDefault.Checked)
            {
                ContextMenuStrip = cmsElement;
                if (MoverB.Visible &&
                    MoverB.X <= msXLast && msXLast < MoverB.X + MoverB.W &&
                    MoverB.Y <= msYLast && msYLast < MoverB.Y + MoverB.H)
                    MoverB.Active = true;
                else if (MoverA.Visible &&
                    MoverA.X <= msXLast && msXLast < MoverA.X + MoverA.W &&
                    MoverA.Y <= msYLast && msYLast < MoverA.Y + MoverA.H)
                    MoverA.Active = true;
                else if (Selection.Visible &&
                    Selection.X <= msXLast && msXLast < Selection.X + Selection.W &&
                    Selection.Y <= msYLast && msYLast < Selection.Y + Selection.H)
                {
                    Selection.Active = true;
                    Cursor = Selection.Cursor;
                }
                else
                {
                    if (Map.SelectAt(msXLast + Map.ScrollX, msYLast + Map.ScrollY) == null)
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
                        ContextMenuStrip = cmsMap;
                    }
                    else
                        Selection.Active = true;
                    CheckFrames(true);
                }
            }
            #endregion

            #region Element tool
            else
            {
                MoverA.Visible =
                MoverB.Visible = false;
                ContextMenuStrip = cmsElement;
                //
                if (rbObject.Checked)
                {
                    var Object = new xObject(Map);
                    Object.Prototype = Map.AddPObject(rbObject.Tag as xPrototype);
                    Object.PrototypeID = Object.Prototype.ID;
                    Object.PrototypeRevision = Object.Prototype.Revision;
                    Map.Objects.Add(Object);
                    // Set data
                    Object.X = msXLast + Map.ScrollX;
                    Object.Y = msYLast + Map.ScrollY;
                    Map.SnapXY(ref Object.X, ref Object.Y);
                    // 
                    Map.Selected = Object;
                    Selection.Active = true;
                }
                else if (rbLink.Checked)
                {
                    var Link = new xLink(Map);
                    Link.Prototype = Map.AddPLink(rbLink.Tag as xPrototype);
                    Link.PrototypeID = Link.Prototype.ID;
                    Link.PrototypeRevision = Link.Prototype.Revision;
                    Map.Links.Add(Link);
                    // Set data
                    Link.XA = Link.XB = msXLast + Map.ScrollX;
                    Link.YA = Link.YB = msYLast + Map.ScrollY;
                    Map.SnapXY(ref Link.XA, ref Link.YA);
                    Map.SnapXY(ref Link.XB, ref Link.YB);
                    // Try to bind to object
                    Map.Selected = Map.ObjectAt(msXLast + Map.ScrollX, msYLast + Map.ScrollY);
                    if (Map.Selected != null)
                        {
                            Link.ObjectA = Map.Selected as xObject;
                            Link.ObjectAID = Link.ObjectA.ID;
                            Link.DotA = Link.ObjectA.GetNearestDot(msXLast + Map.ScrollX, msYLast + Map.ScrollY);
                            Link.DotAID = Link.DotA.ID;
                            Link.XA = Link.ObjectA.Left + Link.DotA.X;
                            Link.YA = Link.ObjectA.Top  + Link.DotA.Y;
                    }
                    // 
                    Map.Selected = Link;
                    MoverB.Cursor = Cursors.SizeAll;
                    MoverB.Active = true;
                }
                else
                {
                    var Box = new xBox(Map);
                    Box.Prototype = Map.AddPBox(rbBox.Tag as xPrototype);
                    Box.PrototypeID = Box.Prototype.ID;
                    Box.PrototypeRevision = Box.Prototype.Revision;
                    Map.Boxes.Add(Box);
                    // Set data
                    Box.Left = msXLast + Map.ScrollX;
                    Box.Top  = msYLast + Map.ScrollY;
                    Box.Width  = 1;
                    Box.Height = 1;
                    Box.Text = (Box.Prototype as xPBox).Text;
                    Map.SnapXY(ref Box.Left, ref Box.Top);
                    // 
                    Map.Selected = Box;
                    MoverB.Cursor = Cursors.SizeNWSE;
                    MoverB.Active = true;
                }
                // Update
                Map.Selected.Check();
                Map.Draw(Map.Selected.Left - 8, Map.Selected.Top - 8, Map.Selected.Width + 16, Map.Selected.Height + 16);
                CheckFrames(true);
            }
            #endregion

            Invalidate();
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)//
        {
            #region Cursor selection
            if (e.Button == MouseButtons.None)
            {
                if (MoverB.Visible &&
                     MoverB.X <= e.X && e.X < MoverB.X + MoverB.W &&
                     MoverB.Y <= e.Y && e.Y < MoverB.Y + MoverB.H)
                    Cursor = MoverB.Cursor;
                else if (MoverA.Visible &&
                    MoverA.X <= e.X && e.X < MoverA.X + MoverA.W &&
                    MoverA.Y <= e.Y && e.Y < MoverA.Y + MoverA.H)
                    Cursor = MoverA.Cursor;
                else if (Selection.Visible &&
                    Selection.X <= e.X && e.X < Selection.X + Selection.W &&
                    Selection.Y <= e.Y && e.Y < Selection.Y + Selection.H)
                    Cursor = Cursors.Hand;
                else
                    Cursor = (Map.AnythingAt(Map.ScrollX + e.X, Map.ScrollY + e.Y) == null) ? Cursors.Default : Cursors.Hand;
            }
            #endregion

            #region Moving/Sizing
            else
            {
                bool redraw = true;
                int msXn = e.X,
                    msYn = e.Y;
                Map.SnapXY(ref msXn, ref msYn);
                int dX = msXn - msXnLast,
                    dY = msYn - msYnLast;
                
                #region Move B point of line / Resize box
                if (MoverB.Active)
                {
                    // Resize
                    if (Map.Selected.IsLink)
                    {
                        if (dX != 0 || dY != 0)
                        {
                            var Link = (Map.Selected as xLink);
                            Link.XB += dX;
                            Link.YB += dY;
                            TryToBindToObject(Map,
                                Map.ScrollX + e.X, Map.ScrollY + e.Y,
                                ref Link.ObjectB, ref Link.ObjectBID,
                                ref Link.DotB, ref Link.DotBID,
                                ref Link.XB, ref Link.YB);
                        }
                        else
                            redraw = false;
                    }
                    // Move
                    else if (Map.Selected.IsBox)
                    {
                        if (dX != 0 || dY != 0)
                        {
                            xBox Box = (Map.Selected as xBox);
                            Box.Width  += dX;
                            Box.Height += dY;
                            if (Box.Width < 1)
                                Box.Width = 1;
                            if (Box.Height < 1)
                                Box.Height = 1;
                        }
                        else
                            redraw = false;
                    }
                }
                #endregion

                #region Move A point of line
                else if (MoverA.Active)
                {
                    if (dX != 0 || dY != 0)
                    {
                        var Link = (Map.Selected as xLink);
                        Link.XA += dX;
                        Link.YA += dY;
                        TryToBindToObject(Map,
                            Map.ScrollX + e.X, Map.ScrollY + e.Y,
                            ref Link.ObjectA, ref Link.ObjectAID,
                            ref Link.DotA, ref Link.DotAID,
                            ref Link.XA, ref Link.YA);
                    }
                    else
                        redraw = false;
                }
                #endregion

                #region Move element
                else if (Selection.Active)
                {
                    if (dX != 0 || dY != 0)
                    {
                        if (Map.Selected.IsObject)
                        {
                            (Map.Selected as xObject).X += dX;
                            (Map.Selected as xObject).Y += dY;
                        }
                        else if (Map.Selected.IsBox)
                        {
                            (Map.Selected as xBox).Left += dX;
                            (Map.Selected as xBox).Top  += dY;
                        }
                        else
                        {
                            //...
                        }
                    }
                    else
                        redraw = false;
                }
                #endregion

                #region Map scrolling
                else
                {
                    Map.ScrollX += msXLast - e.X;
                    Map.ScrollY += msYLast - e.Y;
                    CheckScrollers();
                    redraw = false;
                }
                #endregion

                if (redraw)
                {
                    Map.Changed = true;
                    Map.UpdateTabName();
                    Map.Selected.Check();
                    if (Map.Selected.IsObject)
                        Map.CheckLinksToObject(Map.Selected.ID);
                    Map.Draw(Map.ScrollX, Map.ScrollY, Options.PortW, Options.PortH);
                }

                CheckFrames();
                Invalidate();

                msXLast = e.X;
                msYLast = e.Y;
                msXnLast = msXn;
                msYnLast = msYn;
            }
            #endregion
        }

        private void CheckFrames(bool full = false)
        {
            if (Map.Selected == null || full)
            {
                Selection.Visible =
                MoverA.Visible =
                MoverB.Visible = false;
                if (Map.Selected == null)
                    return;
            }
            Selection.X = Map.Selected.Left - Map.ScrollX - FRAME_PADDING;
            Selection.Y = Map.Selected.Top  - Map.ScrollY - FRAME_PADDING;
            Selection.W = Map.Selected.Width  + FRAME_PADDING * 2;
            Selection.H = Map.Selected.Height + FRAME_PADDING * 2;
            if (full)
            {
                Cursor = Selection.Cursor;
                Selection.Visible = true;
            }
            if (Map.Selected.IsLink)
            {
                MoverA.X = (Map.Selected as xLink).XA - Map.ScrollX - FRAME_PADDING;
                MoverA.Y = (Map.Selected as xLink).YA - Map.ScrollY - FRAME_PADDING;
                MoverB.X = (Map.Selected as xLink).XB - Map.ScrollX - FRAME_PADDING;
                MoverB.Y = (Map.Selected as xLink).YB - Map.ScrollY - FRAME_PADDING;
                if (full)
                {
                    MoverA.Visible =
                    MoverB.Visible = true;
                    MoverB.Cursor = Cursors.SizeAll;
                }
            }
            else if (Map.Selected.IsBox)
            {
                MoverB.X = (Map.Selected as xBox).Right  - Map.ScrollX - FRAME_PADDING - 1;
                MoverB.Y = (Map.Selected as xBox).Bottom - Map.ScrollY - FRAME_PADDING - 1;
                if (full)
                {
                    MoverB.Visible = true;
                    MoverB.Cursor = Cursors.SizeNWSE;
                }
            }
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)//Ok
        {
            if (MoverB.Active)
                MoverB.Active = false;
            else if (MoverA.Active)
                MoverA.Active = false;
            else if (Selection.Active)
            {
                Selection.Active = false;
                Cursor = Cursors.Hand;
            }
            else
                Cursor = Cursors.Default;
        }

        private void MainForm_MouseDoubleClick(object sender, MouseEventArgs e)//Ok
        {
            if (Map.Selected == null)
                tsmiMapOptions_Click(null, null);
            else
                tsmiElementOpenReference_Click(null, null);
        }

        private void TryToBindToObject(xMap Map, int X, int Y, ref xObject Object, ref UInt64 ObjectID, ref xDot Dot, ref UInt64 DotID, ref int paramX, ref int paramY)
        {
            ObjectID = 0;
            Object = Map.ObjectAt(X, Y) as xObject;
            if (Object == null)
                return;
            // Bind
            ObjectID = Object.ID;
            Dot = Object.GetNearestDot(X, Y);
            DotID = Dot.ID;
            paramX = Object.Left + Dot.X;
            paramY = Object.Top  + Dot.Y;
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
                Map.ScrollX = (int)Math.Round((double)(Map.Width  - Options.PortW) * x / (pnlMapOptions.ClientSize.Width  - 2));
                Map.ScrollY = (int)Math.Round((double)(Map.Height - Options.PortH) * y / (pnlMapOptions.ClientSize.Height - 2));
                CheckScrollers();
                Invalidate();
            }
        }
        #endregion
    }
}
