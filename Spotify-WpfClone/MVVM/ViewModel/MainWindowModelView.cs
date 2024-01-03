using Spotify_WpfClone.Core;
using Spotify_WpfClone.MVVM.View;
using System;
using System.Windows;
using System.Windows.Input;

namespace Spotify_WpfClone.MVVM.ViewModel
{
    public class MainWindowModelView : ObservableObject
    {
        public HomeViewModel HomeVM { get; set; }
        public SearchViewModel SearchVM { get; set; }

        private WindowState MainWindowState { get; set; }

        public ICommand CloseButtonClick { get; }
        public ICommand MinimizeButtonClick { get; }
        public ICommand MaximizeButtonClick { get; }
        public RelayCommand HomeViewCommand { get; }
        public RelayCommand SearchViewCommand { get; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }


        public MainWindowModelView()
        {
            CloseButtonClick = new RelayCommand(CloseButton);
            MinimizeButtonClick = new RelayCommand(MinimizeButton);
            MaximizeButtonClick = new RelayCommand(MaximizeButton);

            HomeVM = new HomeViewModel();
            SearchVM = new SearchViewModel();
            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });
            SearchViewCommand = new RelayCommand(o =>
            {
                CurrentView = SearchVM;
            });


            MainWindowState = WindowState.Normal;
        }

        #region Buttons

        public void CloseButton(object obj)
        {
            Environment.Exit(0);
        }

        private void MinimizeButton(object obj)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void MaximizeButton(object obj)
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

        #endregion
    }
}