namespace ZooSim
{
    partial class ZooView
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
            this.AnimalListView = new System.Windows.Forms.ListView();
            this.Animal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Health = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FeedButton = new System.Windows.Forms.Button();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AnimalListView
            // 
            this.AnimalListView.AutoArrange = false;
            this.AnimalListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Animal,
            this.Health,
            this.Status});
            this.AnimalListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AnimalListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.AnimalListView.HideSelection = false;
            this.AnimalListView.Location = new System.Drawing.Point(0, 28);
            this.AnimalListView.Name = "AnimalListView";
            this.AnimalListView.Size = new System.Drawing.Size(800, 422);
            this.AnimalListView.TabIndex = 0;
            this.AnimalListView.TileSize = new System.Drawing.Size(100, 45);
            this.AnimalListView.UseCompatibleStateImageBehavior = false;
            this.AnimalListView.View = System.Windows.Forms.View.Tile;
            // 
            // FeedButton
            // 
            this.FeedButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FeedButton.Location = new System.Drawing.Point(0, 450);
            this.FeedButton.Name = "FeedButton";
            this.FeedButton.Size = new System.Drawing.Size(800, 23);
            this.FeedButton.TabIndex = 1;
            this.FeedButton.Text = "Feed";
            this.FeedButton.UseVisualStyleBackColor = true;
            this.FeedButton.Click += new System.EventHandler(this.FeedButton_Click);
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TimeLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.TimeLabel.Location = new System.Drawing.Point(0, 0);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(78, 28);
            this.TimeLabel.TabIndex = 2;
            this.TimeLabel.Text = "Hours:";
            this.TimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ZooView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 473);
            this.Controls.Add(this.AnimalListView);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.FeedButton);
            this.MinimumSize = new System.Drawing.Size(512, 300);
            this.Name = "ZooView";
            this.Text = "Zoo Simulator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button FeedButton;
        private System.Windows.Forms.Label TimeLabel;
        public System.Windows.Forms.ListView AnimalListView;
        public System.Windows.Forms.ColumnHeader Animal;
        public System.Windows.Forms.ColumnHeader Health;
        public System.Windows.Forms.ColumnHeader Status;
    }
}