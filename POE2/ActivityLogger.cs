using System;
using System.IO;

namespace POE2
{
    public class ActivityLogger
    {
        private string logFilePath = "activity_log.txt";

        public void LogActivity(string activity)
        {
            string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {activity}";
            try
            {
                File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
            }
            catch { }
        }

        public string ReadLog()
        {
            if (File.Exists(logFilePath))
                return File.ReadAllText(logFilePath);
            return "No activity logged yet.";
        }
    }
}