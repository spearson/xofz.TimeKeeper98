namespace xofz.TimeKeeper98.UI.Forms
{
    partial class FormMainUi
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.screenPanel = new System.Windows.Forms.Panel();
            this.appNavUi = new xofz.TimeKeeper98.UI.Forms.UserControlNavUi();
            this.SuspendLayout();
            // 
            // screenPanel
            // 
            this.screenPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.screenPanel.Location = new System.Drawing.Point(0, 50);
            this.screenPanel.Margin = new System.Windows.Forms.Padding(0);
            this.screenPanel.Name = "screenPanel";
            this.screenPanel.Size = new System.Drawing.Size(884, 511);
            this.screenPanel.TabIndex = 1;
            this.screenPanel.TabStop = true;
            // 
            // appNavUi
            // 
            this.appNavUi.Dock = System.Windows.Forms.DockStyle.Top;
            this.appNavUi.Location = new System.Drawing.Point(0, 0);
            this.appNavUi.Margin = new System.Windows.Forms.Padding(0);
            this.appNavUi.Name = "appNavUi";
            this.appNavUi.Size = new System.Drawing.Size(884, 50);
            this.appNavUi.TabIndex = 0;
            // 
            // FormMainUi
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.screenPanel);
            this.Controls.Add(this.appNavUi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMainUi";
            this.Text = "x(z) TimeKeeper98";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.this_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        protected UserControlNavUi appNavUi;
        protected System.Windows.Forms.Panel screenPanel;
    }
}

