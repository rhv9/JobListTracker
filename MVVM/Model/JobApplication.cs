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

        public int JobAppId { get { return _jobAppId; } set { OnPropertyChange("JobAppId"); _jobAppId = value; } }
        public string JobTitle { get { return _jobTitle; } set { OnPropertyChange("JobTitle"); _jobTitle = value; } }
        public string Url { get { return _url; } set { OnPropertyChange("JobAppId"); _url = value; } }
        public string Note { get { return _note; } set { OnPropertyChange("JobAppId"); _note = value; } }
        public string CV { get { return _cv; } set { OnPropertyChange("JobAppId"); _cv = value; } }   
        public string Date { get { return _date; } set { OnPropertyChange("Date"); _date = value; } }   

    }
}
