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
    internal class JobListViewModel
    {

        public ObservableCollection<JobApplication> JobApps { get; set; }   
        public JobListViewModel()
        {
            JobApps = JobApplicationManager.GetJobApps();
        }

    }
}
