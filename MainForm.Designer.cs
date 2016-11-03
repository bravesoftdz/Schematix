namespace Schematix
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tcMaps = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPageAddNew = new System.Windows.Forms.TabPage();
            this.vScrollBar = new System.Windows.Forms.VScrollBar();
            this.hScrollBar = new System.Windows.Forms.HScrollBar();
            this.pnlMapOptions = new System.Windows.Forms.Panel();
            this.pnlMapFrame = new System.Windows.Forms.Panel();
            this.pnlMaps = new System.Windows.Forms.Panel();
            this.btnCloseMap = new System.Windows.Forms.Button();
            this.pnlTools = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbDefault = new System.Windows.Forms.RadioButton();
            this.rbObject = new System.Windows.Forms.RadioButton();
            this.rbLink = new System.Windows.Forms.RadioButton();
            this.rbBox = new System.Windows.Forms.RadioButton();
            this.btnLibrary = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnOptions = new System.Windows.Forms.Button();
            this.timerTools = new System.Windows.Forms.Timer(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.cmsMap = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiMapOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMapSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMapLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMapReload = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMapClose = new System.Windows.Forms.ToolStripMenuItem();
            this.dlgMapOpen = new System.Windows.Forms.OpenFileDialog();
            this.dlgMapSave = new System.Windows.Forms.SaveFileDialog();
            this.timerPing = new System.Windows.Forms.Timer(this.components);
            this.pbPullHScroll = new System.Windows.Forms.PictureBox();
            this.pbPullVScroll = new System.Windows.Forms.PictureBox();
            this.pbPullMaps = new System.Windows.Forms.PictureBox();
            this.pbPullTools = new System.Windows.Forms.PictureBox();
            this.tcMaps.SuspendLayout();
            this.pnlMapOptions.SuspendLayout();
            this.pnlMaps.SuspendLayout();
            this.pnlTools.SuspendLayout();
            this.panel1.SuspendLayout();
            this.cmsMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPullHScroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPullVScroll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPullMaps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPullTools)).BeginInit();
            this.SuspendLayout();
            // 
            // tcMaps
            // 
            this.tcMaps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcMaps.Controls.Add(this.tabPage1);
            this.tcMaps.Controls.Add(this.tabPageAddNew);
            this.tcMaps.Location = new System.Drawing.Point(0, 4);
            this.tcMaps.Name = "tcMaps";
            this.tcMaps.SelectedIndex = 0;
            this.tcMaps.Size = new System.Drawing.Size(448, 24);
            this.tcMaps.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tcMaps.TabIndex = 2;
            this.tcMaps.Selected += new System.Windows.Forms.TabControlEventHandler(this.tcMaps_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(440, 0);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "New";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPageAddNew
            // 
            this.tabPageAddNew.BackColor = System.Drawing.Color.Transparent;
            this.tabPageAddNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabPageAddNew.Location = new System.Drawing.Point(4, 22);
            this.tabPageAddNew.Name = "tabPageAddNew";
            this.tabPageAddNew.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAddNew.Size = new System.Drawing.Size(440, 0);
            this.tabPageAddNew.TabIndex = 1;
            this.tabPageAddNew.Text = "+";
            this.tabPageAddNew.Enter += new System.EventHandler(this.tabPageAddNew_Enter);
            // 
            // vScrollBar
            // 
            this.vScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vScrollBar.LargeChange = 5;
            this.vScrollBar.Location = new System.Drawing.Point(464, 4);
            this.vScrollBar.Maximum = 9;
            this.vScrollBar.Name = "vScrollBar";
            this.vScrollBar.Size = new System.Drawing.Size(17, 230);
            this.vScrollBar.SmallChange = 5;
            this.vScrollBar.TabIndex = 5;
            this.vScrollBar.Value = 1;
            this.vScrollBar.Visible = false;
            this.vScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrollBar_Scroll);
            // 
            // hScrollBar
            // 
            this.hScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hScrollBar.Location = new System.Drawing.Point(4, 240);
            this.hScrollBar.Name = "hScrollBar";
            this.hScrollBar.Size = new System.Drawing.Size(454, 17);
            this.hScrollBar.SmallChange = 10;
            this.hScrollBar.TabIndex = 7;
            this.hScrollBar.Visible = false;
            this.hScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrollBar_Scroll);
            // 
            // pnlMapOptions
            // 
            this.pnlMapOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMapOptions.BackColor = System.Drawing.Color.White;
            this.pnlMapOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMapOptions.Controls.Add(this.pnlMapFrame);
            this.pnlMapOptions.Location = new System.Drawing.Point(460, 236);
            this.pnlMapOptions.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMapOptions.Name = "pnlMapOptions";
            this.pnlMapOptions.Size = new System.Drawing.Size(25, 25);
            this.pnlMapOptions.TabIndex = 4;
            this.pnlMapOptions.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlMapOptions_MouseAction);
            this.pnlMapOptions.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlMapOptions_MouseAction);
            // 
            // pnlMapFrame
            // 
            this.pnlMapFrame.BackColor = System.Drawing.Color.LightSkyBlue;
            this.pnlMapFrame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMapFrame.Location = new System.Drawing.Point(4, 4);
            this.pnlMapFrame.Name = "pnlMapFrame";
            this.pnlMapFrame.Size = new System.Drawing.Size(12, 12);
            this.pnlMapFrame.TabIndex = 0;
            this.pnlMapFrame.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlMapOptions_MouseAction);
            this.pnlMapFrame.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlMapOptions_MouseAction);
            // 
            // pnlMaps
            // 
            this.pnlMaps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMaps.BackColor = System.Drawing.SystemColors.Control;
            this.pnlMaps.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMaps.Controls.Add(this.btnCloseMap);
            this.pnlMaps.Controls.Add(this.tcMaps);
            this.pnlMaps.Location = new System.Drawing.Point(8, 4);
            this.pnlMaps.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMaps.Name = "pnlMaps";
            this.pnlMaps.Size = new System.Drawing.Size(472, 28);
            this.pnlMaps.TabIndex = 4;
            this.pnlMaps.Visible = false;
            // 
            // btnCloseMap
            // 
            this.btnCloseMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseMap.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCloseMap.BackgroundImage")));
            this.btnCloseMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCloseMap.Location = new System.Drawing.Point(448, 3);
            this.btnCloseMap.Name = "btnCloseMap";
            this.btnCloseMap.Size = new System.Drawing.Size(20, 20);
            this.btnCloseMap.TabIndex = 3;
            this.btnCloseMap.UseVisualStyleBackColor = true;
            this.btnCloseMap.Click += new System.EventHandler(this.tsmiMapClose_Click);
            // 
            // pnlTools
            // 
            this.pnlTools.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTools.BackColor = System.Drawing.SystemColors.Control;
            this.pnlTools.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTools.Controls.Add(this.panel1);
            this.pnlTools.Controls.Add(this.btnAbout);
            this.pnlTools.Controls.Add(this.btnOptions);
            this.pnlTools.Location = new System.Drawing.Point(300, 4);
            this.pnlTools.Name = "pnlTools";
            this.pnlTools.Padding = new System.Windows.Forms.Padding(2);
            this.pnlTools.Size = new System.Drawing.Size(181, 31);
            this.pnlTools.TabIndex = 6;
            this.pnlTools.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.rbDefault);
            this.panel1.Controls.Add(this.rbObject);
            this.panel1.Controls.Add(this.rbLink);
            this.panel1.Controls.Add(this.rbBox);
            this.panel1.Controls.Add(this.btnLibrary);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(123, 25);
            this.panel1.TabIndex = 6;
            // 
            // rbDefault
            // 
            this.rbDefault.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbDefault.Checked = true;
            this.rbDefault.Image = global::Schematix.Properties.Resources.toolDefault;
            this.rbDefault.Location = new System.Drawing.Point(0, 0);
            this.rbDefault.Margin = new System.Windows.Forms.Padding(0);
            this.rbDefault.Name = "rbDefault";
            this.rbDefault.Size = new System.Drawing.Size(25, 25);
            this.rbDefault.TabIndex = 5;
            this.rbDefault.TabStop = true;
            this.rbDefault.UseVisualStyleBackColor = true;
            // 
            // rbObject
            // 
            this.rbObject.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbObject.Image = global::Schematix.Properties.Resources.toolObject;
            this.rbObject.Location = new System.Drawing.Point(24, 0);
            this.rbObject.Margin = new System.Windows.Forms.Padding(0);
            this.rbObject.Name = "rbObject";
            this.rbObject.Size = new System.Drawing.Size(25, 25);
            this.rbObject.TabIndex = 5;
            this.rbObject.UseVisualStyleBackColor = true;
            this.rbObject.CheckedChanged += new System.EventHandler(this.rbTool_CheckedChanged);
            this.rbObject.Click += new System.EventHandler(this.rbTool_Click);
            // 
            // rbLink
            // 
            this.rbLink.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbLink.Image = global::Schematix.Properties.Resources.toolLine;
            this.rbLink.Location = new System.Drawing.Point(48, 0);
            this.rbLink.Margin = new System.Windows.Forms.Padding(0);
            this.rbLink.Name = "rbLink";
            this.rbLink.Size = new System.Drawing.Size(25, 25);
            this.rbLink.TabIndex = 5;
            this.rbLink.UseVisualStyleBackColor = true;
            this.rbLink.CheckedChanged += new System.EventHandler(this.rbTool_CheckedChanged);
            this.rbLink.Click += new System.EventHandler(this.rbTool_Click);
            // 
            // rbBox
            // 
            this.rbBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbBox.Image = global::Schematix.Properties.Resources.toolBoxes;
            this.rbBox.Location = new System.Drawing.Point(72, 0);
            this.rbBox.Margin = new System.Windows.Forms.Padding(0);
            this.rbBox.Name = "rbBox";
            this.rbBox.Size = new System.Drawing.Size(25, 25);
            this.rbBox.TabIndex = 5;
            this.rbBox.UseVisualStyleBackColor = true;
            this.rbBox.CheckedChanged += new System.EventHandler(this.rbTool_CheckedChanged);
            this.rbBox.Click += new System.EventHandler(this.rbTool_Click);
            // 
            // btnLibrary
            // 
            this.btnLibrary.Image = global::Schematix.Properties.Resources.folderTree;
            this.btnLibrary.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnLibrary.Location = new System.Drawing.Point(98, 0);
            this.btnLibrary.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnLibrary.Name = "btnLibrary";
            this.btnLibrary.Size = new System.Drawing.Size(25, 25);
            this.btnLibrary.TabIndex = 3;
            this.btnLibrary.UseVisualStyleBackColor = true;
            this.btnLibrary.Click += new System.EventHandler(this.btnLibrary_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Image = global::Schematix.Properties.Resources.help;
            this.btnAbout.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnAbout.Location = new System.Drawing.Point(152, 2);
            this.btnAbout.Margin = new System.Windows.Forms.Padding(0);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(25, 25);
            this.btnAbout.TabIndex = 4;
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnOptions
            // 
            this.btnOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOptions.Image")));
            this.btnOptions.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnOptions.Location = new System.Drawing.Point(128, 2);
            this.btnOptions.Margin = new System.Windows.Forms.Padding(0);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(25, 25);
            this.btnOptions.TabIndex = 3;
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // timerTools
            // 
            this.timerTools.Tick += new System.EventHandler(this.timerTools_Tick);
            // 
            // cmsMap
            // 
            this.cmsMap.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMapOptions,
            this.tsmiMapSave,
            this.tsmiMapLoad,
            this.tsmiMapReload,
            this.tsmiMapClose});
            this.cmsMap.Name = "cmsMap";
            this.cmsMap.Size = new System.Drawing.Size(117, 114);
            this.cmsMap.Opening += new System.ComponentModel.CancelEventHandler(this.cmsMap_Opening);
            // 
            // tsmiMapOptions
            // 
            this.tsmiMapOptions.Image = global::Schematix.Properties.Resources.edit;
            this.tsmiMapOptions.Name = "tsmiMapOptions";
            this.tsmiMapOptions.Size = new System.Drawing.Size(116, 22);
            this.tsmiMapOptions.Text = "Options";
            this.tsmiMapOptions.Click += new System.EventHandler(this.tsmiMapOptions_Click);
            // 
            // tsmiMapSave
            // 
            this.tsmiMapSave.Image = global::Schematix.Properties.Resources.save;
            this.tsmiMapSave.Name = "tsmiMapSave";
            this.tsmiMapSave.Size = new System.Drawing.Size(116, 22);
            this.tsmiMapSave.Text = "Save";
            this.tsmiMapSave.Click += new System.EventHandler(this.tsmiMapSave_Click);
            // 
            // tsmiMapLoad
            // 
            this.tsmiMapLoad.Image = global::Schematix.Properties.Resources.load;
            this.tsmiMapLoad.Name = "tsmiMapLoad";
            this.tsmiMapLoad.Size = new System.Drawing.Size(116, 22);
            this.tsmiMapLoad.Text = "Load...";
            this.tsmiMapLoad.Click += new System.EventHandler(this.tsmiMapLoad_Click);
            // 
            // tsmiMapReload
            // 
            this.tsmiMapReload.Image = global::Schematix.Properties.Resources.reload;
            this.tsmiMapReload.Name = "tsmiMapReload";
            this.tsmiMapReload.Size = new System.Drawing.Size(116, 22);
            this.tsmiMapReload.Text = "Reload";
            this.tsmiMapReload.Click += new System.EventHandler(this.tsmiMapReload_Click);
            // 
            // tsmiMapClose
            // 
            this.tsmiMapClose.Image = ((System.Drawing.Image)(resources.GetObject("tsmiMapClose.Image")));
            this.tsmiMapClose.Name = "tsmiMapClose";
            this.tsmiMapClose.Size = new System.Drawing.Size(116, 22);
            this.tsmiMapClose.Text = "Close";
            this.tsmiMapClose.Click += new System.EventHandler(this.tsmiMapClose_Click);
            // 
            // pbPullHScroll
            // 
            this.pbPullHScroll.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pbPullHScroll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPullHScroll.Image = global::Schematix.Properties.Resources.PullScrollH;
            this.pbPullHScroll.Location = new System.Drawing.Point(233, 250);
            this.pbPullHScroll.Name = "pbPullHScroll";
            this.pbPullHScroll.Size = new System.Drawing.Size(18, 7);
            this.pbPullHScroll.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbPullHScroll.TabIndex = 8;
            this.pbPullHScroll.TabStop = false;
            this.pbPullHScroll.MouseEnter += new System.EventHandler(this.PullHScroll_Over);
            // 
            // pbPullVScroll
            // 
            this.pbPullVScroll.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pbPullVScroll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPullVScroll.Image = global::Schematix.Properties.Resources.PullScrollV;
            this.pbPullVScroll.Location = new System.Drawing.Point(474, 121);
            this.pbPullVScroll.Name = "pbPullVScroll";
            this.pbPullVScroll.Size = new System.Drawing.Size(7, 18);
            this.pbPullVScroll.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbPullVScroll.TabIndex = 8;
            this.pbPullVScroll.TabStop = false;
            this.pbPullVScroll.MouseEnter += new System.EventHandler(this.PullVScroll_Over);
            // 
            // pbPullMaps
            // 
            this.pbPullMaps.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pbPullMaps.BackColor = System.Drawing.Color.Transparent;
            this.pbPullMaps.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPullMaps.Image = global::Schematix.Properties.Resources.PullTabs;
            this.pbPullMaps.Location = new System.Drawing.Point(233, 4);
            this.pbPullMaps.Name = "pbPullMaps";
            this.pbPullMaps.Size = new System.Drawing.Size(18, 7);
            this.pbPullMaps.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbPullMaps.TabIndex = 8;
            this.pbPullMaps.TabStop = false;
            this.pbPullMaps.MouseEnter += new System.EventHandler(this.PullMaps_Over);
            // 
            // pbPullTools
            // 
            this.pbPullTools.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbPullTools.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPullTools.Image = ((System.Drawing.Image)(resources.GetObject("pbPullTools.Image")));
            this.pbPullTools.Location = new System.Drawing.Point(440, 4);
            this.pbPullTools.Name = "pbPullTools";
            this.pbPullTools.Size = new System.Drawing.Size(19, 7);
            this.pbPullTools.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbPullTools.TabIndex = 9;
            this.pbPullTools.TabStop = false;
            this.pbPullTools.MouseEnter += new System.EventHandler(this.PullTools_Over);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(485, 261);
            this.ContextMenuStrip = this.cmsMap;
            this.Controls.Add(this.pnlTools);
            this.Controls.Add(this.pnlMaps);
            this.Controls.Add(this.hScrollBar);
            this.Controls.Add(this.vScrollBar);
            this.Controls.Add(this.pbPullHScroll);
            this.Controls.Add(this.pbPullVScroll);
            this.Controls.Add(this.pbPullMaps);
            this.Controls.Add(this.pbPullTools);
            this.Controls.Add(this.pnlMapOptions);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(501, 299);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Schematix 0.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            this.Move += new System.EventHandler(this.MainForm_Move);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.tcMaps.ResumeLayout(false);
            this.pnlMapOptions.ResumeLayout(false);
            this.pnlMaps.ResumeLayout(false);
            this.pnlTools.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.cmsMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPullHScroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPullVScroll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPullMaps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPullTools)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tcMaps;
        private System.Windows.Forms.TabPage tabPageAddNew;
        private System.Windows.Forms.VScrollBar vScrollBar;
        private System.Windows.Forms.HScrollBar hScrollBar;
        private System.Windows.Forms.Panel pnlMapOptions;
        private System.Windows.Forms.Panel pnlMaps;
        private System.Windows.Forms.Timer timerTools;
        private System.Windows.Forms.Button btnCloseMap;
        private System.Windows.Forms.PictureBox pbPullMaps;
        private System.Windows.Forms.PictureBox pbPullVScroll;
        private System.Windows.Forms.PictureBox pbPullHScroll;
        private System.Windows.Forms.Button btnLibrary;
        private System.Windows.Forms.Button btnOptions;
        private System.Windows.Forms.ContextMenuStrip cmsMap;
        private System.Windows.Forms.ToolStripMenuItem tsmiMapOptions;
        private System.Windows.Forms.ToolStripMenuItem tsmiMapSave;
        private System.Windows.Forms.ToolStripMenuItem tsmiMapLoad;
        private System.Windows.Forms.ToolStripMenuItem tsmiMapReload;
        private System.Windows.Forms.ToolStripMenuItem tsmiMapClose;
        private System.Windows.Forms.OpenFileDialog dlgMapOpen;
        private System.Windows.Forms.SaveFileDialog dlgMapSave;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel pnlMapFrame;
        private System.Windows.Forms.RadioButton rbBox;
        private System.Windows.Forms.RadioButton rbLink;
        private System.Windows.Forms.RadioButton rbObject;
        private System.Windows.Forms.RadioButton rbDefault;
        private System.Windows.Forms.Panel pnlTools;
        public System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Timer timerPing;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbPullTools;
    }
}

