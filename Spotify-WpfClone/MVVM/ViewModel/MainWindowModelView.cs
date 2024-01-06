using Spotify_WpfClone.Core;
using Spotify_WpfClone.MVVM.View;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Spotify_WpfClone.MVVM.ViewModel
{
    public class MainWindowModelView : ObservableObject
    {

        public HomeViewModel HomeVM { get; set; }
        public SearchViewModel SearchVM { get; set; }

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
        }
    }
}