using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFinstaller.Properties;
using System.Drawing;

namespace WPFinstaller
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        private void InstallButton()
        {
            InstallPanel.Visibility = Visibility.Hidden;
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
