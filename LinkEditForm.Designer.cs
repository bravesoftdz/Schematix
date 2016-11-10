namespace Schematix
{
    partial class LinkEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LinkEditForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnOk = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblLineThick = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbStyle = new System.Windows.Forms.ComboBox();
            this.btnLineColor = new System.Windows.Forms.Button();
            this.nudThick = new System.Windows.Forms.NumericUpDown();
            this.lblLineStyle = new System.Windows.Forms.Label();
            this.dlgColor = new System.Windows.Forms.ColorDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tbNode = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.tbRevision = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lblNode = new System.Windows.Forms.Label();
            this.lblRevision = new System.Windows.Forms.Label();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.chkIsPrototype = new System.Windows.Forms.CheckBox();
            this.lblID = new System.Windows.Forms.Label();
            this.tbID = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudThick)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnOk, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(384, 212);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOk.Location = new System.Drawing.Point(154, 186);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.lblLineThick, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.cbbStyle, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnLineColor, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.nudThick, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblLineStyle, 4, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 153);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(378, 27);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // lblLineThick
            // 
            this.lblLineThick.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLineThick.AutoSize = true;
            this.lblLineThick.Location = new System.Drawing.Point(3, 7);
            this.lblLineThick.Name = "lblLineThick";
            this.lblLineThick.Size = new System.Drawing.Size(56, 13);
            this.lblLineThick.TabIndex = 0;
            this.lblLineThick.Text = "Thickness";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(106, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "px";
            // 
            // cbbStyle
            // 
            this.cbbStyle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbbStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbStyle.FormattingEnabled = true;
            this.cbbStyle.Items.AddRange(new object[] {
            "––––––––",
            "–   –   –   –",
            "•  •  •  •  •",
            "– • – • – •",
            "– • • – • •",
            "– • – – • –"});
            this.cbbStyle.Location = new System.Drawing.Point(220, 3);
            this.cbbStyle.Name = "cbbStyle";
            this.cbbStyle.Size = new System.Drawing.Size(100, 21);
            this.cbbStyle.TabIndex = 5;
            // 
            // btnLineColor
            // 
            this.btnLineColor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnLineColor.BackColor = System.Drawing.Color.Maroon;
            this.btnLineColor.Location = new System.Drawing.Point(138, 3);
            this.btnLineColor.Margin = new System.Windows.Forms.Padding(11, 3, 11, 3);
            this.btnLineColor.Name = "btnLineColor";
            this.btnLineColor.Size = new System.Drawing.Size(32, 21);
            this.btnLineColor.TabIndex = 4;
            this.btnLineColor.UseVisualStyleBackColor = false;
            this.btnLineColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // nudThick
            // 
            this.nudThick.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudThick.Location = new System.Drawing.Point(65, 3);
            this.nudThick.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.nudThick.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudThick.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudThick.Name = "nudThick";
            this.nudThick.Size = new System.Drawing.Size(40, 20);
            this.nudThick.TabIndex = 3;
            this.nudThick.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudThick.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblLineStyle
            // 
            this.lblLineStyle.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblLineStyle.AutoSize = true;
            this.lblLineStyle.Location = new System.Drawing.Point(184, 7);
            this.lblLineStyle.Name = "lblLineStyle";
            this.lblLineStyle.Size = new System.Drawing.Size(30, 13);
            this.lblLineStyle.TabIndex = 0;
            this.lblLineStyle.Text = "Style";
            this.lblLineStyle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.tbDescription, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel6, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(378, 144);
            this.tableLayoutPanel4.TabIndex = 9;
            // 
            // tbDescription
            // 
            this.tableLayoutPanel4.SetColumnSpan(this.tbDescription, 5);
            this.tbDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDescription.Location = new System.Drawing.Point(3, 81);
            this.tbDescription.MaxLength = 8192;
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDescription.Size = new System.Drawing.Size(372, 60);
            this.tbDescription.TabIndex = 10;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.ColumnCount = 4;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.Controls.Add(this.tbNode, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.lblName, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.tbRevision, 3, 1);
            this.tableLayoutPanel5.Controls.Add(this.tbName, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.lblNode, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.lblRevision, 2, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.Size = new System.Drawing.Size(378, 52);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // tbNode
            // 
            this.tbNode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbNode.Location = new System.Drawing.Point(71, 29);
            this.tbNode.MaxLength = 32;
            this.tbNode.Name = "tbNode";
            this.tbNode.Size = new System.Drawing.Size(163, 20);
            this.tbNode.TabIndex = 3;
            // 
            // lblName
            // 
            this.lblName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(3, 6);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // tbRevision
            // 
            this.tbRevision.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tbRevision.BackColor = System.Drawing.Color.OldLace;
            this.tbRevision.Location = new System.Drawing.Point(265, 29);
            this.tbRevision.MaxLength = 20;
            this.tbRevision.Name = "tbRevision";
            this.tbRevision.ReadOnly = true;
            this.tbRevision.Size = new System.Drawing.Size(110, 20);
            this.tbRevision.TabIndex = 7;
            this.tbRevision.Text = "2000.01.01 12:00:00";
            this.tbRevision.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbName
            // 
            this.tableLayoutPanel5.SetColumnSpan(this.tbName, 3);
            this.tbName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbName.Location = new System.Drawing.Point(71, 3);
            this.tbName.MaxLength = 255;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(304, 20);
            this.tbName.TabIndex = 2;
            // 
            // lblNode
            // 
            this.lblNode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNode.AutoSize = true;
            this.lblNode.Location = new System.Drawing.Point(3, 32);
            this.lblNode.Name = "lblNode";
            this.lblNode.Size = new System.Drawing.Size(62, 13);
            this.lblNode.TabIndex = 0;
            this.lblNode.Text = "Node name";
            // 
            // lblRevision
            // 
            this.lblRevision.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblRevision.AutoSize = true;
            this.lblRevision.Location = new System.Drawing.Point(237, 32);
            this.lblRevision.Margin = new System.Windows.Forms.Padding(0);
            this.lblRevision.Name = "lblRevision";
            this.lblRevision.Size = new System.Drawing.Size(25, 13);
            this.lblRevision.TabIndex = 0;
            this.lblRevision.Text = "rev.";
            this.lblRevision.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.AutoSize = true;
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.Controls.Add(this.chkIsPrototype, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.lblID, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.tbID, 2, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 52);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.Size = new System.Drawing.Size(378, 26);
            this.tableLayoutPanel6.TabIndex = 1;
            // 
            // chkIsPrototype
            // 
            this.chkIsPrototype.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkIsPrototype.AutoSize = true;
            this.chkIsPrototype.Location = new System.Drawing.Point(3, 4);
            this.chkIsPrototype.Name = "chkIsPrototype";
            this.chkIsPrototype.Size = new System.Drawing.Size(71, 17);
            this.chkIsPrototype.TabIndex = 13;
            this.chkIsPrototype.Text = "Prototype";
            this.chkIsPrototype.UseVisualStyleBackColor = true;
            // 
            // lblID
            // 
            this.lblID.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(231, 6);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(18, 13);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID";
            // 
            // tbID
            // 
            this.tbID.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tbID.BackColor = System.Drawing.Color.OldLace;
            this.tbID.Location = new System.Drawing.Point(255, 3);
            this.tbID.MaxLength = 20;
            this.tbID.Name = "tbID";
            this.tbID.ReadOnly = true;
            this.tbID.Size = new System.Drawing.Size(120, 20);
            this.tbID.TabIndex = 8;
            this.tbID.Text = "9859515965827744064";
            this.tbID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LinkEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(384, 212);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(400, 250);
            this.Name = "LinkEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit link";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudThick)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnLineColor;
        private System.Windows.Forms.ComboBox cbbStyle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudThick;
        private System.Windows.Forms.ColorDialog dlgColor;
        private System.Windows.Forms.Label lblLineThick;
        private System.Windows.Forms.Label lblLineStyle;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TextBox tbNode;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbRevision;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lblNode;
        private System.Windows.Forms.Label lblRevision;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.CheckBox chkIsPrototype;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox tbID;
    }
}