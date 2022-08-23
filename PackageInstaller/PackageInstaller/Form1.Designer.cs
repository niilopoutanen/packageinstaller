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
            this.FilePathInput = new System.Windows.Forms.PictureBox();
            this.FilePathLabel = new System.Windows.Forms.Label();
            this.ProductNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CloseWindow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimizeWindow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilePathInput)).BeginInit();
            this.SuspendLayout();
            // 
            // CloseWindow
            // 
            this.CloseWindow.BackColor = System.Drawing.Color.Transparent;
            this.CloseWindow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CloseWindow.Image = global::PackageInstaller.Properties.Resources.CloseIcon;
            this.CloseWindow.Location = new System.Drawing.Point(483, 24);
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
            this.MinimizeWindow.Image = global::PackageInstaller.Properties.Resources.MinimizeIcon;
            this.MinimizeWindow.Location = new System.Drawing.Point(445, 24);
            this.MinimizeWindow.Name = "MinimizeWindow";
            this.MinimizeWindow.Size = new System.Drawing.Size(20, 20);
            this.MinimizeWindow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MinimizeWindow.TabIndex = 1;
            this.MinimizeWindow.TabStop = false;
            this.MinimizeWindow.Click += new System.EventHandler(this.MinimizeWindow_Click);
            // 
            // FilePathInput
            // 
            this.FilePathInput.BackColor = System.Drawing.Color.Transparent;
            this.FilePathInput.Image = global::PackageInstaller.Properties.Resources.FilePath;
            this.FilePathInput.Location = new System.Drawing.Point(25, 160);
            this.FilePathInput.Name = "FilePathInput";
            this.FilePathInput.Size = new System.Drawing.Size(480, 50);
            this.FilePathInput.TabIndex = 2;
            this.FilePathInput.TabStop = false;
            this.FilePathInput.Click += new System.EventHandler(this.FilePathInput_Click);
            // 
            // FilePathLabel
            // 
            this.FilePathLabel.AutoSize = true;
            this.FilePathLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.FilePathLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FilePathLabel.ForeColor = System.Drawing.Color.White;
            this.FilePathLabel.Location = new System.Drawing.Point(38, 164);
            this.FilePathLabel.Name = "FilePathLabel";
            this.FilePathLabel.Size = new System.Drawing.Size(148, 42);
            this.FilePathLabel.TabIndex = 3;
            this.FilePathLabel.Text = "Folder path";
            this.FilePathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.FilePathLabel.UseCompatibleTextRendering = true;
            // 
            // ProductNameLabel
            // 
            this.ProductNameLabel.AutoSize = true;
            this.ProductNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.ProductNameLabel.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ProductNameLabel.ForeColor = System.Drawing.Color.White;
            this.ProductNameLabel.Location = new System.Drawing.Point(25, 24);
            this.ProductNameLabel.Name = "ProductNameLabel";
            this.ProductNameLabel.Size = new System.Drawing.Size(257, 51);
            this.ProductNameLabel.TabIndex = 4;
            this.ProductNameLabel.Text = "Product name";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PackageInstaller.Properties.Resources.FormBG;
            this.ClientSize = new System.Drawing.Size(530, 320);
            this.Controls.Add(this.ProductNameLabel);
            this.Controls.Add(this.FilePathLabel);
            this.Controls.Add(this.FilePathInput);
            this.Controls.Add(this.MinimizeWindow);
            this.Controls.Add(this.CloseWindow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(0)))), ((int)(((byte)(179)))));
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.CloseWindow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimizeWindow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilePathInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox CloseWindow;
        private PictureBox MinimizeWindow;
        private PictureBox FilePathInput;
        private Label FilePathLabel;
        private Label ProductNameLabel;
    }
}