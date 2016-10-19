namespace Schematix
{
    partial class OptionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.dlgFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.dlgColor = new System.Windows.Forms.ColorDialog();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpMain = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.gbLanguage = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.tbLanguagePath = new System.Windows.Forms.TextBox();
            this.lblLanguagePath = new System.Windows.Forms.Label();
            this.cbbLanguage = new System.Windows.Forms.ComboBox();
            this.gbBehaiour = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbbOnStart = new System.Windows.Forms.ComboBox();
            this.lblOnStart = new System.Windows.Forms.Label();
            this.lblOnClose = new System.Windows.Forms.Label();
            this.cbbOnClose = new System.Windows.Forms.ComboBox();
            this.chkPingPeriod = new System.Windows.Forms.CheckBox();
            this.nudPingPeriod = new System.Windows.Forms.NumericUpDown();
            this.nudPingCount = new System.Windows.Forms.NumericUpDown();
            this.lblPingCount = new System.Windows.Forms.Label();
            this.gbRoots = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblRootMaps = new System.Windows.Forms.Label();
            this.lblRootObjects = new System.Windows.Forms.Label();
            this.lblRootLinks = new System.Windows.Forms.Label();
            this.lblRootBoxes = new System.Windows.Forms.Label();
            this.tbRootMaps = new System.Windows.Forms.TextBox();
            this.tbRootObjects = new System.Windows.Forms.TextBox();
            this.tbRootLinks = new System.Windows.Forms.TextBox();
            this.tbRootBoxes = new System.Windows.Forms.TextBox();
            this.tpMap = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.gbBack = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.chkBackImageBuildIn = new System.Windows.Forms.CheckBox();
            this.cbbBackStyle = new System.Windows.Forms.ComboBox();
            this.lblBackgImagePath = new System.Windows.Forms.Label();
            this.tbBackgImagePath = new System.Windows.Forms.TextBox();
            this.chkBackStore = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.cbbBackImageAlign = new System.Windows.Forms.ComboBox();
            this.lblBackImageAlign = new System.Windows.Forms.Label();
            this.chkBackImageFloat = new System.Windows.Forms.CheckBox();
            this.btnBackColor = new System.Windows.Forms.Button();
            this.gbGrid = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.chkGridAlign = new System.Windows.Forms.CheckBox();
            this.cbbGridStyle = new System.Windows.Forms.ComboBox();
            this.lblGridThick = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nudGridThick = new System.Windows.Forms.NumericUpDown();
            this.nudGridStepY = new System.Windows.Forms.NumericUpDown();
            this.nudGridStepX = new System.Windows.Forms.NumericUpDown();
            this.chkGridStore = new System.Windows.Forms.CheckBox();
            this.btnGridColor = new System.Windows.Forms.Button();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnGetLanguagePath = new System.Windows.Forms.Button();
            this.btnGetRootMaps = new System.Windows.Forms.Button();
            this.btnGetRootObjects = new System.Windows.Forms.Button();
            this.btnGetRootLinks = new System.Windows.Forms.Button();
            this.btnGetRootBoxes = new System.Windows.Forms.Button();
            this.btnGetBackImage = new System.Windows.Forms.Button();
            this.pbBackPreview = new System.Windows.Forms.PictureBox();
            this.tabControl.SuspendLayout();
            this.tpMain.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.gbLanguage.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.gbBehaiour.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPingPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPingCount)).BeginInit();
            this.gbRoots.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tpMap.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.gbBack.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.gbGrid.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGridThick)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGridStepY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGridStepX)).BeginInit();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpMain);
            this.tabControl.Controls.Add(this.tpMap);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(3, 3);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(430, 389);
            this.tabControl.TabIndex = 0;
            // 
            // tpMain
            // 
            this.tpMain.BackColor = System.Drawing.SystemColors.Control;
            this.tpMain.Controls.Add(this.tableLayoutPanel9);
            this.tpMain.Location = new System.Drawing.Point(4, 22);
            this.tpMain.Name = "tpMain";
            this.tpMain.Padding = new System.Windows.Forms.Padding(3);
            this.tpMain.Size = new System.Drawing.Size(422, 363);
            this.tpMain.TabIndex = 0;
            this.tpMain.Text = "Main";
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 1;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.Controls.Add(this.gbLanguage, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.gbBehaiour, 0, 2);
            this.tableLayoutPanel9.Controls.Add(this.gbRoots, 0, 1);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 3;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(416, 357);
            this.tableLayoutPanel9.TabIndex = 1;
            // 
            // gbLanguage
            // 
            this.gbLanguage.Controls.Add(this.tableLayoutPanel8);
            this.gbLanguage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbLanguage.Location = new System.Drawing.Point(3, 3);
            this.gbLanguage.Name = "gbLanguage";
            this.gbLanguage.Size = new System.Drawing.Size(410, 75);
            this.gbLanguage.TabIndex = 1;
            this.gbLanguage.TabStop = false;
            this.gbLanguage.Text = "Language";
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 3;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel8.Controls.Add(this.btnGetLanguagePath, 2, 1);
            this.tableLayoutPanel8.Controls.Add(this.tbLanguagePath, 1, 1);
            this.tableLayoutPanel8.Controls.Add(this.lblLanguagePath, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.cbbLanguage, 0, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 2;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel8.Size = new System.Drawing.Size(404, 56);
            this.tableLayoutPanel8.TabIndex = 5;
            // 
            // tbLanguagePath
            // 
            this.tbLanguagePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLanguagePath.Location = new System.Drawing.Point(63, 31);
            this.tbLanguagePath.Name = "tbLanguagePath";
            this.tbLanguagePath.Size = new System.Drawing.Size(309, 20);
            this.tbLanguagePath.TabIndex = 1;
            this.tbLanguagePath.TextChanged += new System.EventHandler(this.Path_TextChanged);
            // 
            // lblLanguagePath
            // 
            this.lblLanguagePath.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLanguagePath.AutoSize = true;
            this.lblLanguagePath.Location = new System.Drawing.Point(3, 35);
            this.lblLanguagePath.Name = "lblLanguagePath";
            this.lblLanguagePath.Size = new System.Drawing.Size(54, 13);
            this.lblLanguagePath.TabIndex = 2;
            this.lblLanguagePath.Text = "Load from";
            // 
            // cbbLanguage
            // 
            this.cbbLanguage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel8.SetColumnSpan(this.cbbLanguage, 2);
            this.cbbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLanguage.FormattingEnabled = true;
            this.cbbLanguage.Location = new System.Drawing.Point(3, 3);
            this.cbbLanguage.Name = "cbbLanguage";
            this.cbbLanguage.Size = new System.Drawing.Size(160, 21);
            this.cbbLanguage.TabIndex = 0;
            // 
            // gbBehaiour
            // 
            this.gbBehaiour.AutoSize = true;
            this.gbBehaiour.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbBehaiour.Controls.Add(this.tableLayoutPanel1);
            this.gbBehaiour.Location = new System.Drawing.Point(3, 229);
            this.gbBehaiour.Name = "gbBehaiour";
            this.gbBehaiour.Size = new System.Drawing.Size(349, 125);
            this.gbBehaiour.TabIndex = 3;
            this.gbBehaiour.TabStop = false;
            this.gbBehaiour.Text = "Behaiour";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.cbbOnStart, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblOnStart, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblOnClose, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbbOnClose, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkPingPeriod, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.nudPingPeriod, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.nudPingCount, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblPingCount, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(343, 106);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cbbOnStart
            // 
            this.cbbOnStart.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cbbOnStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbOnStart.FormattingEnabled = true;
            this.cbbOnStart.Location = new System.Drawing.Point(180, 3);
            this.cbbOnStart.Name = "cbbOnStart";
            this.cbbOnStart.Size = new System.Drawing.Size(160, 21);
            this.cbbOnStart.TabIndex = 0;
            // 
            // lblOnStart
            // 
            this.lblOnStart.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblOnStart.AutoSize = true;
            this.lblOnStart.Location = new System.Drawing.Point(3, 7);
            this.lblOnStart.Name = "lblOnStart";
            this.lblOnStart.Size = new System.Drawing.Size(99, 13);
            this.lblOnStart.TabIndex = 2;
            this.lblOnStart.Text = "On starting program";
            // 
            // lblOnClose
            // 
            this.lblOnClose.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblOnClose.AutoSize = true;
            this.lblOnClose.Location = new System.Drawing.Point(3, 34);
            this.lblOnClose.Name = "lblOnClose";
            this.lblOnClose.Size = new System.Drawing.Size(98, 13);
            this.lblOnClose.TabIndex = 2;
            this.lblOnClose.Text = "On closing program";
            // 
            // cbbOnClose
            // 
            this.cbbOnClose.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cbbOnClose.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbOnClose.FormattingEnabled = true;
            this.cbbOnClose.Location = new System.Drawing.Point(180, 30);
            this.cbbOnClose.Name = "cbbOnClose";
            this.cbbOnClose.Size = new System.Drawing.Size(160, 21);
            this.cbbOnClose.TabIndex = 1;
            // 
            // chkPingPeriod
            // 
            this.chkPingPeriod.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkPingPeriod.AutoSize = true;
            this.chkPingPeriod.Location = new System.Drawing.Point(3, 58);
            this.chkPingPeriod.Name = "chkPingPeriod";
            this.chkPingPeriod.Size = new System.Drawing.Size(154, 17);
            this.chkPingPeriod.TabIndex = 2;
            this.chkPingPeriod.Text = "Period of ping (miliseconds)";
            this.chkPingPeriod.UseVisualStyleBackColor = true;
            // 
            // nudPingPeriod
            // 
            this.nudPingPeriod.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.nudPingPeriod.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudPingPeriod.Location = new System.Drawing.Point(260, 57);
            this.nudPingPeriod.Maximum = new decimal(new int[] {
            3600000,
            0,
            0,
            0});
            this.nudPingPeriod.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPingPeriod.Name = "nudPingPeriod";
            this.nudPingPeriod.Size = new System.Drawing.Size(80, 20);
            this.nudPingPeriod.TabIndex = 3;
            this.nudPingPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPingPeriod.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // nudPingCount
            // 
            this.nudPingCount.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.nudPingCount.Location = new System.Drawing.Point(300, 83);
            this.nudPingCount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudPingCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPingCount.Name = "nudPingCount";
            this.nudPingCount.Size = new System.Drawing.Size(40, 20);
            this.nudPingCount.TabIndex = 4;
            this.nudPingCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPingCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblPingCount
            // 
            this.lblPingCount.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPingCount.AutoSize = true;
            this.lblPingCount.Location = new System.Drawing.Point(3, 86);
            this.lblPingCount.Name = "lblPingCount";
            this.lblPingCount.Size = new System.Drawing.Size(171, 13);
            this.lblPingCount.TabIndex = 2;
            this.lblPingCount.Text = "Maximum count of pings per period";
            // 
            // gbRoots
            // 
            this.gbRoots.Controls.Add(this.tableLayoutPanel2);
            this.gbRoots.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbRoots.Location = new System.Drawing.Point(4, 85);
            this.gbRoots.Margin = new System.Windows.Forms.Padding(4);
            this.gbRoots.Name = "gbRoots";
            this.gbRoots.Size = new System.Drawing.Size(408, 137);
            this.gbRoots.TabIndex = 2;
            this.gbRoots.TabStop = false;
            this.gbRoots.Text = "Root folders";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.lblRootMaps, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblRootObjects, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblRootLinks, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblRootBoxes, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.tbRootMaps, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tbRootObjects, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.tbRootLinks, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.tbRootBoxes, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.btnGetRootMaps, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnGetRootObjects, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnGetRootLinks, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnGetRootBoxes, 2, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(402, 116);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lblRootMaps
            // 
            this.lblRootMaps.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblRootMaps.AutoSize = true;
            this.lblRootMaps.Location = new System.Drawing.Point(3, 8);
            this.lblRootMaps.Name = "lblRootMaps";
            this.lblRootMaps.Size = new System.Drawing.Size(33, 13);
            this.lblRootMaps.TabIndex = 2;
            this.lblRootMaps.Text = "Maps";
            // 
            // lblRootObjects
            // 
            this.lblRootObjects.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblRootObjects.AutoSize = true;
            this.lblRootObjects.Location = new System.Drawing.Point(3, 37);
            this.lblRootObjects.Name = "lblRootObjects";
            this.lblRootObjects.Size = new System.Drawing.Size(43, 13);
            this.lblRootObjects.TabIndex = 2;
            this.lblRootObjects.Text = "Objects";
            // 
            // lblRootLinks
            // 
            this.lblRootLinks.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblRootLinks.AutoSize = true;
            this.lblRootLinks.Location = new System.Drawing.Point(3, 66);
            this.lblRootLinks.Name = "lblRootLinks";
            this.lblRootLinks.Size = new System.Drawing.Size(32, 13);
            this.lblRootLinks.TabIndex = 2;
            this.lblRootLinks.Text = "Links";
            // 
            // lblRootBoxes
            // 
            this.lblRootBoxes.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblRootBoxes.AutoSize = true;
            this.lblRootBoxes.Location = new System.Drawing.Point(3, 95);
            this.lblRootBoxes.Name = "lblRootBoxes";
            this.lblRootBoxes.Size = new System.Drawing.Size(36, 13);
            this.lblRootBoxes.TabIndex = 2;
            this.lblRootBoxes.Text = "Boxes";
            // 
            // tbRootMaps
            // 
            this.tbRootMaps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRootMaps.Location = new System.Drawing.Point(52, 4);
            this.tbRootMaps.Name = "tbRootMaps";
            this.tbRootMaps.Size = new System.Drawing.Size(318, 20);
            this.tbRootMaps.TabIndex = 0;
            this.tbRootMaps.TextChanged += new System.EventHandler(this.Path_TextChanged);
            // 
            // tbRootObjects
            // 
            this.tbRootObjects.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRootObjects.Location = new System.Drawing.Point(52, 33);
            this.tbRootObjects.Name = "tbRootObjects";
            this.tbRootObjects.Size = new System.Drawing.Size(318, 20);
            this.tbRootObjects.TabIndex = 2;
            this.tbRootObjects.TextChanged += new System.EventHandler(this.Path_TextChanged);
            // 
            // tbRootLinks
            // 
            this.tbRootLinks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRootLinks.Location = new System.Drawing.Point(52, 62);
            this.tbRootLinks.Name = "tbRootLinks";
            this.tbRootLinks.Size = new System.Drawing.Size(318, 20);
            this.tbRootLinks.TabIndex = 4;
            this.tbRootLinks.TextChanged += new System.EventHandler(this.Path_TextChanged);
            // 
            // tbRootBoxes
            // 
            this.tbRootBoxes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRootBoxes.Location = new System.Drawing.Point(52, 91);
            this.tbRootBoxes.Name = "tbRootBoxes";
            this.tbRootBoxes.Size = new System.Drawing.Size(318, 20);
            this.tbRootBoxes.TabIndex = 6;
            this.tbRootBoxes.TextChanged += new System.EventHandler(this.Path_TextChanged);
            // 
            // tpMap
            // 
            this.tpMap.BackColor = System.Drawing.SystemColors.Control;
            this.tpMap.Controls.Add(this.tableLayoutPanel3);
            this.tpMap.Location = new System.Drawing.Point(4, 22);
            this.tpMap.Name = "tpMap";
            this.tpMap.Padding = new System.Windows.Forms.Padding(3);
            this.tpMap.Size = new System.Drawing.Size(422, 363);
            this.tpMap.TabIndex = 1;
            this.tpMap.Text = "New map";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.gbBack, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.gbGrid, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(416, 357);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // gbBack
            // 
            this.gbBack.Controls.Add(this.tableLayoutPanel5);
            this.gbBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbBack.Location = new System.Drawing.Point(3, 101);
            this.gbBack.Name = "gbBack";
            this.gbBack.Size = new System.Drawing.Size(410, 253);
            this.gbBack.TabIndex = 1;
            this.gbBack.TabStop = false;
            this.gbBack.Text = "Background";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 4;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.Controls.Add(this.chkBackImageBuildIn, 0, 4);
            this.tableLayoutPanel5.Controls.Add(this.cbbBackStyle, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.lblBackgImagePath, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.btnGetBackImage, 3, 2);
            this.tableLayoutPanel5.Controls.Add(this.tbBackgImagePath, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.chkBackStore, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel7, 0, 5);
            this.tableLayoutPanel5.Controls.Add(this.cbbBackImageAlign, 1, 3);
            this.tableLayoutPanel5.Controls.Add(this.lblBackImageAlign, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.chkBackImageFloat, 2, 3);
            this.tableLayoutPanel5.Controls.Add(this.btnBackColor, 1, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 6;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.Size = new System.Drawing.Size(404, 234);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // chkBackImageBuildIn
            // 
            this.chkBackImageBuildIn.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkBackImageBuildIn.AutoSize = true;
            this.tableLayoutPanel5.SetColumnSpan(this.chkBackImageBuildIn, 2);
            this.chkBackImageBuildIn.Location = new System.Drawing.Point(3, 109);
            this.chkBackImageBuildIn.Name = "chkBackImageBuildIn";
            this.chkBackImageBuildIn.Size = new System.Drawing.Size(79, 17);
            this.chkBackImageBuildIn.TabIndex = 7;
            this.chkBackImageBuildIn.Text = "Save to file";
            this.chkBackImageBuildIn.UseVisualStyleBackColor = true;
            // 
            // cbbBackStyle
            // 
            this.cbbBackStyle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbbBackStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbBackStyle.FormattingEnabled = true;
            this.cbbBackStyle.Location = new System.Drawing.Point(3, 26);
            this.cbbBackStyle.Name = "cbbBackStyle";
            this.cbbBackStyle.Size = new System.Drawing.Size(120, 21);
            this.cbbBackStyle.TabIndex = 1;
            this.cbbBackStyle.SelectedIndexChanged += new System.EventHandler(this.cbbBackgroundStyle_SelectedIndexChanged);
            // 
            // lblBackgImagePath
            // 
            this.lblBackgImagePath.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblBackgImagePath.AutoSize = true;
            this.lblBackgImagePath.Location = new System.Drawing.Point(51, 58);
            this.lblBackgImagePath.Name = "lblBackgImagePath";
            this.lblBackgImagePath.Size = new System.Drawing.Size(72, 13);
            this.lblBackgImagePath.TabIndex = 5;
            this.lblBackgImagePath.Text = "Path to image";
            // 
            // tbBackgImagePath
            // 
            this.tbBackgImagePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.SetColumnSpan(this.tbBackgImagePath, 2);
            this.tbBackgImagePath.Location = new System.Drawing.Point(129, 54);
            this.tbBackgImagePath.Name = "tbBackgImagePath";
            this.tbBackgImagePath.Size = new System.Drawing.Size(243, 20);
            this.tbBackgImagePath.TabIndex = 3;
            // 
            // chkBackStore
            // 
            this.chkBackStore.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkBackStore.AutoSize = true;
            this.chkBackStore.Checked = true;
            this.chkBackStore.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tableLayoutPanel5.SetColumnSpan(this.chkBackStore, 4);
            this.chkBackStore.Location = new System.Drawing.Point(3, 3);
            this.chkBackStore.Name = "chkBackStore";
            this.chkBackStore.Size = new System.Drawing.Size(122, 17);
            this.chkBackStore.TabIndex = 0;
            this.chkBackStore.Text = "Save options in map";
            this.chkBackStore.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.AutoSize = true;
            this.tableLayoutPanel7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel7.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial;
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel5.SetColumnSpan(this.tableLayoutPanel7, 4);
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.pbBackPreview, 0, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 132);
            this.tableLayoutPanel7.MinimumSize = new System.Drawing.Size(16, 16);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(398, 99);
            this.tableLayoutPanel7.TabIndex = 10;
            // 
            // cbbBackImageAlign
            // 
            this.cbbBackImageAlign.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbbBackImageAlign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbBackImageAlign.FormattingEnabled = true;
            this.cbbBackImageAlign.Location = new System.Drawing.Point(129, 82);
            this.cbbBackImageAlign.Name = "cbbBackImageAlign";
            this.cbbBackImageAlign.Size = new System.Drawing.Size(120, 21);
            this.cbbBackImageAlign.TabIndex = 5;
            this.cbbBackImageAlign.SelectedIndexChanged += new System.EventHandler(this.cbbBackgroundStyle_SelectedIndexChanged);
            // 
            // lblBackImageAlign
            // 
            this.lblBackImageAlign.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblBackImageAlign.AutoSize = true;
            this.lblBackImageAlign.Location = new System.Drawing.Point(62, 86);
            this.lblBackImageAlign.Name = "lblBackImageAlign";
            this.lblBackImageAlign.Size = new System.Drawing.Size(61, 13);
            this.lblBackImageAlign.TabIndex = 5;
            this.lblBackImageAlign.Text = "Image align";
            // 
            // chkBackImageFloat
            // 
            this.chkBackImageFloat.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkBackImageFloat.AutoSize = true;
            this.chkBackImageFloat.Location = new System.Drawing.Point(255, 84);
            this.chkBackImageFloat.Name = "chkBackImageFloat";
            this.chkBackImageFloat.Size = new System.Drawing.Size(80, 17);
            this.chkBackImageFloat.TabIndex = 6;
            this.chkBackImageFloat.Text = "Float image";
            this.chkBackImageFloat.UseVisualStyleBackColor = true;
            // 
            // btnBackColor
            // 
            this.btnBackColor.Location = new System.Drawing.Point(137, 26);
            this.btnBackColor.Margin = new System.Windows.Forms.Padding(11, 3, 11, 3);
            this.btnBackColor.Name = "btnBackColor";
            this.btnBackColor.Size = new System.Drawing.Size(32, 21);
            this.btnBackColor.TabIndex = 2;
            this.btnBackColor.UseVisualStyleBackColor = true;
            this.btnBackColor.BackColorChanged += new System.EventHandler(this.btnBackgroundColor_BackColorChanged);
            this.btnBackColor.Click += new System.EventHandler(this.PickColor_Click);
            // 
            // gbGrid
            // 
            this.gbGrid.Controls.Add(this.tableLayoutPanel4);
            this.gbGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbGrid.Location = new System.Drawing.Point(3, 3);
            this.gbGrid.Name = "gbGrid";
            this.gbGrid.Size = new System.Drawing.Size(410, 92);
            this.gbGrid.TabIndex = 0;
            this.gbGrid.TabStop = false;
            this.gbGrid.Text = "Grid";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 7;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.chkGridAlign, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.cbbGridStyle, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.lblGridThick, 5, 1);
            this.tableLayoutPanel4.Controls.Add(this.label1, 3, 1);
            this.tableLayoutPanel4.Controls.Add(this.nudGridThick, 6, 1);
            this.tableLayoutPanel4.Controls.Add(this.nudGridStepY, 4, 1);
            this.tableLayoutPanel4.Controls.Add(this.nudGridStepX, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.chkGridStore, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnGridColor, 1, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(404, 73);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // chkGridAlign
            // 
            this.chkGridAlign.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkGridAlign.AutoSize = true;
            this.tableLayoutPanel4.SetColumnSpan(this.chkGridAlign, 5);
            this.chkGridAlign.Location = new System.Drawing.Point(3, 53);
            this.chkGridAlign.Name = "chkGridAlign";
            this.chkGridAlign.Size = new System.Drawing.Size(126, 17);
            this.chkGridAlign.TabIndex = 6;
            this.chkGridAlign.Text = "Align elements to grid";
            this.chkGridAlign.UseVisualStyleBackColor = true;
            // 
            // cbbGridStyle
            // 
            this.cbbGridStyle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbbGridStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbGridStyle.FormattingEnabled = true;
            this.cbbGridStyle.Location = new System.Drawing.Point(3, 26);
            this.cbbGridStyle.Name = "cbbGridStyle";
            this.cbbGridStyle.Size = new System.Drawing.Size(120, 21);
            this.cbbGridStyle.TabIndex = 1;
            // 
            // lblGridThick
            // 
            this.lblGridThick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGridThick.AutoSize = true;
            this.lblGridThick.Location = new System.Drawing.Point(287, 30);
            this.lblGridThick.Name = "lblGridThick";
            this.lblGridThick.Size = new System.Drawing.Size(56, 13);
            this.lblGridThick.TabIndex = 5;
            this.lblGridThick.Text = "Thickness";
            this.lblGridThick.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(226, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "x";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nudGridThick
            // 
            this.nudGridThick.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudGridThick.Location = new System.Drawing.Point(349, 26);
            this.nudGridThick.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudGridThick.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudGridThick.Name = "nudGridThick";
            this.nudGridThick.Size = new System.Drawing.Size(40, 20);
            this.nudGridThick.TabIndex = 5;
            this.nudGridThick.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudGridThick.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudGridStepY
            // 
            this.nudGridStepY.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.nudGridStepY.Location = new System.Drawing.Point(241, 26);
            this.nudGridStepY.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudGridStepY.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudGridStepY.Name = "nudGridStepY";
            this.nudGridStepY.Size = new System.Drawing.Size(40, 20);
            this.nudGridStepY.TabIndex = 4;
            this.nudGridStepY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudGridStepY.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // nudGridStepX
            // 
            this.nudGridStepX.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.nudGridStepX.Location = new System.Drawing.Point(183, 26);
            this.nudGridStepX.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudGridStepX.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudGridStepX.Name = "nudGridStepX";
            this.nudGridStepX.Size = new System.Drawing.Size(40, 20);
            this.nudGridStepX.TabIndex = 3;
            this.nudGridStepX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudGridStepX.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // chkGridStore
            // 
            this.chkGridStore.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkGridStore.AutoSize = true;
            this.chkGridStore.Checked = true;
            this.chkGridStore.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tableLayoutPanel4.SetColumnSpan(this.chkGridStore, 7);
            this.chkGridStore.Location = new System.Drawing.Point(3, 3);
            this.chkGridStore.Name = "chkGridStore";
            this.chkGridStore.Size = new System.Drawing.Size(122, 17);
            this.chkGridStore.TabIndex = 0;
            this.chkGridStore.Text = "Save options in map";
            this.chkGridStore.UseVisualStyleBackColor = true;
            // 
            // btnGridColor
            // 
            this.btnGridColor.Location = new System.Drawing.Point(137, 26);
            this.btnGridColor.Margin = new System.Windows.Forms.Padding(11, 3, 11, 3);
            this.btnGridColor.Name = "btnGridColor";
            this.btnGridColor.Size = new System.Drawing.Size(32, 21);
            this.btnGridColor.TabIndex = 2;
            this.btnGridColor.UseVisualStyleBackColor = true;
            this.btnGridColor.Click += new System.EventHandler(this.PickColor_Click);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.tabControl, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnSave, 0, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.Size = new System.Drawing.Size(436, 424);
            this.tableLayoutPanel6.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSave.Location = new System.Drawing.Point(180, 398);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Ok";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnGetLanguagePath
            // 
            this.btnGetLanguagePath.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnGetLanguagePath.Image = global::Schematix.Properties.Resources.open;
            this.btnGetLanguagePath.Location = new System.Drawing.Point(378, 30);
            this.btnGetLanguagePath.Name = "btnGetLanguagePath";
            this.btnGetLanguagePath.Size = new System.Drawing.Size(23, 23);
            this.btnGetLanguagePath.TabIndex = 2;
            this.btnGetLanguagePath.UseVisualStyleBackColor = true;
            this.btnGetLanguagePath.Click += new System.EventHandler(this.btnGetLanguagePath_Click);
            // 
            // btnGetRootMaps
            // 
            this.btnGetRootMaps.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnGetRootMaps.Image = global::Schematix.Properties.Resources.open;
            this.btnGetRootMaps.Location = new System.Drawing.Point(376, 3);
            this.btnGetRootMaps.Name = "btnGetRootMaps";
            this.btnGetRootMaps.Size = new System.Drawing.Size(23, 23);
            this.btnGetRootMaps.TabIndex = 1;
            this.btnGetRootMaps.UseVisualStyleBackColor = true;
            this.btnGetRootMaps.Click += new System.EventHandler(this.btnGetRootMaps_Click);
            // 
            // btnGetRootObjects
            // 
            this.btnGetRootObjects.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnGetRootObjects.Image = global::Schematix.Properties.Resources.open;
            this.btnGetRootObjects.Location = new System.Drawing.Point(376, 32);
            this.btnGetRootObjects.Name = "btnGetRootObjects";
            this.btnGetRootObjects.Size = new System.Drawing.Size(23, 23);
            this.btnGetRootObjects.TabIndex = 3;
            this.btnGetRootObjects.UseVisualStyleBackColor = true;
            this.btnGetRootObjects.Click += new System.EventHandler(this.btnGetRootObjects_Click);
            // 
            // btnGetRootLinks
            // 
            this.btnGetRootLinks.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnGetRootLinks.Image = global::Schematix.Properties.Resources.open;
            this.btnGetRootLinks.Location = new System.Drawing.Point(376, 61);
            this.btnGetRootLinks.Name = "btnGetRootLinks";
            this.btnGetRootLinks.Size = new System.Drawing.Size(23, 23);
            this.btnGetRootLinks.TabIndex = 5;
            this.btnGetRootLinks.UseVisualStyleBackColor = true;
            this.btnGetRootLinks.Click += new System.EventHandler(this.btnGetRootLinks_Click);
            // 
            // btnGetRootBoxes
            // 
            this.btnGetRootBoxes.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnGetRootBoxes.Image = global::Schematix.Properties.Resources.open;
            this.btnGetRootBoxes.Location = new System.Drawing.Point(376, 90);
            this.btnGetRootBoxes.Name = "btnGetRootBoxes";
            this.btnGetRootBoxes.Size = new System.Drawing.Size(23, 23);
            this.btnGetRootBoxes.TabIndex = 7;
            this.btnGetRootBoxes.UseVisualStyleBackColor = true;
            this.btnGetRootBoxes.Click += new System.EventHandler(this.btnGetRootBoxes_Click);
            // 
            // btnGetBackImage
            // 
            this.btnGetBackImage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnGetBackImage.Image = global::Schematix.Properties.Resources.load;
            this.btnGetBackImage.Location = new System.Drawing.Point(378, 53);
            this.btnGetBackImage.Name = "btnGetBackImage";
            this.btnGetBackImage.Size = new System.Drawing.Size(23, 23);
            this.btnGetBackImage.TabIndex = 4;
            this.btnGetBackImage.UseVisualStyleBackColor = true;
            this.btnGetBackImage.Click += new System.EventHandler(this.btnGetImage_Click);
            // 
            // pbBackPreview
            // 
            this.pbBackPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbBackPreview.Location = new System.Drawing.Point(3, 3);
            this.pbBackPreview.Margin = new System.Windows.Forms.Padding(0);
            this.pbBackPreview.Name = "pbBackPreview";
            this.pbBackPreview.Size = new System.Drawing.Size(392, 93);
            this.pbBackPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbBackPreview.TabIndex = 0;
            this.pbBackPreview.TabStop = false;
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(444, 432);
            this.Controls.Add(this.tableLayoutPanel6);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(720, 990);
            this.MinimumSize = new System.Drawing.Size(460, 470);
            this.Name = "OptionsForm";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main options";
            this.tabControl.ResumeLayout(false);
            this.tpMain.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.gbLanguage.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.gbBehaiour.ResumeLayout(false);
            this.gbBehaiour.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPingPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPingCount)).EndInit();
            this.gbRoots.ResumeLayout(false);
            this.gbRoots.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tpMap.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.gbBack.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.gbGrid.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGridThick)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGridStepY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGridStepX)).EndInit();
            this.tableLayoutPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbBackPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog dlgFolder;
        private System.Windows.Forms.ColorDialog dlgColor;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox gbRoots;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ComboBox cbbOnStart;
        private System.Windows.Forms.Label lblOnStart;
        private System.Windows.Forms.Label lblOnClose;
        private System.Windows.Forms.ComboBox cbbOnClose;
        private System.Windows.Forms.CheckBox chkPingPeriod;
        private System.Windows.Forms.NumericUpDown nudPingPeriod;
        private System.Windows.Forms.TabPage tpMap;
        private System.Windows.Forms.NumericUpDown nudPingCount;
        private System.Windows.Forms.Label lblPingCount;
        private System.Windows.Forms.Label lblRootMaps;
        private System.Windows.Forms.Label lblRootObjects;
        private System.Windows.Forms.Label lblRootLinks;
        private System.Windows.Forms.Label lblRootBoxes;
        private System.Windows.Forms.TextBox tbRootMaps;
        private System.Windows.Forms.TextBox tbRootObjects;
        private System.Windows.Forms.TextBox tbRootLinks;
        private System.Windows.Forms.TextBox tbRootBoxes;
        private System.Windows.Forms.Button btnGetRootMaps;
        private System.Windows.Forms.Button btnGetRootObjects;
        private System.Windows.Forms.Button btnGetRootLinks;
        private System.Windows.Forms.Button btnGetRootBoxes;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.GroupBox gbBack;
        private System.Windows.Forms.GroupBox gbGrid;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.ComboBox cbbBackStyle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.ComboBox cbbGridStyle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblGridThick;
        private System.Windows.Forms.NumericUpDown nudGridThick;
        private System.Windows.Forms.CheckBox chkGridAlign;
        private System.Windows.Forms.NumericUpDown nudGridStepY;
        private System.Windows.Forms.NumericUpDown nudGridStepX;
        private System.Windows.Forms.TextBox tbBackgImagePath;
        private System.Windows.Forms.Button btnGetBackImage;
        private System.Windows.Forms.Label lblBackgImagePath;
        private System.Windows.Forms.GroupBox gbBehaiour;
        private System.Windows.Forms.PictureBox pbBackPreview;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkBackStore;
        private System.Windows.Forms.CheckBox chkGridStore;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.GroupBox gbLanguage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.ComboBox cbbLanguage;
        private System.Windows.Forms.Button btnGetLanguagePath;
        private System.Windows.Forms.TextBox tbLanguagePath;
        private System.Windows.Forms.Label lblLanguagePath;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.CheckBox chkBackImageBuildIn;
        private System.Windows.Forms.ComboBox cbbBackImageAlign;
        private System.Windows.Forms.Label lblBackImageAlign;
        private System.Windows.Forms.CheckBox chkBackImageFloat;
        private System.Windows.Forms.Button btnBackColor;
        private System.Windows.Forms.Button btnGridColor;
    }
}