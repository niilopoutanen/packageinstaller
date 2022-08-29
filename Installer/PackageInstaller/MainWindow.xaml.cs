using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            InstallPanel.Visibility = Visibility.Hidden;
            InstallDonePanel.Visibility = Visibility.Hidden;
            InstallDonePanel.Margin = new Thickness(0, 0, 0, 0);
            SameVersionPanel.Visibility = Visibility.Hidden;
            SameVersionPanel.Margin = new Thickness(0, 0, 0, 0);
            OlderVersionPanel.Visibility = Visibility.Hidden;
            OlderVersionPanel.Margin = new Thickness(0, 0, 0, 0);
            UninstallPanel.Visibility = Visibility.Hidden;
            UninstallPanel.Margin = new Thickness(0, 0, 0, 0);
            UninstallDonePanel.Visibility = Visibility.Hidden;
            UninstallDonePanel.Margin = new Thickness(0, 0, 0, 0);

            ProductName.Text = filemanager.GetProductName();
            float version = filemanager.GetVersion(true);
            Version.Text = version.ToString();

            bool IsAppInstalled = filemanager.IsAppInstalled();
            if (IsAppInstalled == true)
            {
                UninstallPanel.Visibility = Visibility.Visible;
            }
            else if (IsAppInstalled == false)
            {
                InstallPanel.Visibility = Visibility.Visible;
            }
        }

        private async void UninstallDoneAnim()
        {
            DoubleAnimation fadein = (this.FindResource("TextFadeIn") as DoubleAnimation).Clone();
            DoubleAnimation fadein2 = (this.FindResource("TextFadeIn") as DoubleAnimation).Clone();
            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(fadein);
            storyboard.Children.Add(fadein2);

            Storyboard.SetTargetName(fadein, AppUninstalledText.Name);
            Storyboard.SetTargetName(fadein2, QuitButtonText.Name);

            Storyboard.SetTargetProperty(fadein, new PropertyPath(TextBlock.OpacityProperty));
            Storyboard.SetTargetProperty(fadein2, new PropertyPath(TextBlock.OpacityProperty));

            storyboard.Begin(this);
        }
        private async void InstallApp()
        {
            DoubleAnimationUsingKeyFrames widthAnim = (this.FindResource("MainButtonWidthAnim") as DoubleAnimationUsingKeyFrames).Clone();
            ThicknessAnimationUsingKeyFrames marginAnim = (this.FindResource("MainButtonMarginAnim") as ThicknessAnimationUsingKeyFrames).Clone();
            DoubleAnimation fadeout = (this.FindResource("TextFadeOut") as DoubleAnimation).Clone();


            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(fadeout);
            storyboard.Children.Add(widthAnim);
            storyboard.Children.Add(marginAnim);
            Storyboard.SetTargetName(fadeout, QuitButtonText2.Name);
            Storyboard.SetTargetName(widthAnim, InstallButton.Name);
            Storyboard.SetTargetName(marginAnim, InstallButton.Name);

            Storyboard.SetTargetProperty(fadeout, new PropertyPath(TextBlock.OpacityProperty));
            Storyboard.SetTargetProperty(widthAnim, new PropertyPath(Border.WidthProperty));
            Storyboard.SetTargetProperty(marginAnim, new PropertyPath(Border.MarginProperty));


            await Task.Delay(500);
            storyboard.Begin(this);
            int successful = filemanager.UnZipResource(false);

            if(successful == 1)
            {
                InstallPanel.Visibility = Visibility.Hidden;
                InstallDonePanel.Visibility = Visibility.Visible;
            }
            else if (successful == 0)
            {
                InstallPanel.Visibility = Visibility.Hidden;
                SameVersionPanel.Visibility = Visibility.Visible;
            }
            else if(successful == 2)
            {
                InstallPanel.Visibility = Visibility.Hidden;
                OlderVersionPanel.Visibility = Visibility.Visible;
            }



        }
        private async void UninstallApp()
        {

            filemanager.UninstallApp();
            UninstallPanel.Visibility = Visibility.Hidden;
            UninstallDonePanel.Visibility = Visibility.Visible;
            UninstallDoneAnim();
        }


        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                try
                {
                    DragMove();
                }
                catch (Exception)
                {

                }
            }
        }
        private void CloseApp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void MinimizeApp(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void OpenLink(object sender, MouseButtonEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://github.com/niilopoutanen") { UseShellExecute = true });
        }
        private void InstallButton_Click(object sender, MouseButtonEventArgs e)
        {
            InstallApp();
        }
        private void UninstallButton_Click(object sender, MouseButtonEventArgs e)
        {
            UninstallApp();
        }
    }
}
