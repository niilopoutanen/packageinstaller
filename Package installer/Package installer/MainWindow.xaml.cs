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
            DoubleAnimation fadeout1 = (this.FindResource("FadeOut") as DoubleAnimation).Clone();
            DoubleAnimation fadeout2 = (this.FindResource("FadeOut") as DoubleAnimation).Clone();
            DoubleAnimation primaryButtonToCircleW = (this.FindResource("PrimaryButtonToCircleW") as DoubleAnimation).Clone();
            DoubleAnimation primaryButtonToCircleH = (this.FindResource("PrimaryButtonToCircleH") as DoubleAnimation).Clone();



            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(fadeout1);
            storyboard.Children.Add(fadeout2);
            storyboard.Children.Add(primaryButtonToCircleW);
            storyboard.Children.Add(primaryButtonToCircleH);


            Storyboard.SetTarget(fadeout1, cancelButton);
            Storyboard.SetTarget(fadeout2, installButtonText);
            Storyboard.SetTarget(primaryButtonToCircleW, installButton);
            Storyboard.SetTarget(primaryButtonToCircleH, installButton);

            storyboard.Completed += delegate
            {
                InstallingViewAnim();
            };
            storyboard.Begin();
            //MainView.Visibility = System.Windows.Visibility.Visible;

            //DoubleAnimation fadeout = new DoubleAnimation
            //{
            //    From = 1.0,
            //    To = 0.0,
            //    FillBehavior = FillBehavior.Stop,
            //    Duration = new Duration(TimeSpan.FromSeconds(0.5))
            //};
            //Storyboard storyboard = new Storyboard();

            //storyboard.Children.Add(fadeout);
            //Storyboard.SetTarget(fadeout, MainView);
            //Storyboard.SetTargetProperty(fadeout, new PropertyPath(OpacityProperty));
            //storyboard.Completed += delegate { 
            //    MainView.Visibility = System.Windows.Visibility.Hidden;
            //    InstallingView.Visibility = Visibility.Visible;
            //    ((Storyboard)Resources["LoadAnim"]).Begin();
            //};
            //storyboard.Begin();

            //await Task.Delay(5000);
            //InstallingView.Visibility = Visibility.Hidden;
            //InstallDoneView.Visibility = Visibility.Visible;
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
