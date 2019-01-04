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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.endDatePicker = new System.Windows.Forms.MonthCalendar();
            this.startDatePicker = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timeWorkedLabel = new System.Windows.Forms.Label();
            this.avgDailyLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.minDailyLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.maxDailyLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.previousWeekKey = new System.Windows.Forms.Button();
            this.nextWeekKey = new System.Windows.Forms.Button();
            this.currentWeekKey = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(228, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 25);
            this.label4.TabIndex = 99;
            this.label4.Text = "End:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 25);
            this.label3.TabIndex = 99;
            this.label3.Text = "Start:";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 29);
            this.label1.TabIndex = 99;
            this.label1.Text = "Statistics";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(476, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 20);
            this.label2.TabIndex = 99;
            this.label2.Text = "Time worked:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(469, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 45);
            this.label6.TabIndex = 99;
            this.label6.Text = "Average daily time worked:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(469, 152);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 45);
            this.label7.TabIndex = 99;
            this.label7.Text = "Min. daily time worked:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(469, 197);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 45);
            this.label8.TabIndex = 99;
            this.label8.Text = "Max. daily time worked:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.Controls.Add(this.label8);
            this.Controls.Add(this.minDailyLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.avgDailyLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.timeWorkedLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.endDatePicker);
            this.Controls.Add(this.startDatePicker);
            this.Name = "UserControlStatisticsUi";
            this.Size = new System.Drawing.Size(884, 345);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MonthCalendar endDatePicker;
        private System.Windows.Forms.MonthCalendar startDatePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label timeWorkedLabel;
        private System.Windows.Forms.Label avgDailyLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label minDailyLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label maxDailyLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button previousWeekKey;
        private System.Windows.Forms.Button nextWeekKey;
        private System.Windows.Forms.Button currentWeekKey;
    }
}
