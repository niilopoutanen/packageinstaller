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

            DoubleAnimation fadeout = new DoubleAnimation
            {
                From = 1.0,
                To = 0.0,
                FillBehavior = FillBehavior.Stop,
                Duration = new Duration(TimeSpan.FromSeconds(0.3))
            };
            ExponentialEase ease = new ExponentialEase();
            ease.EasingMode = EasingMode.EaseOut;
            fadeout.EasingFunction = ease;
            Storyboard storyboard = new Storyboard();

            storyboard.Children.Add(fadeout);
            Storyboard.SetTarget(fadeout, MainView);
            Storyboard.SetTargetProperty(fadeout, new PropertyPath(OpacityProperty));
            storyboard.Completed += delegate
            {
                InstallingViewAnim();
            };
            storyboard.Begin();

        }
        private async void InstallingViewAnim()
        {
            MainView.Visibility = Visibility.Hidden;
            InstallingView.Visibility = Visibility.Visible;

            LoadSpinner.Visibility = Visibility.Visible;
            DoubleAnimation fadein = (this.FindResource("FadeIn") as DoubleAnimation).Clone();

            Storyboard storyboard = new Storyboard();
            ((Storyboard)Resources["LoadAnim"]).Begin();
            storyboard.Children.Add(fadein);
            Storyboard.SetTarget(fadein, LoadSpinner);
            Storyboard.SetTargetProperty(fadein, new PropertyPath(OpacityProperty));
            storyboard.Completed += delegate
            {
                
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
