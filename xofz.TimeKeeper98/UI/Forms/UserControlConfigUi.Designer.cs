namespace xofz.TimeKeeper98.UI.Forms
{
    partial class UserControlConfigUi
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.showSecondsCheckBox = new System.Windows.Forms.CheckBox();
            this.promptCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.titleTextTextBox = new System.Windows.Forms.TextBox();
            this.resetTitleTextKey = new System.Windows.Forms.Button();
            this.saveTitleTextKey = new System.Windows.Forms.Button();
            this.defaultTitleTextKeyTapped = new System.Windows.Forms.Button();
            this.keyboardKey = new System.Windows.Forms.Button();
            this.publishKey = new System.Windows.Forms.Button();
            this.core98GroupBox = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.totalTimeStampCountLabel = new System.Windows.Forms.Label();
            this.timestampCountGroupBox = new System.Windows.Forms.GroupBox();
            this.statisticsRangeTimestampCountLabel = new System.Windows.Forms.Label();
            this.thisWeekTimestampCountLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.saveIntervalKey = new System.Windows.Forms.Button();
            this.timerIntervalPicker = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.resetIntervalKey = new System.Windows.Forms.Button();
            this.core98GroupBox.SuspendLayout();
            this.timestampCountGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timerIntervalPicker)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 29);
            this.label1.TabIndex = 99;
            this.label1.Text = "Config";
            // 
            // showSecondsCheckBox
            // 
            this.showSecondsCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.showSecondsCheckBox.AutoSize = true;
            this.showSecondsCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlDark;
            this.showSecondsCheckBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.showSecondsCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showSecondsCheckBox.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showSecondsCheckBox.Location = new System.Drawing.Point(5, 165);
            this.showSecondsCheckBox.Name = "showSecondsCheckBox";
            this.showSecondsCheckBox.Size = new System.Drawing.Size(140, 32);
            this.showSecondsCheckBox.TabIndex = 6;
            this.showSecondsCheckBox.Text = "Show Seconds";
            this.showSecondsCheckBox.UseVisualStyleBackColor = true;
            this.showSecondsCheckBox.CheckedChanged += new System.EventHandler(this.showSecondsCheckBox_CheckedChanged);
            // 
            // promptCheckBox
            // 
            this.promptCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.promptCheckBox.AutoSize = true;
            this.promptCheckBox.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlDark;
            this.promptCheckBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.promptCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.promptCheckBox.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.promptCheckBox.Location = new System.Drawing.Point(5, 34);
            this.promptCheckBox.Name = "promptCheckBox";
            this.promptCheckBox.Size = new System.Drawing.Size(80, 32);
            this.promptCheckBox.TabIndex = 0;
            this.promptCheckBox.Text = "Prompt";
            this.promptCheckBox.UseVisualStyleBackColor = true;
            this.promptCheckBox.CheckedChanged += new System.EventHandler(this.promptCheckBox_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 99;
            this.label2.Text = "Title text:";
            // 
            // titleTextTextBox
            // 
            this.titleTextTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleTextTextBox.Location = new System.Drawing.Point(63, 106);
            this.titleTextTextBox.Name = "titleTextTextBox";
            this.titleTextTextBox.Size = new System.Drawing.Size(434, 29);
            this.titleTextTextBox.TabIndex = 2;
            // 
            // resetTitleTextKey
            // 
            this.resetTitleTextKey.AutoSize = true;
            this.resetTitleTextKey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.resetTitleTextKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.resetTitleTextKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.resetTitleTextKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetTitleTextKey.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetTitleTextKey.Location = new System.Drawing.Point(636, 106);
            this.resetTitleTextKey.Name = "resetTitleTextKey";
            this.resetTitleTextKey.Size = new System.Drawing.Size(72, 34);
            this.resetTitleTextKey.TabIndex = 4;
            this.resetTitleTextKey.Text = "Reset";
            this.resetTitleTextKey.UseVisualStyleBackColor = true;
            this.resetTitleTextKey.Click += new System.EventHandler(this.resetTitleTextKey_Click);
            // 
            // saveTitleTextKey
            // 
            this.saveTitleTextKey.AutoSize = true;
            this.saveTitleTextKey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.saveTitleTextKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.saveTitleTextKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.saveTitleTextKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveTitleTextKey.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveTitleTextKey.Location = new System.Drawing.Point(503, 106);
            this.saveTitleTextKey.Name = "saveTitleTextKey";
            this.saveTitleTextKey.Size = new System.Drawing.Size(62, 34);
            this.saveTitleTextKey.TabIndex = 3;
            this.saveTitleTextKey.Text = "Save";
            this.saveTitleTextKey.UseVisualStyleBackColor = true;
            this.saveTitleTextKey.Click += new System.EventHandler(this.saveTitleTextKey_Click);
            // 
            // defaultTitleTextKeyTapped
            // 
            this.defaultTitleTextKeyTapped.AutoSize = true;
            this.defaultTitleTextKeyTapped.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.defaultTitleTextKeyTapped.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.defaultTitleTextKeyTapped.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.defaultTitleTextKeyTapped.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.defaultTitleTextKeyTapped.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.defaultTitleTextKeyTapped.Location = new System.Drawing.Point(714, 106);
            this.defaultTitleTextKeyTapped.Name = "defaultTitleTextKeyTapped";
            this.defaultTitleTextKeyTapped.Size = new System.Drawing.Size(92, 34);
            this.defaultTitleTextKeyTapped.TabIndex = 5;
            this.defaultTitleTextKeyTapped.Text = "Default";
            this.defaultTitleTextKeyTapped.UseVisualStyleBackColor = true;
            this.defaultTitleTextKeyTapped.Click += new System.EventHandler(this.defaultTitleTextKeyTapped_Click);
            // 
            // keyboardKey
            // 
            this.keyboardKey.AutoSize = true;
            this.keyboardKey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.keyboardKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.keyboardKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.keyboardKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.keyboardKey.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keyboardKey.Location = new System.Drawing.Point(5, 105);
            this.keyboardKey.Name = "keyboardKey";
            this.keyboardKey.Size = new System.Drawing.Size(52, 34);
            this.keyboardKey.TabIndex = 1;
            this.keyboardKey.Text = "Kbd";
            this.keyboardKey.UseVisualStyleBackColor = true;
            this.keyboardKey.Click += new System.EventHandler(this.keyboardKey_Click);
            // 
            // publishKey
            // 
            this.publishKey.AutoSize = true;
            this.publishKey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.publishKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.publishKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.publishKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.publishKey.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.publishKey.Location = new System.Drawing.Point(9, 88);
            this.publishKey.Name = "publishKey";
            this.publishKey.Size = new System.Drawing.Size(92, 34);
            this.publishKey.TabIndex = 100;
            this.publishKey.Text = "Publish";
            this.publishKey.UseVisualStyleBackColor = true;
            this.publishKey.Click += new System.EventHandler(this.publishKey_Click);
            // 
            // core98GroupBox
            // 
            this.core98GroupBox.Controls.Add(this.label3);
            this.core98GroupBox.Controls.Add(this.publishKey);
            this.core98GroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.core98GroupBox.Location = new System.Drawing.Point(503, 165);
            this.core98GroupBox.Name = "core98GroupBox";
            this.core98GroupBox.Size = new System.Drawing.Size(303, 160);
            this.core98GroupBox.TabIndex = 101;
            this.core98GroupBox.TabStop = false;
            this.core98GroupBox.Text = "xofz.Core98";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(255, 57);
            this.label3.TabIndex = 101;
            this.label3.Text = "Library and PDB may be published to current program directory after accepting lic" +
    "ense";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(72, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 16);
            this.label4.TabIndex = 102;
            this.label4.Text = "Total:";
            // 
            // totalTimeStampCountLabel
            // 
            this.totalTimeStampCountLabel.AutoSize = true;
            this.totalTimeStampCountLabel.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalTimeStampCountLabel.Location = new System.Drawing.Point(120, 34);
            this.totalTimeStampCountLabel.Name = "totalTimeStampCountLabel";
            this.totalTimeStampCountLabel.Size = new System.Drawing.Size(103, 28);
            this.totalTimeStampCountLabel.TabIndex = 103;
            this.totalTimeStampCountLabel.Text = "0000000";
            // 
            // timestampCountGroupBox
            // 
            this.timestampCountGroupBox.Controls.Add(this.statisticsRangeTimestampCountLabel);
            this.timestampCountGroupBox.Controls.Add(this.thisWeekTimestampCountLabel);
            this.timestampCountGroupBox.Controls.Add(this.label6);
            this.timestampCountGroupBox.Controls.Add(this.label5);
            this.timestampCountGroupBox.Controls.Add(this.totalTimeStampCountLabel);
            this.timestampCountGroupBox.Controls.Add(this.label4);
            this.timestampCountGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timestampCountGroupBox.Location = new System.Drawing.Point(263, 165);
            this.timestampCountGroupBox.Name = "timestampCountGroupBox";
            this.timestampCountGroupBox.Size = new System.Drawing.Size(234, 160);
            this.timestampCountGroupBox.TabIndex = 104;
            this.timestampCountGroupBox.TabStop = false;
            this.timestampCountGroupBox.Text = "Timestamp Count";
            // 
            // statisticsRangeTimestampCountLabel
            // 
            this.statisticsRangeTimestampCountLabel.AutoSize = true;
            this.statisticsRangeTimestampCountLabel.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statisticsRangeTimestampCountLabel.Location = new System.Drawing.Point(120, 123);
            this.statisticsRangeTimestampCountLabel.Name = "statisticsRangeTimestampCountLabel";
            this.statisticsRangeTimestampCountLabel.Size = new System.Drawing.Size(103, 28);
            this.statisticsRangeTimestampCountLabel.TabIndex = 107;
            this.statisticsRangeTimestampCountLabel.Text = "0000000";
            // 
            // thisWeekTimestampCountLabel
            // 
            this.thisWeekTimestampCountLabel.AutoSize = true;
            this.thisWeekTimestampCountLabel.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thisWeekTimestampCountLabel.Location = new System.Drawing.Point(120, 79);
            this.thisWeekTimestampCountLabel.Name = "thisWeekTimestampCountLabel";
            this.thisWeekTimestampCountLabel.Size = new System.Drawing.Size(103, 28);
            this.thisWeekTimestampCountLabel.TabIndex = 106;
            this.thisWeekTimestampCountLabel.Text = "0000000";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 16);
            this.label6.TabIndex = 105;
            this.label6.Text = "Statistics Range:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(42, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 104;
            this.label5.Text = "This week:";
            // 
            // saveIntervalKey
            // 
            this.saveIntervalKey.AutoSize = true;
            this.saveIntervalKey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.saveIntervalKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.saveIntervalKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.saveIntervalKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveIntervalKey.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveIntervalKey.Location = new System.Drawing.Point(129, 254);
            this.saveIntervalKey.Name = "saveIntervalKey";
            this.saveIntervalKey.Size = new System.Drawing.Size(62, 34);
            this.saveIntervalKey.TabIndex = 105;
            this.saveIntervalKey.Text = "Save";
            this.saveIntervalKey.UseVisualStyleBackColor = true;
            this.saveIntervalKey.Click += new System.EventHandler(this.SaveIntervalKey_Click);
            // 
            // timerIntervalPicker
            // 
            this.timerIntervalPicker.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerIntervalPicker.Location = new System.Drawing.Point(3, 253);
            this.timerIntervalPicker.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.timerIntervalPicker.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.timerIntervalPicker.Name = "timerIntervalPicker";
            this.timerIntervalPicker.Size = new System.Drawing.Size(120, 36);
            this.timerIntervalPicker.TabIndex = 106;
            this.timerIntervalPicker.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1, 230);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(200, 20);
            this.label7.TabIndex = 107;
            this.label7.Text = "Timer interval (seconds)";
            // 
            // resetIntervalKey
            // 
            this.resetIntervalKey.AutoSize = true;
            this.resetIntervalKey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.resetIntervalKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.resetIntervalKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.resetIntervalKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetIntervalKey.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetIntervalKey.Location = new System.Drawing.Point(3, 295);
            this.resetIntervalKey.Name = "resetIntervalKey";
            this.resetIntervalKey.Size = new System.Drawing.Size(72, 34);
            this.resetIntervalKey.TabIndex = 108;
            this.resetIntervalKey.Text = "Reset";
            this.resetIntervalKey.UseVisualStyleBackColor = true;
            this.resetIntervalKey.Click += new System.EventHandler(this.resetIntervalKey_Click);
            // 
            // UserControlConfigUi
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.resetIntervalKey);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.timerIntervalPicker);
            this.Controls.Add(this.saveIntervalKey);
            this.Controls.Add(this.timestampCountGroupBox);
            this.Controls.Add(this.core98GroupBox);
            this.Controls.Add(this.keyboardKey);
            this.Controls.Add(this.defaultTitleTextKeyTapped);
            this.Controls.Add(this.saveTitleTextKey);
            this.Controls.Add(this.resetTitleTextKey);
            this.Controls.Add(this.titleTextTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.promptCheckBox);
            this.Controls.Add(this.showSecondsCheckBox);
            this.Controls.Add(this.label1);
            this.Name = "UserControlConfigUi";
            this.Size = new System.Drawing.Size(884, 345);
            this.core98GroupBox.ResumeLayout(false);
            this.core98GroupBox.PerformLayout();
            this.timestampCountGroupBox.ResumeLayout(false);
            this.timestampCountGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timerIntervalPicker)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox showSecondsCheckBox;
        private System.Windows.Forms.CheckBox promptCheckBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox titleTextTextBox;
        private System.Windows.Forms.Button resetTitleTextKey;
        private System.Windows.Forms.Button saveTitleTextKey;
        private System.Windows.Forms.Button defaultTitleTextKeyTapped;
        private System.Windows.Forms.Button keyboardKey;
        private System.Windows.Forms.Button publishKey;
        private System.Windows.Forms.GroupBox core98GroupBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label totalTimeStampCountLabel;
        private System.Windows.Forms.GroupBox timestampCountGroupBox;
        private System.Windows.Forms.Label statisticsRangeTimestampCountLabel;
        private System.Windows.Forms.Label thisWeekTimestampCountLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button saveIntervalKey;
        private System.Windows.Forms.NumericUpDown timerIntervalPicker;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button resetIntervalKey;
    }
}
