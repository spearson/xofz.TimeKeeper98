namespace xofz.TimeKeeper98.UI.Forms
{
    partial class UserControlDailyUi
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
            this.statisticsRangeKey = new System.Windows.Forms.RadioButton();
            this.currentKey = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.infoTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // statisticsRangeKey
            // 
            this.statisticsRangeKey.Appearance = System.Windows.Forms.Appearance.Button;
            this.statisticsRangeKey.AutoSize = true;
            this.statisticsRangeKey.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlDark;
            this.statisticsRangeKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.statisticsRangeKey.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
            this.statisticsRangeKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.statisticsRangeKey.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statisticsRangeKey.Location = new System.Drawing.Point(241, 5);
            this.statisticsRangeKey.Name = "statisticsRangeKey";
            this.statisticsRangeKey.Size = new System.Drawing.Size(148, 30);
            this.statisticsRangeKey.TabIndex = 8;
            this.statisticsRangeKey.Text = "Statistics Range";
            this.statisticsRangeKey.UseVisualStyleBackColor = true;
            this.statisticsRangeKey.Click += new System.EventHandler(this.statisticsRangeKey_Click);
            // 
            // currentKey
            // 
            this.currentKey.Appearance = System.Windows.Forms.Appearance.Button;
            this.currentKey.AutoSize = true;
            this.currentKey.Checked = true;
            this.currentKey.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlDark;
            this.currentKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.currentKey.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark;
            this.currentKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.currentKey.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentKey.Location = new System.Drawing.Point(159, 5);
            this.currentKey.Name = "currentKey";
            this.currentKey.Size = new System.Drawing.Size(76, 30);
            this.currentKey.TabIndex = 7;
            this.currentKey.TabStop = true;
            this.currentKey.Text = "Current";
            this.currentKey.UseVisualStyleBackColor = true;
            this.currentKey.Click += new System.EventHandler(this.currentKey_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 2);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 29);
            this.label4.TabIndex = 9;
            this.label4.Text = "Daily Info";
            // 
            // infoTextBox
            // 
            this.infoTextBox.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infoTextBox.Location = new System.Drawing.Point(5, 43);
            this.infoTextBox.Multiline = true;
            this.infoTextBox.Name = "infoTextBox";
            this.infoTextBox.ReadOnly = true;
            this.infoTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.infoTextBox.Size = new System.Drawing.Size(384, 299);
            this.infoTextBox.TabIndex = 10;
            // 
            // UserControlDailyUi
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.infoTextBox);
            this.Controls.Add(this.statisticsRangeKey);
            this.Controls.Add(this.currentKey);
            this.Controls.Add(this.label4);
            this.Name = "UserControlDailyUi";
            this.Size = new System.Drawing.Size(884, 345);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        protected System.Windows.Forms.RadioButton statisticsRangeKey;
        protected System.Windows.Forms.RadioButton currentKey;
        protected System.Windows.Forms.TextBox infoTextBox;
    }
}
