using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobListTracker.Core;
using JobListTracker.MVVM.Model;
using System.Data.SQLite;

namespace JobListTracker.MVVM.ViewModel
{
    internal class AddUserViewModel : ObservableObject
    {
        private string _jobTitle, _url, _cv, _note;

        public string JobTitle { get { return _jobTitle; } set { _jobTitle = value; OnPropertyChange(nameof(JobTitle)); } }  
        public string URL { get { return _url; } set { _url = value; OnPropertyChange(nameof(URL)); } } 
        public string CV { get { return _cv; } set { _cv = value; OnPropertyChange(nameof(CV)); } }
        public string Note { get { return _note; } set { _note = value; OnPropertyChange(nameof(Note)); } }  

        public RelayCommand AddJob { get; set; }
        public RelayCommand SqlTest { get; set; }

        public AddUserViewModel() 
        {
            AddJob = new RelayCommand(o =>
            {
                if (JobTitle == null || CV == null || URL == null)
                {
                    Console.Error.WriteLine("Error: Adding job with empty properties: " );
                    Console.Error.WriteLine("JobTitle: " + JobTitle + " | URL: " + URL + " | Note: " + Note + " | CV: " + CV);
                    return;
                }
                Note = Note == null ? string.Empty : Note.Trim();

                DateTime date = DateTime.Now;
                string sqlFormattedDate = date.ToString("yyyy-MM-dd HH:mm:ss.fff");

                JobApplication newJobApp = new JobApplication() { JobTitle = JobTitle, CV = CV, Url = URL, Note = this.Note, Date=sqlFormattedDate };
                Console.WriteLine("Adding new Job: " + newJobApp.JobTitle);
                JobApplicationManager.AddJobApp(newJobApp);
            });

        }   

    }
}
