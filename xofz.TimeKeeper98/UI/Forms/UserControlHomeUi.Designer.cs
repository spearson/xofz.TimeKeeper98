﻿namespace xofz.TimeKeeper98.UI.Forms
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
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.inKey = new System.Windows.Forms.Button();
            this.outKey = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.timeThisWeekLabel = new System.Windows.Forms.Label();
            this.screenPanel = new System.Windows.Forms.Panel();
            this.timeTodayLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.coreVersionLabel = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLabel.ForeColor = System.Drawing.Color.SteelBlue;
            this.welcomeLabel.Location = new System.Drawing.Point(0, 0);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(488, 37);
            this.welcomeLabel.TabIndex = 0;
            this.welcomeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // inKey
            // 
            this.inKey.AutoSize = true;
            this.inKey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.inKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.inKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.inKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.inKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inKey.Location = new System.Drawing.Point(10, 40);
            this.inKey.Name = "inKey";
            this.inKey.Size = new System.Drawing.Size(217, 67);
            this.inKey.TabIndex = 1;
            this.inKey.Text = "Clock In";
            this.inKey.UseVisualStyleBackColor = true;
            this.inKey.Click += new System.EventHandler(this.inKey_Click);
            // 
            // outKey
            // 
            this.outKey.AutoSize = true;
            this.outKey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.outKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.outKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.outKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.outKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outKey.Location = new System.Drawing.Point(233, 40);
            this.outKey.Name = "outKey";
            this.outKey.Size = new System.Drawing.Size(255, 67);
            this.outKey.TabIndex = 2;
            this.outKey.Text = "Clock Out";
            this.outKey.UseVisualStyleBackColor = true;
            this.outKey.Click += new System.EventHandler(this.outKey_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(532, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "This Week:";
            // 
            // timeThisWeekLabel
            // 
            this.timeThisWeekLabel.AutoSize = true;
            this.timeThisWeekLabel.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeThisWeekLabel.Location = new System.Drawing.Point(530, 20);
            this.timeThisWeekLabel.Name = "timeThisWeekLabel";
            this.timeThisWeekLabel.Size = new System.Drawing.Size(191, 34);
            this.timeThisWeekLabel.TabIndex = 4;
            this.timeThisWeekLabel.Text = "00h 00m 00s";
            // 
            // screenPanel
            // 
            this.screenPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.screenPanel.Location = new System.Drawing.Point(0, 113);
            this.screenPanel.Name = "screenPanel";
            this.screenPanel.Size = new System.Drawing.Size(784, 298);
            this.screenPanel.TabIndex = 5;
            // 
            // timeTodayLabel
            // 
            this.timeTodayLabel.AutoSize = true;
            this.timeTodayLabel.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeTodayLabel.Location = new System.Drawing.Point(530, 74);
            this.timeTodayLabel.Name = "timeTodayLabel";
            this.timeTodayLabel.Size = new System.Drawing.Size(191, 34);
            this.timeTodayLabel.TabIndex = 7;
            this.timeTodayLabel.Text = "00h 00m 00s";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(532, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Today:";
            // 
            // coreVersionLabel
            // 
            this.coreVersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coreVersionLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.coreVersionLabel.Location = new System.Drawing.Point(584, 431);
            this.coreVersionLabel.Margin = new System.Windows.Forms.Padding(0);
            this.coreVersionLabel.Name = "coreVersionLabel";
            this.coreVersionLabel.Size = new System.Drawing.Size(200, 34);
            this.coreVersionLabel.TabIndex = 8;
            this.coreVersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // versionLabel
            // 
            this.versionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.versionLabel.Location = new System.Drawing.Point(0, 431);
            this.versionLabel.Margin = new System.Windows.Forms.Padding(0);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(200, 34);
            this.versionLabel.TabIndex = 9;
            this.versionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserControlHomeUi
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.coreVersionLabel);
            this.Controls.Add(this.timeTodayLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.screenPanel);
            this.Controls.Add(this.timeThisWeekLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.outKey);
            this.Controls.Add(this.inKey);
            this.Controls.Add(this.welcomeLabel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UserControlHomeUi";
            this.Size = new System.Drawing.Size(784, 465);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.Button inKey;
        private System.Windows.Forms.Button outKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label timeThisWeekLabel;
        private System.Windows.Forms.Panel screenPanel;
        private System.Windows.Forms.Label timeTodayLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label coreVersionLabel;
        private System.Windows.Forms.Label versionLabel;
    }
}
