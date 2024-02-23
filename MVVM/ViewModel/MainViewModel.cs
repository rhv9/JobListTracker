using JobListTracker.Core;
using JobListTracker.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JobListTracker.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand JobListViewCommand { get; set; }
        public RelayCommand AddUserViewCommand { get; set; }

        public HomeViewModel HomeVm { get; set; }
        public JobListViewModel JobListVm { get; set; }
        public AddUserViewModel AddUserVm { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set { 
                _currentView = value;
                OnPropertyChange();
            }
        }

        public MainViewModel()
        {
            JobApplicationManager.Init();

            HomeVm = new HomeViewModel();
            JobListVm = new JobListViewModel();
            AddUserVm = new AddUserViewModel();

            CurrentView = HomeVm;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVm;
            });

            JobListViewCommand = new RelayCommand(o =>
            {
                CurrentView = JobListVm;
            });

            AddUserViewCommand = new RelayCommand(o =>
            {
                CurrentView = AddUserVm;
            });
        }
    }
}
