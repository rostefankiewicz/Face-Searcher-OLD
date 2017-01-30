namespace Face_Searcher.Forms
{
    partial class License
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(License));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.backButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.machineButton = new System.Windows.Forms.Button();
            this.LicenseButton = new System.Windows.Forms.Button();
            this.MachineKeyBox = new System.Windows.Forms.TextBox();
            this.LicenseExpBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(16, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1279, 123);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(644, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(629, 53);
            this.label2.TabIndex = 2;
            this.label2.Text = "License Information";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(5, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(629, 113);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(644, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(629, 53);
            this.label1.TabIndex = 0;
            this.label1.Text = "Face-Searcher";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.backButton);
            this.panel2.Controls.Add(this.exitButton);
            this.panel2.Location = new System.Drawing.Point(16, 690);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1279, 123);
            this.panel2.TabIndex = 5;
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.Location = new System.Drawing.Point(799, 62);
            this.backButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(233, 55);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "MAIN PAGE";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(1040, 62);
            this.exitButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(233, 55);
            this.exitButton.TabIndex = 0;
            this.exitButton.Text = "EXIT";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // machineButton
            // 
            this.machineButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.machineButton.Location = new System.Drawing.Point(136, 235);
            this.machineButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.machineButton.Name = "machineButton";
            this.machineButton.Size = new System.Drawing.Size(400, 123);
            this.machineButton.TabIndex = 6;
            this.machineButton.Text = "Machine Key Generation";
            this.machineButton.UseVisualStyleBackColor = true;
            this.machineButton.Click += new System.EventHandler(this.machineButton_Click);
            // 
            // LicenseButton
            // 
            this.LicenseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LicenseButton.Location = new System.Drawing.Point(136, 459);
            this.LicenseButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LicenseButton.Name = "LicenseButton";
            this.LicenseButton.Size = new System.Drawing.Size(400, 123);
            this.LicenseButton.TabIndex = 7;
            this.LicenseButton.Text = "License Expiration";
            this.LicenseButton.UseVisualStyleBackColor = true;
            this.LicenseButton.Click += new System.EventHandler(this.LicenseButton_Click);
            // 
            // MachineKeyBox
            // 
            this.MachineKeyBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MachineKeyBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.MachineKeyBox.Location = new System.Drawing.Point(544, 268);
            this.MachineKeyBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MachineKeyBox.Name = "MachineKeyBox";
            this.MachineKeyBox.Size = new System.Drawing.Size(655, 55);
            this.MachineKeyBox.TabIndex = 8;
            this.MachineKeyBox.Text = "...MachineID key...";
            this.MachineKeyBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LicenseExpBox
            // 
            this.LicenseExpBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LicenseExpBox.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.LicenseExpBox.Location = new System.Drawing.Point(544, 459);
            this.LicenseExpBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LicenseExpBox.Multiline = true;
            this.LicenseExpBox.Name = "LicenseExpBox";
            this.LicenseExpBox.Size = new System.Drawing.Size(655, 122);
            this.LicenseExpBox.TabIndex = 9;
            this.LicenseExpBox.Text = "...License Expiration Info...";
            this.LicenseExpBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(293, 586);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(804, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Please ensure that at least one camera is started in order to get the most up to " +
    "date expiration information.";
            // 
            // License
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1312, 828);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LicenseExpBox);
            this.Controls.Add(this.MachineKeyBox);
            this.Controls.Add(this.LicenseButton);
            this.Controls.Add(this.machineButton);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "License";
            this.Text = "Face-Searcher - License";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button machineButton;
        private System.Windows.Forms.Button LicenseButton;
        private System.Windows.Forms.TextBox MachineKeyBox;
        private System.Windows.Forms.TextBox LicenseExpBox;
        private System.Windows.Forms.Label label3;
    }
}