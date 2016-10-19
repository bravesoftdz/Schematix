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
            this.lblPeriod = new System.Windows.Forms.Label();
            this.lblTimeOut = new System.Windows.Forms.Label();
            this.nudPeriod = new System.Windows.Forms.NumericUpDown();
            this.nudTimeOut = new System.Windows.Forms.NumericUpDown();
            this.lblTimeNext = new System.Windows.Forms.Label();
            this.dtpDateNext = new System.Windows.Forms.DateTimePicker();
            this.dtpTimeNext = new System.Windows.Forms.DateTimePicker();
            this.lblAddress = new System.Windows.Forms.Label();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeOut)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tbDescription, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnOk, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblPeriod, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblTimeOut, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.nudPeriod, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.nudTimeOut, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblAddress, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbAddress, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTimeNext, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.dtpDateNext, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.dtpTimeNext, 4, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 8);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(418, 196);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tbDescription
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tbDescription, 5);
            this.tbDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDescription.Location = new System.Drawing.Point(3, 55);
            this.tbDescription.MaxLength = 4096;
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDescription.Size = new System.Drawing.Size(412, 57);
            this.tbDescription.TabIndex = 14;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.SetColumnSpan(this.btnOk, 5);
            this.btnOk.Location = new System.Drawing.Point(171, 170);
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
            this.tableLayoutPanel1.SetColumnSpan(this.tbName, 4);
            this.tbName.Location = new System.Drawing.Point(79, 29);
            this.tbName.MaxLength = 255;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(336, 20);
            this.tbName.TabIndex = 5;
            // 
            // lblPeriod
            // 
            this.lblPeriod.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.Location = new System.Drawing.Point(3, 121);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(59, 13);
            this.lblPeriod.TabIndex = 2;
            this.lblPeriod.Text = "Period (ms)";
            // 
            // lblTimeOut
            // 
            this.lblTimeOut.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTimeOut.AutoSize = true;
            this.lblTimeOut.Location = new System.Drawing.Point(3, 147);
            this.lblTimeOut.Name = "lblTimeOut";
            this.lblTimeOut.Size = new System.Drawing.Size(70, 13);
            this.lblTimeOut.TabIndex = 2;
            this.lblTimeOut.Text = "Time out (ms)";
            // 
            // nudPeriod
            // 
            this.nudPeriod.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudPeriod.Location = new System.Drawing.Point(79, 118);
            this.nudPeriod.Maximum = new decimal(new int[] {
            3600000,
            0,
            0,
            0});
            this.nudPeriod.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPeriod.Name = "nudPeriod";
            this.nudPeriod.Size = new System.Drawing.Size(67, 20);
            this.nudPeriod.TabIndex = 15;
            this.nudPeriod.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudTimeOut
            // 
            this.nudTimeOut.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudTimeOut.Location = new System.Drawing.Point(79, 144);
            this.nudTimeOut.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.nudTimeOut.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTimeOut.Name = "nudTimeOut";
            this.nudTimeOut.Size = new System.Drawing.Size(67, 20);
            this.nudTimeOut.TabIndex = 15;
            this.nudTimeOut.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblTimeNext
            // 
            this.lblTimeNext.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTimeNext.AutoSize = true;
            this.lblTimeNext.Location = new System.Drawing.Point(152, 121);
            this.lblTimeNext.Name = "lblTimeNext";
            this.lblTimeNext.Size = new System.Drawing.Size(62, 13);
            this.lblTimeNext.TabIndex = 2;
            this.lblTimeNext.Text = "Next check";
            // 
            // dtpDateNext
            // 
            this.dtpDateNext.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpDateNext.CustomFormat = "yyyy.MM.dd";
            this.dtpDateNext.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateNext.Location = new System.Drawing.Point(220, 118);
            this.dtpDateNext.Name = "dtpDateNext";
            this.dtpDateNext.ShowCheckBox = true;
            this.dtpDateNext.Size = new System.Drawing.Size(110, 20);
            this.dtpDateNext.TabIndex = 16;
            // 
            // dtpTimeNext
            // 
            this.dtpTimeNext.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpTimeNext.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTimeNext.Location = new System.Drawing.Point(336, 118);
            this.dtpTimeNext.Name = "dtpTimeNext";
            this.dtpTimeNext.ShowUpDown = true;
            this.dtpTimeNext.Size = new System.Drawing.Size(70, 20);
            this.dtpTimeNext.TabIndex = 16;
            this.dtpTimeNext.Value = new System.DateTime(2016, 10, 19, 15, 35, 0, 0);
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
            this.tableLayoutPanel1.SetColumnSpan(this.tbAddress, 4);
            this.tbAddress.Location = new System.Drawing.Point(79, 3);
            this.tbAddress.MaxLength = 255;
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(336, 20);
            this.tbAddress.TabIndex = 3;
            // 
            // IPEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(434, 212);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 250);
            this.Name = "IPEditForm";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IPEditForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeOut)).EndInit();
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
        private System.Windows.Forms.Label lblTimeOut;
        private System.Windows.Forms.NumericUpDown nudPeriod;
        private System.Windows.Forms.NumericUpDown nudTimeOut;
        private System.Windows.Forms.Label lblTimeNext;
        private System.Windows.Forms.DateTimePicker dtpDateNext;
        private System.Windows.Forms.DateTimePicker dtpTimeNext;
        private System.Windows.Forms.Label lblAddress;
    }
}