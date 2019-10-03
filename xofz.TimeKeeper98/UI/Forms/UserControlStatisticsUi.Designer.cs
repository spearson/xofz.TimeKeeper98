namespace xofz.TimeKeeper98.UI.Forms
{
    partial class UserControlStatisticsUi
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
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.endLabel = new System.Windows.Forms.Label();
            this.startLabel = new System.Windows.Forms.Label();
            this.endDatePicker = new System.Windows.Forms.MonthCalendar();
            this.startDatePicker = new System.Windows.Forms.MonthCalendar();
            this.labelLabel = new System.Windows.Forms.Label();
            this.timeWorkedLabelLabel = new System.Windows.Forms.Label();
            this.timeWorkedLabel = new System.Windows.Forms.Label();
            this.avgDailyLabel = new System.Windows.Forms.Label();
            this.avgDailyLabelLabel = new System.Windows.Forms.Label();
            this.minDailyLabel = new System.Windows.Forms.Label();
            this.minDailyLabelLabel = new System.Windows.Forms.Label();
            this.maxDailyLabel = new System.Windows.Forms.Label();
            this.maxDailyLabelLabel = new System.Windows.Forms.Label();
            this.previousWeekKey = new System.Windows.Forms.Button();
            this.nextWeekKey = new System.Windows.Forms.Button();
            this.currentWeekKey = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // endLabel
            // 
            this.endLabel.AutoSize = true;
            this.endLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endLabel.Location = new System.Drawing.Point(228, 42);
            this.endLabel.Name = "endLabel";
            this.endLabel.Size = new System.Drawing.Size(60, 25);
            this.endLabel.TabIndex = 99;
            this.endLabel.Text = "End:";
            // 
            // startLabel
            // 
            this.startLabel.AutoSize = true;
            this.startLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startLabel.Location = new System.Drawing.Point(3, 42);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(69, 25);
            this.startLabel.TabIndex = 99;
            this.startLabel.Text = "Start:";
            // 
            // endDatePicker
            // 
            this.endDatePicker.Location = new System.Drawing.Point(233, 76);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.TabIndex = 1;
            this.endDatePicker.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.endDatePicker_DateChanged);
            // 
            // startDatePicker
            // 
            this.startDatePicker.Location = new System.Drawing.Point(0, 76);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.TabIndex = 0;
            this.startDatePicker.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.startDatePicker_DateChanged);
            // 
            // labelLabel
            // 
            this.labelLabel.AutoSize = true;
            this.labelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLabel.Location = new System.Drawing.Point(0, 2);
            this.labelLabel.Margin = new System.Windows.Forms.Padding(0);
            this.labelLabel.Name = "labelLabel";
            this.labelLabel.Size = new System.Drawing.Size(118, 29);
            this.labelLabel.TabIndex = 99;
            this.labelLabel.Text = "Statistics";
            // 
            // timeWorkedLabelLabel
            // 
            this.timeWorkedLabelLabel.AutoSize = true;
            this.timeWorkedLabelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeWorkedLabelLabel.Location = new System.Drawing.Point(476, 83);
            this.timeWorkedLabelLabel.Name = "timeWorkedLabelLabel";
            this.timeWorkedLabelLabel.Size = new System.Drawing.Size(102, 20);
            this.timeWorkedLabelLabel.TabIndex = 99;
            this.timeWorkedLabelLabel.Text = "Time worked:";
            this.timeWorkedLabelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timeWorkedLabel
            // 
            this.timeWorkedLabel.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeWorkedLabel.Location = new System.Drawing.Point(584, 80);
            this.timeWorkedLabel.Name = "timeWorkedLabel";
            this.timeWorkedLabel.Size = new System.Drawing.Size(143, 24);
            this.timeWorkedLabel.TabIndex = 99;
            this.timeWorkedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // avgDailyLabel
            // 
            this.avgDailyLabel.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avgDailyLabel.Location = new System.Drawing.Point(584, 116);
            this.avgDailyLabel.Name = "avgDailyLabel";
            this.avgDailyLabel.Size = new System.Drawing.Size(143, 24);
            this.avgDailyLabel.TabIndex = 99;
            this.avgDailyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // avgDailyLabelLabel
            // 
            this.avgDailyLabelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avgDailyLabelLabel.Location = new System.Drawing.Point(469, 107);
            this.avgDailyLabelLabel.Name = "avgDailyLabelLabel";
            this.avgDailyLabelLabel.Size = new System.Drawing.Size(109, 45);
            this.avgDailyLabelLabel.TabIndex = 99;
            this.avgDailyLabelLabel.Text = "Average daily time worked:";
            this.avgDailyLabelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // minDailyLabel
            // 
            this.minDailyLabel.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minDailyLabel.Location = new System.Drawing.Point(584, 161);
            this.minDailyLabel.Name = "minDailyLabel";
            this.minDailyLabel.Size = new System.Drawing.Size(143, 24);
            this.minDailyLabel.TabIndex = 99;
            this.minDailyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // minDailyLabelLabel
            // 
            this.minDailyLabelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minDailyLabelLabel.Location = new System.Drawing.Point(469, 152);
            this.minDailyLabelLabel.Name = "minDailyLabelLabel";
            this.minDailyLabelLabel.Size = new System.Drawing.Size(109, 45);
            this.minDailyLabelLabel.TabIndex = 99;
            this.minDailyLabelLabel.Text = "Min. daily time worked:";
            this.minDailyLabelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // maxDailyLabel
            // 
            this.maxDailyLabel.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxDailyLabel.Location = new System.Drawing.Point(584, 205);
            this.maxDailyLabel.Name = "maxDailyLabel";
            this.maxDailyLabel.Size = new System.Drawing.Size(143, 24);
            this.maxDailyLabel.TabIndex = 99;
            this.maxDailyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // maxDailyLabelLabel
            // 
            this.maxDailyLabelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxDailyLabelLabel.Location = new System.Drawing.Point(469, 197);
            this.maxDailyLabelLabel.Name = "maxDailyLabelLabel";
            this.maxDailyLabelLabel.Size = new System.Drawing.Size(109, 45);
            this.maxDailyLabelLabel.TabIndex = 99;
            this.maxDailyLabelLabel.Text = "Max. daily time worked:";
            this.maxDailyLabelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // previousWeekKey
            // 
            this.previousWeekKey.AutoSize = true;
            this.previousWeekKey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.previousWeekKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.previousWeekKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.previousWeekKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.previousWeekKey.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previousWeekKey.Location = new System.Drawing.Point(0, 247);
            this.previousWeekKey.Margin = new System.Windows.Forms.Padding(0);
            this.previousWeekKey.Name = "previousWeekKey";
            this.previousWeekKey.Size = new System.Drawing.Size(148, 30);
            this.previousWeekKey.TabIndex = 2;
            this.previousWeekKey.Text = "<< Previous Week";
            this.previousWeekKey.UseVisualStyleBackColor = true;
            this.previousWeekKey.Click += new System.EventHandler(this.previousWeekKey_Click);
            // 
            // nextWeekKey
            // 
            this.nextWeekKey.AutoSize = true;
            this.nextWeekKey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.nextWeekKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.nextWeekKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.nextWeekKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextWeekKey.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextWeekKey.Location = new System.Drawing.Point(344, 247);
            this.nextWeekKey.Margin = new System.Windows.Forms.Padding(0);
            this.nextWeekKey.Name = "nextWeekKey";
            this.nextWeekKey.Size = new System.Drawing.Size(116, 30);
            this.nextWeekKey.TabIndex = 4;
            this.nextWeekKey.Text = "Next Week >>";
            this.nextWeekKey.UseVisualStyleBackColor = true;
            this.nextWeekKey.Click += new System.EventHandler(this.nextWeekKey_Click);
            // 
            // currentWeekKey
            // 
            this.currentWeekKey.AutoSize = true;
            this.currentWeekKey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.currentWeekKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.currentWeekKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.currentWeekKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.currentWeekKey.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentWeekKey.Location = new System.Drawing.Point(188, 247);
            this.currentWeekKey.Margin = new System.Windows.Forms.Padding(0);
            this.currentWeekKey.Name = "currentWeekKey";
            this.currentWeekKey.Size = new System.Drawing.Size(116, 30);
            this.currentWeekKey.TabIndex = 3;
            this.currentWeekKey.Text = "Current Week";
            this.currentWeekKey.UseVisualStyleBackColor = true;
            this.currentWeekKey.Click += new System.EventHandler(this.currentWeekKey_Click);
            // 
            // UserControlStatisticsUi
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.currentWeekKey);
            this.Controls.Add(this.nextWeekKey);
            this.Controls.Add(this.previousWeekKey);
            this.Controls.Add(this.maxDailyLabel);
            this.Controls.Add(this.maxDailyLabelLabel);
            this.Controls.Add(this.minDailyLabel);
            this.Controls.Add(this.minDailyLabelLabel);
            this.Controls.Add(this.avgDailyLabel);
            this.Controls.Add(this.avgDailyLabelLabel);
            this.Controls.Add(this.timeWorkedLabel);
            this.Controls.Add(this.timeWorkedLabelLabel);
            this.Controls.Add(this.labelLabel);
            this.Controls.Add(this.endLabel);
            this.Controls.Add(this.startLabel);
            this.Controls.Add(this.endDatePicker);
            this.Controls.Add(this.startDatePicker);
            this.Name = "UserControlStatisticsUi";
            this.Size = new System.Drawing.Size(884, 345);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected System.Windows.Forms.Label labelLabel;
        protected System.Windows.Forms.Label endLabel;
        protected System.Windows.Forms.Label startLabel;
        protected System.Windows.Forms.MonthCalendar endDatePicker;
        protected System.Windows.Forms.MonthCalendar startDatePicker;
        protected System.Windows.Forms.Button previousWeekKey;
        protected System.Windows.Forms.Button nextWeekKey;
        protected System.Windows.Forms.Button currentWeekKey;
        protected System.Windows.Forms.Label timeWorkedLabelLabel;
        protected System.Windows.Forms.Label avgDailyLabel;
        protected System.Windows.Forms.Label avgDailyLabelLabel;
        protected System.Windows.Forms.Label minDailyLabel;
        protected System.Windows.Forms.Label minDailyLabelLabel;
        protected System.Windows.Forms.Label maxDailyLabel;
        protected System.Windows.Forms.Label maxDailyLabelLabel;
        protected System.Windows.Forms.Label timeWorkedLabel;
    }
}
