using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobListTracker.MVVM.Model
{
    public class JobApplicationManager
    {
        public static ObservableCollection<JobApplication> _DatabaseJobApp;

        public static ObservableCollection<JobApplication> GetJobApps() { return _DatabaseJobApp; }

        public static void AddJobApp(JobApplication jobApp)
        {
            _DatabaseJobApp.Add(jobApp);
        }

        public static void Init()
        {
            _DatabaseJobApp = new ObservableCollection<JobApplication>()
            {
                new JobApplication() {JobAppId = 0, Url = "https://www.google1.com", Note="Hardest job to get into", CV="bestone.pdf"},
                new JobApplication() {JobAppId = 1, Url = "https://www.google2.com", Note="this is a note for 1", CV="bestone.pdf"},
                new JobApplication() {JobAppId = 2, Url = "https://www.google3.com", Note="this is a note for 2", CV="rahulcv.pdf"},
                new JobApplication() {JobAppId = 3, Url = "https://www.google4.com", Note="this is a note for 3", CV="slic-template.pdf"},
            };
        }
    }
}
