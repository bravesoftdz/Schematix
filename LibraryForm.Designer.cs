namespace Schematix
{
    partial class LibraryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LibraryForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblObjectsCatalog = new System.Windows.Forms.Label();
            this.tvObjects = new System.Windows.Forms.TreeView();
            this.btnObjectEdit = new System.Windows.Forms.Button();
            this.btnObjectAdd = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lblUsedObjects = new System.Windows.Forms.Label();
            this.lvObjects = new System.Windows.Forms.ListView();
            this.clmObjectName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmObjectLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnUsedObjectEdit = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tvLinks = new System.Windows.Forms.TreeView();
            this.lblLinksCatalog = new System.Windows.Forms.Label();
            this.btnLinkEdit = new System.Windows.Forms.Button();
            this.btnLinkAdd = new System.Windows.Forms.Button();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.lblUsedLinks = new System.Windows.Forms.Label();
            this.lvLinks = new System.Windows.Forms.ListView();
            this.clmLinkName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmLinkLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnUsedLinkEdit = new System.Windows.Forms.Button();
            this.tcCatalog = new System.Windows.Forms.TabControl();
            this.tpObjects = new System.Windows.Forms.TabPage();
            this.tpLinks = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tpBoxes = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tvBoxes = new System.Windows.Forms.TreeView();
            this.lblBoxesCatalog = new System.Windows.Forms.Label();
            this.btnBoxEdit = new System.Windows.Forms.Button();
            this.btnBoxAdd = new System.Windows.Forms.Button();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.lblUsedBoxes = new System.Windows.Forms.Label();
            this.lvBoxes = new System.Windows.Forms.ListView();
            this.clmBoxName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmBoxLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnUsedBoxEdit = new System.Windows.Forms.Button();
            this.imageListTab = new System.Windows.Forms.ImageList(this.components);
            this.chkPin = new System.Windows.Forms.CheckBox();
            this.imageListPin = new System.Windows.Forms.ImageList(this.components);
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tcCatalog.SuspendLayout();
            this.tpObjects.SuspendLayout();
            this.tpLinks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tpBoxes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel1MinSize = 100;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel4);
            this.splitContainer1.Panel2MinSize = 100;
            this.splitContainer1.Size = new System.Drawing.Size(261, 222);
            this.splitContainer1.SplitterDistance = 118;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lblObjectsCatalog, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tvObjects, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnObjectEdit, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnObjectAdd, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(261, 118);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lblObjectsCatalog
            // 
            this.lblObjectsCatalog.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblObjectsCatalog.AutoSize = true;
            this.lblObjectsCatalog.Location = new System.Drawing.Point(3, 6);
            this.lblObjectsCatalog.Name = "lblObjectsCatalog";
            this.lblObjectsCatalog.Size = new System.Drawing.Size(43, 13);
            this.lblObjectsCatalog.TabIndex = 2;
            this.lblObjectsCatalog.Text = "Catalog";
            // 
            // tvObjects
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tvObjects, 3);
            this.tvObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvObjects.HideSelection = false;
            this.tvObjects.Location = new System.Drawing.Point(3, 28);
            this.tvObjects.Name = "tvObjects";
            this.tvObjects.Size = new System.Drawing.Size(255, 87);
            this.tvObjects.TabIndex = 0;
            this.tvObjects.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvObjects_AfterSelect);
            this.tvObjects.DoubleClick += new System.EventHandler(this.btnObjectEdit_Click);
            // 
            // btnObjectEdit
            // 
            this.btnObjectEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnObjectEdit.Enabled = false;
            this.btnObjectEdit.Image = global::Schematix.Properties.Resources.edit;
            this.btnObjectEdit.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnObjectEdit.Location = new System.Drawing.Point(204, 0);
            this.btnObjectEdit.Margin = new System.Windows.Forms.Padding(3, 0, 3, 1);
            this.btnObjectEdit.Name = "btnObjectEdit";
            this.btnObjectEdit.Size = new System.Drawing.Size(24, 24);
            this.btnObjectEdit.TabIndex = 4;
            this.btnObjectEdit.UseVisualStyleBackColor = true;
            this.btnObjectEdit.Click += new System.EventHandler(this.btnObjectEdit_Click);
            // 
            // btnObjectAdd
            // 
            this.btnObjectAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnObjectAdd.Image = global::Schematix.Properties.Resources.plus;
            this.btnObjectAdd.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnObjectAdd.Location = new System.Drawing.Point(234, 0);
            this.btnObjectAdd.Margin = new System.Windows.Forms.Padding(3, 0, 3, 1);
            this.btnObjectAdd.Name = "btnObjectAdd";
            this.btnObjectAdd.Size = new System.Drawing.Size(24, 24);
            this.btnObjectAdd.TabIndex = 4;
            this.btnObjectAdd.UseVisualStyleBackColor = true;
            this.btnObjectAdd.Click += new System.EventHandler(this.btnObjectAdd_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.lblUsedObjects, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.lvObjects, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.btnUsedObjectEdit, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(261, 100);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // lblUsedObjects
            // 
            this.lblUsedObjects.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblUsedObjects.AutoSize = true;
            this.lblUsedObjects.Location = new System.Drawing.Point(3, 2);
            this.lblUsedObjects.MinimumSize = new System.Drawing.Size(0, 21);
            this.lblUsedObjects.Name = "lblUsedObjects";
            this.lblUsedObjects.Size = new System.Drawing.Size(70, 21);
            this.lblUsedObjects.TabIndex = 2;
            this.lblUsedObjects.Text = "Used on map";
            this.lblUsedObjects.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lvObjects
            // 
            this.lvObjects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmObjectName,
            this.clmObjectLocation});
            this.tableLayoutPanel4.SetColumnSpan(this.lvObjects, 2);
            this.lvObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvObjects.FullRowSelect = true;
            this.lvObjects.HideSelection = false;
            this.lvObjects.Location = new System.Drawing.Point(3, 28);
            this.lvObjects.MultiSelect = false;
            this.lvObjects.Name = "lvObjects";
            this.lvObjects.Size = new System.Drawing.Size(255, 69);
            this.lvObjects.TabIndex = 1;
            this.lvObjects.UseCompatibleStateImageBehavior = false;
            this.lvObjects.View = System.Windows.Forms.View.Details;
            this.lvObjects.SelectedIndexChanged += new System.EventHandler(this.lvObjects_SelectedIndexChanged);
            this.lvObjects.DoubleClick += new System.EventHandler(this.btnUsedObjectEdit_Click);
            // 
            // clmObjectName
            // 
            this.clmObjectName.Text = "Name";
            this.clmObjectName.Width = 150;
            // 
            // clmObjectLocation
            // 
            this.clmObjectLocation.Text = "Location";
            this.clmObjectLocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmObjectLocation.Width = 80;
            // 
            // btnUsedObjectEdit
            // 
            this.btnUsedObjectEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUsedObjectEdit.Enabled = false;
            this.btnUsedObjectEdit.Image = global::Schematix.Properties.Resources.edit;
            this.btnUsedObjectEdit.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnUsedObjectEdit.Location = new System.Drawing.Point(234, 0);
            this.btnUsedObjectEdit.Margin = new System.Windows.Forms.Padding(3, 0, 3, 1);
            this.btnUsedObjectEdit.Name = "btnUsedObjectEdit";
            this.btnUsedObjectEdit.Size = new System.Drawing.Size(24, 24);
            this.btnUsedObjectEdit.TabIndex = 4;
            this.btnUsedObjectEdit.UseVisualStyleBackColor = true;
            this.btnUsedObjectEdit.Click += new System.EventHandler(this.btnUsedObjectEdit_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.tvLinks, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblLinksCatalog, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnLinkEdit, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnLinkAdd, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(261, 118);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // tvLinks
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.tvLinks, 3);
            this.tvLinks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvLinks.HideSelection = false;
            this.tvLinks.Location = new System.Drawing.Point(3, 28);
            this.tvLinks.Name = "tvLinks";
            this.tvLinks.Size = new System.Drawing.Size(255, 87);
            this.tvLinks.TabIndex = 0;
            this.tvLinks.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvLinks_AfterSelect);
            this.tvLinks.DoubleClick += new System.EventHandler(this.btnLinkEdit_Click);
            // 
            // lblLinksCatalog
            // 
            this.lblLinksCatalog.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLinksCatalog.AutoSize = true;
            this.lblLinksCatalog.Location = new System.Drawing.Point(3, 6);
            this.lblLinksCatalog.Name = "lblLinksCatalog";
            this.lblLinksCatalog.Size = new System.Drawing.Size(43, 13);
            this.lblLinksCatalog.TabIndex = 2;
            this.lblLinksCatalog.Text = "Catalog";
            // 
            // btnLinkEdit
            // 
            this.btnLinkEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLinkEdit.Enabled = false;
            this.btnLinkEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnLinkEdit.Image")));
            this.btnLinkEdit.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnLinkEdit.Location = new System.Drawing.Point(204, 0);
            this.btnLinkEdit.Margin = new System.Windows.Forms.Padding(3, 0, 3, 1);
            this.btnLinkEdit.Name = "btnLinkEdit";
            this.btnLinkEdit.Size = new System.Drawing.Size(24, 24);
            this.btnLinkEdit.TabIndex = 4;
            this.btnLinkEdit.UseVisualStyleBackColor = true;
            this.btnLinkEdit.Click += new System.EventHandler(this.btnLinkEdit_Click);
            // 
            // btnLinkAdd
            // 
            this.btnLinkAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLinkAdd.Image = global::Schematix.Properties.Resources.plus;
            this.btnLinkAdd.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnLinkAdd.Location = new System.Drawing.Point(234, 0);
            this.btnLinkAdd.Margin = new System.Windows.Forms.Padding(3, 0, 3, 1);
            this.btnLinkAdd.Name = "btnLinkAdd";
            this.btnLinkAdd.Size = new System.Drawing.Size(24, 24);
            this.btnLinkAdd.TabIndex = 4;
            this.btnLinkAdd.UseVisualStyleBackColor = true;
            this.btnLinkAdd.Click += new System.EventHandler(this.btnLinkAdd_Click);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.Controls.Add(this.lblUsedLinks, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.lvLinks, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.btnUsedLinkEdit, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(261, 100);
            this.tableLayoutPanel5.TabIndex = 3;
            // 
            // lblUsedLinks
            // 
            this.lblUsedLinks.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblUsedLinks.AutoSize = true;
            this.lblUsedLinks.Location = new System.Drawing.Point(3, 2);
            this.lblUsedLinks.MinimumSize = new System.Drawing.Size(0, 21);
            this.lblUsedLinks.Name = "lblUsedLinks";
            this.lblUsedLinks.Size = new System.Drawing.Size(73, 21);
            this.lblUsedLinks.TabIndex = 2;
            this.lblUsedLinks.Text = "Used on map:";
            this.lblUsedLinks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lvLinks
            // 
            this.lvLinks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmLinkName,
            this.clmLinkLocation});
            this.tableLayoutPanel5.SetColumnSpan(this.lvLinks, 2);
            this.lvLinks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvLinks.FullRowSelect = true;
            this.lvLinks.HideSelection = false;
            this.lvLinks.Location = new System.Drawing.Point(3, 28);
            this.lvLinks.MultiSelect = false;
            this.lvLinks.Name = "lvLinks";
            this.lvLinks.Size = new System.Drawing.Size(255, 69);
            this.lvLinks.TabIndex = 1;
            this.lvLinks.UseCompatibleStateImageBehavior = false;
            this.lvLinks.View = System.Windows.Forms.View.Details;
            this.lvLinks.SelectedIndexChanged += new System.EventHandler(this.lvLinks_SelectedIndexChanged);
            this.lvLinks.DoubleClick += new System.EventHandler(this.btnUsedLinkEdit_Click);
            // 
            // clmLinkName
            // 
            this.clmLinkName.Text = "Name";
            this.clmLinkName.Width = 150;
            // 
            // clmLinkLocation
            // 
            this.clmLinkLocation.Text = "Location";
            this.clmLinkLocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmLinkLocation.Width = 80;
            // 
            // btnUsedLinkEdit
            // 
            this.btnUsedLinkEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUsedLinkEdit.Enabled = false;
            this.btnUsedLinkEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnUsedLinkEdit.Image")));
            this.btnUsedLinkEdit.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnUsedLinkEdit.Location = new System.Drawing.Point(234, 0);
            this.btnUsedLinkEdit.Margin = new System.Windows.Forms.Padding(3, 0, 3, 1);
            this.btnUsedLinkEdit.Name = "btnUsedLinkEdit";
            this.btnUsedLinkEdit.Size = new System.Drawing.Size(24, 24);
            this.btnUsedLinkEdit.TabIndex = 4;
            this.btnUsedLinkEdit.UseVisualStyleBackColor = true;
            this.btnUsedLinkEdit.Click += new System.EventHandler(this.btnUsedLinkEdit_Click);
            // 
            // tcCatalog
            // 
            this.tcCatalog.Controls.Add(this.tpObjects);
            this.tcCatalog.Controls.Add(this.tpLinks);
            this.tcCatalog.Controls.Add(this.tpBoxes);
            this.tcCatalog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcCatalog.ImageList = this.imageListTab;
            this.tcCatalog.Location = new System.Drawing.Point(4, 4);
            this.tcCatalog.Margin = new System.Windows.Forms.Padding(0);
            this.tcCatalog.Name = "tcCatalog";
            this.tcCatalog.SelectedIndex = 0;
            this.tcCatalog.Size = new System.Drawing.Size(275, 255);
            this.tcCatalog.TabIndex = 1;
            // 
            // tpObjects
            // 
            this.tpObjects.BackColor = System.Drawing.SystemColors.Control;
            this.tpObjects.Controls.Add(this.splitContainer1);
            this.tpObjects.ImageIndex = 0;
            this.tpObjects.Location = new System.Drawing.Point(4, 23);
            this.tpObjects.Name = "tpObjects";
            this.tpObjects.Padding = new System.Windows.Forms.Padding(3);
            this.tpObjects.Size = new System.Drawing.Size(267, 228);
            this.tpObjects.TabIndex = 0;
            this.tpObjects.Text = "Objects";
            // 
            // tpLinks
            // 
            this.tpLinks.BackColor = System.Drawing.SystemColors.Control;
            this.tpLinks.Controls.Add(this.splitContainer2);
            this.tpLinks.ImageIndex = 1;
            this.tpLinks.Location = new System.Drawing.Point(4, 23);
            this.tpLinks.Name = "tpLinks";
            this.tpLinks.Padding = new System.Windows.Forms.Padding(3);
            this.tpLinks.Size = new System.Drawing.Size(267, 228);
            this.tpLinks.TabIndex = 1;
            this.tpLinks.Text = "Links";
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer2.Panel1MinSize = 100;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel5);
            this.splitContainer2.Panel2MinSize = 100;
            this.splitContainer2.Size = new System.Drawing.Size(261, 222);
            this.splitContainer2.SplitterDistance = 118;
            this.splitContainer2.TabIndex = 1;
            this.splitContainer2.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer2_SplitterMoved);
            // 
            // tpBoxes
            // 
            this.tpBoxes.BackColor = System.Drawing.SystemColors.Control;
            this.tpBoxes.Controls.Add(this.splitContainer3);
            this.tpBoxes.ImageIndex = 2;
            this.tpBoxes.Location = new System.Drawing.Point(4, 23);
            this.tpBoxes.Name = "tpBoxes";
            this.tpBoxes.Padding = new System.Windows.Forms.Padding(3);
            this.tpBoxes.Size = new System.Drawing.Size(267, 228);
            this.tpBoxes.TabIndex = 2;
            this.tpBoxes.Text = "Boxes";
            // 
            // splitContainer3
            // 
            this.splitContainer3.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 3);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer3.Panel1.Controls.Add(this.tableLayoutPanel3);
            this.splitContainer3.Panel1MinSize = 100;
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer3.Panel2.Controls.Add(this.tableLayoutPanel6);
            this.splitContainer3.Panel2MinSize = 100;
            this.splitContainer3.Size = new System.Drawing.Size(261, 222);
            this.splitContainer3.SplitterDistance = 118;
            this.splitContainer3.TabIndex = 1;
            this.splitContainer3.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer3_SplitterMoved);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.tvBoxes, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblBoxesCatalog, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnBoxEdit, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnBoxAdd, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(261, 118);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // tvBoxes
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.tvBoxes, 3);
            this.tvBoxes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvBoxes.HideSelection = false;
            this.tvBoxes.Location = new System.Drawing.Point(3, 28);
            this.tvBoxes.Name = "tvBoxes";
            this.tvBoxes.Size = new System.Drawing.Size(255, 87);
            this.tvBoxes.TabIndex = 0;
            this.tvBoxes.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvBoxes_AfterSelect);
            this.tvBoxes.DoubleClick += new System.EventHandler(this.btnBoxEdit_Click);
            // 
            // lblBoxesCatalog
            // 
            this.lblBoxesCatalog.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblBoxesCatalog.AutoSize = true;
            this.lblBoxesCatalog.Location = new System.Drawing.Point(3, 6);
            this.lblBoxesCatalog.Name = "lblBoxesCatalog";
            this.lblBoxesCatalog.Size = new System.Drawing.Size(43, 13);
            this.lblBoxesCatalog.TabIndex = 2;
            this.lblBoxesCatalog.Text = "Catalog";
            // 
            // btnBoxEdit
            // 
            this.btnBoxEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBoxEdit.Enabled = false;
            this.btnBoxEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnBoxEdit.Image")));
            this.btnBoxEdit.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnBoxEdit.Location = new System.Drawing.Point(204, 0);
            this.btnBoxEdit.Margin = new System.Windows.Forms.Padding(3, 0, 3, 1);
            this.btnBoxEdit.Name = "btnBoxEdit";
            this.btnBoxEdit.Size = new System.Drawing.Size(24, 24);
            this.btnBoxEdit.TabIndex = 4;
            this.btnBoxEdit.UseVisualStyleBackColor = true;
            this.btnBoxEdit.Click += new System.EventHandler(this.btnBoxEdit_Click);
            // 
            // btnBoxAdd
            // 
            this.btnBoxAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBoxAdd.Image = global::Schematix.Properties.Resources.plus;
            this.btnBoxAdd.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnBoxAdd.Location = new System.Drawing.Point(234, 0);
            this.btnBoxAdd.Margin = new System.Windows.Forms.Padding(3, 0, 3, 1);
            this.btnBoxAdd.Name = "btnBoxAdd";
            this.btnBoxAdd.Size = new System.Drawing.Size(24, 24);
            this.btnBoxAdd.TabIndex = 4;
            this.btnBoxAdd.UseVisualStyleBackColor = true;
            this.btnBoxAdd.Click += new System.EventHandler(this.btnBoxAdd_Click);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.Controls.Add(this.lblUsedBoxes, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.lvBoxes, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.btnUsedBoxEdit, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(261, 100);
            this.tableLayoutPanel6.TabIndex = 3;
            // 
            // lblUsedBoxes
            // 
            this.lblUsedBoxes.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblUsedBoxes.AutoSize = true;
            this.lblUsedBoxes.Location = new System.Drawing.Point(3, 2);
            this.lblUsedBoxes.MinimumSize = new System.Drawing.Size(0, 21);
            this.lblUsedBoxes.Name = "lblUsedBoxes";
            this.lblUsedBoxes.Size = new System.Drawing.Size(73, 21);
            this.lblUsedBoxes.TabIndex = 2;
            this.lblUsedBoxes.Text = "Used on map:";
            this.lblUsedBoxes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lvBoxes
            // 
            this.lvBoxes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmBoxName,
            this.clmBoxLocation});
            this.tableLayoutPanel6.SetColumnSpan(this.lvBoxes, 2);
            this.lvBoxes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvBoxes.FullRowSelect = true;
            this.lvBoxes.HideSelection = false;
            this.lvBoxes.Location = new System.Drawing.Point(3, 28);
            this.lvBoxes.MultiSelect = false;
            this.lvBoxes.Name = "lvBoxes";
            this.lvBoxes.Size = new System.Drawing.Size(255, 69);
            this.lvBoxes.TabIndex = 1;
            this.lvBoxes.UseCompatibleStateImageBehavior = false;
            this.lvBoxes.View = System.Windows.Forms.View.Details;
            this.lvBoxes.SelectedIndexChanged += new System.EventHandler(this.lvBoxes_SelectedIndexChanged);
            this.lvBoxes.DoubleClick += new System.EventHandler(this.btnUsedBoxEdit_Click);
            // 
            // clmBoxName
            // 
            this.clmBoxName.Text = "Name";
            this.clmBoxName.Width = 150;
            // 
            // clmBoxLocation
            // 
            this.clmBoxLocation.Text = "Location";
            this.clmBoxLocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmBoxLocation.Width = 80;
            // 
            // btnUsedBoxEdit
            // 
            this.btnUsedBoxEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUsedBoxEdit.Enabled = false;
            this.btnUsedBoxEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnUsedBoxEdit.Image")));
            this.btnUsedBoxEdit.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnUsedBoxEdit.Location = new System.Drawing.Point(234, 0);
            this.btnUsedBoxEdit.Margin = new System.Windows.Forms.Padding(3, 0, 3, 1);
            this.btnUsedBoxEdit.Name = "btnUsedBoxEdit";
            this.btnUsedBoxEdit.Size = new System.Drawing.Size(24, 24);
            this.btnUsedBoxEdit.TabIndex = 4;
            this.btnUsedBoxEdit.UseVisualStyleBackColor = true;
            this.btnUsedBoxEdit.Click += new System.EventHandler(this.btnUsedBoxEdit_Click);
            // 
            // imageListTab
            // 
            this.imageListTab.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTab.ImageStream")));
            this.imageListTab.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListTab.Images.SetKeyName(0, "toolObject.png");
            this.imageListTab.Images.SetKeyName(1, "toolLine.png");
            this.imageListTab.Images.SetKeyName(2, "toolPrimitive.png");
            // 
            // chkPin
            // 
            this.chkPin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkPin.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkPin.BackgroundImage = global::Schematix.Properties.Resources.PinUp;
            this.chkPin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.chkPin.CheckAlign = System.Drawing.ContentAlignment.BottomRight;
            this.chkPin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkPin.Location = new System.Drawing.Point(268, 0);
            this.chkPin.Name = "chkPin";
            this.chkPin.Size = new System.Drawing.Size(12, 12);
            this.chkPin.TabIndex = 2;
            this.chkPin.UseVisualStyleBackColor = true;
            this.chkPin.CheckedChanged += new System.EventHandler(this.chkPin_CheckedChanged);
            // 
            // imageListPin
            // 
            this.imageListPin.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListPin.ImageStream")));
            this.imageListPin.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListPin.Images.SetKeyName(0, "PinUp.png");
            this.imageListPin.Images.SetKeyName(1, "PinDown.png");
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Location";
            // 
            // LibraryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 263);
            this.Controls.Add(this.chkPin);
            this.Controls.Add(this.tcCatalog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(299, 301);
            this.Name = "LibraryForm";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Library";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LibraryForm_FormClosing);
            this.Move += new System.EventHandler(this.LibraryForm_Move);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tcCatalog.ResumeLayout(false);
            this.tpObjects.ResumeLayout(false);
            this.tpLinks.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tpBoxes.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tcCatalog;
        private System.Windows.Forms.TabPage tpObjects;
        private System.Windows.Forms.TabPage tpLinks;
        private System.Windows.Forms.TreeView tvObjects;
        private System.Windows.Forms.TabPage tpBoxes;
        private System.Windows.Forms.TreeView tvLinks;
        private System.Windows.Forms.TreeView tvBoxes;
        private System.Windows.Forms.ColumnHeader clmLinkName;
        private System.Windows.Forms.ColumnHeader clmObjectName;
        private System.Windows.Forms.ColumnHeader clmBoxName;
        private System.Windows.Forms.Label lblObjectsCatalog;
        private System.Windows.Forms.Label lblUsedObjects;
        private System.Windows.Forms.Button btnObjectAdd;
        private System.Windows.Forms.Button btnObjectEdit;
        private System.Windows.Forms.ImageList imageListTab;
        private System.Windows.Forms.Button btnUsedObjectEdit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblLinksCatalog;
        private System.Windows.Forms.Button btnLinkEdit;
        private System.Windows.Forms.Button btnLinkAdd;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lblBoxesCatalog;
        private System.Windows.Forms.Button btnBoxEdit;
        private System.Windows.Forms.Button btnBoxAdd;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label lblUsedLinks;
        private System.Windows.Forms.Button btnUsedLinkEdit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label lblUsedBoxes;
        private System.Windows.Forms.Button btnUsedBoxEdit;
        private System.Windows.Forms.CheckBox chkPin;
        private System.Windows.Forms.ImageList imageListPin;
        private System.Windows.Forms.ColumnHeader clmObjectLocation;
        private System.Windows.Forms.ColumnHeader clmLinkLocation;
        private System.Windows.Forms.ColumnHeader clmBoxLocation;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ToolTip toolTip;
        public System.Windows.Forms.ListView lvLinks;
        public System.Windows.Forms.ListView lvObjects;
        public System.Windows.Forms.ListView lvBoxes;
    }
}