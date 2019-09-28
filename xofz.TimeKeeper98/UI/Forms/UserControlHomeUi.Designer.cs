namespace xofz.TimeKeeper98.UI.Forms
{
    partial class UserControlHomeUi
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
            this.inKey = new System.Windows.Forms.Button();
            this.outKey = new System.Windows.Forms.Button();
            this.timeThisWeekLabelLabel = new System.Windows.Forms.Label();
            this.timeThisWeekLabel = new System.Windows.Forms.Label();
            this.screenPanel = new System.Windows.Forms.Panel();
            this.timeTodayLabel = new System.Windows.Forms.Label();
            this.timeTodayLabelLabel = new System.Windows.Forms.Label();
            this.coreVersionLabel = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.editKey = new System.Windows.Forms.Button();
            this.timeWorkedContainer = new System.Windows.Forms.GroupBox();
            this.timeWorkedContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // inKey
            // 
            this.inKey.AutoSize = true;
            this.inKey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.inKey.BackColor = System.Drawing.Color.LightGreen;
            this.inKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.inKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.inKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.inKey.Font = new System.Drawing.Font("Consolas", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inKey.Location = new System.Drawing.Point(0, 6);
            this.inKey.Margin = new System.Windows.Forms.Padding(0);
            this.inKey.Name = "inKey";
            this.inKey.Size = new System.Drawing.Size(244, 68);
            this.inKey.TabIndex = 0;
            this.inKey.Text = "Clock In";
            this.inKey.UseVisualStyleBackColor = false;
            this.inKey.Click += new System.EventHandler(this.inKey_Click);
            // 
            // outKey
            // 
            this.outKey.AutoSize = true;
            this.outKey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.outKey.BackColor = System.Drawing.Color.MistyRose;
            this.outKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.outKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.outKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.outKey.Font = new System.Drawing.Font("Consolas", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outKey.Location = new System.Drawing.Point(337, 6);
            this.outKey.Margin = new System.Windows.Forms.Padding(0);
            this.outKey.Name = "outKey";
            this.outKey.Size = new System.Drawing.Size(270, 68);
            this.outKey.TabIndex = 1;
            this.outKey.Text = "Clock Out";
            this.outKey.UseVisualStyleBackColor = false;
            this.outKey.Click += new System.EventHandler(this.outKey_Click);
            // 
            // timeThisWeekLabelLabel
            // 
            this.timeThisWeekLabelLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.timeThisWeekLabelLabel.AutoSize = true;
            this.timeThisWeekLabelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeThisWeekLabelLabel.Location = new System.Drawing.Point(10, 16);
            this.timeThisWeekLabelLabel.Name = "timeThisWeekLabelLabel";
            this.timeThisWeekLabelLabel.Size = new System.Drawing.Size(97, 20);
            this.timeThisWeekLabelLabel.TabIndex = 99;
            this.timeThisWeekLabelLabel.Text = "This Week:";
            // 
            // timeThisWeekLabel
            // 
            this.timeThisWeekLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.timeThisWeekLabel.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeThisWeekLabel.Location = new System.Drawing.Point(8, 36);
            this.timeThisWeekLabel.Name = "timeThisWeekLabel";
            this.timeThisWeekLabel.Size = new System.Drawing.Size(207, 34);
            this.timeThisWeekLabel.TabIndex = 99;
            this.timeThisWeekLabel.Text = "000h 00m 00s";
            this.timeThisWeekLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // screenPanel
            // 
            this.screenPanel.Location = new System.Drawing.Point(0, 130);
            this.screenPanel.Margin = new System.Windows.Forms.Padding(0);
            this.screenPanel.Name = "screenPanel";
            this.screenPanel.Size = new System.Drawing.Size(884, 346);
            this.screenPanel.TabIndex = 3;
            this.screenPanel.TabStop = true;
            // 
            // timeTodayLabel
            // 
            this.timeTodayLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.timeTodayLabel.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeTodayLabel.Location = new System.Drawing.Point(8, 92);
            this.timeTodayLabel.Name = "timeTodayLabel";
            this.timeTodayLabel.Size = new System.Drawing.Size(207, 34);
            this.timeTodayLabel.TabIndex = 99;
            this.timeTodayLabel.Text = "000h 00m 00s";
            this.timeTodayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timeTodayLabelLabel
            // 
            this.timeTodayLabelLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.timeTodayLabelLabel.AutoSize = true;
            this.timeTodayLabelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeTodayLabelLabel.Location = new System.Drawing.Point(10, 72);
            this.timeTodayLabelLabel.Name = "timeTodayLabelLabel";
            this.timeTodayLabelLabel.Size = new System.Drawing.Size(62, 20);
            this.timeTodayLabelLabel.TabIndex = 99;
            this.timeTodayLabelLabel.Text = "Today:";
            // 
            // coreVersionLabel
            // 
            this.coreVersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coreVersionLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.coreVersionLabel.Location = new System.Drawing.Point(606, 475);
            this.coreVersionLabel.Margin = new System.Windows.Forms.Padding(0);
            this.coreVersionLabel.Name = "coreVersionLabel";
            this.coreVersionLabel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 10);
            this.coreVersionLabel.Size = new System.Drawing.Size(278, 34);
            this.coreVersionLabel.TabIndex = 99;
            this.coreVersionLabel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // versionLabel
            // 
            this.versionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.versionLabel.Location = new System.Drawing.Point(0, 476);
            this.versionLabel.Margin = new System.Windows.Forms.Padding(0);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 10);
            this.versionLabel.Size = new System.Drawing.Size(200, 34);
            this.versionLabel.TabIndex = 99;
            this.versionLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // editKey
            // 
            this.editKey.AutoSize = true;
            this.editKey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.editKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.editKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.editKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editKey.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editKey.Location = new System.Drawing.Point(0, 96);
            this.editKey.Margin = new System.Windows.Forms.Padding(0);
            this.editKey.Name = "editKey";
            this.editKey.Size = new System.Drawing.Size(212, 34);
            this.editKey.TabIndex = 2;
            this.editKey.Text = "Edit Last Timestamp";
            this.editKey.UseVisualStyleBackColor = true;
            this.editKey.Click += new System.EventHandler(this.editKey_Click);
            // 
            // timeWorkedContainer
            // 
            this.timeWorkedContainer.Controls.Add(this.timeThisWeekLabelLabel);
            this.timeWorkedContainer.Controls.Add(this.timeThisWeekLabel);
            this.timeWorkedContainer.Controls.Add(this.timeTodayLabelLabel);
            this.timeWorkedContainer.Controls.Add(this.timeTodayLabel);
            this.timeWorkedContainer.Location = new System.Drawing.Point(666, 0);
            this.timeWorkedContainer.Margin = new System.Windows.Forms.Padding(0);
            this.timeWorkedContainer.Name = "timeWorkedContainer";
            this.timeWorkedContainer.Size = new System.Drawing.Size(218, 130);
            this.timeWorkedContainer.TabIndex = 100;
            this.timeWorkedContainer.TabStop = false;
            // 
            // UserControlHomeUi
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.timeWorkedContainer);
            this.Controls.Add(this.editKey);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.coreVersionLabel);
            this.Controls.Add(this.screenPanel);
            this.Controls.Add(this.outKey);
            this.Controls.Add(this.inKey);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UserControlHomeUi";
            this.Size = new System.Drawing.Size(884, 511);
            this.timeWorkedContainer.ResumeLayout(false);
            this.timeWorkedContainer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label coreVersionLabel;
        private System.Windows.Forms.Label versionLabel;
        protected System.Windows.Forms.Button inKey;
        protected System.Windows.Forms.Button outKey;
        protected System.Windows.Forms.Button editKey;
        protected System.Windows.Forms.GroupBox timeWorkedContainer;
        protected System.Windows.Forms.Label timeThisWeekLabelLabel;
        protected System.Windows.Forms.Label timeThisWeekLabel;
        protected System.Windows.Forms.Panel screenPanel;
        protected System.Windows.Forms.Label timeTodayLabel;
        protected System.Windows.Forms.Label timeTodayLabelLabel;
    }
}
