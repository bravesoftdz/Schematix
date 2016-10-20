namespace Schematix
{
    partial class IPEditForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.lblTimeOutYellow = new System.Windows.Forms.Label();
            this.nudTimeOutYellow = new System.Windows.Forms.NumericUpDown();
            this.lblTimeOutGreen = new System.Windows.Forms.Label();
            this.nudTimeOutGreen = new System.Windows.Forms.NumericUpDown();
            this.lblTimeOutRed = new System.Windows.Forms.Label();
            this.nudTimeOutRed = new System.Windows.Forms.NumericUpDown();
            this.lblTimeNext = new System.Windows.Forms.Label();
            this.dtpDateNext = new System.Windows.Forms.DateTimePicker();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.nudPeriod = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeOutYellow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeOutGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeOutRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPeriod)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tbDescription, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnOk, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblAddress, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbAddress, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTimeOutYellow, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.nudTimeOutYellow, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblTimeOutGreen, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.nudTimeOutGreen, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblTimeOutRed, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.nudTimeOutRed, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblTimeNext, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.dtpDateNext, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblPeriod, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.nudPeriod, 3, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 8);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(455, 236);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tbDescription
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tbDescription, 4);
            this.tbDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDescription.Location = new System.Drawing.Point(3, 55);
            this.tbDescription.MaxLength = 4096;
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDescription.Size = new System.Drawing.Size(449, 71);
            this.tbDescription.TabIndex = 14;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.SetColumnSpan(this.btnOk, 4);
            this.btnOk.Location = new System.Drawing.Point(190, 210);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblName
            // 
            this.lblName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(3, 32);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name";
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.tbName, 3);
            this.tbName.Location = new System.Drawing.Point(118, 29);
            this.tbName.MaxLength = 255;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(334, 20);
            this.tbName.TabIndex = 5;
            // 
            // lblAddress
            // 
            this.lblAddress.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(3, 6);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(45, 13);
            this.lblAddress.TabIndex = 2;
            this.lblAddress.Text = "Address";
            // 
            // tbAddress
            // 
            this.tbAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.tbAddress, 3);
            this.tbAddress.Location = new System.Drawing.Point(118, 3);
            this.tbAddress.MaxLength = 255;
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(334, 20);
            this.tbAddress.TabIndex = 3;
            // 
            // lblTimeOutYellow
            // 
            this.lblTimeOutYellow.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTimeOutYellow.AutoSize = true;
            this.lblTimeOutYellow.Location = new System.Drawing.Point(3, 161);
            this.lblTimeOutYellow.Name = "lblTimeOutYellow";
            this.lblTimeOutYellow.Size = new System.Drawing.Size(109, 13);
            this.lblTimeOutYellow.TabIndex = 2;
            this.lblTimeOutYellow.Text = "+ time out Yellow (ms)";
            // 
            // nudTimeOutYellow
            // 
            this.nudTimeOutYellow.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudTimeOutYellow.Location = new System.Drawing.Point(118, 158);
            this.nudTimeOutYellow.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudTimeOutYellow.Name = "nudTimeOutYellow";
            this.nudTimeOutYellow.Size = new System.Drawing.Size(67, 20);
            this.nudTimeOutYellow.TabIndex = 15;
            this.nudTimeOutYellow.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // lblTimeOutGreen
            // 
            this.lblTimeOutGreen.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTimeOutGreen.AutoSize = true;
            this.lblTimeOutGreen.Location = new System.Drawing.Point(3, 135);
            this.lblTimeOutGreen.Name = "lblTimeOutGreen";
            this.lblTimeOutGreen.Size = new System.Drawing.Size(102, 13);
            this.lblTimeOutGreen.TabIndex = 2;
            this.lblTimeOutGreen.Text = "Time out Green (ms)";
            // 
            // nudTimeOutGreen
            // 
            this.nudTimeOutGreen.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudTimeOutGreen.Location = new System.Drawing.Point(118, 132);
            this.nudTimeOutGreen.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudTimeOutGreen.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTimeOutGreen.Name = "nudTimeOutGreen";
            this.nudTimeOutGreen.Size = new System.Drawing.Size(67, 20);
            this.nudTimeOutGreen.TabIndex = 15;
            this.nudTimeOutGreen.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // lblTimeOutRed
            // 
            this.lblTimeOutRed.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTimeOutRed.AutoSize = true;
            this.lblTimeOutRed.Location = new System.Drawing.Point(3, 187);
            this.lblTimeOutRed.Name = "lblTimeOutRed";
            this.lblTimeOutRed.Size = new System.Drawing.Size(98, 13);
            this.lblTimeOutRed.TabIndex = 2;
            this.lblTimeOutRed.Text = "+ time out Red (ms)";
            // 
            // nudTimeOutRed
            // 
            this.nudTimeOutRed.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudTimeOutRed.Location = new System.Drawing.Point(118, 184);
            this.nudTimeOutRed.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudTimeOutRed.Name = "nudTimeOutRed";
            this.nudTimeOutRed.Size = new System.Drawing.Size(67, 20);
            this.nudTimeOutRed.TabIndex = 15;
            this.nudTimeOutRed.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // lblTimeNext
            // 
            this.lblTimeNext.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTimeNext.AutoSize = true;
            this.lblTimeNext.Location = new System.Drawing.Point(207, 135);
            this.lblTimeNext.Margin = new System.Windows.Forms.Padding(19, 0, 3, 0);
            this.lblTimeNext.Name = "lblTimeNext";
            this.lblTimeNext.Size = new System.Drawing.Size(62, 13);
            this.lblTimeNext.TabIndex = 2;
            this.lblTimeNext.Text = "Next check";
            // 
            // dtpDateNext
            // 
            this.dtpDateNext.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpDateNext.Checked = false;
            this.dtpDateNext.CustomFormat = "yyyy.MM.dd HH:mm:ss";
            this.dtpDateNext.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateNext.Location = new System.Drawing.Point(275, 132);
            this.dtpDateNext.Name = "dtpDateNext";
            this.dtpDateNext.ShowCheckBox = true;
            this.dtpDateNext.Size = new System.Drawing.Size(160, 20);
            this.dtpDateNext.TabIndex = 16;
            this.dtpDateNext.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // lblPeriod
            // 
            this.lblPeriod.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.Location = new System.Drawing.Point(210, 161);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(59, 13);
            this.lblPeriod.TabIndex = 2;
            this.lblPeriod.Text = "Period (ms)";
            // 
            // nudPeriod
            // 
            this.nudPeriod.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudPeriod.Location = new System.Drawing.Point(275, 158);
            this.nudPeriod.Maximum = new decimal(new int[] {
            86400000,
            0,
            0,
            0});
            this.nudPeriod.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPeriod.Name = "nudPeriod";
            this.nudPeriod.Size = new System.Drawing.Size(80, 20);
            this.nudPeriod.TabIndex = 15;
            this.nudPeriod.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // IPEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(471, 252);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 250);
            this.Name = "IPEditForm";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit IP";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeOutYellow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeOutGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeOutRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPeriod)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.Label lblTimeOutGreen;
        private System.Windows.Forms.NumericUpDown nudPeriod;
        private System.Windows.Forms.NumericUpDown nudTimeOutGreen;
        private System.Windows.Forms.Label lblTimeNext;
        private System.Windows.Forms.DateTimePicker dtpDateNext;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblTimeOutYellow;
        private System.Windows.Forms.NumericUpDown nudTimeOutYellow;
        private System.Windows.Forms.Label lblTimeOutRed;
        private System.Windows.Forms.NumericUpDown nudTimeOutRed;
    }
}