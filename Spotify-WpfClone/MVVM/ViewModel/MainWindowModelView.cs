using Spotify_WpfClone.Core;
using System;
using System.Windows;
using System.Windows.Input;

namespace Spotify_WpfClone.MVVM.ViewModel
{
    public class MainWindowModelView  
    {
        public WindowState MainWindowState { get; set; }

        public ICommand CloseButtonClick { get; private set; }
        public ICommand MinimizeButtonClick { get; private set; }
        public ICommand MaximizeButtonClick { get; private set; }
        

        public MainWindowModelView()
        {
            CloseButtonClick = new RelayCommand(CloseButton);
            MinimizeButtonClick = new RelayCommand(MinimizeButton);
            MaximizeButtonClick = new RelayCommand(MaximizeButton);

            MainWindowState= WindowState.Normal;
        }

        public void CloseButton()
        {
            Environment.Exit(0);
        }

        private void MinimizeButton()
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void MaximizeButton()
        {
            if(MainWindowState == WindowState.Normal)
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }
            else
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }

            MainWindowState = Application.Current.MainWindow.WindowState;
        }
    }
}