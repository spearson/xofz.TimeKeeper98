namespace xofz.TimeKeeper98.UI.Forms
{
    partial class UserControlTimestampEditUi
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
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.saveKey = new System.Windows.Forms.Button();
            this.cancelKey = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CalendarFont = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(0, 3);
            this.dateTimePicker.Margin = new System.Windows.Forms.Padding(0);
            this.dateTimePicker.MinimumSize = new System.Drawing.Size(240, 0);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(240, 30);
            this.dateTimePicker.TabIndex = 0;
            // 
            // saveKey
            // 
            this.saveKey.AutoSize = true;
            this.saveKey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.saveKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.saveKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.saveKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveKey.Location = new System.Drawing.Point(290, 0);
            this.saveKey.Margin = new System.Windows.Forms.Padding(0);
            this.saveKey.Name = "saveKey";
            this.saveKey.Size = new System.Drawing.Size(77, 37);
            this.saveKey.TabIndex = 1;
            this.saveKey.Text = "Save";
            this.saveKey.UseVisualStyleBackColor = true;
            this.saveKey.Click += new System.EventHandler(this.saveKey_Click);
            // 
            // cancelKey
            // 
            this.cancelKey.AutoSize = true;
            this.cancelKey.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cancelKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.cancelKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.cancelKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelKey.Location = new System.Drawing.Point(384, 0);
            this.cancelKey.Margin = new System.Windows.Forms.Padding(0);
            this.cancelKey.Name = "cancelKey";
            this.cancelKey.Size = new System.Drawing.Size(97, 37);
            this.cancelKey.TabIndex = 2;
            this.cancelKey.Text = "Cancel";
            this.cancelKey.UseVisualStyleBackColor = true;
            this.cancelKey.Click += new System.EventHandler(this.cancelKey_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(-3, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(403, 58);
            this.label1.TabIndex = 13;
            this.label1.Text = "Note: edited timestamp must be before current time and after previous timestamp";
            // 
            // UserControlTimestampEditUi
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelKey);
            this.Controls.Add(this.saveKey);
            this.Controls.Add(this.dateTimePicker);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UserControlTimestampEditUi";
            this.Size = new System.Drawing.Size(784, 298);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button saveKey;
        private System.Windows.Forms.Button cancelKey;
        private System.Windows.Forms.Label label1;
    }
}
