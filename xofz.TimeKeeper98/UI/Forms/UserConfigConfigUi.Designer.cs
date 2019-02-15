namespace xofz.TimeKeeper98.UI.Forms
{
    partial class UserConfigConfigUi
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
            this.core98GroupBox.SuspendLayout();
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
            this.promptCheckBox.Size = new System.Drawing.Size(240, 32);
            this.promptCheckBox.TabIndex = 0;
            this.promptCheckBox.Text = "Prompt to Clock In/Out";
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
            this.core98GroupBox.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            // UserConfigConfigUi
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
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
            this.Name = "UserConfigConfigUi";
            this.Size = new System.Drawing.Size(884, 345);
            this.core98GroupBox.ResumeLayout(false);
            this.core98GroupBox.PerformLayout();
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
    }
}
