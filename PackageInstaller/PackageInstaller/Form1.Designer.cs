namespace PackageInstaller
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CloseWindow = new System.Windows.Forms.PictureBox();
            this.MinimizeWindow = new System.Windows.Forms.PictureBox();
            this.ProductNameLabel = new System.Windows.Forms.Label();
            this.Logo = new System.Windows.Forms.PictureBox();
            this.InstallButton = new System.Windows.Forms.PictureBox();
            this.InstallLabel = new System.Windows.Forms.Label();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.VersionExistsPanel = new System.Windows.Forms.Panel();
            this.UninstallLabel = new System.Windows.Forms.Label();
            this.UninstallButton = new System.Windows.Forms.PictureBox();
            this.OKLabel = new System.Windows.Forms.Label();
            this.OkButton = new System.Windows.Forms.PictureBox();
            this.NewestVersionLabel = new System.Windows.Forms.Label();
            this.InstallDonePanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.QuitLabel = new System.Windows.Forms.Label();
            this.QuitButton = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CloseWindow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimizeWindow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InstallButton)).BeginInit();
            this.VersionExistsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UninstallButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OkButton)).BeginInit();
            this.InstallDonePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuitButton)).BeginInit();
            this.SuspendLayout();
            // 
            // CloseWindow
            // 
            this.CloseWindow.BackColor = System.Drawing.Color.Transparent;
            this.CloseWindow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CloseWindow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseWindow.Image = global::PackageInstaller.Properties.Resources.CloseIcon;
            this.CloseWindow.Location = new System.Drawing.Point(486, 15);
            this.CloseWindow.Name = "CloseWindow";
            this.CloseWindow.Size = new System.Drawing.Size(20, 20);
            this.CloseWindow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CloseWindow.TabIndex = 0;
            this.CloseWindow.TabStop = false;
            this.CloseWindow.Click += new System.EventHandler(this.CloseWindow_Click);
            // 
            // MinimizeWindow
            // 
            this.MinimizeWindow.BackColor = System.Drawing.Color.Transparent;
            this.MinimizeWindow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MinimizeWindow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MinimizeWindow.Image = global::PackageInstaller.Properties.Resources.MinimizeIcon;
            this.MinimizeWindow.Location = new System.Drawing.Point(444, 15);
            this.MinimizeWindow.Name = "MinimizeWindow";
            this.MinimizeWindow.Size = new System.Drawing.Size(20, 20);
            this.MinimizeWindow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MinimizeWindow.TabIndex = 1;
            this.MinimizeWindow.TabStop = false;
            this.MinimizeWindow.Click += new System.EventHandler(this.MinimizeWindow_Click);
            // 
            // ProductNameLabel
            // 
            this.ProductNameLabel.AutoSize = true;
            this.ProductNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.ProductNameLabel.Font = new System.Drawing.Font("Segoe UI", 34F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ProductNameLabel.ForeColor = System.Drawing.Color.White;
            this.ProductNameLabel.Location = new System.Drawing.Point(15, 67);
            this.ProductNameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.ProductNameLabel.Name = "ProductNameLabel";
            this.ProductNameLabel.Size = new System.Drawing.Size(330, 62);
            this.ProductNameLabel.TabIndex = 4;
            this.ProductNameLabel.Text = "Product name";
            this.ProductNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Logo
            // 
            this.Logo.BackColor = System.Drawing.Color.Transparent;
            this.Logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Logo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Logo.Image = global::PackageInstaller.Properties.Resources.Logo;
            this.Logo.Location = new System.Drawing.Point(25, 15);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(20, 20);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Logo.TabIndex = 9;
            this.Logo.TabStop = false;
            this.Logo.Click += new System.EventHandler(this.Logo_Click);
            this.Logo.MouseHover += new System.EventHandler(this.Logo_MouseHover);
            // 
            // InstallButton
            // 
            this.InstallButton.BackColor = System.Drawing.Color.Transparent;
            this.InstallButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.InstallButton.Image = global::PackageInstaller.Properties.Resources.InstallButton;
            this.InstallButton.Location = new System.Drawing.Point(64, 221);
            this.InstallButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.InstallButton.Name = "InstallButton";
            this.InstallButton.Size = new System.Drawing.Size(400, 60);
            this.InstallButton.TabIndex = 11;
            this.InstallButton.TabStop = false;
            this.InstallButton.Click += new System.EventHandler(this.InstallButton_Click);
            // 
            // InstallLabel
            // 
            this.InstallLabel.AutoSize = true;
            this.InstallLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(134)))), ((int)(((byte)(252)))));
            this.InstallLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.InstallLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.InstallLabel.ForeColor = System.Drawing.Color.White;
            this.InstallLabel.Location = new System.Drawing.Point(215, 233);
            this.InstallLabel.Name = "InstallLabel";
            this.InstallLabel.Size = new System.Drawing.Size(96, 37);
            this.InstallLabel.TabIndex = 12;
            this.InstallLabel.Text = "Install";
            this.InstallLabel.Click += new System.EventHandler(this.InstallLabel_Click);
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.BackColor = System.Drawing.Color.Transparent;
            this.VersionLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.VersionLabel.ForeColor = System.Drawing.Color.White;
            this.VersionLabel.Location = new System.Drawing.Point(25, 145);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(115, 30);
            this.VersionLabel.TabIndex = 13;
            this.VersionLabel.Text = "Version: 0";
            // 
            // VersionExistsPanel
            // 
            this.VersionExistsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(1)))), ((int)(((byte)(217)))), ((int)(((byte)(124)))));
            this.VersionExistsPanel.Controls.Add(this.UninstallLabel);
            this.VersionExistsPanel.Controls.Add(this.UninstallButton);
            this.VersionExistsPanel.Controls.Add(this.OKLabel);
            this.VersionExistsPanel.Controls.Add(this.OkButton);
            this.VersionExistsPanel.Controls.Add(this.NewestVersionLabel);
            this.VersionExistsPanel.Location = new System.Drawing.Point(25, 187);
            this.VersionExistsPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.VersionExistsPanel.Name = "VersionExistsPanel";
            this.VersionExistsPanel.Size = new System.Drawing.Size(91, 30);
            this.VersionExistsPanel.TabIndex = 14;
            // 
            // UninstallLabel
            // 
            this.UninstallLabel.AutoSize = true;
            this.UninstallLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(134)))), ((int)(((byte)(252)))));
            this.UninstallLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UninstallLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.UninstallLabel.ForeColor = System.Drawing.Color.White;
            this.UninstallLabel.Location = new System.Drawing.Point(357, 43);
            this.UninstallLabel.Name = "UninstallLabel";
            this.UninstallLabel.Size = new System.Drawing.Size(96, 28);
            this.UninstallLabel.TabIndex = 4;
            this.UninstallLabel.Text = "Uninstall";
            // 
            // UninstallButton
            // 
            this.UninstallButton.BackColor = System.Drawing.Color.Transparent;
            this.UninstallButton.Image = global::PackageInstaller.Properties.Resources.UninstallButton;
            this.UninstallButton.InitialImage = global::PackageInstaller.Properties.Resources.UninstallButton;
            this.UninstallButton.Location = new System.Drawing.Point(339, 34);
            this.UninstallButton.Name = "UninstallButton";
            this.UninstallButton.Size = new System.Drawing.Size(130, 50);
            this.UninstallButton.TabIndex = 0;
            this.UninstallButton.TabStop = false;
            this.UninstallButton.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // OKLabel
            // 
            this.OKLabel.AutoSize = true;
            this.OKLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(134)))), ((int)(((byte)(252)))));
            this.OKLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OKLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.OKLabel.ForeColor = System.Drawing.Color.White;
            this.OKLabel.Location = new System.Drawing.Point(254, 43);
            this.OKLabel.Name = "OKLabel";
            this.OKLabel.Size = new System.Drawing.Size(40, 28);
            this.OKLabel.TabIndex = 2;
            this.OKLabel.Text = "OK";
            this.OKLabel.Click += new System.EventHandler(this.OKLabel_Click);
            // 
            // OkButton
            // 
            this.OkButton.BackColor = System.Drawing.Color.Transparent;
            this.OkButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OkButton.Image = global::PackageInstaller.Properties.Resources.OKButton;
            this.OkButton.Location = new System.Drawing.Point(228, 34);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(90, 50);
            this.OkButton.TabIndex = 3;
            this.OkButton.TabStop = false;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // NewestVersionLabel
            // 
            this.NewestVersionLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.NewestVersionLabel.ForeColor = System.Drawing.Color.White;
            this.NewestVersionLabel.Location = new System.Drawing.Point(3, 20);
            this.NewestVersionLabel.Name = "NewestVersionLabel";
            this.NewestVersionLabel.Size = new System.Drawing.Size(219, 74);
            this.NewestVersionLabel.TabIndex = 0;
            this.NewestVersionLabel.Text = "Newest version already installed.";
            // 
            // InstallDonePanel
            // 
            this.InstallDonePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.InstallDonePanel.Controls.Add(this.label3);
            this.InstallDonePanel.Controls.Add(this.QuitLabel);
            this.InstallDonePanel.Controls.Add(this.QuitButton);
            this.InstallDonePanel.Controls.Add(this.label1);
            this.InstallDonePanel.Location = new System.Drawing.Point(122, 187);
            this.InstallDonePanel.Name = "InstallDonePanel";
            this.InstallDonePanel.Size = new System.Drawing.Size(73, 29);
            this.InstallDonePanel.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(15, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(258, 38);
            this.label3.TabIndex = 3;
            this.label3.Text = "Application installed to:\nC:/User/Program Files/NiiloPoutanen";
            // 
            // QuitLabel
            // 
            this.QuitLabel.AutoSize = true;
            this.QuitLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(134)))), ((int)(((byte)(252)))));
            this.QuitLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.QuitLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.QuitLabel.ForeColor = System.Drawing.Color.White;
            this.QuitLabel.Location = new System.Drawing.Point(368, 43);
            this.QuitLabel.Name = "QuitLabel";
            this.QuitLabel.Size = new System.Drawing.Size(53, 28);
            this.QuitLabel.TabIndex = 2;
            this.QuitLabel.Text = "Quit";
            this.QuitLabel.Click += new System.EventHandler(this.QuitLabel_Click);
            // 
            // QuitButton
            // 
            this.QuitButton.BackColor = System.Drawing.Color.Transparent;
            this.QuitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.QuitButton.Image = global::PackageInstaller.Properties.Resources.OKButton;
            this.QuitButton.Location = new System.Drawing.Point(349, 33);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(90, 50);
            this.QuitButton.TabIndex = 1;
            this.QuitButton.TabStop = false;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Installation done.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PackageInstaller.Properties.Resources.FormBG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(530, 320);
            this.Controls.Add(this.InstallDonePanel);
            this.Controls.Add(this.VersionExistsPanel);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.InstallLabel);
            this.Controls.Add(this.InstallButton);
            this.Controls.Add(this.Logo);
            this.Controls.Add(this.ProductNameLabel);
            this.Controls.Add(this.MinimizeWindow);
            this.Controls.Add(this.CloseWindow);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(0)))), ((int)(((byte)(179)))));
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.CloseWindow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimizeWindow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InstallButton)).EndInit();
            this.VersionExistsPanel.ResumeLayout(false);
            this.VersionExistsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UninstallButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OkButton)).EndInit();
            this.InstallDonePanel.ResumeLayout(false);
            this.InstallDonePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuitButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox CloseWindow;
        private PictureBox MinimizeWindow;
        private Label ProductNameLabel;
        private PictureBox Logo;
        private PictureBox InstallButton;
        private Label InstallLabel;
        private Label VersionLabel;
        private Panel VersionExistsPanel;
        private Label NewestVersionLabel;
        private Label OKLabel;
        private PictureBox OkButton;
        private PictureBox UninstallButton;
        private Label UninstallLabel;
        private Panel InstallDonePanel;
        private Label label1;
        private Label QuitLabel;
        private PictureBox QuitButton;
        private Label label3;
    }
}