namespace LogonBGChanger2 {
    partial class Main {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.Step1Box = new System.Windows.Forms.GroupBox();
            this.RegToggle = new System.Windows.Forms.CheckBox();
            this.Step2Box = new System.Windows.Forms.GroupBox();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.UseButton = new System.Windows.Forms.Button();
            this.MissingLabel = new System.Windows.Forms.Label();
            this.BGBox = new System.Windows.Forms.PictureBox();
            this.AboutButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.RevertButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BGDialog = new System.Windows.Forms.OpenFileDialog();
            this.Step1Box.SuspendLayout();
            this.Step2Box.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BGBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Step1Box
            // 
            this.Step1Box.Controls.Add(this.RegToggle);
            this.Step1Box.Location = new System.Drawing.Point(12, 35);
            this.Step1Box.Name = "Step1Box";
            this.Step1Box.Size = new System.Drawing.Size(216, 55);
            this.Step1Box.TabIndex = 0;
            this.Step1Box.TabStop = false;
            this.Step1Box.Text = "Step 1: Edit Registry";
            // 
            // RegToggle
            // 
            this.RegToggle.Appearance = System.Windows.Forms.Appearance.Button;
            this.RegToggle.Location = new System.Drawing.Point(6, 24);
            this.RegToggle.Name = "RegToggle";
            this.RegToggle.Size = new System.Drawing.Size(204, 24);
            this.RegToggle.TabIndex = 1;
            this.RegToggle.Text = "Use Custom Backgrounds";
            this.RegToggle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RegToggle.UseVisualStyleBackColor = true;
            this.RegToggle.Click += new System.EventHandler(this.RegToggle_Clicked);
            // 
            // Step2Box
            // 
            this.Step2Box.Controls.Add(this.BrowseButton);
            this.Step2Box.Controls.Add(this.ResetButton);
            this.Step2Box.Controls.Add(this.UseButton);
            this.Step2Box.Controls.Add(this.MissingLabel);
            this.Step2Box.Controls.Add(this.BGBox);
            this.Step2Box.Location = new System.Drawing.Point(12, 97);
            this.Step2Box.Name = "Step2Box";
            this.Step2Box.Size = new System.Drawing.Size(216, 192);
            this.Step2Box.TabIndex = 1;
            this.Step2Box.TabStop = false;
            this.Step2Box.Text = "Step 2: Select Background";
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(6, 129);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(205, 23);
            this.BrowseButton.TabIndex = 4;
            this.BrowseButton.Text = "Browse...";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(136, 158);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(74, 23);
            this.ResetButton.TabIndex = 3;
            this.ResetButton.Text = "Reset\r\n";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // UseButton
            // 
            this.UseButton.Location = new System.Drawing.Point(6, 158);
            this.UseButton.Name = "UseButton";
            this.UseButton.Size = new System.Drawing.Size(124, 23);
            this.UseButton.TabIndex = 2;
            this.UseButton.Text = "Use Background";
            this.UseButton.UseVisualStyleBackColor = true;
            this.UseButton.Click += new System.EventHandler(this.UseButton_Click);
            // 
            // MissingLabel
            // 
            this.MissingLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MissingLabel.Location = new System.Drawing.Point(6, 19);
            this.MissingLabel.Name = "MissingLabel";
            this.MissingLabel.Size = new System.Drawing.Size(204, 104);
            this.MissingLabel.TabIndex = 1;
            this.MissingLabel.Text = "No image selected. Make sure to use a JPG file under 256 KB.";
            this.MissingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BGBox
            // 
            this.BGBox.Location = new System.Drawing.Point(6, 19);
            this.BGBox.Name = "BGBox";
            this.BGBox.Size = new System.Drawing.Size(204, 104);
            this.BGBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BGBox.TabIndex = 0;
            this.BGBox.TabStop = false;
            // 
            // AboutButton
            // 
            this.AboutButton.Location = new System.Drawing.Point(12, 295);
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(56, 23);
            this.AboutButton.TabIndex = 2;
            this.AboutButton.Text = "About...";
            this.AboutButton.UseVisualStyleBackColor = true;
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(74, 295);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(91, 23);
            this.OKButton.TabIndex = 3;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // RevertButton
            // 
            this.RevertButton.Location = new System.Drawing.Point(171, 295);
            this.RevertButton.Name = "RevertButton";
            this.RevertButton.Size = new System.Drawing.Size(57, 23);
            this.RevertButton.TabIndex = 4;
            this.RevertButton.Text = "Revert";
            this.RevertButton.UseVisualStyleBackColor = true;
            this.RevertButton.Click += new System.EventHandler(this.RevertButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Book", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Logon Background Changer";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BGDialog
            // 
            this.BGDialog.Filter = "JPG Files|*.jpg";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 330);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RevertButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.AboutButton);
            this.Controls.Add(this.Step2Box);
            this.Controls.Add(this.Step1Box);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "LogonBGChanger";
            this.Step1Box.ResumeLayout(false);
            this.Step2Box.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BGBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Step1Box;
        private System.Windows.Forms.CheckBox RegToggle;
        private System.Windows.Forms.GroupBox Step2Box;
        private System.Windows.Forms.Label MissingLabel;
        private System.Windows.Forms.PictureBox BGBox;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.Button UseButton;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.Button AboutButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button RevertButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog BGDialog;
    }
}

