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
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbType = new System.Windows.Forms.ComboBox();
            this.tpAlpha = new System.Windows.Forms.TabPage();
            this.tapNodes = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbNodeDot = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.pbNodePicker = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.cbbNodes = new System.Windows.Forms.ComboBox();
            this.lblNodes = new System.Windows.Forms.Label();
            this.btnNodeMoveUp = new System.Windows.Forms.Button();
            this.btnNodeMoveDown = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.btnNodeAdd = new System.Windows.Forms.Button();
            this.tbNodeDescription = new System.Windows.Forms.TextBox();
            this.lblNodeName = new System.Windows.Forms.Label();
            this.tbNodeName = new System.Windows.Forms.TextBox();
            this.nudNodeY = new System.Windows.Forms.NumericUpDown();
            this.nudNodeX = new System.Windows.Forms.NumericUpDown();
            this.lblLocation = new System.Windows.Forms.Label();
            this.chkNodeGetXY = new System.Windows.Forms.CheckBox();
            this.btnNodeDelete = new System.Windows.Forms.Button();
            this.btnNodeSave = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnOk = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tpMain.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tpImage.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tapNodes.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbNodeDot)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbNodePicker)).BeginInit();
            this.tableLayoutPanel6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNodeY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNodeX)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpMain);
            this.tabControl.Controls.Add(this.tpImage);
            this.tabControl.Controls.Add(this.tpAlpha);
            this.tabControl.Controls.Add(this.tapNodes);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(3, 3);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(428, 327);
            this.tabControl.TabIndex = 0;
            // 
            // tpMain
            // 
            this.tpMain.BackColor = System.Drawing.SystemColors.Control;
            this.tpMain.Controls.Add(this.tableLayoutPanel2);
            this.tpMain.Location = new System.Drawing.Point(4, 22);
            this.tpMain.Name = "tpMain";
            this.tpMain.Padding = new System.Windows.Forms.Padding(3);
            this.tpMain.Size = new System.Drawing.Size(420, 301);
            this.tpMain.TabIndex = 0;
            this.tpMain.Text = "Main";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.lblName, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.tbName, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblNode, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tbNode, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tbRevision, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.tbID, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblID, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblRevision, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.tbDescription, 0, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(414, 184);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // lblName
            // 
            this.lblName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(3, 58);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(52, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Full name";
            // 
            // tbName
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.tbName, 3);
            this.tbName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbName.Location = new System.Drawing.Point(71, 55);
            this.tbName.MaxLength = 255;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(340, 20);
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
            this.tbNode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbNode.Location = new System.Drawing.Point(71, 3);
            this.tbNode.MaxLength = 32;
            this.tbNode.Name = "tbNode";
            this.tbNode.Size = new System.Drawing.Size(224, 20);
            this.tbNode.TabIndex = 0;
            // 
            // tbRevision
            // 
            this.tbRevision.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tbRevision.BackColor = System.Drawing.Color.OldLace;
            this.tableLayoutPanel2.SetColumnSpan(this.tbRevision, 2);
            this.tbRevision.Location = new System.Drawing.Point(301, 29);
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
            this.tbID.Location = new System.Drawing.Point(331, 3);
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
            this.lblID.Location = new System.Drawing.Point(307, 6);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(18, 13);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID";
            // 
            // lblRevision
            // 
            this.lblRevision.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblRevision.AutoSize = true;
            this.lblRevision.Location = new System.Drawing.Point(270, 32);
            this.lblRevision.Name = "lblRevision";
            this.lblRevision.Size = new System.Drawing.Size(25, 13);
            this.lblRevision.TabIndex = 0;
            this.lblRevision.Text = "rev.";
            this.lblRevision.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbDescription
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.tbDescription, 4);
            this.tbDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDescription.Location = new System.Drawing.Point(3, 81);
            this.tbDescription.MaxLength = 8192;
            this.tbDescription.MinimumSize = new System.Drawing.Size(4, 100);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDescription.Size = new System.Drawing.Size(408, 100);
            this.tbDescription.TabIndex = 10;
            // 
            // tpImage
            // 
            this.tpImage.BackColor = System.Drawing.SystemColors.Control;
            this.tpImage.Controls.Add(this.tableLayoutPanel3);
            this.tpImage.Location = new System.Drawing.Point(4, 22);
            this.tpImage.Name = "tpImage";
            this.tpImage.Padding = new System.Windows.Forms.Padding(3);
            this.tpImage.Size = new System.Drawing.Size(420, 301);
            this.tpImage.TabIndex = 1;
            this.tpImage.Text = "Image";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 71F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.textBox1, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.cbbType, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(414, 277);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Full name";
            // 
            // textBox1
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.textBox1, 3);
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(90, 47);
            this.textBox1.MaxLength = 255;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(321, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Node name";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(322, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "ID";
            // 
            // cbbType
            // 
            this.cbbType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbType.FormattingEnabled = true;
            this.cbbType.Location = new System.Drawing.Point(90, 3);
            this.cbbType.Name = "cbbType";
            this.cbbType.Size = new System.Drawing.Size(66, 21);
            this.cbbType.TabIndex = 6;
            // 
            // tpAlpha
            // 
            this.tpAlpha.BackColor = System.Drawing.SystemColors.Control;
            this.tpAlpha.Location = new System.Drawing.Point(4, 22);
            this.tpAlpha.Name = "tpAlpha";
            this.tpAlpha.Padding = new System.Windows.Forms.Padding(3);
            this.tpAlpha.Size = new System.Drawing.Size(420, 301);
            this.tpAlpha.TabIndex = 2;
            this.tpAlpha.Text = "Transparence";
            // 
            // tapNodes
            // 
            this.tapNodes.BackColor = System.Drawing.SystemColors.Control;
            this.tapNodes.Controls.Add(this.tableLayoutPanel5);
            this.tapNodes.Location = new System.Drawing.Point(4, 22);
            this.tapNodes.Name = "tapNodes";
            this.tapNodes.Padding = new System.Windows.Forms.Padding(3);
            this.tapNodes.Size = new System.Drawing.Size(420, 301);
            this.tapNodes.TabIndex = 3;
            this.tapNodes.Text = "Nodes";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.Size = new System.Drawing.Size(414, 259);
            this.tableLayoutPanel5.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.pbNodeDot);
            this.panel1.Controls.Add(this.tableLayoutPanel4);
            this.panel1.Location = new System.Drawing.Point(188, 218);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(38, 38);
            this.panel1.TabIndex = 6;
            // 
            // pbNodeDot
            // 
            this.pbNodeDot.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbNodeDot.BackColor = System.Drawing.Color.Transparent;
            this.pbNodeDot.Image = global::Schematix.Properties.Resources.dot_5x5_24a;
            this.pbNodeDot.Location = new System.Drawing.Point(1, 1);
            this.pbNodeDot.Margin = new System.Windows.Forms.Padding(0);
            this.pbNodeDot.Name = "pbNodeDot";
            this.pbNodeDot.Size = new System.Drawing.Size(5, 5);
            this.pbNodeDot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbNodeDot.TabIndex = 5;
            this.pbNodeDot.TabStop = false;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial;
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.pbNodePicker, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(38, 38);
            this.tableLayoutPanel4.TabIndex = 4;
            // 
            // pbNodePicker
            // 
            this.pbNodePicker.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbNodePicker.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbNodePicker.Location = new System.Drawing.Point(3, 3);
            this.pbNodePicker.Margin = new System.Windows.Forms.Padding(0);
            this.pbNodePicker.Name = "pbNodePicker";
            this.pbNodePicker.Size = new System.Drawing.Size(32, 32);
            this.pbNodePicker.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbNodePicker.TabIndex = 1;
            this.pbNodePicker.TabStop = false;
            this.pbNodePicker.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbNodePicker_MouseDown);
            this.pbNodePicker.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbNodePicker_MouseMove);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.AutoSize = true;
            this.tableLayoutPanel6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel6.ColumnCount = 4;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.Controls.Add(this.cbbNodes, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.lblNodes, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnNodeMoveUp, 2, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnNodeMoveDown, 3, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(408, 30);
            this.tableLayoutPanel6.TabIndex = 8;
            // 
            // cbbNodes
            // 
            this.cbbNodes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbNodes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbNodes.FormattingEnabled = true;
            this.cbbNodes.Location = new System.Drawing.Point(47, 4);
            this.cbbNodes.Name = "cbbNodes";
            this.cbbNodes.Size = new System.Drawing.Size(298, 21);
            this.cbbNodes.TabIndex = 7;
            this.cbbNodes.SelectedIndexChanged += new System.EventHandler(this.cbbNodes_SelectedIndexChanged);
            // 
            // lblNodes
            // 
            this.lblNodes.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNodes.AutoSize = true;
            this.lblNodes.Location = new System.Drawing.Point(3, 8);
            this.lblNodes.Name = "lblNodes";
            this.lblNodes.Size = new System.Drawing.Size(38, 13);
            this.lblNodes.TabIndex = 1;
            this.lblNodes.Text = "Nodes";
            // 
            // btnNodeMoveUp
            // 
            this.btnNodeMoveUp.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnNodeMoveUp.Image = global::Schematix.Properties.Resources.MoveUp;
            this.btnNodeMoveUp.Location = new System.Drawing.Point(351, 3);
            this.btnNodeMoveUp.Name = "btnNodeMoveUp";
            this.btnNodeMoveUp.Size = new System.Drawing.Size(24, 24);
            this.btnNodeMoveUp.TabIndex = 8;
            this.btnNodeMoveUp.UseVisualStyleBackColor = true;
            this.btnNodeMoveUp.Click += new System.EventHandler(this.btnNodeMoveUp_Click);
            // 
            // btnNodeMoveDown
            // 
            this.btnNodeMoveDown.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnNodeMoveDown.Image = global::Schematix.Properties.Resources.MoveDown;
            this.btnNodeMoveDown.Location = new System.Drawing.Point(381, 3);
            this.btnNodeMoveDown.Name = "btnNodeMoveDown";
            this.btnNodeMoveDown.Size = new System.Drawing.Size(24, 24);
            this.btnNodeMoveDown.TabIndex = 8;
            this.btnNodeMoveDown.UseVisualStyleBackColor = true;
            this.btnNodeMoveDown.Click += new System.EventHandler(this.btnNodeMoveDown_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel7);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(408, 173);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel7.ColumnCount = 6;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.Controls.Add(this.btnNodeAdd, 1, 2);
            this.tableLayoutPanel7.Controls.Add(this.tbNodeDescription, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.lblNodeName, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.tbNodeName, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.nudNodeY, 5, 2);
            this.tableLayoutPanel7.Controls.Add(this.nudNodeX, 3, 2);
            this.tableLayoutPanel7.Controls.Add(this.lblLocation, 2, 2);
            this.tableLayoutPanel7.Controls.Add(this.chkNodeGetXY, 4, 2);
            this.tableLayoutPanel7.Controls.Add(this.btnNodeDelete, 0, 2);
            this.tableLayoutPanel7.Controls.Add(this.btnNodeSave, 5, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 3;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.Size = new System.Drawing.Size(402, 154);
            this.tableLayoutPanel7.TabIndex = 0;
            // 
            // btnNodeAdd
            // 
            this.btnNodeAdd.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnNodeAdd.Image = global::Schematix.Properties.Resources.plus;
            this.btnNodeAdd.Location = new System.Drawing.Point(44, 127);
            this.btnNodeAdd.Name = "btnNodeAdd";
            this.btnNodeAdd.Size = new System.Drawing.Size(24, 24);
            this.btnNodeAdd.TabIndex = 8;
            this.btnNodeAdd.UseVisualStyleBackColor = true;
            this.btnNodeAdd.Click += new System.EventHandler(this.btnNodeAdd_Click);
            // 
            // tbNodeDescription
            // 
            this.tableLayoutPanel7.SetColumnSpan(this.tbNodeDescription, 6);
            this.tbNodeDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbNodeDescription.Location = new System.Drawing.Point(3, 33);
            this.tbNodeDescription.MaxLength = 8096;
            this.tbNodeDescription.MinimumSize = new System.Drawing.Size(4, 10);
            this.tbNodeDescription.Multiline = true;
            this.tbNodeDescription.Name = "tbNodeDescription";
            this.tbNodeDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbNodeDescription.Size = new System.Drawing.Size(396, 88);
            this.tbNodeDescription.TabIndex = 11;
            this.tbNodeDescription.TextChanged += new System.EventHandler(this.Node_TextChanged);
            // 
            // lblNodeName
            // 
            this.lblNodeName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNodeName.AutoSize = true;
            this.lblNodeName.Location = new System.Drawing.Point(3, 8);
            this.lblNodeName.Name = "lblNodeName";
            this.lblNodeName.Size = new System.Drawing.Size(35, 13);
            this.lblNodeName.TabIndex = 1;
            this.lblNodeName.Text = "Name";
            // 
            // tbNodeName
            // 
            this.tbNodeName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel7.SetColumnSpan(this.tbNodeName, 4);
            this.tbNodeName.Location = new System.Drawing.Point(44, 5);
            this.tbNodeName.MaxLength = 255;
            this.tbNodeName.Name = "tbNodeName";
            this.tbNodeName.Size = new System.Drawing.Size(299, 20);
            this.tbNodeName.TabIndex = 2;
            this.tbNodeName.TextChanged += new System.EventHandler(this.Node_TextChanged);
            // 
            // nudNodeY
            // 
            this.nudNodeY.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudNodeY.Location = new System.Drawing.Point(349, 129);
            this.nudNodeY.Name = "nudNodeY";
            this.nudNodeY.Size = new System.Drawing.Size(50, 20);
            this.nudNodeY.TabIndex = 12;
            this.nudNodeY.ValueChanged += new System.EventHandler(this.nudNodeXY_ValueChanged);
            // 
            // nudNodeX
            // 
            this.nudNodeX.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudNodeX.Location = new System.Drawing.Point(247, 129);
            this.nudNodeX.Name = "nudNodeX";
            this.nudNodeX.Size = new System.Drawing.Size(50, 20);
            this.nudNodeX.TabIndex = 12;
            this.nudNodeX.ValueChanged += new System.EventHandler(this.nudNodeXY_ValueChanged);
            // 
            // lblLocation
            // 
            this.lblLocation.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(193, 132);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(48, 13);
            this.lblLocation.TabIndex = 1;
            this.lblLocation.Text = "Location";
            // 
            // chkNodeGetXY
            // 
            this.chkNodeGetXY.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkNodeGetXY.AutoSize = true;
            this.chkNodeGetXY.Location = new System.Drawing.Point(303, 127);
            this.chkNodeGetXY.Name = "chkNodeGetXY";
            this.chkNodeGetXY.Size = new System.Drawing.Size(40, 23);
            this.chkNodeGetXY.TabIndex = 14;
            this.chkNodeGetXY.Text = "X : Y";
            this.chkNodeGetXY.UseVisualStyleBackColor = true;
            this.chkNodeGetXY.CheckedChanged += new System.EventHandler(this.chkNodeGetXY_CheckedChanged);
            // 
            // btnNodeDelete
            // 
            this.btnNodeDelete.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnNodeDelete.Image = global::Schematix.Properties.Resources.delete;
            this.btnNodeDelete.Location = new System.Drawing.Point(3, 127);
            this.btnNodeDelete.Name = "btnNodeDelete";
            this.btnNodeDelete.Size = new System.Drawing.Size(24, 24);
            this.btnNodeDelete.TabIndex = 8;
            this.btnNodeDelete.UseVisualStyleBackColor = true;
            this.btnNodeDelete.Click += new System.EventHandler(this.btnNodeDelete_Click);
            // 
            // btnNodeSave
            // 
            this.btnNodeSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnNodeSave.Enabled = false;
            this.btnNodeSave.Image = global::Schematix.Properties.Resources.save;
            this.btnNodeSave.Location = new System.Drawing.Point(375, 3);
            this.btnNodeSave.Name = "btnNodeSave";
            this.btnNodeSave.Size = new System.Drawing.Size(24, 24);
            this.btnNodeSave.TabIndex = 8;
            this.btnNodeSave.UseVisualStyleBackColor = true;
            this.btnNodeSave.Click += new System.EventHandler(this.btnNodeSave_Click);
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(434, 362);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOk.Location = new System.Drawing.Point(179, 336);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // ObjectEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(434, 362);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(450, 400);
            this.Name = "ObjectEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ObjectEditForm";
            this.tabControl.ResumeLayout(false);
            this.tpMain.ResumeLayout(false);
            this.tpMain.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tpImage.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tapNodes.ResumeLayout(false);
            this.tapNodes.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbNodeDot)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbNodePicker)).EndInit();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNodeY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNodeX)).EndInit();
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
        private System.Windows.Forms.TabPage tapNodes;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbType;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.ComboBox cbbNodes;
        private System.Windows.Forms.Label lblNodes;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button btnNodeAdd;
        private System.Windows.Forms.Button btnNodeMoveUp;
        private System.Windows.Forms.Button btnNodeMoveDown;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Label lblNodeName;
        private System.Windows.Forms.TextBox tbNodeName;
        private System.Windows.Forms.TextBox tbNodeDescription;
        private System.Windows.Forms.NumericUpDown nudNodeY;
        private System.Windows.Forms.NumericUpDown nudNodeX;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Button btnNodeDelete;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbNodeDot;
        private System.Windows.Forms.PictureBox pbNodePicker;
        private System.Windows.Forms.CheckBox chkNodeGetXY;
        private System.Windows.Forms.Button btnNodeSave;
    }
}