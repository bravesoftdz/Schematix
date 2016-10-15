using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schematix
{
    public partial class MainForm : Form
    {
        const int TOOLS_HIDE_DELAY = 500; // mseconds

        public MainForm()
        {
            InitializeComponent();
            //options.Init();

            //Loads
            options.Load();
            String eStr = options.LoadLanguages(options.LangPath);
            options.SelectLanguage(options.LangName);
            SetText(options.LangCur);
            if (eStr != "")
                MessageBox.Show(options.LangCur.mOccurred + "\r\n" + eStr, options.LangCur.mLanguagesLoading, MessageBoxButtons.OK);
        }

        private void SetText(LanguageRecord lang)//Ok
        {
            //toolTip.RemoveAll();
            //Main
            //tpFiles.Text = lang.lblFiles;
            //toolTip.SetToolTip(btnOptions, lang.hintOptions);
        }

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

        private void tabPageAddNew_Enter(object sender, EventArgs e)//!!!
        {
            int i = tcMaps.SelectedIndex;
            tcMaps.TabPages.Insert(i, "New");
            tcMaps.SelectedIndex = i;
        }
        
        private void btnCloseMap_Click(object sender, EventArgs e)//!!!
        {
            //
            tcMaps.TabPages.Remove(tcMaps.SelectedTab);
        }

        private void btnLibrary_Click(object sender, EventArgs e)
        {
            //
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            //
        }

        private void pnlMapOptions_Click(object sender, EventArgs e)
        {
            //
        }

        private void tcMaps_Selected(object sender, TabControlEventArgs e)
        {
            //
        }
    }
}
