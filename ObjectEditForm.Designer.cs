namespace Schematix
{
    partial class ObjectEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObjectEditForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpMain = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lblNode = new System.Windows.Forms.Label();
            this.tbNode = new System.Windows.Forms.TextBox();
            this.tbRevision = new System.Windows.Forms.TextBox();
            this.tbID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.lblRevision = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tpImage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tbImagePath = new System.Windows.Forms.TextBox();
            this.lblImageType = new System.Windows.Forms.Label();
            this.cbbImageType = new System.Windows.Forms.ComboBox();
            this.lblImagePath = new System.Windows.Forms.Label();
            this.lblImageBPP = new System.Windows.Forms.Label();
            this.cbbImageBPP = new System.Windows.Forms.ComboBox();
            this.btnGetImagePath = new System.Windows.Forms.Button();
            this.btnImageColor = new System.Windows.Forms.Button();
            this.lblImageBackColor = new System.Windows.Forms.Label();
            this.tpAlpha = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.pbAlpha = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.tbAlphaPath = new System.Windows.Forms.TextBox();
            this.lblAlphaType = new System.Windows.Forms.Label();
            this.cbbAlphaType = new System.Windows.Forms.ComboBox();
            this.lblAlphaPath = new System.Windows.Forms.Label();
            this.btnAlphaColor = new System.Windows.Forms.Button();
            this.btnGetAlphaPath = new System.Windows.Forms.Button();
            this.cbbAlphaBPP = new System.Windows.Forms.ComboBox();
            this.lblAlphaBPP = new System.Windows.Forms.Label();
            this.tpDotes = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.pbDotPicker = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDotAdd = new System.Windows.Forms.Button();
            this.cbbDotes = new System.Windows.Forms.ComboBox();
            this.lblDot = new System.Windows.Forms.Label();
            this.btnDotMoveUp = new System.Windows.Forms.Button();
            this.btnDotMoveDown = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.tbDotDescription = new System.Windows.Forms.TextBox();
            this.tbDotName = new System.Windows.Forms.TextBox();
            this.nudDotY = new System.Windows.Forms.NumericUpDown();
            this.nudDotX = new System.Windows.Forms.NumericUpDown();
            this.lblDotLocation = new System.Windows.Forms.Label();
            this.lblDotName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDotDelete = new System.Windows.Forms.Button();
            this.btnDotSave = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnOk = new System.Windows.Forms.Button();
            this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
            this.dlgColor = new System.Windows.Forms.ColorDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.chkPrototype = new System.Windows.Forms.CheckBox();
            this.tabControl.SuspendLayout();
            this.tpMain.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tpImage.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.tableLayoutPanel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tpAlpha.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAlpha)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tpDotes.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDotPicker)).BeginInit();
            this.tableLayoutPanel6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDotY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDotX)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpMain);
            this.tabControl.Controls.Add(this.tpImage);
            this.tabControl.Controls.Add(this.tpAlpha);
            this.tabControl.Controls.Add(this.tpDotes);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(3, 3);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(412, 281);
            this.tabControl.TabIndex = 0;
            // 
            // tpMain
            // 
            this.tpMain.BackColor = System.Drawing.SystemColors.Control;
            this.tpMain.Controls.Add(this.tableLayoutPanel2);
            this.tpMain.Location = new System.Drawing.Point(4, 22);
            this.tpMain.Name = "tpMain";
            this.tpMain.Padding = new System.Windows.Forms.Padding(3);
            this.tpMain.Size = new System.Drawing.Size(404, 255);
            this.tpMain.TabIndex = 0;
            this.tpMain.Text = "Main";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.lblName, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.tbName, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblNode, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tbNode, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tbRevision, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.tbID, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblID, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.tbDescription, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.chkPrototype, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblRevision, 2, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(398, 249);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // lblName
            // 
            this.lblName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(3, 58);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // tbName
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.tbName, 4);
            this.tbName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbName.Location = new System.Drawing.Point(71, 55);
            this.tbName.MaxLength = 255;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(324, 20);
            this.tbName.TabIndex = 1;
            // 
            // lblNode
            // 
            this.lblNode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNode.AutoSize = true;
            this.lblNode.Location = new System.Drawing.Point(3, 6);
            this.lblNode.Name = "lblNode";
            this.lblNode.Size = new System.Drawing.Size(62, 13);
            this.lblNode.TabIndex = 0;
            this.lblNode.Text = "Node name";
            // 
            // tbNode
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.tbNode, 2);
            this.tbNode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbNode.Location = new System.Drawing.Point(71, 3);
            this.tbNode.MaxLength = 32;
            this.tbNode.Name = "tbNode";
            this.tbNode.Size = new System.Drawing.Size(208, 20);
            this.tbNode.TabIndex = 0;
            // 
            // tbRevision
            // 
            this.tbRevision.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tbRevision.BackColor = System.Drawing.Color.OldLace;
            this.tableLayoutPanel2.SetColumnSpan(this.tbRevision, 2);
            this.tbRevision.Location = new System.Drawing.Point(285, 29);
            this.tbRevision.MaxLength = 20;
            this.tbRevision.Name = "tbRevision";
            this.tbRevision.ReadOnly = true;
            this.tbRevision.Size = new System.Drawing.Size(110, 20);
            this.tbRevision.TabIndex = 7;
            this.tbRevision.Text = "2000.01.01 12:00:00";
            this.tbRevision.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbID
            // 
            this.tbID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbID.BackColor = System.Drawing.Color.OldLace;
            this.tbID.Enabled = false;
            this.tbID.Location = new System.Drawing.Point(315, 3);
            this.tbID.MaxLength = 16;
            this.tbID.Name = "tbID";
            this.tbID.ReadOnly = true;
            this.tbID.Size = new System.Drawing.Size(80, 20);
            this.tbID.TabIndex = 8;
            this.tbID.Text = "1119767714";
            this.tbID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblID
            // 
            this.lblID.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(291, 6);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(18, 13);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID";
            // 
            // lblRevision
            // 
            this.lblRevision.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblRevision.AutoSize = true;
            this.lblRevision.Location = new System.Drawing.Point(254, 32);
            this.lblRevision.Name = "lblRevision";
            this.lblRevision.Size = new System.Drawing.Size(25, 13);
            this.lblRevision.TabIndex = 0;
            this.lblRevision.Text = "rev.";
            this.lblRevision.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbDescription
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.tbDescription, 5);
            this.tbDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDescription.Location = new System.Drawing.Point(3, 81);
            this.tbDescription.MaxLength = 8192;
            this.tbDescription.MinimumSize = new System.Drawing.Size(4, 100);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDescription.Size = new System.Drawing.Size(392, 165);
            this.tbDescription.TabIndex = 10;
            // 
            // tpImage
            // 
            this.tpImage.BackColor = System.Drawing.SystemColors.Control;
            this.tpImage.Controls.Add(this.tableLayoutPanel11);
            this.tpImage.Location = new System.Drawing.Point(4, 22);
            this.tpImage.Name = "tpImage";
            this.tpImage.Padding = new System.Windows.Forms.Padding(3);
            this.tpImage.Size = new System.Drawing.Size(404, 255);
            this.tpImage.TabIndex = 1;
            this.tpImage.Text = "Image";
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.AutoSize = true;
            this.tableLayoutPanel11.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel11.ColumnCount = 1;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel11.Controls.Add(this.tableLayoutPanel12, 0, 1);
            this.tableLayoutPanel11.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 2;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(398, 249);
            this.tableLayoutPanel11.TabIndex = 4;
            // 
            // tableLayoutPanel12
            // 
            this.tableLayoutPanel12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tableLayoutPanel12.AutoSize = true;
            this.tableLayoutPanel12.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel12.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial;
            this.tableLayoutPanel12.ColumnCount = 1;
            this.tableLayoutPanel11.SetColumnSpan(this.tableLayoutPanel12, 4);
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel12.Controls.Add(this.pbImage, 0, 0);
            this.tableLayoutPanel12.Location = new System.Drawing.Point(180, 109);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 1;
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel12.Size = new System.Drawing.Size(38, 38);
            this.tableLayoutPanel12.TabIndex = 10;
            // 
            // pbImage
            // 
            this.pbImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbImage.BackColor = System.Drawing.Color.Bisque;
            this.pbImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbImage.Location = new System.Drawing.Point(3, 3);
            this.pbImage.Margin = new System.Windows.Forms.Padding(0);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(32, 32);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbImage.TabIndex = 1;
            this.pbImage.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel3);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(392, 100);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 5;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.tbImagePath, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblImageType, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.cbbImageType, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblImagePath, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblImageBPP, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.cbbImageBPP, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.btnGetImagePath, 4, 1);
            this.tableLayoutPanel3.Controls.Add(this.btnImageColor, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblImageBackColor, 3, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(386, 83);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // tbImagePath
            // 
            this.tbImagePath.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel3.SetColumnSpan(this.tbImagePath, 3);
            this.tbImagePath.Location = new System.Drawing.Point(73, 31);
            this.tbImagePath.MaxLength = 255;
            this.tbImagePath.Name = "tbImagePath";
            this.tbImagePath.Size = new System.Drawing.Size(281, 20);
            this.tbImagePath.TabIndex = 1;
            // 
            // lblImageType
            // 
            this.lblImageType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblImageType.AutoSize = true;
            this.lblImageType.Location = new System.Drawing.Point(3, 7);
            this.lblImageType.Name = "lblImageType";
            this.lblImageType.Size = new System.Drawing.Size(31, 13);
            this.lblImageType.TabIndex = 0;
            this.lblImageType.Text = "Type";
            // 
            // cbbImageType
            // 
            this.cbbImageType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbbImageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbImageType.FormattingEnabled = true;
            this.cbbImageType.Location = new System.Drawing.Point(73, 3);
            this.cbbImageType.Name = "cbbImageType";
            this.cbbImageType.Size = new System.Drawing.Size(120, 21);
            this.cbbImageType.TabIndex = 6;
            // 
            // lblImagePath
            // 
            this.lblImagePath.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblImagePath.AutoSize = true;
            this.lblImagePath.Location = new System.Drawing.Point(3, 35);
            this.lblImagePath.Name = "lblImagePath";
            this.lblImagePath.Size = new System.Drawing.Size(29, 13);
            this.lblImagePath.TabIndex = 0;
            this.lblImagePath.Text = "Path";
            // 
            // lblImageBPP
            // 
            this.lblImageBPP.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblImageBPP.AutoSize = true;
            this.lblImageBPP.Location = new System.Drawing.Point(3, 63);
            this.lblImageBPP.Name = "lblImageBPP";
            this.lblImageBPP.Size = new System.Drawing.Size(64, 13);
            this.lblImageBPP.TabIndex = 7;
            this.lblImageBPP.Text = "Storing BPP";
            // 
            // cbbImageBPP
            // 
            this.cbbImageBPP.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbbImageBPP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbImageBPP.FormattingEnabled = true;
            this.cbbImageBPP.Items.AddRange(new object[] {
            "32 (ARGB)",
            "24 (RGB)",
            "16 (6r5g5b)",
            "8 (256)",
            "8 (Gray)",
            "4 (16)",
            "4 (Gray)"});
            this.cbbImageBPP.Location = new System.Drawing.Point(73, 59);
            this.cbbImageBPP.Name = "cbbImageBPP";
            this.cbbImageBPP.Size = new System.Drawing.Size(100, 21);
            this.cbbImageBPP.TabIndex = 8;
            // 
            // btnGetImagePath
            // 
            this.btnGetImagePath.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnGetImagePath.Image = global::Schematix.Properties.Resources.load;
            this.btnGetImagePath.Location = new System.Drawing.Point(360, 30);
            this.btnGetImagePath.Name = "btnGetImagePath";
            this.btnGetImagePath.Size = new System.Drawing.Size(23, 23);
            this.btnGetImagePath.TabIndex = 9;
            this.btnGetImagePath.UseVisualStyleBackColor = true;
            this.btnGetImagePath.Click += new System.EventHandler(this.btnGetImagePath_Click);
            // 
            // btnImageColor
            // 
            this.btnImageColor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnImageColor.BackColor = System.Drawing.Color.Bisque;
            this.btnImageColor.Location = new System.Drawing.Point(207, 3);
            this.btnImageColor.Margin = new System.Windows.Forms.Padding(11, 3, 11, 3);
            this.btnImageColor.Name = "btnImageColor";
            this.btnImageColor.Size = new System.Drawing.Size(32, 21);
            this.btnImageColor.TabIndex = 10;
            this.btnImageColor.UseVisualStyleBackColor = false;
            this.btnImageColor.Click += new System.EventHandler(this.btnImageColor_Click);
            // 
            // lblImageBackColor
            // 
            this.lblImageBackColor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel3.SetColumnSpan(this.lblImageBackColor, 2);
            this.lblImageBackColor.Location = new System.Drawing.Point(253, 7);
            this.lblImageBackColor.Name = "lblImageBackColor";
            this.lblImageBackColor.Size = new System.Drawing.Size(113, 13);
            this.lblImageBackColor.TabIndex = 0;
            this.lblImageBackColor.Text = "Back color on preview";
            // 
            // tpAlpha
            // 
            this.tpAlpha.BackColor = System.Drawing.SystemColors.Control;
            this.tpAlpha.Controls.Add(this.tableLayoutPanel10);
            this.tpAlpha.Location = new System.Drawing.Point(4, 22);
            this.tpAlpha.Name = "tpAlpha";
            this.tpAlpha.Padding = new System.Windows.Forms.Padding(3);
            this.tpAlpha.Size = new System.Drawing.Size(404, 255);
            this.tpAlpha.TabIndex = 2;
            this.tpAlpha.Text = "Transparence";
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.AutoSize = true;
            this.tableLayoutPanel10.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel10.ColumnCount = 1;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Controls.Add(this.tableLayoutPanel9, 0, 1);
            this.tableLayoutPanel10.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 2;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(398, 249);
            this.tableLayoutPanel10.TabIndex = 5;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tableLayoutPanel9.AutoSize = true;
            this.tableLayoutPanel9.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel9.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial;
            this.tableLayoutPanel9.ColumnCount = 1;
            this.tableLayoutPanel10.SetColumnSpan(this.tableLayoutPanel9, 4);
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.Controls.Add(this.pbAlpha, 0, 0);
            this.tableLayoutPanel9.Location = new System.Drawing.Point(180, 109);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(38, 38);
            this.tableLayoutPanel9.TabIndex = 9;
            // 
            // pbAlpha
            // 
            this.pbAlpha.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbAlpha.BackColor = System.Drawing.Color.White;
            this.pbAlpha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbAlpha.Location = new System.Drawing.Point(3, 3);
            this.pbAlpha.Margin = new System.Windows.Forms.Padding(0);
            this.pbAlpha.Name = "pbAlpha";
            this.pbAlpha.Size = new System.Drawing.Size(32, 32);
            this.pbAlpha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbAlpha.TabIndex = 1;
            this.pbAlpha.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel8);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(392, 100);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.AutoSize = true;
            this.tableLayoutPanel8.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel8.ColumnCount = 4;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel8.Controls.Add(this.tbAlphaPath, 1, 1);
            this.tableLayoutPanel8.Controls.Add(this.lblAlphaType, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.cbbAlphaType, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.lblAlphaPath, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.btnAlphaColor, 2, 0);
            this.tableLayoutPanel8.Controls.Add(this.btnGetAlphaPath, 3, 1);
            this.tableLayoutPanel8.Controls.Add(this.cbbAlphaBPP, 1, 2);
            this.tableLayoutPanel8.Controls.Add(this.lblAlphaBPP, 0, 2);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 3;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(386, 83);
            this.tableLayoutPanel8.TabIndex = 4;
            // 
            // tbAlphaPath
            // 
            this.tbAlphaPath.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel8.SetColumnSpan(this.tbAlphaPath, 2);
            this.tbAlphaPath.Location = new System.Drawing.Point(73, 31);
            this.tbAlphaPath.MaxLength = 255;
            this.tbAlphaPath.Name = "tbAlphaPath";
            this.tbAlphaPath.Size = new System.Drawing.Size(281, 20);
            this.tbAlphaPath.TabIndex = 1;
            // 
            // lblAlphaType
            // 
            this.lblAlphaType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAlphaType.AutoSize = true;
            this.lblAlphaType.Location = new System.Drawing.Point(3, 7);
            this.lblAlphaType.Name = "lblAlphaType";
            this.lblAlphaType.Size = new System.Drawing.Size(31, 13);
            this.lblAlphaType.TabIndex = 0;
            this.lblAlphaType.Text = "Type";
            // 
            // cbbAlphaType
            // 
            this.cbbAlphaType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbbAlphaType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbAlphaType.FormattingEnabled = true;
            this.cbbAlphaType.Location = new System.Drawing.Point(73, 3);
            this.cbbAlphaType.Name = "cbbAlphaType";
            this.cbbAlphaType.Size = new System.Drawing.Size(120, 21);
            this.cbbAlphaType.TabIndex = 6;
            // 
            // lblAlphaPath
            // 
            this.lblAlphaPath.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAlphaPath.AutoSize = true;
            this.lblAlphaPath.Location = new System.Drawing.Point(3, 35);
            this.lblAlphaPath.Name = "lblAlphaPath";
            this.lblAlphaPath.Size = new System.Drawing.Size(29, 13);
            this.lblAlphaPath.TabIndex = 0;
            this.lblAlphaPath.Text = "Path";
            // 
            // btnAlphaColor
            // 
            this.btnAlphaColor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAlphaColor.BackColor = System.Drawing.Color.White;
            this.btnAlphaColor.Location = new System.Drawing.Point(207, 3);
            this.btnAlphaColor.Margin = new System.Windows.Forms.Padding(11, 3, 11, 3);
            this.btnAlphaColor.Name = "btnAlphaColor";
            this.btnAlphaColor.Size = new System.Drawing.Size(32, 21);
            this.btnAlphaColor.TabIndex = 7;
            this.btnAlphaColor.UseVisualStyleBackColor = false;
            this.btnAlphaColor.Click += new System.EventHandler(this.btnAlphaColor_Click);
            // 
            // btnGetAlphaPath
            // 
            this.btnGetAlphaPath.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnGetAlphaPath.Image = global::Schematix.Properties.Resources.load;
            this.btnGetAlphaPath.Location = new System.Drawing.Point(360, 30);
            this.btnGetAlphaPath.Name = "btnGetAlphaPath";
            this.btnGetAlphaPath.Size = new System.Drawing.Size(23, 23);
            this.btnGetAlphaPath.TabIndex = 8;
            this.btnGetAlphaPath.UseVisualStyleBackColor = true;
            this.btnGetAlphaPath.Click += new System.EventHandler(this.btnGetAlphaImage_Click);
            // 
            // cbbAlphaBPP
            // 
            this.cbbAlphaBPP.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbbAlphaBPP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbAlphaBPP.FormattingEnabled = true;
            this.cbbAlphaBPP.Items.AddRange(new object[] {
            "8",
            "4",
            "2",
            "1"});
            this.cbbAlphaBPP.Location = new System.Drawing.Point(73, 59);
            this.cbbAlphaBPP.Name = "cbbAlphaBPP";
            this.cbbAlphaBPP.Size = new System.Drawing.Size(100, 21);
            this.cbbAlphaBPP.TabIndex = 6;
            // 
            // lblAlphaBPP
            // 
            this.lblAlphaBPP.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAlphaBPP.AutoSize = true;
            this.lblAlphaBPP.Location = new System.Drawing.Point(3, 63);
            this.lblAlphaBPP.Name = "lblAlphaBPP";
            this.lblAlphaBPP.Size = new System.Drawing.Size(64, 13);
            this.lblAlphaBPP.TabIndex = 0;
            this.lblAlphaBPP.Text = "Storing BPP";
            // 
            // tpDotes
            // 
            this.tpDotes.BackColor = System.Drawing.SystemColors.Control;
            this.tpDotes.Controls.Add(this.tableLayoutPanel5);
            this.tpDotes.Location = new System.Drawing.Point(4, 22);
            this.tpDotes.Name = "tpDotes";
            this.tpDotes.Padding = new System.Windows.Forms.Padding(3);
            this.tpDotes.Size = new System.Drawing.Size(404, 255);
            this.tpDotes.TabIndex = 3;
            this.tpDotes.Text = "Dotes";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(398, 249);
            this.tableLayoutPanel5.TabIndex = 5;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial;
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.pbDotPicker, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(180, 184);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(38, 38);
            this.tableLayoutPanel4.TabIndex = 4;
            // 
            // pbDotPicker
            // 
            this.pbDotPicker.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbDotPicker.BackColor = System.Drawing.Color.Bisque;
            this.pbDotPicker.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbDotPicker.Location = new System.Drawing.Point(3, 3);
            this.pbDotPicker.Margin = new System.Windows.Forms.Padding(0);
            this.pbDotPicker.Name = "pbDotPicker";
            this.pbDotPicker.Size = new System.Drawing.Size(32, 32);
            this.pbDotPicker.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbDotPicker.TabIndex = 1;
            this.pbDotPicker.TabStop = false;
            this.pbDotPicker.BackgroundImageChanged += new System.EventHandler(this.pbNodePicker_BackgroundImageChanged);
            this.pbDotPicker.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pbNodePicker_MouseDoubleClick);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 5;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.Controls.Add(this.btnDotAdd, 4, 0);
            this.tableLayoutPanel6.Controls.Add(this.cbbDotes, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.lblDot, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnDotMoveUp, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnDotMoveDown, 3, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(392, 29);
            this.tableLayoutPanel6.TabIndex = 8;
            // 
            // btnDotAdd
            // 
            this.btnDotAdd.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDotAdd.Image = global::Schematix.Properties.Resources.plus;
            this.btnDotAdd.Location = new System.Drawing.Point(366, 3);
            this.btnDotAdd.Name = "btnDotAdd";
            this.btnDotAdd.Size = new System.Drawing.Size(23, 23);
            this.btnDotAdd.TabIndex = 8;
            this.btnDotAdd.UseVisualStyleBackColor = true;
            this.btnDotAdd.Click += new System.EventHandler(this.btnNodeAdd_Click);
            // 
            // cbbDotes
            // 
            this.cbbDotes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbDotes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbDotes.FormattingEnabled = true;
            this.cbbDotes.Location = new System.Drawing.Point(33, 4);
            this.cbbDotes.Name = "cbbDotes";
            this.cbbDotes.Size = new System.Drawing.Size(269, 21);
            this.cbbDotes.TabIndex = 7;
            this.cbbDotes.SelectedIndexChanged += new System.EventHandler(this.cbbNodes_SelectedIndexChanged);
            // 
            // lblDot
            // 
            this.lblDot.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDot.AutoSize = true;
            this.lblDot.Location = new System.Drawing.Point(3, 8);
            this.lblDot.Name = "lblDot";
            this.lblDot.Size = new System.Drawing.Size(24, 13);
            this.lblDot.TabIndex = 1;
            this.lblDot.Text = "Dot";
            // 
            // btnDotMoveUp
            // 
            this.btnDotMoveUp.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDotMoveUp.Image = global::Schematix.Properties.Resources.MoveUp;
            this.btnDotMoveUp.Location = new System.Drawing.Point(308, 3);
            this.btnDotMoveUp.Name = "btnDotMoveUp";
            this.btnDotMoveUp.Size = new System.Drawing.Size(23, 23);
            this.btnDotMoveUp.TabIndex = 8;
            this.btnDotMoveUp.UseVisualStyleBackColor = true;
            this.btnDotMoveUp.Click += new System.EventHandler(this.btnNodeMoveUp_Click);
            // 
            // btnDotMoveDown
            // 
            this.btnDotMoveDown.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnDotMoveDown.Image = global::Schematix.Properties.Resources.MoveDown;
            this.btnDotMoveDown.Location = new System.Drawing.Point(337, 3);
            this.btnDotMoveDown.Name = "btnDotMoveDown";
            this.btnDotMoveDown.Size = new System.Drawing.Size(23, 23);
            this.btnDotMoveDown.TabIndex = 8;
            this.btnDotMoveDown.UseVisualStyleBackColor = true;
            this.btnDotMoveDown.Click += new System.EventHandler(this.btnNodeMoveDown_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.tableLayoutPanel7);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 140);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.AutoSize = true;
            this.tableLayoutPanel7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel7.ColumnCount = 6;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.Controls.Add(this.tbDotDescription, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.tbDotName, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.nudDotY, 5, 2);
            this.tableLayoutPanel7.Controls.Add(this.nudDotX, 3, 2);
            this.tableLayoutPanel7.Controls.Add(this.lblDotLocation, 2, 2);
            this.tableLayoutPanel7.Controls.Add(this.lblDotName, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.label1, 4, 2);
            this.tableLayoutPanel7.Controls.Add(this.btnDotDelete, 1, 2);
            this.tableLayoutPanel7.Controls.Add(this.btnDotSave, 0, 2);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 3;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.Size = new System.Drawing.Size(386, 121);
            this.tableLayoutPanel7.TabIndex = 0;
            // 
            // tbDotDescription
            // 
            this.tableLayoutPanel7.SetColumnSpan(this.tbDotDescription, 6);
            this.tbDotDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDotDescription.Location = new System.Drawing.Point(3, 29);
            this.tbDotDescription.MaxLength = 4096;
            this.tbDotDescription.Multiline = true;
            this.tbDotDescription.Name = "tbDotDescription";
            this.tbDotDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDotDescription.Size = new System.Drawing.Size(380, 60);
            this.tbDotDescription.TabIndex = 11;
            this.tbDotDescription.TextChanged += new System.EventHandler(this.Node_TextChanged);
            // 
            // tbDotName
            // 
            this.tbDotName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel7.SetColumnSpan(this.tbDotName, 5);
            this.tbDotName.Location = new System.Drawing.Point(44, 3);
            this.tbDotName.MaxLength = 255;
            this.tbDotName.Name = "tbDotName";
            this.tbDotName.Size = new System.Drawing.Size(339, 20);
            this.tbDotName.TabIndex = 2;
            this.tbDotName.TextChanged += new System.EventHandler(this.Node_TextChanged);
            // 
            // nudDotY
            // 
            this.nudDotY.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudDotY.Location = new System.Drawing.Point(333, 96);
            this.nudDotY.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudDotY.Name = "nudDotY";
            this.nudDotY.Size = new System.Drawing.Size(50, 20);
            this.nudDotY.TabIndex = 12;
            this.nudDotY.ValueChanged += new System.EventHandler(this.nudNodeXY_ValueChanged);
            // 
            // nudDotX
            // 
            this.nudDotX.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudDotX.Location = new System.Drawing.Point(247, 96);
            this.nudDotX.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudDotX.Name = "nudDotX";
            this.nudDotX.Size = new System.Drawing.Size(50, 20);
            this.nudDotX.TabIndex = 12;
            this.nudDotX.ValueChanged += new System.EventHandler(this.nudNodeXY_ValueChanged);
            // 
            // lblDotLocation
            // 
            this.lblDotLocation.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblDotLocation.AutoSize = true;
            this.lblDotLocation.Location = new System.Drawing.Point(193, 100);
            this.lblDotLocation.Name = "lblDotLocation";
            this.lblDotLocation.Size = new System.Drawing.Size(48, 13);
            this.lblDotLocation.TabIndex = 1;
            this.lblDotLocation.Text = "Location";
            // 
            // lblDotName
            // 
            this.lblDotName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDotName.AutoSize = true;
            this.lblDotName.Location = new System.Drawing.Point(3, 6);
            this.lblDotName.Name = "lblDotName";
            this.lblDotName.Size = new System.Drawing.Size(35, 13);
            this.lblDotName.TabIndex = 1;
            this.lblDotName.Text = "Name";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(303, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "X:Y";
            // 
            // btnDotDelete
            // 
            this.btnDotDelete.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnDotDelete.Image = global::Schematix.Properties.Resources.delete;
            this.btnDotDelete.Location = new System.Drawing.Point(44, 95);
            this.btnDotDelete.Name = "btnDotDelete";
            this.btnDotDelete.Size = new System.Drawing.Size(23, 23);
            this.btnDotDelete.TabIndex = 8;
            this.btnDotDelete.UseVisualStyleBackColor = true;
            this.btnDotDelete.Click += new System.EventHandler(this.btnNodeDelete_Click);
            // 
            // btnDotSave
            // 
            this.btnDotSave.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnDotSave.Enabled = false;
            this.btnDotSave.Image = global::Schematix.Properties.Resources.save;
            this.btnDotSave.Location = new System.Drawing.Point(3, 95);
            this.btnDotSave.Name = "btnDotSave";
            this.btnDotSave.Size = new System.Drawing.Size(23, 23);
            this.btnDotSave.TabIndex = 8;
            this.btnDotSave.UseVisualStyleBackColor = true;
            this.btnDotSave.EnabledChanged += new System.EventHandler(this.btnNodeSave_EnabledChanged);
            this.btnDotSave.Click += new System.EventHandler(this.btnNodeSave_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnOk, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tabControl, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 8);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(418, 316);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOk.Location = new System.Drawing.Point(171, 290);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // dlgOpen
            // 
            this.dlgOpen.SupportMultiDottedExtensions = true;
            // 
            // chkPrototype
            // 
            this.chkPrototype.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkPrototype.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.chkPrototype, 2);
            this.chkPrototype.Location = new System.Drawing.Point(3, 30);
            this.chkPrototype.Name = "chkPrototype";
            this.chkPrototype.Size = new System.Drawing.Size(71, 17);
            this.chkPrototype.TabIndex = 11;
            this.chkPrototype.Text = "Prototype";
            this.chkPrototype.UseVisualStyleBackColor = true;
            // 
            // ObjectEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(434, 332);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(570, 810);
            this.MinimumSize = new System.Drawing.Size(450, 370);
            this.Name = "ObjectEditForm";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit object";
            this.tabControl.ResumeLayout(false);
            this.tpMain.ResumeLayout(false);
            this.tpMain.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tpImage.ResumeLayout(false);
            this.tpImage.PerformLayout();
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel11.PerformLayout();
            this.tableLayoutPanel12.ResumeLayout(false);
            this.tableLayoutPanel12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tpAlpha.ResumeLayout(false);
            this.tpAlpha.PerformLayout();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAlpha)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tpDotes.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDotPicker)).EndInit();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDotY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDotX)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpMain;
        private System.Windows.Forms.TabPage tpImage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TabPage tpAlpha;
        private System.Windows.Forms.TabPage tpDotes;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lblNode;
        private System.Windows.Forms.TextBox tbNode;
        private System.Windows.Forms.TextBox tbRevision;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblRevision;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lblImagePath;
        private System.Windows.Forms.TextBox tbImagePath;
        private System.Windows.Forms.Label lblImageType;
        private System.Windows.Forms.ComboBox cbbImageType;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.ComboBox cbbDotes;
        private System.Windows.Forms.Label lblDot;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button btnDotAdd;
        private System.Windows.Forms.Button btnDotMoveUp;
        private System.Windows.Forms.Button btnDotMoveDown;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Label lblDotName;
        private System.Windows.Forms.TextBox tbDotName;
        private System.Windows.Forms.TextBox tbDotDescription;
        private System.Windows.Forms.NumericUpDown nudDotY;
        private System.Windows.Forms.NumericUpDown nudDotX;
        private System.Windows.Forms.Label lblDotLocation;
        private System.Windows.Forms.Button btnDotDelete;
        private System.Windows.Forms.PictureBox pbDotPicker;
        private System.Windows.Forms.Button btnDotSave;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.TextBox tbAlphaPath;
        private System.Windows.Forms.Label lblAlphaType;
        private System.Windows.Forms.ComboBox cbbAlphaType;
        private System.Windows.Forms.Label lblAlphaPath;
        private System.Windows.Forms.Button btnAlphaColor;
        private System.Windows.Forms.Button btnGetAlphaPath;
        private System.Windows.Forms.Label lblAlphaBPP;
        private System.Windows.Forms.ComboBox cbbAlphaBPP;
        private System.Windows.Forms.OpenFileDialog dlgOpen;
        private System.Windows.Forms.ColorDialog dlgColor;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label lblImageBPP;
        private System.Windows.Forms.ComboBox cbbImageBPP;
        private System.Windows.Forms.Button btnGetImagePath;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel12;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.PictureBox pbAlpha;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnImageColor;
        private System.Windows.Forms.Label lblImageBackColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkPrototype;
    }
}