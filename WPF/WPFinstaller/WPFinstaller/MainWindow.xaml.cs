using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace WPFinstaller
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        FileManager filemanager = new FileManager();
        public MainWindow()
        {
            InitializeComponent();
            InstallDonePanel.Visibility = Visibility.Hidden;
            InstallDonePanel.Margin = new Thickness(0,0,10,0);
            SameVersionPanel.Visibility = Visibility.Hidden;
            SameVersionPanel.Margin = new Thickness(0, 0, 10, 0);
            UninstallDonePanel.Visibility = Visibility.Hidden;
            UninstallDonePanel.Margin = new Thickness(0, 0, 10, 0);
        }
        public void InstallButton()
        {
            bool isdone = filemanager.UnZipResource();
            if(isdone == true)
            {
                InstallPanel.Visibility = Visibility.Hidden;
                InstallDonePanel.Visibility = Visibility.Visible;
            }
            else if (isdone == false)
            {
                InstallPanel.Visibility = Visibility.Hidden;
                SameVersionPanel.Visibility = Visibility.Visible;
            }

        }
        public void UninstallApp(object sender, MouseEventArgs e)
        {
            filemanager.UninstallApp();
            UninstallDonePanel.Visibility = Visibility.Visible;
        }
        private void QuitApp(object sender, MouseEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Form_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }
        public void InstallButton_Click(object sender, RoutedEventArgs e)
        {
            InstallButton();
        }
        public void InstallBorder_Click(object sender, MouseEventArgs e)
        {
            InstallButton();
        }
        private void CloseWindow_Click(object sender, MouseEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void MinimizeWindow_Click(object sender, MouseEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void GithubButton_Click(object sender, MouseEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://github.com/niilopoutanen") { UseShellExecute = true });
        }
    }
}
