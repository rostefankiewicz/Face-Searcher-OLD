namespace Face_Searcher.Forms
{
    partial class MainPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.setUpDocButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.exitButton = new System.Windows.Forms.Button();
            this.licenseInfoButton = new System.Windows.Forms.Button();
            this.aoiSettingButton = new System.Windows.Forms.Button();
            this.cameraButton = new System.Windows.Forms.Button();
            this.nifiButton = new System.Windows.Forms.Button();
            this.emailSetup = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(16, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1279, 123);
            this.panel1.TabIndex = 0;
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
            this.label1.Size = new System.Drawing.Size(629, 113);
            this.label1.TabIndex = 0;
            this.label1.Text = "Face-Searcher";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // setUpDocButton
            // 
            this.setUpDocButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setUpDocButton.Location = new System.Drawing.Point(16, 185);
            this.setUpDocButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.setUpDocButton.Name = "setUpDocButton";
            this.setUpDocButton.Size = new System.Drawing.Size(629, 123);
            this.setUpDocButton.TabIndex = 1;
            this.setUpDocButton.Text = "Documentation";
            this.setUpDocButton.UseVisualStyleBackColor = true;
            this.setUpDocButton.Click += new System.EventHandler(this.setUpDocButton_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.exitButton);
            this.panel2.Location = new System.Drawing.Point(16, 690);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1279, 123);
            this.panel2.TabIndex = 2;
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
            // licenseInfoButton
            // 
            this.licenseInfoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.licenseInfoButton.Location = new System.Drawing.Point(16, 351);
            this.licenseInfoButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.licenseInfoButton.Name = "licenseInfoButton";
            this.licenseInfoButton.Size = new System.Drawing.Size(629, 123);
            this.licenseInfoButton.TabIndex = 3;
            this.licenseInfoButton.Text = "License Information";
            this.licenseInfoButton.UseVisualStyleBackColor = true;
            this.licenseInfoButton.Click += new System.EventHandler(this.licenseInfoButton_Click);
            // 
            // aoiSettingButton
            // 
            this.aoiSettingButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aoiSettingButton.Location = new System.Drawing.Point(16, 521);
            this.aoiSettingButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.aoiSettingButton.Name = "aoiSettingButton";
            this.aoiSettingButton.Size = new System.Drawing.Size(629, 123);
            this.aoiSettingButton.TabIndex = 4;
            this.aoiSettingButton.Text = "Default AOI Settings";
            this.aoiSettingButton.UseVisualStyleBackColor = true;
            this.aoiSettingButton.Click += new System.EventHandler(this.aoiSettingButton_Click);
            // 
            // cameraButton
            // 
            this.cameraButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cameraButton.Location = new System.Drawing.Point(667, 185);
            this.cameraButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cameraButton.Name = "cameraButton";
            this.cameraButton.Size = new System.Drawing.Size(629, 123);
            this.cameraButton.TabIndex = 5;
            this.cameraButton.Text = "Configure / Start Camera";
            this.cameraButton.UseVisualStyleBackColor = true;
            this.cameraButton.Click += new System.EventHandler(this.cameraButton_Click);
            // 
            // nifiButton
            // 
            this.nifiButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nifiButton.Location = new System.Drawing.Point(667, 351);
            this.nifiButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nifiButton.Name = "nifiButton";
            this.nifiButton.Size = new System.Drawing.Size(629, 123);
            this.nifiButton.TabIndex = 6;
            this.nifiButton.Text = "Configure / Start NiFi";
            this.nifiButton.UseVisualStyleBackColor = true;
            this.nifiButton.Click += new System.EventHandler(this.nifiButton_Click);
            // 
            // emailSetup
            // 
            this.emailSetup.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailSetup.Location = new System.Drawing.Point(667, 521);
            this.emailSetup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.emailSetup.Name = "emailSetup";
            this.emailSetup.Size = new System.Drawing.Size(629, 123);
            this.emailSetup.TabIndex = 7;
            this.emailSetup.Text = "Email Setup";
            this.emailSetup.UseVisualStyleBackColor = true;
            this.emailSetup.Click += new System.EventHandler(this.emailSetup_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1312, 828);
            this.Controls.Add(this.emailSetup);
            this.Controls.Add(this.nifiButton);
            this.Controls.Add(this.cameraButton);
            this.Controls.Add(this.aoiSettingButton);
            this.Controls.Add(this.licenseInfoButton);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.setUpDocButton);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "MainPage";
            this.Text = "Face-Searcher";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button setUpDocButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button licenseInfoButton;
        private System.Windows.Forms.Button aoiSettingButton;
        private System.Windows.Forms.Button cameraButton;
        private System.Windows.Forms.Button nifiButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button emailSetup;
        //private System.Windows.Forms.Button aboutButton;
    }
}