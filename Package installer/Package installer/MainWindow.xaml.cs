using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Package_installer
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

        private void CloseApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void InstallApp(object sender, RoutedEventArgs e)
        {
            installButton.IsEnabled = false;
            MainView.Visibility = Visibility.Visible;
            ThicknessAnimationUsingKeyFrames secondarySlide = (this.FindResource("secondaryButtonSlide") as ThicknessAnimationUsingKeyFrames).Clone();
            DoubleAnimation fadeout = new DoubleAnimation
            {
                From = 1.0,
                To = 0.0,
                FillBehavior = FillBehavior.Stop,
                Duration = new Duration(TimeSpan.FromSeconds(0.3))
            };
            ExponentialEase ease = new ExponentialEase();
            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(secondarySlide);
            Storyboard.SetTarget(secondarySlide, cancelButton);
            storyboard.Completed += delegate
            {
                Storyboard storyboard2 = new Storyboard();
                storyboard2.Children.Add(fadeout);
                Storyboard.SetTarget(fadeout, MainView);
                Storyboard.SetTargetProperty(fadeout, new PropertyPath(OpacityProperty));
                storyboard2.Completed += delegate
                {
                    InstallingViewAnim();
                };
                storyboard2.Begin();
            };
            storyboard.Begin();

        }
        private async void InstallingViewAnim()
        {
            MainView.Visibility = Visibility.Hidden;
            InstallingView.Visibility = Visibility.Visible;

            LoadSpinner.Visibility = Visibility.Visible;
            DoubleAnimation fadein = (this.FindResource("FadeIn") as DoubleAnimation).Clone();
            DoubleAnimation fadeout = (this.FindResource("FadeOut") as DoubleAnimation).Clone();
            DoubleAnimation resultOpen = (this.FindResource("resultOpen") as DoubleAnimation).Clone();
            DoubleAnimation resultClose = (this.FindResource("resultClose") as DoubleAnimation).Clone();

            Storyboard storyboard = new Storyboard();
            ((Storyboard)Resources["LoadAnim"]).Begin();
            storyboard.Children.Add(fadein);
            Storyboard.SetTarget(fadein, LoadSpinner);
            Storyboard.SetTargetProperty(fadein, new PropertyPath(OpacityProperty));
            storyboard.Completed += delegate
            {
                
            };
            storyboard.Begin();

            await Task.Delay(5000);
            LoadSpinner.Visibility = Visibility.Hidden;
            ((Storyboard)Resources["LoadAnim"]).Stop();


            Storyboard resultBoard = new Storyboard();
            resultBoard.Children.Add(resultOpen);
            resultBoard.Children.Add(fadein);
            Storyboard.SetTarget(resultOpen, loadingBG);
            Storyboard.SetTarget(fadein, successIcon);
            resultBoard.Completed += async delegate
            {
                Storyboard fadeinresult = new Storyboard();
                fadeinresult.Children.Add(fadein);
                Storyboard.SetTarget(fadein, successIcon);
                successIcon.Visibility = Visibility.Visible;
                fadeinresult.Begin();
                await Task.Delay(2000);
                Storyboard resultBoardClose = new Storyboard();
                resultBoardClose.Children.Add(resultClose);
                resultBoardClose.Children.Add(fadeout);
                Storyboard.SetTarget(resultClose, loadingBG);
                Storyboard.SetTarget(fadeout, successIcon);
                resultBoardClose.Completed += delegate
                {
                    Storyboard fadeOutResult = new Storyboard();
                    fadeOutResult.Children.Add(fadeout);
                    Storyboard.SetTarget(fadeout, loadingBG);
                    fadeOutResult.Completed += delegate
                    {
                        InstallingView.Visibility = Visibility.Hidden;
                        InstallDoneAnim();
                    };
                    fadeOutResult.Begin();

                };
                resultBoardClose.Begin();
            };
            resultBoard.Begin();
        }
        private void InstallDoneAnim()
        {
            InstallDoneView.Visibility = Visibility.Visible;
            ThicknessAnimationUsingKeyFrames secondarySlide = (this.FindResource("secondaryButtonSlideOut") as ThicknessAnimationUsingKeyFrames).Clone();
            DoubleAnimation fadein = new DoubleAnimation
            {
                From = 0.0,
                To = 1.0,
                FillBehavior = FillBehavior.Stop,
                Duration = new Duration(TimeSpan.FromSeconds(0.3))
            };
            ExponentialEase ease = new ExponentialEase();
            ease.EasingMode = EasingMode.EaseOut;
            fadein.EasingFunction = ease;
            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(fadein);
            Storyboard.SetTarget(fadein, InstallDoneView);
            Storyboard.SetTargetProperty(fadein, new PropertyPath(OpacityProperty));
            storyboard.Completed += delegate
            {
                Storyboard storyboard2 = new Storyboard();
                storyboard2.Children.Add(secondarySlide);
                Storyboard.SetTarget(secondarySlide, quitButton);
                storyboard2.Completed += delegate
                {

                };
                storyboard2.Begin();
            };
            storyboard.Begin();
        }
        private void OpenApp(object sender, RoutedEventArgs e)
        {

        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
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
    }
}
