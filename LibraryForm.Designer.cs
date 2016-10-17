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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Node2");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Node0", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Node1");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Dot", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Node2");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Node0", new System.Windows.Forms.TreeNode[] {
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Node1");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Link", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Node2");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Node0", new System.Windows.Forms.TreeNode[] {
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Node1");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Box", new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode11});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LibraryForm));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("box");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("box 2");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("obj");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("obj 2");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("link");
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("link 2");
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.tlpTreeViewContainer = new System.Windows.Forms.TableLayoutPanel();
            this.lblCatalog = new System.Windows.Forms.Label();
            this.tcCatalog = new System.Windows.Forms.TabControl();
            this.tpObjects = new System.Windows.Forms.TabPage();
            this.tvObjects = new System.Windows.Forms.TreeView();
            this.tpLinks = new System.Windows.Forms.TabPage();
            this.tvLinks = new System.Windows.Forms.TreeView();
            this.tpBoxes = new System.Windows.Forms.TabPage();
            this.tvBoxes = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.tlpListViewContainer = new System.Windows.Forms.TableLayoutPanel();
            this.lblUsedOnMap = new System.Windows.Forms.Label();
            this.pnlListViewGroup = new System.Windows.Forms.Panel();
            this.lvBoxes = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvObjects = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvLinks = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnUsedEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.tlpTreeViewContainer.SuspendLayout();
            this.tcCatalog.SuspendLayout();
            this.tpObjects.SuspendLayout();
            this.tpLinks.SuspendLayout();
            this.tpBoxes.SuspendLayout();
            this.tlpListViewContainer.SuspendLayout();
            this.pnlListViewGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(4, 4);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer.Panel1.Controls.Add(this.tlpTreeViewContainer);
            this.splitContainer.Panel1MinSize = 100;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer.Panel2.Controls.Add(this.tlpListViewContainer);
            this.splitContainer.Panel2MinSize = 100;
            this.splitContainer.Size = new System.Drawing.Size(275, 255);
            this.splitContainer.SplitterDistance = 125;
            this.splitContainer.TabIndex = 0;
            // 
            // tlpTreeViewContainer
            // 
            this.tlpTreeViewContainer.ColumnCount = 3;
            this.tlpTreeViewContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTreeViewContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpTreeViewContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpTreeViewContainer.Controls.Add(this.lblCatalog, 0, 0);
            this.tlpTreeViewContainer.Controls.Add(this.tcCatalog, 0, 1);
            this.tlpTreeViewContainer.Controls.Add(this.btnAdd, 2, 0);
            this.tlpTreeViewContainer.Controls.Add(this.btnEdit, 1, 0);
            this.tlpTreeViewContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTreeViewContainer.Location = new System.Drawing.Point(0, 0);
            this.tlpTreeViewContainer.Name = "tlpTreeViewContainer";
            this.tlpTreeViewContainer.RowCount = 2;
            this.tlpTreeViewContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpTreeViewContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTreeViewContainer.Size = new System.Drawing.Size(275, 125);
            this.tlpTreeViewContainer.TabIndex = 5;
            // 
            // lblCatalog
            // 
            this.lblCatalog.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCatalog.AutoSize = true;
            this.lblCatalog.Location = new System.Drawing.Point(3, 6);
            this.lblCatalog.Name = "lblCatalog";
            this.lblCatalog.Size = new System.Drawing.Size(43, 13);
            this.lblCatalog.TabIndex = 2;
            this.lblCatalog.Text = "Catalog";
            // 
            // tcCatalog
            // 
            this.tcCatalog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpTreeViewContainer.SetColumnSpan(this.tcCatalog, 3);
            this.tcCatalog.Controls.Add(this.tpObjects);
            this.tcCatalog.Controls.Add(this.tpLinks);
            this.tcCatalog.Controls.Add(this.tpBoxes);
            this.tcCatalog.ImageList = this.imageList;
            this.tcCatalog.Location = new System.Drawing.Point(0, 25);
            this.tcCatalog.Margin = new System.Windows.Forms.Padding(0);
            this.tcCatalog.Name = "tcCatalog";
            this.tcCatalog.SelectedIndex = 0;
            this.tcCatalog.Size = new System.Drawing.Size(275, 100);
            this.tcCatalog.TabIndex = 1;
            // 
            // tpObjects
            // 
            this.tpObjects.BackColor = System.Drawing.SystemColors.Control;
            this.tpObjects.Controls.Add(this.tvObjects);
            this.tpObjects.ImageIndex = 0;
            this.tpObjects.Location = new System.Drawing.Point(4, 23);
            this.tpObjects.Name = "tpObjects";
            this.tpObjects.Padding = new System.Windows.Forms.Padding(3);
            this.tpObjects.Size = new System.Drawing.Size(267, 73);
            this.tpObjects.TabIndex = 0;
            this.tpObjects.Text = "Objects";
            this.tpObjects.Enter += new System.EventHandler(this.tpObjects_Enter);
            // 
            // tvObjects
            // 
            this.tvObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvObjects.HideSelection = false;
            this.tvObjects.Location = new System.Drawing.Point(3, 3);
            this.tvObjects.Name = "tvObjects";
            treeNode1.Name = "Node2";
            treeNode1.Text = "Node2";
            treeNode2.Name = "Node0";
            treeNode2.Text = "Node0";
            treeNode3.Name = "Node1";
            treeNode3.Text = "Node1";
            treeNode4.Name = "tvNodeDot";
            treeNode4.Text = "Dot";
            this.tvObjects.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4});
            this.tvObjects.Size = new System.Drawing.Size(261, 67);
            this.tvObjects.TabIndex = 0;
            this.tvObjects.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_AfterSelect);
            // 
            // tpLinks
            // 
            this.tpLinks.BackColor = System.Drawing.SystemColors.Control;
            this.tpLinks.Controls.Add(this.tvLinks);
            this.tpLinks.ImageIndex = 1;
            this.tpLinks.Location = new System.Drawing.Point(4, 23);
            this.tpLinks.Name = "tpLinks";
            this.tpLinks.Padding = new System.Windows.Forms.Padding(3);
            this.tpLinks.Size = new System.Drawing.Size(267, 73);
            this.tpLinks.TabIndex = 1;
            this.tpLinks.Text = "Links";
            this.tpLinks.Enter += new System.EventHandler(this.tpLinks_Enter);
            // 
            // tvLinks
            // 
            this.tvLinks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvLinks.HideSelection = false;
            this.tvLinks.Location = new System.Drawing.Point(3, 3);
            this.tvLinks.Name = "tvLinks";
            treeNode5.Name = "Node2";
            treeNode5.Text = "Node2";
            treeNode6.Name = "Node0";
            treeNode6.Text = "Node0";
            treeNode7.Name = "Node1";
            treeNode7.Text = "Node1";
            treeNode8.Name = "tvNodeLink";
            treeNode8.Text = "Link";
            this.tvLinks.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode8});
            this.tvLinks.Size = new System.Drawing.Size(261, 67);
            this.tvLinks.TabIndex = 0;
            this.tvLinks.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_AfterSelect);
            // 
            // tpBoxes
            // 
            this.tpBoxes.BackColor = System.Drawing.SystemColors.Control;
            this.tpBoxes.Controls.Add(this.tvBoxes);
            this.tpBoxes.ImageIndex = 2;
            this.tpBoxes.Location = new System.Drawing.Point(4, 23);
            this.tpBoxes.Name = "tpBoxes";
            this.tpBoxes.Padding = new System.Windows.Forms.Padding(3);
            this.tpBoxes.Size = new System.Drawing.Size(267, 73);
            this.tpBoxes.TabIndex = 2;
            this.tpBoxes.Text = "Boxes";
            this.tpBoxes.Enter += new System.EventHandler(this.tpBoxes_Enter);
            // 
            // tvBoxes
            // 
            this.tvBoxes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvBoxes.HideSelection = false;
            this.tvBoxes.Location = new System.Drawing.Point(3, 3);
            this.tvBoxes.Name = "tvBoxes";
            treeNode9.Name = "Node2";
            treeNode9.Text = "Node2";
            treeNode10.Name = "Node0";
            treeNode10.Text = "Node0";
            treeNode11.Name = "Node1";
            treeNode11.Text = "Node1";
            treeNode12.Name = "tvNodeBox";
            treeNode12.Text = "Box";
            this.tvBoxes.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode12});
            this.tvBoxes.Size = new System.Drawing.Size(261, 67);
            this.tvBoxes.TabIndex = 0;
            this.tvBoxes.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_AfterSelect);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "toolObject.png");
            this.imageList.Images.SetKeyName(1, "toolLine.png");
            this.imageList.Images.SetKeyName(2, "toolPrimitive.png");
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Image = global::Schematix.Properties.Resources.plus;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnAdd.Location = new System.Drawing.Point(248, 0);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 0, 3, 1);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(24, 24);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Enabled = false;
            this.btnEdit.Image = global::Schematix.Properties.Resources.edit;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnEdit.Location = new System.Drawing.Point(218, 0);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 0, 3, 1);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(24, 24);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // tlpListViewContainer
            // 
            this.tlpListViewContainer.ColumnCount = 2;
            this.tlpListViewContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpListViewContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpListViewContainer.Controls.Add(this.lblUsedOnMap, 0, 0);
            this.tlpListViewContainer.Controls.Add(this.pnlListViewGroup, 0, 1);
            this.tlpListViewContainer.Controls.Add(this.btnUsedEdit, 1, 0);
            this.tlpListViewContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpListViewContainer.Location = new System.Drawing.Point(0, 0);
            this.tlpListViewContainer.Name = "tlpListViewContainer";
            this.tlpListViewContainer.RowCount = 2;
            this.tlpListViewContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpListViewContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpListViewContainer.Size = new System.Drawing.Size(275, 126);
            this.tlpListViewContainer.TabIndex = 3;
            // 
            // lblUsedOnMap
            // 
            this.lblUsedOnMap.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblUsedOnMap.AutoSize = true;
            this.lblUsedOnMap.Location = new System.Drawing.Point(3, 2);
            this.lblUsedOnMap.MinimumSize = new System.Drawing.Size(0, 21);
            this.lblUsedOnMap.Name = "lblUsedOnMap";
            this.lblUsedOnMap.Size = new System.Drawing.Size(73, 21);
            this.lblUsedOnMap.TabIndex = 2;
            this.lblUsedOnMap.Text = "Used on map:";
            this.lblUsedOnMap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlListViewGroup
            // 
            this.tlpListViewContainer.SetColumnSpan(this.pnlListViewGroup, 2);
            this.pnlListViewGroup.Controls.Add(this.lvBoxes);
            this.pnlListViewGroup.Controls.Add(this.lvObjects);
            this.pnlListViewGroup.Controls.Add(this.lvLinks);
            this.pnlListViewGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlListViewGroup.Location = new System.Drawing.Point(3, 28);
            this.pnlListViewGroup.Name = "pnlListViewGroup";
            this.pnlListViewGroup.Size = new System.Drawing.Size(269, 95);
            this.pnlListViewGroup.TabIndex = 3;
            // 
            // lvBoxes
            // 
            this.lvBoxes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.lvBoxes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvBoxes.HideSelection = false;
            this.lvBoxes.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.lvBoxes.Location = new System.Drawing.Point(0, 0);
            this.lvBoxes.Name = "lvBoxes";
            this.lvBoxes.Size = new System.Drawing.Size(269, 95);
            this.lvBoxes.TabIndex = 1;
            this.lvBoxes.UseCompatibleStateImageBehavior = false;
            this.lvBoxes.View = System.Windows.Forms.View.Details;
            this.lvBoxes.Visible = false;
            this.lvBoxes.SelectedIndexChanged += new System.EventHandler(this.ListView_SelectedIndexChanged);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 109;
            // 
            // lvObjects
            // 
            this.lvObjects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.lvObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvObjects.HideSelection = false;
            this.lvObjects.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem3,
            listViewItem4});
            this.lvObjects.Location = new System.Drawing.Point(0, 0);
            this.lvObjects.Name = "lvObjects";
            this.lvObjects.Size = new System.Drawing.Size(269, 95);
            this.lvObjects.TabIndex = 1;
            this.lvObjects.UseCompatibleStateImageBehavior = false;
            this.lvObjects.View = System.Windows.Forms.View.Details;
            this.lvObjects.Visible = false;
            this.lvObjects.SelectedIndexChanged += new System.EventHandler(this.ListView_SelectedIndexChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 122;
            // 
            // lvLinks
            // 
            this.lvLinks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvLinks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvLinks.HideSelection = false;
            this.lvLinks.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem5,
            listViewItem6});
            this.lvLinks.Location = new System.Drawing.Point(0, 0);
            this.lvLinks.Name = "lvLinks";
            this.lvLinks.Size = new System.Drawing.Size(269, 95);
            this.lvLinks.TabIndex = 1;
            this.lvLinks.UseCompatibleStateImageBehavior = false;
            this.lvLinks.View = System.Windows.Forms.View.Details;
            this.lvLinks.Visible = false;
            this.lvLinks.SelectedIndexChanged += new System.EventHandler(this.ListView_SelectedIndexChanged);
            // 
            // btnUsedEdit
            // 
            this.btnUsedEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUsedEdit.Enabled = false;
            this.btnUsedEdit.Image = global::Schematix.Properties.Resources.edit;
            this.btnUsedEdit.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnUsedEdit.Location = new System.Drawing.Point(248, 0);
            this.btnUsedEdit.Margin = new System.Windows.Forms.Padding(3, 0, 3, 1);
            this.btnUsedEdit.Name = "btnUsedEdit";
            this.btnUsedEdit.Size = new System.Drawing.Size(24, 24);
            this.btnUsedEdit.TabIndex = 4;
            this.btnUsedEdit.UseVisualStyleBackColor = true;
            // 
            // LibraryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 263);
            this.Controls.Add(this.splitContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(299, 301);
            this.Name = "LibraryForm";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Library";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LibraryForm_FormClosing);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.tlpTreeViewContainer.ResumeLayout(false);
            this.tlpTreeViewContainer.PerformLayout();
            this.tcCatalog.ResumeLayout(false);
            this.tpObjects.ResumeLayout(false);
            this.tpLinks.ResumeLayout(false);
            this.tpBoxes.ResumeLayout(false);
            this.tlpListViewContainer.ResumeLayout(false);
            this.tlpListViewContainer.PerformLayout();
            this.pnlListViewGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TabControl tcCatalog;
        private System.Windows.Forms.TabPage tpObjects;
        private System.Windows.Forms.TabPage tpLinks;
        private System.Windows.Forms.TreeView tvObjects;
        private System.Windows.Forms.TabPage tpBoxes;
        private System.Windows.Forms.TreeView tvLinks;
        private System.Windows.Forms.TreeView tvBoxes;
        private System.Windows.Forms.ListView lvLinks;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView lvObjects;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView lvBoxes;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label lblCatalog;
        private System.Windows.Forms.Label lblUsedOnMap;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.TableLayoutPanel tlpTreeViewContainer;
        private System.Windows.Forms.TableLayoutPanel tlpListViewContainer;
        private System.Windows.Forms.Panel pnlListViewGroup;
        private System.Windows.Forms.Button btnUsedEdit;
    }
}