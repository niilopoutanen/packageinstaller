using System.Diagnostics;
using System.Runtime.InteropServices;

namespace PackageInstaller
{
    public partial class Form1 : Form
    {
        FileManager filemanager = new FileManager();
        UI uiclass = new UI();
        
        public Form1()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.AppIcon;
        }
        public void ChangeInstallLabel(string TextToShow)
        {
            InstallLabel.Text = TextToShow;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            FontFamily InterBold = uiclass.CreateInterBold();
            FontFamily InterSemiBold = uiclass.CreateInterSemiBold();
            uiclass.UpdateLabel(VersionLabel, "Version: " + filemanager.GetVersion(true).ToString());
            uiclass.ChangePanelVisibility(VersionExistsPanel, false);
            VersionExistsPanel.Size = new Size(480, 120);
            InstallDonePanel.Visible = false;
            InstallDonePanel.Size = new Size(480,120);
            InstallDonePanel.Location = new Point(25,187);
        }

        //Form dragging stuff
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);



        /// <summary>
        /// Used to move the form, since borderless form can't be moved without implementing it yourself.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        /// <summary>
        /// Shuts down the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseWindow_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        /// <summary>
        /// Minimizes the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MinimizeWindow_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }


        /// <summary>
        /// Moves the user to my github page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Logo_Click(object sender, EventArgs e)
        {
            string target = "https://github.com/niilopoutanen";
            Process.Start(new ProcessStartInfo(target) { UseShellExecute = true });
        }

        private void InstallButton_Click(object sender, EventArgs e)
        {
            bool trueorfalse = filemanager.UnZipResource();
            if (trueorfalse == false)
            {
                uiclass.ChangePanelVisibility(VersionExistsPanel, true);
            }
            else if (trueorfalse == true)
            {
                InstallDonePanel.Visible = true;
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OKLabel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void InstallLabel_Click(object sender, EventArgs e)
        {
            bool trueorfalse = filemanager.UnZipResource();
            if ( trueorfalse == false)
            {
                uiclass.ChangePanelVisibility(VersionExistsPanel, true);
            }
            else if(trueorfalse == true)
            {
                InstallDonePanel.Visible = true;
            }
        }

        private void Logo_MouseHover(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void QuitLabel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}