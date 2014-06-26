namespace EliteDangerousTradingAssistant
{
    partial class RouteEditorDialog
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
            this.CenterSystemLabel = new System.Windows.Forms.Label();
            this.CenterSystemComboBox = new System.Windows.Forms.ComboBox();
            this.CenterStationLabel = new System.Windows.Forms.Label();
            this.CenterStationComboBox = new System.Windows.Forms.ComboBox();
            this.ManifestGrid = new System.Windows.Forms.DataGridView();
            this.TripsTextBox = new System.Windows.Forms.TextBox();
            this.TripsLabel = new System.Windows.Forms.Label();
            this.ProfitTextBox = new System.Windows.Forms.TextBox();
            this.ProfitLabel = new System.Windows.Forms.Label();
            this.AverageProfitTextBox = new System.Windows.Forms.TextBox();
            this.AverageProfitLabel = new System.Windows.Forms.Label();
            this.ManifestsLabel = new System.Windows.Forms.Label();
            this.OldestDataLabel = new System.Windows.Forms.Label();
            this.OldestDataTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ManifestGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // CenterSystemLabel
            // 
            this.CenterSystemLabel.AutoSize = true;
            this.CenterSystemLabel.Location = new System.Drawing.Point(12, 9);
            this.CenterSystemLabel.Name = "CenterSystemLabel";
            this.CenterSystemLabel.Size = new System.Drawing.Size(75, 13);
            this.CenterSystemLabel.TabIndex = 2;
            this.CenterSystemLabel.Text = "Center System";
            // 
            // CenterSystemComboBox
            // 
            this.CenterSystemComboBox.FormattingEnabled = true;
            this.CenterSystemComboBox.Location = new System.Drawing.Point(93, 6);
            this.CenterSystemComboBox.Name = "CenterSystemComboBox";
            this.CenterSystemComboBox.Size = new System.Drawing.Size(150, 21);
            this.CenterSystemComboBox.TabIndex = 17;
            // 
            // CenterStationLabel
            // 
            this.CenterStationLabel.AutoSize = true;
            this.CenterStationLabel.Location = new System.Drawing.Point(249, 9);
            this.CenterStationLabel.Name = "CenterStationLabel";
            this.CenterStationLabel.Size = new System.Drawing.Size(74, 13);
            this.CenterStationLabel.TabIndex = 18;
            this.CenterStationLabel.Text = "Center Station";
            // 
            // CenterStationComboBox
            // 
            this.CenterStationComboBox.FormattingEnabled = true;
            this.CenterStationComboBox.Location = new System.Drawing.Point(329, 6);
            this.CenterStationComboBox.Name = "CenterStationComboBox";
            this.CenterStationComboBox.Size = new System.Drawing.Size(150, 21);
            this.CenterStationComboBox.TabIndex = 19;
            // 
            // ManifestGrid
            // 
            this.ManifestGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ManifestGrid.Location = new System.Drawing.Point(12, 85);
            this.ManifestGrid.Name = "ManifestGrid";
            this.ManifestGrid.Size = new System.Drawing.Size(711, 200);
            this.ManifestGrid.TabIndex = 20;
            this.ManifestGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ManifestGrid_CellContentClick);
            // 
            // TripsTextBox
            // 
            this.TripsTextBox.Location = new System.Drawing.Point(93, 34);
            this.TripsTextBox.Name = "TripsTextBox";
            this.TripsTextBox.Size = new System.Drawing.Size(150, 20);
            this.TripsTextBox.TabIndex = 21;
            // 
            // TripsLabel
            // 
            this.TripsLabel.AutoSize = true;
            this.TripsLabel.Location = new System.Drawing.Point(57, 37);
            this.TripsLabel.Name = "TripsLabel";
            this.TripsLabel.Size = new System.Drawing.Size(30, 13);
            this.TripsLabel.TabIndex = 22;
            this.TripsLabel.Text = "Trips";
            // 
            // ProfitTextBox
            // 
            this.ProfitTextBox.Location = new System.Drawing.Point(329, 33);
            this.ProfitTextBox.Name = "ProfitTextBox";
            this.ProfitTextBox.Size = new System.Drawing.Size(150, 20);
            this.ProfitTextBox.TabIndex = 23;
            // 
            // ProfitLabel
            // 
            this.ProfitLabel.AutoSize = true;
            this.ProfitLabel.Location = new System.Drawing.Point(265, 37);
            this.ProfitLabel.Name = "ProfitLabel";
            this.ProfitLabel.Size = new System.Drawing.Size(58, 13);
            this.ProfitLabel.TabIndex = 24;
            this.ProfitLabel.Text = "Total Profit";
            // 
            // AverageProfitTextBox
            // 
            this.AverageProfitTextBox.Location = new System.Drawing.Point(568, 33);
            this.AverageProfitTextBox.Name = "AverageProfitTextBox";
            this.AverageProfitTextBox.Size = new System.Drawing.Size(150, 20);
            this.AverageProfitTextBox.TabIndex = 25;
            // 
            // AverageProfitLabel
            // 
            this.AverageProfitLabel.AutoSize = true;
            this.AverageProfitLabel.Location = new System.Drawing.Point(480, 36);
            this.AverageProfitLabel.Name = "AverageProfitLabel";
            this.AverageProfitLabel.Size = new System.Drawing.Size(82, 13);
            this.AverageProfitLabel.TabIndex = 27;
            this.AverageProfitLabel.Text = "Avg Profit / Trip";
            // 
            // ManifestsLabel
            // 
            this.ManifestsLabel.AutoSize = true;
            this.ManifestsLabel.Location = new System.Drawing.Point(12, 69);
            this.ManifestsLabel.Name = "ManifestsLabel";
            this.ManifestsLabel.Size = new System.Drawing.Size(52, 13);
            this.ManifestsLabel.TabIndex = 28;
            this.ManifestsLabel.Text = "Manifests";
            // 
            // OldestDataLabel
            // 
            this.OldestDataLabel.AutoSize = true;
            this.OldestDataLabel.Location = new System.Drawing.Point(9, 294);
            this.OldestDataLabel.Name = "OldestDataLabel";
            this.OldestDataLabel.Size = new System.Drawing.Size(63, 13);
            this.OldestDataLabel.TabIndex = 30;
            this.OldestDataLabel.Text = "Oldest Data";
            // 
            // OldestDataTextBox
            // 
            this.OldestDataTextBox.Enabled = false;
            this.OldestDataTextBox.Location = new System.Drawing.Point(78, 291);
            this.OldestDataTextBox.Name = "OldestDataTextBox";
            this.OldestDataTextBox.Size = new System.Drawing.Size(645, 20);
            this.OldestDataTextBox.TabIndex = 29;
            // 
            // RouteEditorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 317);
            this.Controls.Add(this.OldestDataLabel);
            this.Controls.Add(this.OldestDataTextBox);
            this.Controls.Add(this.ManifestsLabel);
            this.Controls.Add(this.AverageProfitLabel);
            this.Controls.Add(this.AverageProfitTextBox);
            this.Controls.Add(this.ProfitLabel);
            this.Controls.Add(this.ProfitTextBox);
            this.Controls.Add(this.TripsLabel);
            this.Controls.Add(this.TripsTextBox);
            this.Controls.Add(this.ManifestGrid);
            this.Controls.Add(this.CenterStationComboBox);
            this.Controls.Add(this.CenterStationLabel);
            this.Controls.Add(this.CenterSystemComboBox);
            this.Controls.Add(this.CenterSystemLabel);
            this.Name = "RouteEditorDialog";
            this.Text = "RouteEditorDialog";
            ((System.ComponentModel.ISupportInitialize)(this.ManifestGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CenterSystemLabel;
        private System.Windows.Forms.ComboBox CenterSystemComboBox;
        private System.Windows.Forms.Label CenterStationLabel;
        private System.Windows.Forms.ComboBox CenterStationComboBox;
        private System.Windows.Forms.DataGridView ManifestGrid;
        private System.Windows.Forms.TextBox TripsTextBox;
        private System.Windows.Forms.Label TripsLabel;
        private System.Windows.Forms.TextBox ProfitTextBox;
        private System.Windows.Forms.Label ProfitLabel;
        private System.Windows.Forms.TextBox AverageProfitTextBox;
        private System.Windows.Forms.Label AverageProfitLabel;
        private System.Windows.Forms.Label ManifestsLabel;
        private System.Windows.Forms.Label OldestDataLabel;
        private System.Windows.Forms.TextBox OldestDataTextBox;
    }
}