using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobListTracker.Core;
using JobListTracker.MVVM.Model;

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
        public RelayCommand ChangeVar { get; set; }

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

                JobApplication newJobApp = new JobApplication() { JobTitle = JobTitle, CV = CV, Url = URL, Note = this.Note };
                Console.WriteLine("Adding new Job: " + newJobApp.JobTitle);
                JobApplicationManager.AddJobApp(newJobApp);
            });

            ChangeVar = new RelayCommand(o =>
            {
                Console.WriteLine("Changing var...");
                CV = "brep.pdf";
            });
        }   

    }
}
