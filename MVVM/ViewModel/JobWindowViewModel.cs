using JobListTracker.Core;
using JobListTracker.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobListTracker.MVVM.ViewModel
{
    internal class JobWindowViewModel : ObservableObject
    {
        private object _currentView;

        public ObservableCollection<JobApplication> JobApps { get; set; }


        private JobListViewModel _listViewModel;
        private AddUserViewModel _addUserViewModel;

        public RelayCommand SwitchAddUserView {  get; set; }

        public object CurrentView
        {
            get { return _currentView; } 
            set { 
                _currentView = value;
                OnPropertyChange();
            }
        }

        public JobWindowViewModel() 
        {
            JobApps = JobApplicationManager.GetJobApps();

            _listViewModel = new JobListViewModel();
            _addUserViewModel = new AddUserViewModel();

            CurrentView = _listViewModel;

            SwitchAddUserView = new RelayCommand(o =>
            {
                Console.WriteLine(_currentView);
                CurrentView = _addUserViewModel;
            });
        } 


    }
}
