namespace EliteDangerousTradingAssistant
{
    partial class ChooseExistingCommodityDialog
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
            this.CommodityComboBox = new System.Windows.Forms.ComboBox();
            this.CommodityLabel = new System.Windows.Forms.Label();
            this.SelectButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CommodityComboBox
            // 
            this.CommodityComboBox.FormattingEnabled = true;
            this.CommodityComboBox.Location = new System.Drawing.Point(76, 13);
            this.CommodityComboBox.Name = "CommodityComboBox";
            this.CommodityComboBox.Size = new System.Drawing.Size(196, 21);
            this.CommodityComboBox.TabIndex = 0;
            // 
            // CommodityLabel
            // 
            this.CommodityLabel.AutoSize = true;
            this.CommodityLabel.Location = new System.Drawing.Point(12, 16);
            this.CommodityLabel.Name = "CommodityLabel";
            this.CommodityLabel.Size = new System.Drawing.Size(58, 13);
            this.CommodityLabel.TabIndex = 1;
            this.CommodityLabel.Text = "Commodity";
            // 
            // SelectButton
            // 
            this.SelectButton.Location = new System.Drawing.Point(76, 40);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(95, 23);
            this.SelectButton.TabIndex = 2;
            this.SelectButton.Text = "Select";
            this.SelectButton.UseVisualStyleBackColor = true;
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(177, 40);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(95, 23);
            this.CancelButton.TabIndex = 3;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ChooseExistingCommodity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 71);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SelectButton);
            this.Controls.Add(this.CommodityLabel);
            this.Controls.Add(this.CommodityComboBox);
            this.Name = "ChooseExistingCommodity";
            this.Text = "Choose Existing Commodity";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CommodityComboBox;
        private System.Windows.Forms.Label CommodityLabel;
        private System.Windows.Forms.Button SelectButton;
        private System.Windows.Forms.Button CancelButton;
    }
}