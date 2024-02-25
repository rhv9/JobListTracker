using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace JobListTracker.MVVM.Model
{
    public class JobApplicationManager
    {
        private static int _jobCount=0;
        private static int _lastJobId = -1;
        private readonly static string _dbpath = "jobs.db";

        public static ObservableCollection<JobApplication> _DatabaseJobApp;

        public static ObservableCollection<JobApplication> GetJobApps() { return _DatabaseJobApp; }

        public static void AddJobApp(JobApplication jobApp)
        {
            jobApp.JobAppId = _jobCount++;
            _DatabaseJobApp.Add(jobApp);
        }

        public static void Init()
        {
            _DatabaseJobApp = new ObservableCollection<JobApplication>();
            Console.WriteLine("Loading Job Application SQLite database...");
            

            if (!File.Exists(_dbpath))
            {
                SQLiteConnection.CreateFile(_dbpath);
                using (SQLiteConnection conn = new SQLiteConnection($"Data Source={_dbpath}"))
                {
                    conn.Open();
                    SQLiteCommand command = conn.CreateCommand();
                    command.CommandText =@"
                        CREATE TABLE jobapplications (
                            job_title TEXT NOT NULL,
                            url TEXT,
                            note TEXT,
                            cv TEXT
                        );";
                    command.ExecuteNonQuery();
                }
                return;
            }

            using (SQLiteConnection conn = new SQLiteConnection($"Data Source={_dbpath}"))
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText = "SELECT * FROM jobapplications;";

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string job_title = reader.GetString(0);
                        string url = reader.GetString(1);
                        string note = reader.GetString(2);
                        string cv = reader.GetString(3);

                        JobApplication app = new JobApplication() { JobTitle = job_title, Url = url, Note = note, CV = cv };
                        AddJobApp(app);
                    }
                }

            }

            _lastJobId = _jobCount-1;
        }

        internal static void SaveToSQLite()
        {
            if (_jobCount == 0)
            {
                // there is no job applications to load
                Console.WriteLine("[JobApplicationManager]: Nothing to save to SQLite db.");
                return;
            }

            if (_lastJobId == _jobCount-1)
            {
                // no new jobs added so nothing to save
                Console.WriteLine("[JobApplicationManager]: Nothing to save. No new entries.");
                return;
            }

            string commandText = "INSERT INTO jobapplications(job_title, url, note, cv)\nVALUES";
            int count = 0;

            for(int i = _DatabaseJobApp.Count - 1; i >= 0; i--)
            {
                JobApplication jobApp = _DatabaseJobApp[i];
                if (jobApp.JobAppId <= _lastJobId)
                {
                    break;
                }

                string newValues = $"('{jobApp.JobTitle}', '{jobApp.Url}', '{jobApp.Note}', '{jobApp.CV}'),\n";
                commandText += newValues;
                count++;
            }

            commandText = commandText.Remove(commandText.Length - 2);
            commandText += ";";
            Console.WriteLine("[JobApplicationManager]: Insertion sql command: \n " + commandText);
            
            using (SQLiteConnection conn = new SQLiteConnection($"Data Source={_dbpath}"))
            {
                conn.Open();
                SQLiteCommand command = conn.CreateCommand();
                command.CommandText = commandText;

                int rows = command.ExecuteNonQuery();

                // TODO: Could check if all values get added to database based on reader output
                Console.WriteLine($"[JobApplicationManager]: Expected Job Added: {count}, Reality:{rows}");
            }

        }
    }
}
