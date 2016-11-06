namespace Schematix
{
    partial class BoxOptionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BoxOptionsForm));
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tbText = new System.Windows.Forms.TextBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnGetReference = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lblReference = new System.Windows.Forms.Label();
            this.tbReference = new System.Windows.Forms.TextBox();
            this.lblText = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nudSizeHeight = new System.Windows.Forms.NumericUpDown();
            this.nudSizeWidth = new System.Windows.Forms.NumericUpDown();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSizeHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSizeWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.tbText, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.tbDescription, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnOk, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.btnGetReference, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblName, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tbName, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblReference, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tbReference, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblText, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblSize, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.label1, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.nudSizeHeight, 3, 4);
            this.tableLayoutPanel2.Controls.Add(this.nudSizeWidth, 1, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(284, 192);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // tbText
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.tbText, 4);
            this.tbText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbText.Location = new System.Drawing.Point(66, 114);
            this.tbText.MaxLength = 255;
            this.tbText.Name = "tbText";
            this.tbText.Size = new System.Drawing.Size(215, 20);
            this.tbText.TabIndex = 11;
            // 
            // tbDescription
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.tbDescription, 5);
            this.tbDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDescription.Location = new System.Drawing.Point(3, 58);
            this.tbDescription.MaxLength = 8192;
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDescription.Size = new System.Drawing.Size(278, 50);
            this.tbDescription.TabIndex = 10;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel2.SetColumnSpan(this.btnOk, 5);
            this.btnOk.Location = new System.Drawing.Point(104, 166);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnGetReference
            // 
            this.btnGetReference.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnGetReference.Image = global::Schematix.Properties.Resources.Reference;
            this.btnGetReference.Location = new System.Drawing.Point(258, 3);
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
            this.tableLayoutPanel2.SetColumnSpan(this.tbName, 4);
            this.tbName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbName.Location = new System.Drawing.Point(66, 32);
            this.tbName.MaxLength = 255;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(215, 20);
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
            this.tableLayoutPanel2.SetColumnSpan(this.tbReference, 3);
            this.tbReference.Location = new System.Drawing.Point(66, 4);
            this.tbReference.MaxLength = 32;
            this.tbReference.Name = "tbReference";
            this.tbReference.Size = new System.Drawing.Size(186, 20);
            this.tbReference.TabIndex = 0;
            // 
            // lblText
            // 
            this.lblText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(3, 117);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(28, 13);
            this.lblText.TabIndex = 0;
            this.lblText.Text = "Text";
            // 
            // lblSize
            // 
            this.lblSize.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(3, 143);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(27, 13);
            this.lblSize.TabIndex = 0;
            this.lblSize.Text = "Size";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(132, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "x";
            // 
            // nudSizeHeight
            // 
            this.nudSizeHeight.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudSizeHeight.Location = new System.Drawing.Point(150, 140);
            this.nudSizeHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudSizeHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSizeHeight.Name = "nudSizeHeight";
            this.nudSizeHeight.Size = new System.Drawing.Size(60, 20);
            this.nudSizeHeight.TabIndex = 13;
            this.nudSizeHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudSizeHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudSizeWidth
            // 
            this.nudSizeWidth.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudSizeWidth.Location = new System.Drawing.Point(66, 140);
            this.nudSizeWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudSizeWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSizeWidth.Name = "nudSizeWidth";
            this.nudSizeWidth.Size = new System.Drawing.Size(60, 20);
            this.nudSizeWidth.TabIndex = 13;
            this.nudSizeWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudSizeWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // BoxOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 192);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(300, 230);
            this.Name = "BoxOptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BoxOptionsForm";
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSizeHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSizeWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnGetReference;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lblReference;
        private System.Windows.Forms.TextBox tbReference;
        private System.Windows.Forms.TextBox tbText;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudSizeHeight;
        private System.Windows.Forms.NumericUpDown nudSizeWidth;
        private System.Windows.Forms.ToolTip toolTip;
    }
}