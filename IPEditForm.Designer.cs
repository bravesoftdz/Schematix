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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IPEditForm));
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpMain = new System.Windows.Forms.TabPage();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tlpTimers = new System.Windows.Forms.TableLayoutPanel();
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
            this.tpPings = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lvPings = new System.Windows.Forms.ListView();
            this.clmSendTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmState = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmTripTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ilPingColor = new System.Windows.Forms.ImageList(this.components);
            this.btnClearPings = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel2.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tpMain.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tlpTimers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeOutYellow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeOutGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeOutRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPeriod)).BeginInit();
            this.tpPings.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tabControl, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnOk, 0, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(8, 8);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(418, 296);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpMain);
            this.tabControl.Controls.Add(this.tpPings);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(3, 3);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(412, 261);
            this.tabControl.TabIndex = 3;
            // 
            // tpMain
            // 
            this.tpMain.BackColor = System.Drawing.SystemColors.Control;
            this.tpMain.Controls.Add(this.tlpMain);
            this.tpMain.Location = new System.Drawing.Point(4, 22);
            this.tpMain.Name = "tpMain";
            this.tpMain.Padding = new System.Windows.Forms.Padding(3);
            this.tpMain.Size = new System.Drawing.Size(404, 235);
            this.tpMain.TabIndex = 0;
            this.tpMain.Text = "Main";
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMain.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tlpMain.Controls.Add(this.tbDescription, 0, 1);
            this.tlpMain.Controls.Add(this.tlpTimers, 0, 2);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(3, 3);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.Size = new System.Drawing.Size(398, 229);
            this.tlpMain.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.lblAddress, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblName, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tbAddress, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.tbName, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(418, 52);
            this.tableLayoutPanel3.TabIndex = 17;
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
            // tbAddress
            // 
            this.tbAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAddress.Location = new System.Drawing.Point(54, 3);
            this.tbAddress.MaxLength = 255;
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(361, 20);
            this.tbAddress.TabIndex = 3;
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbName.Location = new System.Drawing.Point(54, 29);
            this.tbName.MaxLength = 255;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(361, 20);
            this.tbName.TabIndex = 5;
            // 
            // tbDescription
            // 
            this.tlpMain.SetColumnSpan(this.tbDescription, 4);
            this.tbDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDescription.Location = new System.Drawing.Point(3, 61);
            this.tbDescription.MaxLength = 4096;
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDescription.Size = new System.Drawing.Size(418, 81);
            this.tbDescription.TabIndex = 15;
            // 
            // tlpTimers
            // 
            this.tlpTimers.AutoSize = true;
            this.tlpTimers.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpTimers.ColumnCount = 5;
            this.tlpTimers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpTimers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpTimers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpTimers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpTimers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTimers.Controls.Add(this.lblTimeOutYellow, 0, 1);
            this.tlpTimers.Controls.Add(this.nudTimeOutYellow, 1, 1);
            this.tlpTimers.Controls.Add(this.lblTimeOutGreen, 0, 0);
            this.tlpTimers.Controls.Add(this.nudTimeOutGreen, 1, 0);
            this.tlpTimers.Controls.Add(this.lblTimeOutRed, 0, 2);
            this.tlpTimers.Controls.Add(this.nudTimeOutRed, 1, 2);
            this.tlpTimers.Controls.Add(this.lblTimeNext, 2, 0);
            this.tlpTimers.Controls.Add(this.dtpDateNext, 3, 0);
            this.tlpTimers.Controls.Add(this.lblPeriod, 2, 1);
            this.tlpTimers.Controls.Add(this.nudPeriod, 3, 1);
            this.tlpTimers.Location = new System.Drawing.Point(3, 148);
            this.tlpTimers.Name = "tlpTimers";
            this.tlpTimers.RowCount = 3;
            this.tlpTimers.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpTimers.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpTimers.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpTimers.Size = new System.Drawing.Size(418, 78);
            this.tlpTimers.TabIndex = 16;
            // 
            // lblTimeOutYellow
            // 
            this.lblTimeOutYellow.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTimeOutYellow.AutoSize = true;
            this.lblTimeOutYellow.Location = new System.Drawing.Point(3, 32);
            this.lblTimeOutYellow.Name = "lblTimeOutYellow";
            this.lblTimeOutYellow.Size = new System.Drawing.Size(109, 13);
            this.lblTimeOutYellow.TabIndex = 2;
            this.lblTimeOutYellow.Text = "+ time out Yellow (ms)";
            // 
            // nudTimeOutYellow
            // 
            this.nudTimeOutYellow.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudTimeOutYellow.Location = new System.Drawing.Point(118, 29);
            this.nudTimeOutYellow.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudTimeOutYellow.Name = "nudTimeOutYellow";
            this.nudTimeOutYellow.Size = new System.Drawing.Size(67, 20);
            this.nudTimeOutYellow.TabIndex = 15;
            this.nudTimeOutYellow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.lblTimeOutGreen.Location = new System.Drawing.Point(3, 6);
            this.lblTimeOutGreen.Name = "lblTimeOutGreen";
            this.lblTimeOutGreen.Size = new System.Drawing.Size(102, 13);
            this.lblTimeOutGreen.TabIndex = 2;
            this.lblTimeOutGreen.Text = "Time out Green (ms)";
            // 
            // nudTimeOutGreen
            // 
            this.nudTimeOutGreen.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudTimeOutGreen.Location = new System.Drawing.Point(118, 3);
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
            this.nudTimeOutGreen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.lblTimeOutRed.Location = new System.Drawing.Point(3, 58);
            this.lblTimeOutRed.Name = "lblTimeOutRed";
            this.lblTimeOutRed.Size = new System.Drawing.Size(98, 13);
            this.lblTimeOutRed.TabIndex = 2;
            this.lblTimeOutRed.Text = "+ time out Red (ms)";
            // 
            // nudTimeOutRed
            // 
            this.nudTimeOutRed.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudTimeOutRed.Location = new System.Drawing.Point(118, 55);
            this.nudTimeOutRed.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudTimeOutRed.Name = "nudTimeOutRed";
            this.nudTimeOutRed.Size = new System.Drawing.Size(67, 20);
            this.nudTimeOutRed.TabIndex = 15;
            this.nudTimeOutRed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.lblTimeNext.Location = new System.Drawing.Point(207, 6);
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
            this.dtpDateNext.Location = new System.Drawing.Point(275, 3);
            this.dtpDateNext.Name = "dtpDateNext";
            this.dtpDateNext.ShowCheckBox = true;
            this.dtpDateNext.Size = new System.Drawing.Size(140, 20);
            this.dtpDateNext.TabIndex = 16;
            this.dtpDateNext.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // lblPeriod
            // 
            this.lblPeriod.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.Location = new System.Drawing.Point(210, 32);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(59, 13);
            this.lblPeriod.TabIndex = 2;
            this.lblPeriod.Text = "Period (ms)";
            // 
            // nudPeriod
            // 
            this.nudPeriod.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.nudPeriod.Location = new System.Drawing.Point(335, 29);
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
            this.nudPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPeriod.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // tpPings
            // 
            this.tpPings.BackColor = System.Drawing.SystemColors.Control;
            this.tpPings.Controls.Add(this.tableLayoutPanel4);
            this.tpPings.Location = new System.Drawing.Point(4, 22);
            this.tpPings.Name = "tpPings";
            this.tpPings.Padding = new System.Windows.Forms.Padding(3);
            this.tpPings.Size = new System.Drawing.Size(404, 235);
            this.tpPings.TabIndex = 1;
            this.tpPings.Text = "Pings";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.lvPings, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.btnClearPings, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(398, 229);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // lvPings
            // 
            this.lvPings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmSendTime,
            this.clmState,
            this.clmTripTime});
            this.tableLayoutPanel4.SetColumnSpan(this.lvPings, 2);
            this.lvPings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPings.FullRowSelect = true;
            this.lvPings.GridLines = true;
            this.lvPings.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvPings.HideSelection = false;
            this.lvPings.Location = new System.Drawing.Point(3, 27);
            this.lvPings.Name = "lvPings";
            this.lvPings.Size = new System.Drawing.Size(392, 199);
            this.lvPings.SmallImageList = this.ilPingColor;
            this.lvPings.TabIndex = 0;
            this.lvPings.UseCompatibleStateImageBehavior = false;
            this.lvPings.View = System.Windows.Forms.View.Details;
            // 
            // clmSendTime
            // 
            this.clmSendTime.Text = "Send at";
            this.clmSendTime.Width = 130;
            // 
            // clmState
            // 
            this.clmState.Text = "State";
            this.clmState.Width = 170;
            // 
            // clmTripTime
            // 
            this.clmTripTime.Text = "Trip time";
            this.clmTripTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ilPingColor
            // 
            this.ilPingColor.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilPingColor.ImageStream")));
            this.ilPingColor.TransparentColor = System.Drawing.Color.Transparent;
            this.ilPingColor.Images.SetKeyName(0, "dotWhite.png");
            this.ilPingColor.Images.SetKeyName(1, "dotGreen.png");
            this.ilPingColor.Images.SetKeyName(2, "dotYellow.png");
            this.ilPingColor.Images.SetKeyName(3, "dotRed.png");
            this.ilPingColor.Images.SetKeyName(4, "dotGray.png");
            this.ilPingColor.Images.SetKeyName(5, "dotRedGreen.png");
            // 
            // btnClearPings
            // 
            this.btnClearPings.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnClearPings.Image = global::Schematix.Properties.Resources.deleteAll;
            this.btnClearPings.Location = new System.Drawing.Point(371, 0);
            this.btnClearPings.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnClearPings.Name = "btnClearPings";
            this.btnClearPings.Size = new System.Drawing.Size(24, 24);
            this.btnClearPings.TabIndex = 6;
            this.btnClearPings.UseVisualStyleBackColor = true;
            this.btnClearPings.Click += new System.EventHandler(this.btnClearPings_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOk.Location = new System.Drawing.Point(171, 270);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // IPEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(434, 312);
            this.Controls.Add(this.tableLayoutPanel2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 350);
            this.Name = "IPEditForm";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit IP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IPEditForm_FormClosing);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tpMain.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tlpTimers.ResumeLayout(false);
            this.tlpTimers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeOutYellow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeOutGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeOutRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPeriod)).EndInit();
            this.tpPings.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tlpTimers;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblTimeOutYellow;
        private System.Windows.Forms.NumericUpDown nudTimeOutYellow;
        private System.Windows.Forms.Label lblTimeOutGreen;
        private System.Windows.Forms.NumericUpDown nudTimeOutGreen;
        private System.Windows.Forms.Label lblTimeOutRed;
        private System.Windows.Forms.NumericUpDown nudTimeOutRed;
        private System.Windows.Forms.Label lblTimeNext;
        private System.Windows.Forms.DateTimePicker dtpDateNext;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.NumericUpDown nudPeriod;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpMain;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TabPage tpPings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.ListView lvPings;
        private System.Windows.Forms.ColumnHeader clmSendTime;
        private System.Windows.Forms.ColumnHeader clmState;
        private System.Windows.Forms.ColumnHeader clmTripTime;
        private System.Windows.Forms.ImageList ilPingColor;
        private System.Windows.Forms.Button btnClearPings;
        private System.Windows.Forms.ToolTip toolTip;
    }
}