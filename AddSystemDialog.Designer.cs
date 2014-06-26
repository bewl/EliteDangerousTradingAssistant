namespace EliteDangerousTradingAssistant
{
    partial class AddSystemDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSystemDialog));
            this.SystemLabel = new System.Windows.Forms.Label();
            this.SystemTextBox = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SystemLabel
            // 
            this.SystemLabel.AutoSize = true;
            this.SystemLabel.Location = new System.Drawing.Point(12, 9);
            this.SystemLabel.Name = "SystemLabel";
            this.SystemLabel.Size = new System.Drawing.Size(41, 13);
            this.SystemLabel.TabIndex = 0;
            this.SystemLabel.Text = "System";
            // 
            // SystemTextBox
            // 
            this.SystemTextBox.Location = new System.Drawing.Point(53, 6);
            this.SystemTextBox.Name = "SystemTextBox";
            this.SystemTextBox.Size = new System.Drawing.Size(250, 20);
            this.SystemTextBox.TabIndex = 1;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(53, 33);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(250, 23);
            this.AddButton.TabIndex = 2;
            this.AddButton.Text = "Add System";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // AddSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 66);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.SystemTextBox);
            this.Controls.Add(this.SystemLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddSystem";
            this.Text = "Add a System";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SystemLabel;
        private System.Windows.Forms.TextBox SystemTextBox;
        private System.Windows.Forms.Button AddButton;
    }
}