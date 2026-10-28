namespace Group71.Presentation
{
    partial class OccupanyReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OccupanyReport));
            this._occupancyenddatelabel = new System.Windows.Forms.Label();
            this.occupancy_end_datetimepicker = new System.Windows.Forms.DateTimePicker();
            this.occupancy_start_datetimepicker = new System.Windows.Forms.DateTimePicker();
            this._occupancystartdatelabel = new System.Windows.Forms.Label();
            this.txtOccupancyRpt = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageBookingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageGuestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.financialReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _occupancyenddatelabel
            // 
            this._occupancyenddatelabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._occupancyenddatelabel.AutoSize = true;
            this._occupancyenddatelabel.BackColor = System.Drawing.Color.Gray;
            this._occupancyenddatelabel.Font = new System.Drawing.Font("Californian FB", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._occupancyenddatelabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this._occupancyenddatelabel.Location = new System.Drawing.Point(795, 89);
            this._occupancyenddatelabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._occupancyenddatelabel.Name = "_occupancyenddatelabel";
            this._occupancyenddatelabel.Size = new System.Drawing.Size(420, 32);
            this._occupancyenddatelabel.TabIndex = 10;
            this._occupancyenddatelabel.Text = "Select Occupancy Reoprt End Date";
            // 
            // occupancy_end_datetimepicker
            // 
            this.occupancy_end_datetimepicker.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.occupancy_end_datetimepicker.Location = new System.Drawing.Point(874, 149);
            this.occupancy_end_datetimepicker.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.occupancy_end_datetimepicker.Name = "occupancy_end_datetimepicker";
            this.occupancy_end_datetimepicker.Size = new System.Drawing.Size(298, 26);
            this.occupancy_end_datetimepicker.TabIndex = 9;
            // 
            // occupancy_start_datetimepicker
            // 
            this.occupancy_start_datetimepicker.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.occupancy_start_datetimepicker.Location = new System.Drawing.Point(254, 149);
            this.occupancy_start_datetimepicker.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.occupancy_start_datetimepicker.Name = "occupancy_start_datetimepicker";
            this.occupancy_start_datetimepicker.Size = new System.Drawing.Size(298, 26);
            this.occupancy_start_datetimepicker.TabIndex = 8;
            // 
            // _occupancystartdatelabel
            // 
            this._occupancystartdatelabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this._occupancystartdatelabel.AutoSize = true;
            this._occupancystartdatelabel.BackColor = System.Drawing.Color.Gray;
            this._occupancystartdatelabel.Font = new System.Drawing.Font("Californian FB", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._occupancystartdatelabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this._occupancystartdatelabel.Location = new System.Drawing.Point(236, 89);
            this._occupancystartdatelabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this._occupancystartdatelabel.Name = "_occupancystartdatelabel";
            this._occupancystartdatelabel.Size = new System.Drawing.Size(419, 32);
            this._occupancystartdatelabel.TabIndex = 7;
            this._occupancystartdatelabel.Text = "Select Occupancy Report Sart Date";
            // 
            // txtOccupancyRpt
            // 
            this.txtOccupancyRpt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtOccupancyRpt.Font = new System.Drawing.Font("Californian FB", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOccupancyRpt.Location = new System.Drawing.Point(110, 248);
            this.txtOccupancyRpt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOccupancyRpt.Multiline = true;
            this.txtOccupancyRpt.Name = "txtOccupancyRpt";
            this.txtOccupancyRpt.ReadOnly = true;
            this.txtOccupancyRpt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOccupancyRpt.Size = new System.Drawing.Size(1034, 527);
            this.txtOccupancyRpt.TabIndex = 11;
            this.txtOccupancyRpt.Text = "Occupancy Report";
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.Gray;
            this.btnGenerate.Font = new System.Drawing.Font("Californian FB", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.ForeColor = System.Drawing.Color.White;
            this.btnGenerate.Location = new System.Drawing.Point(446, 786);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(366, 42);
            this.btnGenerate.TabIndex = 20;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.manageBookingsToolStripMenuItem,
            this.manageGuestsToolStripMenuItem,
            this.financialReportsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1230, 35);
            this.menuStrip1.TabIndex = 21;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(77, 29);
            this.homeToolStripMenuItem.Text = "Home";
            this.homeToolStripMenuItem.Click += new System.EventHandler(this.homeToolStripMenuItem_Click);
            // 
            // manageBookingsToolStripMenuItem
            // 
            this.manageBookingsToolStripMenuItem.Name = "manageBookingsToolStripMenuItem";
            this.manageBookingsToolStripMenuItem.Size = new System.Drawing.Size(171, 29);
            this.manageBookingsToolStripMenuItem.Text = "Manage Bookings";
            this.manageBookingsToolStripMenuItem.Click += new System.EventHandler(this.manageBookingsToolStripMenuItem_Click);
            // 
            // manageGuestsToolStripMenuItem
            // 
            this.manageGuestsToolStripMenuItem.Name = "manageGuestsToolStripMenuItem";
            this.manageGuestsToolStripMenuItem.Size = new System.Drawing.Size(150, 29);
            this.manageGuestsToolStripMenuItem.Text = "Manage Guests";
            this.manageGuestsToolStripMenuItem.Click += new System.EventHandler(this.manageGuestsToolStripMenuItem_Click);
            // 
            // financialReportsToolStripMenuItem
            // 
            this.financialReportsToolStripMenuItem.Name = "financialReportsToolStripMenuItem";
            this.financialReportsToolStripMenuItem.Size = new System.Drawing.Size(161, 29);
            this.financialReportsToolStripMenuItem.Text = "Financial Reports";
            this.financialReportsToolStripMenuItem.Click += new System.EventHandler(this.financialReportsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(55, 29);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // OccupanyReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1230, 843);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.txtOccupancyRpt);
            this.Controls.Add(this._occupancyenddatelabel);
            this.Controls.Add(this.occupancy_end_datetimepicker);
            this.Controls.Add(this.occupancy_start_datetimepicker);
            this.Controls.Add(this._occupancystartdatelabel);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "OccupanyReport";
            this.Text = "OccupancyReport";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label _occupancyenddatelabel;
        private System.Windows.Forms.DateTimePicker occupancy_end_datetimepicker;
        private System.Windows.Forms.DateTimePicker occupancy_start_datetimepicker;
        private System.Windows.Forms.Label _occupancystartdatelabel;
        private System.Windows.Forms.TextBox txtOccupancyRpt;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageBookingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageGuestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem financialReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}