using System;
using System.ComponentModel;
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
        const int TOOLS_HIDE_DELAY = 500; // mseconds
        LibraryForm libraryForm = new LibraryForm();
        xMap Map = null;
        int msXLast, msXnLast,
            msYLast, msYnLast;
        xFrame Selection, MoverA, MoverB;

        public MainForm()//
        {
            Selection.Cursor = Cursors.SizeAll;
            MoverA.W = 6;
            MoverA.H = 6;
            MoverA.Cursor = Cursors.SizeAll;
            MoverB = MoverA;
            InitializeComponent();
            Options.mainForm = this;
            Options.rbDefault = rbDefault;
            Options.rbObject  = rbObject;
            Options.rbLink    = rbLink;
            Options.rbBox     = rbBox;
            Options.ToolTip   = toolTip;

            //Loads
            String eStr = "";
            Options.Init();
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
            Map.lv_PObjects = Options.lvUsedObjects;
            Map.lv_PLinks   = Options.lvUsedLinks;
            Map.lv_PBoxes   = Options.lvUsedBoxes;
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
                Map.lv_PObjects =
                Map.lv_PLinks   =
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
                PObject.lvItemUsed.Tag = PObject;
                Share.Library_UpdateNodeName(PObject);
            }
            foreach (var PLink in Map.PLinks)
            {
                PLink.lvItemUsed = Options.lvUsedLinks.Items.Add("");
                PLink.lvItemUsed.Tag = PLink;
                Share.Library_UpdateNodeName(PLink);
            }
            foreach (var PBox in Map.PBoxes)
            {
                PBox.lvItemUsed = Options.lvUsedBoxes.Items.Add("");
                PBox.lvItemUsed.Tag = PBox;
                Share.Library_UpdateNodeName(PBox);
            }
            Options.lvUsedObjects.EndUpdate();
            Options.lvUsedLinks.EndUpdate();
            Options.lvUsedBoxes.EndUpdate();
            Map.lv_PObjects = Options.lvUsedObjects;
            Map.lv_PLinks   = Options.lvUsedLinks;
            Map.lv_PBoxes   = Options.lvUsedBoxes;
            // Hide frames
            Selection.Visible =
            MoverA.Visible    =
            MoverB.Visible    = false;
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
        internal void RenewMaps()
        {
            foreach (var Map in Options.Maps)
                Map.Draw();
            Invalidate();
        }

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
            // Frames
            var pen = new Pen(Color.Black);
            if (Selection.Visible)
                e.Graphics.DrawRectangle(pen,
                    Selection.X - 3, Selection.Y - 3,
                    Selection.W + 6, Selection.H + 6);
            if (MoverA.Visible)
                e.Graphics.DrawRectangle(pen,
                    MoverA.X - 3, MoverA.Y - 3,
                    MoverA.W, MoverA.H);
            if (MoverB.Visible)
                e.Graphics.DrawRectangle(pen,
                    MoverB.X - 3, MoverB.Y - 3,
                    MoverB.W, MoverB.H);
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
                     MoverB.X - 3 <= e.X && e.X <= MoverB.X + MoverB.W - 3 &&
                     MoverB.Y - 3 <= e.Y && e.Y <= MoverB.Y + MoverB.H - 3)
                    MoverB.Active = true;
                else if (MoverA.Visible &&
                    MoverA.X - 3 <= e.X && e.X <= MoverA.X + MoverA.W - 3 &&
                    MoverA.Y - 3 <= e.Y && e.Y <= MoverA.Y + MoverA.H - 3)
                    MoverA.Active = true;
                else if (Selection.Visible &&
                    Selection.X <= e.X && e.X <= Selection.X + Selection.W &&
                    Selection.Y <= e.Y && e.Y <= Selection.Y + Selection.H)
                {
                    Selection.Active = true;
                    Cursor = Selection.Cursor;
                }
                else
                {
                    Selection.Visible =
                    MoverA.Visible =
                    MoverB.Visible = false;
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
                    {
                        Cursor = Selection.Cursor;
                        Selection.X = Map.Selected.Left - Map.ScrollX;
                        Selection.Y = Map.Selected.Top  - Map.ScrollY;
                        Selection.W = Map.Selected.Width;
                        Selection.H = Map.Selected.Height;
                        Selection.Active =
                        Selection.Visible = true;
                        if (Map.Selected.IsLink)
                        {
                            MoverA.X = (Map.Selected as xLink).XA - Map.ScrollX;
                            MoverA.Y = (Map.Selected as xLink).YA - Map.ScrollY;
                            MoverA.Visible = true;
                            MoverB.X = (Map.Selected as xLink).XB - Map.ScrollX;
                            MoverB.Y = (Map.Selected as xLink).YB - Map.ScrollY;
                            MoverB.Visible = true;
                            MoverB.Cursor = Cursors.SizeAll;
                        }
                        else if (Map.Selected.IsBox)
                        {
                            MoverB.X = (Map.Selected as xBox).Right  - Map.ScrollX;
                            MoverB.Y = (Map.Selected as xBox).Bottom - Map.ScrollY;
                            MoverB.Visible = true;
                            MoverB.Cursor = Cursors.SizeNWSE;
                        }
                    }
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
                    Object.Prototype = Map.AddPObject(rbObject.Tag as xPObject);
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
                    Cursor = Selection.Cursor;
                }
                else if (rbLink.Checked)
                {
                    var Link = new xLink(Map);
                    Link.Prototype = Map.AddPLink(rbLink.Tag as xPLink);
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
                    MoverA.X = Link.XA - Map.ScrollX;
                    MoverA.Y = Link.YA - Map.ScrollY;
                    MoverA.Visible = true;
                    MoverB.X = Link.XB - Map.ScrollX;
                    MoverB.Y = Link.YB - Map.ScrollY;
                    MoverB.Active =
                    MoverB.Visible = true;
                    MoverB.Cursor = Cursors.SizeAll;
                    Cursor = MoverB.Cursor;
                }
                else
                {
                    var Box = new xBox(Map);
                    Box.Prototype = Map.AddPBox(rbBox.Tag as xPBox);
                    Box.PrototypeID = Box.Prototype.ID;
                    Box.PrototypeRevision = Box.Prototype.Revision;
                    Map.Boxes.Add(Box);
                    // Set data
                    Box.Left = msXLast + Map.ScrollX;
                    Box.Top  = msYLast + Map.ScrollY;
                    Box.Width  = 1;
                    Box.Height = 1;
                    Box.Text = Box.Prototype.Text;
                    Map.SnapXY(ref Box.Left, ref Box.Top);
                    // 
                    Map.Selected = Box;
                    MoverB.X = Box.Right  - Map.ScrollX;
                    MoverB.Y = Box.Bottom - Map.ScrollY;
                    MoverB.Active =
                    MoverB.Visible = true;
                    MoverB.Cursor = Cursors.SizeNWSE;
                    Cursor = MoverB.Cursor;
                }
                // Update
                Map.Selected.Check();
                Map.Draw(Map.Selected.Left - 8, Map.Selected.Top - 8, Map.Selected.Width + 16, Map.Selected.Height + 16);
                Selection.X = Map.Selected.Left - Map.ScrollX;
                Selection.Y = Map.Selected.Top  - Map.ScrollY;
                Selection.W = Map.Selected.Width;
                Selection.H = Map.Selected.Height;
                Selection.Visible = true;
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
                     MoverB.X - 3 <= e.X && e.X <= MoverB.X + MoverB.W - 3 &&
                     MoverB.Y - 3 <= e.Y && e.Y <= MoverB.Y + MoverB.H - 3)
                    Cursor = MoverB.Cursor;
                else if (MoverA.Visible &&
                    MoverA.X - 3 <= e.X && e.X <= MoverA.X + MoverA.W - 3 &&
                    MoverA.Y - 3 <= e.Y && e.Y <= MoverA.Y + MoverA.H - 3)
                    Cursor = MoverA.Cursor;
                else if (Selection.Visible &&
                    Selection.X <= e.X && e.X <= Selection.X + Selection.W &&
                    Selection.Y <= e.Y && e.Y <= Selection.Y + Selection.H)
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

                // Move/Resize
                #region Move element
                if (Selection.Active)
                {
                    if (dX != 0 || dY != 0)
                    {
                        if (Map.Selected.IsObject)
                        {
                            var Object = (Map.Selected as xObject);
                            Object.X += dX;
                            Object.Y += dY;
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
                        MoverA.X = Link.XA - Map.ScrollX;
                        MoverA.Y = Link.YA - Map.ScrollY;
                    }
                    else
                        redraw = false;
                }
                #endregion

                #region Move B point of line / Resize box
                else if (MoverB.Active)
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
                            MoverB.X = Link.XB - Map.ScrollX;
                            MoverB.Y = Link.YB - Map.ScrollY;
                        }
                        else
                            redraw = false;
                    }
                    // Move
                    else if (Map.Selected.IsBox)
                    {
                        if (dX != 0 || dY != 0)
                        {
                            (Map.Selected as xBox).Width += dX;
                            (Map.Selected as xBox).Height += dY;
                            if ((Map.Selected as xBox).Width < 1)
                                (Map.Selected as xBox).Width = 1;
                            if ((Map.Selected as xBox).Height < 1)
                                (Map.Selected as xBox).Height = 1;
                        }
                        else
                            redraw = false;
                    }
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
                    Map.Draw(Map.ScrollX, Map.ScrollY, Options.WindowW, Options.WindowH);
                }

                #region Update frames
                if (Selection.Visible)
                {
                    Selection.X = Map.Selected.Left - Map.ScrollX;
                    Selection.Y = Map.Selected.Top  - Map.ScrollY;
                    Selection.W = Map.Selected.Width;
                    Selection.H = Map.Selected.Height;
                }
                if (MoverA.Visible)
                {
                    MoverA.X = (Map.Selected as xLink).XA - Map.ScrollX;
                    MoverA.Y = (Map.Selected as xLink).YA - Map.ScrollY;
                }
                if (MoverB.Visible)
                    if (Map.Selected.IsLink)
                    {
                        MoverB.X = (Map.Selected as xLink).XB - Map.ScrollX;
                        MoverB.Y = (Map.Selected as xLink).YB - Map.ScrollY;
                    }
                    else
                    {
                        MoverB.X = (Map.Selected as xBox).Right - Map.ScrollX;
                        MoverB.Y = (Map.Selected as xBox).Bottom - Map.ScrollY;
                    }
                #endregion

                Invalidate();
                msXLast = e.X;
                msYLast = e.Y;
                msXnLast = msXn;
                msYnLast = msYn;
            }
            #endregion
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)//Ok
        {
            if (Selection.Active)
            {
                Cursor = Cursors.Hand;
                Selection.Active = false;
            }
            else if (MoverA.Active)
                MoverA.Active = false;
            else if (MoverB.Active)
                MoverB.Active = false;
            else
                Cursor = Cursors.Default;
        }

        private void MainForm_MouseDoubleClick(object sender, MouseEventArgs e)//Ok
        {
            if (Map.Selected == null)
                tsmiMapOptions_Click(null, null);
            else
                tsmiElementOptions_Click(null, null);
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
                Map.ScrollX = (int)Math.Round((double)(Map.Width  - Options.WindowW) * x / (pnlMapOptions.ClientSize.Width  - 2));
                Map.ScrollY = (int)Math.Round((double)(Map.Height - Options.WindowH) * y / (pnlMapOptions.ClientSize.Height - 2));
                CheckScrollers();
                Invalidate();
            }
        }
        #endregion
    }
}
