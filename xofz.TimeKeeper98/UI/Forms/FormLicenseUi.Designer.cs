namespace xofz.TimeKeeper98.UI.Forms
{
    partial class FormLicenseUi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLicenseUi));
            this.licenseTextBox = new System.Windows.Forms.TextBox();
            this.acceptKey = new System.Windows.Forms.Button();
            this.rejectKey = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // licenseTextBox
            // 
            this.licenseTextBox.Location = new System.Drawing.Point(12, 12);
            this.licenseTextBox.Multiline = true;
            this.licenseTextBox.Name = "licenseTextBox";
            this.licenseTextBox.ReadOnly = true;
            this.licenseTextBox.Size = new System.Drawing.Size(760, 391);
            this.licenseTextBox.TabIndex = 99;
            this.licenseTextBox.TabStop = false;
            this.licenseTextBox.Text = resources.GetString("licenseTextBox.Text");
            // 
            // acceptKey
            // 
            this.acceptKey.AutoSize = true;
            this.acceptKey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.acceptKey.BackColor = System.Drawing.Color.LightGreen;
            this.acceptKey.FlatAppearance.BorderSize = 3;
            this.acceptKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.acceptKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.acceptKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.acceptKey.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acceptKey.Location = new System.Drawing.Point(12, 409);
            this.acceptKey.Name = "acceptKey";
            this.acceptKey.Size = new System.Drawing.Size(242, 40);
            this.acceptKey.TabIndex = 1;
            this.acceptKey.Text = "Accept and Publish";
            this.acceptKey.UseVisualStyleBackColor = false;
            this.acceptKey.Click += new System.EventHandler(this.acceptKey_Click);
            // 
            // rejectKey
            // 
            this.rejectKey.AutoSize = true;
            this.rejectKey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.rejectKey.BackColor = System.Drawing.Color.LightCoral;
            this.rejectKey.FlatAppearance.BorderSize = 3;
            this.rejectKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.rejectKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.rejectKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rejectKey.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rejectKey.Location = new System.Drawing.Point(674, 409);
            this.rejectKey.Name = "rejectKey";
            this.rejectKey.Size = new System.Drawing.Size(98, 40);
            this.rejectKey.TabIndex = 0;
            this.rejectKey.Text = "Reject";
            this.rejectKey.UseVisualStyleBackColor = false;
            this.rejectKey.Click += new System.EventHandler(this.rejectKey_Click);
            // 
            // FormLicenseUi
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.rejectKey);
            this.Controls.Add(this.acceptKey);
            this.Controls.Add(this.licenseTextBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLicenseUi";
            this.ShowIcon = false;
            this.Text = "ms-PL";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.this_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.TextBox licenseTextBox;
        protected System.Windows.Forms.Button acceptKey;
        protected System.Windows.Forms.Button rejectKey;
    }
}