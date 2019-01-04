namespace xofz.TimeKeeper98.UI.Forms
{
    partial class UserControlHomeNavUi
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.exitKey = new System.Windows.Forms.Button();
            this.statisticsKey = new System.Windows.Forms.Button();
            this.timestampsKey = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 5;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 177F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 177F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 177F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 177F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 176F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Controls.Add(this.exitKey, 4, 0);
            this.tableLayoutPanel.Controls.Add(this.statisticsKey, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.timestampsKey, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(884, 50);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // exitKey
            // 
            this.exitKey.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.exitKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.exitKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.exitKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitKey.Location = new System.Drawing.Point(708, 0);
            this.exitKey.Margin = new System.Windows.Forms.Padding(0);
            this.exitKey.Name = "exitKey";
            this.exitKey.Size = new System.Drawing.Size(176, 50);
            this.exitKey.TabIndex = 2;
            this.exitKey.Text = "Exit";
            this.exitKey.UseVisualStyleBackColor = true;
            this.exitKey.Click += new System.EventHandler(this.exitKey_Click);
            // 
            // statisticsKey
            // 
            this.statisticsKey.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statisticsKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.statisticsKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.statisticsKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.statisticsKey.Location = new System.Drawing.Point(177, 0);
            this.statisticsKey.Margin = new System.Windows.Forms.Padding(0);
            this.statisticsKey.Name = "statisticsKey";
            this.statisticsKey.Size = new System.Drawing.Size(177, 50);
            this.statisticsKey.TabIndex = 1;
            this.statisticsKey.Text = "Statistics";
            this.statisticsKey.UseVisualStyleBackColor = true;
            this.statisticsKey.Click += new System.EventHandler(this.statisticsKey_Click);
            // 
            // timestampsKey
            // 
            this.timestampsKey.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.timestampsKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.timestampsKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.timestampsKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.timestampsKey.Location = new System.Drawing.Point(0, 0);
            this.timestampsKey.Margin = new System.Windows.Forms.Padding(0);
            this.timestampsKey.Name = "timestampsKey";
            this.timestampsKey.Size = new System.Drawing.Size(177, 50);
            this.timestampsKey.TabIndex = 0;
            this.timestampsKey.Text = "Timestamps";
            this.timestampsKey.UseVisualStyleBackColor = true;
            this.timestampsKey.Click += new System.EventHandler(this.timestampsKey_Click);
            // 
            // UserControlHomeNavUi
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tableLayoutPanel);
            this.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UserControlHomeNavUi";
            this.Size = new System.Drawing.Size(884, 50);
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button statisticsKey;
        private System.Windows.Forms.Button exitKey;
        private System.Windows.Forms.Button timestampsKey;
    }
}
