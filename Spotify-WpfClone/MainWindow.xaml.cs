using Spotify_WpfClone.MVVM.ViewModel;
using Spotify_WpfClone.Core;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Spotify_WpfClone
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new MainWindowModelView();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        #region TitleBar Button

        private WindowState MainWindowState = WindowState.Normal;

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Maximize_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindowState == WindowState.Normal)
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }
            else
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }

            MainWindowState = Application.Current.MainWindow.WindowState;
        }

        private void btn_Minimize_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        #endregion

        private void btn_NPVClose_Click(object sender, RoutedEventArgs e)
        {
            cold_NowPlayingView.Width = GridLength.Auto;
            grd_NowPlayingView.Visibility = Visibility.Collapsed;
            grds_NPVSplitter.Visibility = Visibility.Collapsed;     
        }



        private void grd_NowPlayingView_MouseEnter(object sender, MouseEventArgs e)
        {
            ScrollBar myScrollBar = FindChild.FindVisualChild<ScrollBar>(sclv_NPV);

            if (myScrollBar != null)
            {
                myScrollBar.Opacity = 1.0;
            }
        }

        private void grd_NowPlayingView_MouseLeave(object sender, MouseEventArgs e)
        {
            ScrollBar myScrollBar = FindChild.FindVisualChild<ScrollBar>(sclv_NPV);

            if (myScrollBar != null)
            {
                myScrollBar.Opacity = 0.0; 
            }
        }
    }
}
