namespace Schematix
{
    partial class ObjectOptionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObjectOptionsForm));
            this.btnOk = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnGetReference = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lblReference = new System.Windows.Forms.Label();
            this.tbReference = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnIPAdd = new System.Windows.Forms.Button();
            this.btnIPDelete = new System.Windows.Forms.Button();
            this.lvIPs = new System.Windows.Forms.ListView();
            this.clmIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmPeriod = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmTimeLast = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmTimeNext = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmPing = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel2.SetColumnSpan(this.btnOk, 3);
            this.btnOk.Location = new System.Drawing.Point(179, 318);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.btnOk, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.btnGetReference, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblName, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tbName, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblReference, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tbReference, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.splitContainer1, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(8, 8);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(433, 344);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btnGetReference
            // 
            this.btnGetReference.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnGetReference.Image = global::Schematix.Properties.Resources.Reference;
            this.btnGetReference.Location = new System.Drawing.Point(407, 3);
            this.btnGetReference.Name = "btnGetReference";
            this.btnGetReference.Size = new System.Drawing.Size(23, 23);
            this.btnGetReference.TabIndex = 2;
            this.btnGetReference.UseVisualStyleBackColor = true;
            this.btnGetReference.Click += new System.EventHandler(this.btnGetReference_Click);
            // 
            // lblName
            // 
            this.lblName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(3, 35);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // tbName
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.tbName, 2);
            this.tbName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbName.Location = new System.Drawing.Point(66, 32);
            this.tbName.MaxLength = 255;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(364, 20);
            this.tbName.TabIndex = 1;
            // 
            // lblReference
            // 
            this.lblReference.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblReference.AutoSize = true;
            this.lblReference.Location = new System.Drawing.Point(3, 8);
            this.lblReference.Name = "lblReference";
            this.lblReference.Size = new System.Drawing.Size(57, 13);
            this.lblReference.TabIndex = 0;
            this.lblReference.Text = "Reference";
            // 
            // tbReference
            // 
            this.tbReference.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbReference.Location = new System.Drawing.Point(66, 4);
            this.tbReference.MaxLength = 32;
            this.tbReference.Name = "tbReference";
            this.tbReference.Size = new System.Drawing.Size(335, 20);
            this.tbReference.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.splitContainer1, 3);
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 58);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tbDescription);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(427, 254);
            this.splitContainer1.SplitterDistance = 127;
            this.splitContainer1.TabIndex = 10;
            // 
            // tbDescription
            // 
            this.tbDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDescription.Location = new System.Drawing.Point(0, 0);
            this.tbDescription.MaxLength = 8192;
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDescription.Size = new System.Drawing.Size(427, 127);
            this.tbDescription.TabIndex = 9;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.btnIPAdd, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnIPDelete, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lvIPs, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(427, 123);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnIPAdd
            // 
            this.btnIPAdd.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnIPAdd.Image = global::Schematix.Properties.Resources.plus;
            this.btnIPAdd.Location = new System.Drawing.Point(3, 3);
            this.btnIPAdd.Name = "btnIPAdd";
            this.btnIPAdd.Size = new System.Drawing.Size(23, 23);
            this.btnIPAdd.TabIndex = 2;
            this.btnIPAdd.UseVisualStyleBackColor = true;
            this.btnIPAdd.Click += new System.EventHandler(this.btnIPAdd_Click);
            // 
            // btnIPDelete
            // 
            this.btnIPDelete.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnIPDelete.Enabled = false;
            this.btnIPDelete.Image = global::Schematix.Properties.Resources.delete;
            this.btnIPDelete.Location = new System.Drawing.Point(401, 3);
            this.btnIPDelete.Name = "btnIPDelete";
            this.btnIPDelete.Size = new System.Drawing.Size(23, 23);
            this.btnIPDelete.TabIndex = 2;
            this.btnIPDelete.UseVisualStyleBackColor = true;
            this.btnIPDelete.Click += new System.EventHandler(this.btnIPDelete_Click);
            // 
            // lvIPs
            // 
            this.lvIPs.CheckBoxes = true;
            this.lvIPs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmIP,
            this.clmPeriod,
            this.clmTimeLast,
            this.clmTimeNext,
            this.clmPing});
            this.tableLayoutPanel1.SetColumnSpan(this.lvIPs, 3);
            this.lvIPs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvIPs.FullRowSelect = true;
            this.lvIPs.GridLines = true;
            this.lvIPs.HideSelection = false;
            this.lvIPs.Location = new System.Drawing.Point(3, 32);
            this.lvIPs.Name = "lvIPs";
            this.lvIPs.Size = new System.Drawing.Size(421, 88);
            this.lvIPs.TabIndex = 3;
            this.lvIPs.UseCompatibleStateImageBehavior = false;
            this.lvIPs.View = System.Windows.Forms.View.Details;
            this.lvIPs.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvIPs_ItemChecked);
            this.lvIPs.SelectedIndexChanged += new System.EventHandler(this.lvIPs_SelectedIndexChanged);
            this.lvIPs.DoubleClick += new System.EventHandler(this.lvIPs_DoubleClick);
            // 
            // clmIP
            // 
            this.clmIP.Text = "IP";
            this.clmIP.Width = 120;
            // 
            // clmPeriod
            // 
            this.clmPeriod.Text = "Period";
            this.clmPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // clmTimeLast
            // 
            this.clmTimeLast.Text = "Last check";
            this.clmTimeLast.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmTimeLast.Width = 120;
            // 
            // clmTimeNext
            // 
            this.clmTimeNext.Text = "Next check";
            this.clmTimeNext.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clmTimeNext.Width = 120;
            // 
            // clmPing
            // 
            this.clmPing.Text = "Ping";
            this.clmPing.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ObjectOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 360);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ObjectOptionsForm";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ObjectOptionsForm";
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lblReference;
        private System.Windows.Forms.TextBox tbReference;
        private System.Windows.Forms.Button btnGetReference;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnIPAdd;
        private System.Windows.Forms.Button btnIPDelete;
        private System.Windows.Forms.ListView lvIPs;
        private System.Windows.Forms.ColumnHeader clmIP;
        private System.Windows.Forms.ColumnHeader clmPeriod;
        private System.Windows.Forms.ColumnHeader clmTimeLast;
        private System.Windows.Forms.ColumnHeader clmTimeNext;
        private System.Windows.Forms.ColumnHeader clmPing;
        private System.Windows.Forms.ToolTip toolTip;
    }
}