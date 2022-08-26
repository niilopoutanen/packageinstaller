using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace WPFinstaller
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Storyboard storyboard;
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
        public void OnComplete()
        {
            InstallDonePanel.Visibility = Visibility.Visible;

        }
        public async Task ShutdownAnim()
        {
            DoubleAnimation opacity = new DoubleAnimation();
            opacity.From = 1;
            opacity.To = 0;
            opacity.FillBehavior = FillBehavior.HoldEnd;
            opacity.Duration = new Duration(TimeSpan.FromSeconds(0.5));
            storyboard = new Storyboard();
            storyboard.Children.Add(opacity);
            Storyboard.SetTargetName(opacity, TopGrid.Name);
            Storyboard.SetTargetProperty(opacity, new PropertyPath(Grid.OpacityProperty));
            storyboard.Begin(this);
            await Task.Delay(600);
            Application.Current.Shutdown();
        }
        public async Task InstallAnim(bool success)
        {
            int MinSize = 90;
            if (success == true)
            {
                MinSize = 90;
            }
            else if (success == false)
            {
                MinSize = 130;
            }
            DoubleAnimationUsingKeyFrames change = new DoubleAnimationUsingKeyFrames();
            change.Duration = new Duration(TimeSpan.FromSeconds(1));
            change.AutoReverse = false;
            change.FillBehavior = FillBehavior.HoldEnd;
            change.KeyFrames.Add(
                new SplineDoubleKeyFrame(
                    400,
                    KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0))));
            change.KeyFrames.Add(
                new SplineDoubleKeyFrame(
                    MinSize,
                    KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0.8)),
                    new KeySpline(0.2, 0.5, 0, 1)
                    ));

            DoubleAnimation fadeout = new DoubleAnimation();
            fadeout.From = 1;
            fadeout.To = 0;
            fadeout.Duration = new Duration(TimeSpan.FromSeconds(0.4));
            fadeout.FillBehavior = FillBehavior.HoldEnd;


            storyboard = new Storyboard();
            storyboard.Children.Add(change);
            storyboard.Children.Add(fadeout);

            Storyboard.SetTargetName(change, InstallBTN.Name);
            Storyboard.SetTargetName(fadeout, InstallText.Name);

            Storyboard.SetTargetProperty(change, new PropertyPath(Border.WidthProperty));
            Storyboard.SetTargetProperty(fadeout, new PropertyPath(TextBlock.OpacityProperty));

            storyboard.Begin(this);
            await Task.Delay(800);
            ShowNextPanel(success);
        }
        public void ShowNextPanel(bool success)
        {
            DoubleAnimation fade1 = new DoubleAnimation();
            fade1.From = 0;
            fade1.To = 1;
            fade1.Duration = new Duration(TimeSpan.FromSeconds(1));
            fade1.FillBehavior = FillBehavior.HoldEnd;

            DoubleAnimation fade2 = new DoubleAnimation();
            fade2.From = 0;
            fade2.To = 1;
            fade2.Duration = new Duration(TimeSpan.FromSeconds(1));
            fade2.FillBehavior = FillBehavior.HoldEnd;

            DoubleAnimation fade3 = new DoubleAnimation();
            fade3.From = 0;
            fade3.To = 1;
            fade3.Duration = new Duration(TimeSpan.FromSeconds(1));
            fade3.FillBehavior = FillBehavior.HoldEnd;

            DoubleAnimation fade4 = new DoubleAnimation();
            fade4.From = 0;
            fade4.To = 1;
            fade4.Duration = new Duration(TimeSpan.FromSeconds(1));
            fade4.FillBehavior = FillBehavior.HoldEnd;
            storyboard = new Storyboard();
            storyboard.Children.Add(fade1);
            storyboard.Children.Add(fade2);
            storyboard.Children.Add(fade3);
            storyboard.Children.Add(fade4);

            if(success == true)
            {
                Storyboard.SetTargetName(fade1, InstallationDone.Name);
                Storyboard.SetTargetName(fade2, ApplicationInstalledTo.Name);
                Storyboard.SetTargetName(fade3, FilePathText.Name);
                Storyboard.SetTargetName(fade4, QuitText.Name);


                Storyboard.SetTargetProperty(fade4, new PropertyPath(TextBlock.OpacityProperty));
                Storyboard.SetTargetProperty(fade3, new PropertyPath(TextBlock.OpacityProperty));
                Storyboard.SetTargetProperty(fade2, new PropertyPath(TextBlock.OpacityProperty));
                Storyboard.SetTargetProperty(fade1, new PropertyPath(TextBlock.OpacityProperty));
                storyboard.Begin(this);
            }
            else if (success == false)
            {
                Storyboard.SetTargetName(fade1, NewVerText.Name);
                Storyboard.SetTargetName(fade2, AlrInstText.Name);
                Storyboard.SetTargetName(fade3, OKButton.Name);
                Storyboard.SetTargetName(fade4, UninstallBTNText.Name);


                Storyboard.SetTargetProperty(fade4, new PropertyPath(TextBlock.OpacityProperty));
                Storyboard.SetTargetProperty(fade3, new PropertyPath(Border.OpacityProperty));
                Storyboard.SetTargetProperty(fade2, new PropertyPath(TextBlock.OpacityProperty));
                Storyboard.SetTargetProperty(fade1, new PropertyPath(TextBlock.OpacityProperty));
                storyboard.Begin(this);
            }


        }
        public async void InstallButton()
        {
            bool didsucceed = filemanager.UnZipResource();
            await InstallAnim(didsucceed);
            if (didsucceed == true)
            {
                InstallPanel.Visibility = Visibility.Hidden;

                InstallDonePanel.Visibility = Visibility.Visible;

            }
            else if (didsucceed == false)
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
        private async void QuitApp(object sender, MouseEventArgs e)
        {
            await ShutdownAnim();
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
        private async void CloseWindow_Click(object sender, MouseEventArgs e)
        {
            await ShutdownAnim();
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
