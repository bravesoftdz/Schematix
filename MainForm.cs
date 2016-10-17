using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schematix
{
    public partial class MainForm : Form
    {
        const int TOOLS_HIDE_DELAY = 500; // mseconds
        LibraryForm LibraryForm = new LibraryForm();

        #region Main
        public MainForm()//!!!
        {
            String eStr = "";
            InitializeComponent();
            //options.Init();

            //Loads
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
        }

        private void SetText()//Ok
        {
            toolTip.RemoveAll();
            //# Maps panel
            toolTip.SetToolTip(tabPageAddNew, options.LangCur.hMFNewMap);
            toolTip.SetToolTip(btnCloseMap,   options.LangCur.hMFCloseMap);
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
            if (LibraryForm.Visible)
                LibraryForm.Hide();
            else
                LibraryForm.Show();
        }

        private void btnOptions_Click(object sender, EventArgs e)//!!!
        {
            var form = new OptionsForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                SetText();
                //...
                //.Draw();
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)//Ok
        {
            new AboutForm().ShowDialog();
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
            //...
            tcMaps.TabPages.Insert(idx, "New " + i);
            // Select new tab
            tcMaps.SelectedIndex = idx;
        }

        private void tcMaps_Selected(object sender, TabControlEventArgs e)//!!!
        {
            //
        }
        #endregion

        #region Context menu
        private void cmsMap_Opening(object sender, CancelEventArgs e)//
        {
            tsmiMapReload.Visible = (tcMaps.SelectedTab.Tag != null);
        }

        private void tsmiMapOptions_Click(object sender, EventArgs e)//!!!
        {
            /*
            MapOptionsForm mapOptionsForm = new MapOptionsForm(/.../);
            if (mapOptionsForm.ShowDialog() == DialogResult.OK)
            {
                //...
            }
            */
        }

        private void tsmiMapSave_Click(object sender, EventArgs e)//!!!
        {
            //.Save();
        }

        private void tsmiMapLoad_Click(object sender, EventArgs e)//!!!
        {
            //
            //.Close();
            //.Load();
        }

        private void tsmiMapReload_Click(object sender, EventArgs e)//!!!
        {
            //.Close();
            //.Load();
        }

        private void tsmiMapClose_Click(object sender, EventArgs e)//!!!
        {
            //if(.Close())
            int idx = tcMaps.SelectedIndex;
            if (idx + 2 == tcMaps.TabCount)
                if (0 < idx)
                    idx--;
            tcMaps.TabPages.Remove(tcMaps.SelectedTab);
            tcMaps.SelectedIndex = idx;
        }
        #endregion

        #region Map pad
        private void pbMap_MouseDown(object sender, MouseEventArgs e)//!!!
        {
            //
            //pbMap.Cursor = (...) ? Cursors.NoMove2D : Cursors.SizeAll;
            pbMap.Cursor = 
                (hScrollBar.LargeChange < hScrollBar.Maximum || vScrollBar.LargeChange < vScrollBar.Maximum)
                ? Cursors.NoMove2D
                : Cursors.No;
        }

        private void pbMap_MouseUp(object sender, MouseEventArgs e)//!!!
        {
            //
            pbMap.Cursor = Cursors.Default;
        }

        private void pbMap_MouseMove(object sender, MouseEventArgs e)//!!!
        {
            //
            //pbMap.Cursor = (...) ? Cursors.Default : Cursors.Hand;
        }

        private void pbMap_MouseDoubleClick(object sender, MouseEventArgs e)//!!!
        {
            //
        }

        private void pbMap_MouseClick(object sender, MouseEventArgs e)//!!!
        {
            //
        }
        #endregion
    }
}
