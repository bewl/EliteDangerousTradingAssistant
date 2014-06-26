namespace EliteDangerousTradingAssistant
{
    partial class TradesManifestsRoutesDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TradesManifestsRoutesDialog));
            this.TradesGrid = new System.Windows.Forms.DataGridView();
            this.StartSystemFilterComboBox = new System.Windows.Forms.ComboBox();
            this.StartSystemFilterLabel = new System.Windows.Forms.Label();
            this.FilterGroupBox = new System.Windows.Forms.GroupBox();
            this.InvestmentFilterTextBox = new System.Windows.Forms.MaskedTextBox();
            this.InvestmentFilterOperatorComboBox = new System.Windows.Forms.ComboBox();
            this.InvestmentLabel = new System.Windows.Forms.Label();
            this.CommodityLabel = new System.Windows.Forms.Label();
            this.CommodityComboBox = new System.Windows.Forms.ComboBox();
            this.ROIFilterLabel = new System.Windows.Forms.Label();
            this.ProfitFilterLabel = new System.Windows.Forms.Label();
            this.ROIFilterTextBox = new System.Windows.Forms.MaskedTextBox();
            this.ProfitFilterTextBox = new System.Windows.Forms.MaskedTextBox();
            this.ROIFilterOperatorComboBox = new System.Windows.Forms.ComboBox();
            this.ProfitFilterOperatorComboBox = new System.Windows.Forms.ComboBox();
            this.SellPriceFilterLabel = new System.Windows.Forms.Label();
            this.BuyPriceFilterLabel = new System.Windows.Forms.Label();
            this.SellPriceFilterTextBox = new System.Windows.Forms.MaskedTextBox();
            this.SellPriceFilterOperatorComboBox = new System.Windows.Forms.ComboBox();
            this.BuyPriceFilterTextBox = new System.Windows.Forms.MaskedTextBox();
            this.BuyPriceFilterOperatorComboBox = new System.Windows.Forms.ComboBox();
            this.EndStationFilterLabel = new System.Windows.Forms.Label();
            this.StartStationFilterLabel = new System.Windows.Forms.Label();
            this.EndStationFilterComboBox = new System.Windows.Forms.ComboBox();
            this.StartStationFilterComboBox = new System.Windows.Forms.ComboBox();
            this.EndSystemFilterComboBox = new System.Windows.Forms.ComboBox();
            this.EndSystemFilterLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ManifestsGrid = new System.Windows.Forms.DataGridView();
            this.RoutesGroupBox = new System.Windows.Forms.GroupBox();
            this.RoutesGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.TradesGrid)).BeginInit();
            this.FilterGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ManifestsGrid)).BeginInit();
            this.RoutesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoutesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // TradesGrid
            // 
            this.TradesGrid.AllowUserToAddRows = false;
            this.TradesGrid.AllowUserToDeleteRows = false;
            this.TradesGrid.AllowUserToResizeRows = false;
            this.TradesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TradesGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.TradesGrid.Location = new System.Drawing.Point(6, 19);
            this.TradesGrid.Name = "TradesGrid";
            this.TradesGrid.ReadOnly = true;
            this.TradesGrid.Size = new System.Drawing.Size(805, 200);
            this.TradesGrid.TabIndex = 0;
            // 
            // StartSystemFilterComboBox
            // 
            this.StartSystemFilterComboBox.FormattingEnabled = true;
            this.StartSystemFilterComboBox.Location = new System.Drawing.Point(133, 33);
            this.StartSystemFilterComboBox.Name = "StartSystemFilterComboBox";
            this.StartSystemFilterComboBox.Size = new System.Drawing.Size(121, 21);
            this.StartSystemFilterComboBox.TabIndex = 1;
            this.StartSystemFilterComboBox.SelectedIndexChanged += new System.EventHandler(this.StartSystemFilterComboBox_SelectedIndexChanged);
            // 
            // StartSystemFilterLabel
            // 
            this.StartSystemFilterLabel.AutoSize = true;
            this.StartSystemFilterLabel.Location = new System.Drawing.Point(130, 16);
            this.StartSystemFilterLabel.Name = "StartSystemFilterLabel";
            this.StartSystemFilterLabel.Size = new System.Drawing.Size(66, 13);
            this.StartSystemFilterLabel.TabIndex = 2;
            this.StartSystemFilterLabel.Text = "Start System";
            // 
            // FilterGroupBox
            // 
            this.FilterGroupBox.Controls.Add(this.InvestmentFilterTextBox);
            this.FilterGroupBox.Controls.Add(this.InvestmentFilterOperatorComboBox);
            this.FilterGroupBox.Controls.Add(this.InvestmentLabel);
            this.FilterGroupBox.Controls.Add(this.CommodityLabel);
            this.FilterGroupBox.Controls.Add(this.CommodityComboBox);
            this.FilterGroupBox.Controls.Add(this.ROIFilterLabel);
            this.FilterGroupBox.Controls.Add(this.ProfitFilterLabel);
            this.FilterGroupBox.Controls.Add(this.ROIFilterTextBox);
            this.FilterGroupBox.Controls.Add(this.ProfitFilterTextBox);
            this.FilterGroupBox.Controls.Add(this.ROIFilterOperatorComboBox);
            this.FilterGroupBox.Controls.Add(this.ProfitFilterOperatorComboBox);
            this.FilterGroupBox.Controls.Add(this.SellPriceFilterLabel);
            this.FilterGroupBox.Controls.Add(this.BuyPriceFilterLabel);
            this.FilterGroupBox.Controls.Add(this.SellPriceFilterTextBox);
            this.FilterGroupBox.Controls.Add(this.SellPriceFilterOperatorComboBox);
            this.FilterGroupBox.Controls.Add(this.BuyPriceFilterTextBox);
            this.FilterGroupBox.Controls.Add(this.BuyPriceFilterOperatorComboBox);
            this.FilterGroupBox.Controls.Add(this.EndStationFilterLabel);
            this.FilterGroupBox.Controls.Add(this.StartStationFilterLabel);
            this.FilterGroupBox.Controls.Add(this.EndStationFilterComboBox);
            this.FilterGroupBox.Controls.Add(this.StartStationFilterComboBox);
            this.FilterGroupBox.Controls.Add(this.EndSystemFilterComboBox);
            this.FilterGroupBox.Controls.Add(this.EndSystemFilterLabel);
            this.FilterGroupBox.Controls.Add(this.StartSystemFilterLabel);
            this.FilterGroupBox.Controls.Add(this.StartSystemFilterComboBox);
            this.FilterGroupBox.Location = new System.Drawing.Point(12, 12);
            this.FilterGroupBox.Name = "FilterGroupBox";
            this.FilterGroupBox.Size = new System.Drawing.Size(817, 107);
            this.FilterGroupBox.TabIndex = 3;
            this.FilterGroupBox.TabStop = false;
            this.FilterGroupBox.Text = "Filter by";
            // 
            // InvestmentFilterTextBox
            // 
            this.InvestmentFilterTextBox.Location = new System.Drawing.Point(555, 32);
            this.InvestmentFilterTextBox.Mask = "0000000";
            this.InvestmentFilterTextBox.Name = "InvestmentFilterTextBox";
            this.InvestmentFilterTextBox.Size = new System.Drawing.Size(50, 20);
            this.InvestmentFilterTextBox.TabIndex = 25;
            this.InvestmentFilterTextBox.TextChanged += new System.EventHandler(this.InvestmentFilterTextBox_TextChanged);
            // 
            // InvestmentFilterOperatorComboBox
            // 
            this.InvestmentFilterOperatorComboBox.FormattingEnabled = true;
            this.InvestmentFilterOperatorComboBox.Location = new System.Drawing.Point(499, 32);
            this.InvestmentFilterOperatorComboBox.Name = "InvestmentFilterOperatorComboBox";
            this.InvestmentFilterOperatorComboBox.Size = new System.Drawing.Size(50, 21);
            this.InvestmentFilterOperatorComboBox.TabIndex = 24;
            this.InvestmentFilterOperatorComboBox.SelectedIndexChanged += new System.EventHandler(this.InvestmentFilterOperatorComboBox_SelectedIndexChanged);
            // 
            // InvestmentLabel
            // 
            this.InvestmentLabel.AutoSize = true;
            this.InvestmentLabel.Location = new System.Drawing.Point(496, 16);
            this.InvestmentLabel.Name = "InvestmentLabel";
            this.InvestmentLabel.Size = new System.Drawing.Size(59, 13);
            this.InvestmentLabel.TabIndex = 23;
            this.InvestmentLabel.Text = "Investment";
            // 
            // CommodityLabel
            // 
            this.CommodityLabel.AutoSize = true;
            this.CommodityLabel.Location = new System.Drawing.Point(7, 14);
            this.CommodityLabel.Name = "CommodityLabel";
            this.CommodityLabel.Size = new System.Drawing.Size(58, 13);
            this.CommodityLabel.TabIndex = 22;
            this.CommodityLabel.Text = "Commodity";
            // 
            // CommodityComboBox
            // 
            this.CommodityComboBox.FormattingEnabled = true;
            this.CommodityComboBox.Location = new System.Drawing.Point(6, 33);
            this.CommodityComboBox.Name = "CommodityComboBox";
            this.CommodityComboBox.Size = new System.Drawing.Size(121, 21);
            this.CommodityComboBox.TabIndex = 21;
            this.CommodityComboBox.SelectedIndexChanged += new System.EventHandler(this.CommodityComboBox_SelectedIndexChanged);
            // 
            // ROIFilterLabel
            // 
            this.ROIFilterLabel.AutoSize = true;
            this.ROIFilterLabel.Location = new System.Drawing.Point(608, 16);
            this.ROIFilterLabel.Name = "ROIFilterLabel";
            this.ROIFilterLabel.Size = new System.Drawing.Size(26, 13);
            this.ROIFilterLabel.TabIndex = 20;
            this.ROIFilterLabel.Text = "ROI";
            // 
            // ProfitFilterLabel
            // 
            this.ProfitFilterLabel.AutoSize = true;
            this.ProfitFilterLabel.Location = new System.Drawing.Point(496, 57);
            this.ProfitFilterLabel.Name = "ProfitFilterLabel";
            this.ProfitFilterLabel.Size = new System.Drawing.Size(31, 13);
            this.ProfitFilterLabel.TabIndex = 19;
            this.ProfitFilterLabel.Text = "Profit";
            // 
            // ROIFilterTextBox
            // 
            this.ROIFilterTextBox.Location = new System.Drawing.Point(667, 32);
            this.ROIFilterTextBox.Mask = "000.00";
            this.ROIFilterTextBox.Name = "ROIFilterTextBox";
            this.ROIFilterTextBox.Size = new System.Drawing.Size(50, 20);
            this.ROIFilterTextBox.TabIndex = 18;
            this.ROIFilterTextBox.TextChanged += new System.EventHandler(this.ROIFilterTextBox_TextChanged);
            // 
            // ProfitFilterTextBox
            // 
            this.ProfitFilterTextBox.Location = new System.Drawing.Point(555, 73);
            this.ProfitFilterTextBox.Mask = "0000000";
            this.ProfitFilterTextBox.Name = "ProfitFilterTextBox";
            this.ProfitFilterTextBox.Size = new System.Drawing.Size(50, 20);
            this.ProfitFilterTextBox.TabIndex = 17;
            this.ProfitFilterTextBox.TextChanged += new System.EventHandler(this.ProfitFilterTextBox_TextChanged);
            // 
            // ROIFilterOperatorComboBox
            // 
            this.ROIFilterOperatorComboBox.FormattingEnabled = true;
            this.ROIFilterOperatorComboBox.Location = new System.Drawing.Point(611, 32);
            this.ROIFilterOperatorComboBox.Name = "ROIFilterOperatorComboBox";
            this.ROIFilterOperatorComboBox.Size = new System.Drawing.Size(50, 21);
            this.ROIFilterOperatorComboBox.TabIndex = 16;
            this.ROIFilterOperatorComboBox.SelectedIndexChanged += new System.EventHandler(this.ROIFilterOperatorComboBox_SelectedIndexChanged);
            // 
            // ProfitFilterOperatorComboBox
            // 
            this.ProfitFilterOperatorComboBox.FormattingEnabled = true;
            this.ProfitFilterOperatorComboBox.Location = new System.Drawing.Point(499, 73);
            this.ProfitFilterOperatorComboBox.Name = "ProfitFilterOperatorComboBox";
            this.ProfitFilterOperatorComboBox.Size = new System.Drawing.Size(50, 21);
            this.ProfitFilterOperatorComboBox.TabIndex = 15;
            this.ProfitFilterOperatorComboBox.SelectedIndexChanged += new System.EventHandler(this.ProfitFilterOperatorComboBox_SelectedIndexChanged);
            // 
            // SellPriceFilterLabel
            // 
            this.SellPriceFilterLabel.AutoSize = true;
            this.SellPriceFilterLabel.Location = new System.Drawing.Point(384, 57);
            this.SellPriceFilterLabel.Name = "SellPriceFilterLabel";
            this.SellPriceFilterLabel.Size = new System.Drawing.Size(51, 13);
            this.SellPriceFilterLabel.TabIndex = 14;
            this.SellPriceFilterLabel.Text = "Sell Price";
            // 
            // BuyPriceFilterLabel
            // 
            this.BuyPriceFilterLabel.AutoSize = true;
            this.BuyPriceFilterLabel.Location = new System.Drawing.Point(384, 16);
            this.BuyPriceFilterLabel.Name = "BuyPriceFilterLabel";
            this.BuyPriceFilterLabel.Size = new System.Drawing.Size(52, 13);
            this.BuyPriceFilterLabel.TabIndex = 13;
            this.BuyPriceFilterLabel.Text = "Buy Price";
            // 
            // SellPriceFilterTextBox
            // 
            this.SellPriceFilterTextBox.Location = new System.Drawing.Point(443, 73);
            this.SellPriceFilterTextBox.Mask = "0000000";
            this.SellPriceFilterTextBox.Name = "SellPriceFilterTextBox";
            this.SellPriceFilterTextBox.Size = new System.Drawing.Size(50, 20);
            this.SellPriceFilterTextBox.TabIndex = 12;
            this.SellPriceFilterTextBox.TextChanged += new System.EventHandler(this.SellPriceFilterTextBox_TextChanged);
            // 
            // SellPriceFilterOperatorComboBox
            // 
            this.SellPriceFilterOperatorComboBox.FormattingEnabled = true;
            this.SellPriceFilterOperatorComboBox.Location = new System.Drawing.Point(387, 73);
            this.SellPriceFilterOperatorComboBox.Name = "SellPriceFilterOperatorComboBox";
            this.SellPriceFilterOperatorComboBox.Size = new System.Drawing.Size(50, 21);
            this.SellPriceFilterOperatorComboBox.TabIndex = 11;
            this.SellPriceFilterOperatorComboBox.SelectedIndexChanged += new System.EventHandler(this.SellPriceFilterOperatorComboBox_SelectedIndexChanged);
            // 
            // BuyPriceFilterTextBox
            // 
            this.BuyPriceFilterTextBox.Location = new System.Drawing.Point(443, 32);
            this.BuyPriceFilterTextBox.Mask = "0000000";
            this.BuyPriceFilterTextBox.Name = "BuyPriceFilterTextBox";
            this.BuyPriceFilterTextBox.Size = new System.Drawing.Size(50, 20);
            this.BuyPriceFilterTextBox.TabIndex = 10;
            this.BuyPriceFilterTextBox.TextChanged += new System.EventHandler(this.BuyPriceFilterTextBox_TextChanged);
            // 
            // BuyPriceFilterOperatorComboBox
            // 
            this.BuyPriceFilterOperatorComboBox.FormattingEnabled = true;
            this.BuyPriceFilterOperatorComboBox.Location = new System.Drawing.Point(387, 33);
            this.BuyPriceFilterOperatorComboBox.Name = "BuyPriceFilterOperatorComboBox";
            this.BuyPriceFilterOperatorComboBox.Size = new System.Drawing.Size(50, 21);
            this.BuyPriceFilterOperatorComboBox.TabIndex = 9;
            this.BuyPriceFilterOperatorComboBox.SelectedIndexChanged += new System.EventHandler(this.BuyPriceFilterOperatorComboBox_SelectedIndexChanged);
            // 
            // EndStationFilterLabel
            // 
            this.EndStationFilterLabel.AutoSize = true;
            this.EndStationFilterLabel.Location = new System.Drawing.Point(257, 57);
            this.EndStationFilterLabel.Name = "EndStationFilterLabel";
            this.EndStationFilterLabel.Size = new System.Drawing.Size(62, 13);
            this.EndStationFilterLabel.TabIndex = 8;
            this.EndStationFilterLabel.Text = "End Station";
            // 
            // StartStationFilterLabel
            // 
            this.StartStationFilterLabel.AutoSize = true;
            this.StartStationFilterLabel.Location = new System.Drawing.Point(257, 16);
            this.StartStationFilterLabel.Name = "StartStationFilterLabel";
            this.StartStationFilterLabel.Size = new System.Drawing.Size(65, 13);
            this.StartStationFilterLabel.TabIndex = 7;
            this.StartStationFilterLabel.Text = "Start Station";
            // 
            // EndStationFilterComboBox
            // 
            this.EndStationFilterComboBox.FormattingEnabled = true;
            this.EndStationFilterComboBox.Location = new System.Drawing.Point(260, 73);
            this.EndStationFilterComboBox.Name = "EndStationFilterComboBox";
            this.EndStationFilterComboBox.Size = new System.Drawing.Size(121, 21);
            this.EndStationFilterComboBox.TabIndex = 6;
            this.EndStationFilterComboBox.SelectedIndexChanged += new System.EventHandler(this.EndStationFilterComboBox_SelectedIndexChanged);
            // 
            // StartStationFilterComboBox
            // 
            this.StartStationFilterComboBox.FormattingEnabled = true;
            this.StartStationFilterComboBox.Location = new System.Drawing.Point(260, 33);
            this.StartStationFilterComboBox.Name = "StartStationFilterComboBox";
            this.StartStationFilterComboBox.Size = new System.Drawing.Size(121, 21);
            this.StartStationFilterComboBox.TabIndex = 5;
            this.StartStationFilterComboBox.SelectedIndexChanged += new System.EventHandler(this.StartStationFilterComboBox_SelectedIndexChanged);
            // 
            // EndSystemFilterComboBox
            // 
            this.EndSystemFilterComboBox.FormattingEnabled = true;
            this.EndSystemFilterComboBox.Location = new System.Drawing.Point(133, 73);
            this.EndSystemFilterComboBox.Name = "EndSystemFilterComboBox";
            this.EndSystemFilterComboBox.Size = new System.Drawing.Size(121, 21);
            this.EndSystemFilterComboBox.TabIndex = 4;
            this.EndSystemFilterComboBox.SelectedIndexChanged += new System.EventHandler(this.EndSystemFilterComboBox_SelectedIndexChanged);
            // 
            // EndSystemFilterLabel
            // 
            this.EndSystemFilterLabel.AutoSize = true;
            this.EndSystemFilterLabel.Location = new System.Drawing.Point(130, 57);
            this.EndSystemFilterLabel.Name = "EndSystemFilterLabel";
            this.EndSystemFilterLabel.Size = new System.Drawing.Size(63, 13);
            this.EndSystemFilterLabel.TabIndex = 3;
            this.EndSystemFilterLabel.Text = "End System";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TradesGrid);
            this.groupBox1.Location = new System.Drawing.Point(12, 125);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(817, 225);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Trades";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ManifestsGrid);
            this.groupBox2.Location = new System.Drawing.Point(12, 356);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(817, 227);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Manifests";
            // 
            // ManifestsGrid
            // 
            this.ManifestsGrid.AllowUserToAddRows = false;
            this.ManifestsGrid.AllowUserToDeleteRows = false;
            this.ManifestsGrid.AllowUserToResizeRows = false;
            this.ManifestsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ManifestsGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.ManifestsGrid.Location = new System.Drawing.Point(6, 19);
            this.ManifestsGrid.Name = "ManifestsGrid";
            this.ManifestsGrid.ReadOnly = true;
            this.ManifestsGrid.Size = new System.Drawing.Size(805, 200);
            this.ManifestsGrid.TabIndex = 4;
            this.ManifestsGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ManifestsGrid_CellContentClick);
            // 
            // RoutesGroupBox
            // 
            this.RoutesGroupBox.Controls.Add(this.RoutesGridView);
            this.RoutesGroupBox.Location = new System.Drawing.Point(12, 589);
            this.RoutesGroupBox.Name = "RoutesGroupBox";
            this.RoutesGroupBox.Size = new System.Drawing.Size(817, 227);
            this.RoutesGroupBox.TabIndex = 9;
            this.RoutesGroupBox.TabStop = false;
            this.RoutesGroupBox.Text = "Routes";
            // 
            // RoutesGridView
            // 
            this.RoutesGridView.AllowUserToAddRows = false;
            this.RoutesGridView.AllowUserToDeleteRows = false;
            this.RoutesGridView.AllowUserToResizeRows = false;
            this.RoutesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RoutesGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.RoutesGridView.Location = new System.Drawing.Point(6, 19);
            this.RoutesGridView.Name = "RoutesGridView";
            this.RoutesGridView.ReadOnly = true;
            this.RoutesGridView.Size = new System.Drawing.Size(805, 200);
            this.RoutesGridView.TabIndex = 4;
            this.RoutesGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RoutesGridView_CellContentClick);
            // 
            // TradesManifestsRoutesDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 826);
            this.Controls.Add(this.RoutesGroupBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.FilterGroupBox);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TradesManifestsRoutesDialog";
            this.Text = "Trades, Manifests and Routes";
            ((System.ComponentModel.ISupportInitialize)(this.TradesGrid)).EndInit();
            this.FilterGroupBox.ResumeLayout(false);
            this.FilterGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ManifestsGrid)).EndInit();
            this.RoutesGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RoutesGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView TradesGrid;
        private System.Windows.Forms.ComboBox StartSystemFilterComboBox;
        private System.Windows.Forms.Label StartSystemFilterLabel;
        private System.Windows.Forms.GroupBox FilterGroupBox;
        private System.Windows.Forms.Label EndSystemFilterLabel;
        private System.Windows.Forms.ComboBox EndSystemFilterComboBox;
        private System.Windows.Forms.Label SellPriceFilterLabel;
        private System.Windows.Forms.Label BuyPriceFilterLabel;
        private System.Windows.Forms.MaskedTextBox SellPriceFilterTextBox;
        private System.Windows.Forms.ComboBox SellPriceFilterOperatorComboBox;
        private System.Windows.Forms.MaskedTextBox BuyPriceFilterTextBox;
        private System.Windows.Forms.ComboBox BuyPriceFilterOperatorComboBox;
        private System.Windows.Forms.Label EndStationFilterLabel;
        private System.Windows.Forms.Label StartStationFilterLabel;
        private System.Windows.Forms.ComboBox EndStationFilterComboBox;
        private System.Windows.Forms.ComboBox StartStationFilterComboBox;
        private System.Windows.Forms.Label ROIFilterLabel;
        private System.Windows.Forms.Label ProfitFilterLabel;
        private System.Windows.Forms.MaskedTextBox ROIFilterTextBox;
        private System.Windows.Forms.MaskedTextBox ProfitFilterTextBox;
        private System.Windows.Forms.ComboBox ROIFilterOperatorComboBox;
        private System.Windows.Forms.ComboBox ProfitFilterOperatorComboBox;
        private System.Windows.Forms.Label CommodityLabel;
        private System.Windows.Forms.ComboBox CommodityComboBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView ManifestsGrid;
        private System.Windows.Forms.MaskedTextBox InvestmentFilterTextBox;
        private System.Windows.Forms.ComboBox InvestmentFilterOperatorComboBox;
        private System.Windows.Forms.Label InvestmentLabel;
        private System.Windows.Forms.GroupBox RoutesGroupBox;
        private System.Windows.Forms.DataGridView RoutesGridView;
    }
}