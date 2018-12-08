namespace xofz.TimeKeeper98.UI.Forms
{
    partial class UserControlTimestampsUi
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
            this.timesInTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timesOutTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.timesSplicedListBox = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.currentKey = new System.Windows.Forms.RadioButton();
            this.statisticsRangeKey = new System.Windows.Forms.RadioButton();
            this.showDurationsCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // timesInTextBox
            // 
            this.timesInTextBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timesInTextBox.Location = new System.Drawing.Point(0, 68);
            this.timesInTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.timesInTextBox.Multiline = true;
            this.timesInTextBox.Name = "timesInTextBox";
            this.timesInTextBox.ReadOnly = true;
            this.timesInTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.timesInTextBox.Size = new System.Drawing.Size(180, 230);
            this.timesInTextBox.TabIndex = 0;
            this.timesInTextBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Times in:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(175, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Times out:";
            // 
            // timesOutTextBox
            // 
            this.timesOutTextBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timesOutTextBox.Location = new System.Drawing.Point(180, 68);
            this.timesOutTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.timesOutTextBox.Multiline = true;
            this.timesOutTextBox.Name = "timesOutTextBox";
            this.timesOutTextBox.ReadOnly = true;
            this.timesOutTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.timesOutTextBox.Size = new System.Drawing.Size(180, 230);
            this.timesOutTextBox.TabIndex = 2;
            this.timesOutTextBox.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(358, 40);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(258, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Times spliced together:";
            // 
            // timesSplicedListBox
            // 
            this.timesSplicedListBox.BackColor = System.Drawing.SystemColors.Control;
            this.timesSplicedListBox.ColumnWidth = 245;
            this.timesSplicedListBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timesSplicedListBox.FormattingEnabled = true;
            this.timesSplicedListBox.ItemHeight = 14;
            this.timesSplicedListBox.Location = new System.Drawing.Point(363, 68);
            this.timesSplicedListBox.MultiColumn = true;
            this.timesSplicedListBox.Name = "timesSplicedListBox";
            this.timesSplicedListBox.ScrollAlwaysVisible = true;
            this.timesSplicedListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.timesSplicedListBox.Size = new System.Drawing.Size(418, 214);
            this.timesSplicedListBox.TabIndex = 5;
            this.timesSplicedListBox.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 2);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 29);
            this.label4.TabIndex = 6;
            this.label4.Text = "Timestamps";
            // 
            // currentKey
            // 
            this.currentKey.Appearance = System.Windows.Forms.Appearance.Button;
            this.currentKey.AutoSize = true;
            this.currentKey.Checked = true;
            this.currentKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.currentKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.currentKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.currentKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentKey.Location = new System.Drawing.Point(159, 3);
            this.currentKey.Name = "currentKey";
            this.currentKey.Size = new System.Drawing.Size(81, 32);
            this.currentKey.TabIndex = 0;
            this.currentKey.TabStop = true;
            this.currentKey.Text = "Current";
            this.currentKey.UseVisualStyleBackColor = true;
            this.currentKey.CheckedChanged += new System.EventHandler(this.currentKey_CheckedChanged);
            // 
            // statisticsRangeKey
            // 
            this.statisticsRangeKey.Appearance = System.Windows.Forms.Appearance.Button;
            this.statisticsRangeKey.AutoSize = true;
            this.statisticsRangeKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.statisticsRangeKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.statisticsRangeKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.statisticsRangeKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statisticsRangeKey.Location = new System.Drawing.Point(246, 3);
            this.statisticsRangeKey.Name = "statisticsRangeKey";
            this.statisticsRangeKey.Size = new System.Drawing.Size(154, 32);
            this.statisticsRangeKey.TabIndex = 1;
            this.statisticsRangeKey.Text = "Statistics Range";
            this.statisticsRangeKey.UseVisualStyleBackColor = true;
            // 
            // showDurationsCheckBox
            // 
            this.showDurationsCheckBox.AutoSize = true;
            this.showDurationsCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showDurationsCheckBox.Location = new System.Drawing.Point(406, 9);
            this.showDurationsCheckBox.Name = "showDurationsCheckBox";
            this.showDurationsCheckBox.Size = new System.Drawing.Size(147, 22);
            this.showDurationsCheckBox.TabIndex = 7;
            this.showDurationsCheckBox.Text = "Show Durations";
            this.showDurationsCheckBox.UseVisualStyleBackColor = true;
            this.showDurationsCheckBox.CheckedChanged += new System.EventHandler(this.showDurationsCheckBox_CheckedChanged);
            // 
            // UserControlTimestampsUi
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.showDurationsCheckBox);
            this.Controls.Add(this.statisticsRangeKey);
            this.Controls.Add(this.currentKey);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.timesSplicedListBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.timesOutTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.timesInTextBox);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UserControlTimestampsUi";
            this.Size = new System.Drawing.Size(784, 298);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox timesInTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox timesOutTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox timesSplicedListBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton currentKey;
        private System.Windows.Forms.RadioButton statisticsRangeKey;
        private System.Windows.Forms.CheckBox showDurationsCheckBox;
    }
}
