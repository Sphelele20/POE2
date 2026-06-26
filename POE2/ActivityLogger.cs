using System;
using System.IO;

namespace POE2
{
    public class ActivityLogger
    {
        private string logFile = "chatbot_log.txt";

        public void LogActivity(string message)
        {
            try
            {
                string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}\n";
                File.AppendAllText(logFile, logEntry);
            }
            catch (Exception ex)
            {
                // Handle logging errors silently
                Console.WriteLine($"Logging error: {ex.Message}");
            }
        }

        public string GetLogs()
        {
            try
            {
                if (File.Exists(logFile))
                    return File.ReadAllText(logFile);
                return "No logs available.";
            }
            catch
            {
                return "Unable to read logs.";
            }
        }
    }
}