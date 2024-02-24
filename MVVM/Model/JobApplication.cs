using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobListTracker.Core;

namespace JobListTracker.MVVM.Model
{
    public class JobApplication : ObservableObject
    {
        private int _jobAppId;
        private string _jobTitle;
        private string _url;
        private string _note;
        private string _cv;
        private string _date = "n/a";

        public int JobAppId { get { return _jobAppId; } set { _jobAppId = value; OnPropertyChange("JobAppId"); } }
        public string JobTitle { get { return _jobTitle; } set { _jobTitle = value; OnPropertyChange("JobTitle"); } }
        public string Url { get { return _url; } set {_url = value; OnPropertyChange("JobAppId"); } }
        public string Note { get { return _note; } set { _note = value; OnPropertyChange("JobAppId"); } }
        public string CV { get { return _cv; } set { _cv = value; OnPropertyChange("JobAppId"); } }   
        public string Date { get { return _date; } set { _date = value; OnPropertyChange("Date"); } }   

    }
}
