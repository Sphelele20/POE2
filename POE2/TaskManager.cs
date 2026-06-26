using System;
using System.Collections.Generic;

namespace POE2
{
    public class TaskManager
    {
        private List<string> securityTasks;

        public TaskManager()
        {
            securityTasks = new List<string>
            {
                "Task 1: Change your email password if older than 90 days",
                "Task 2: Enable Two-Factor Authentication on important accounts",
                "Task 3: Run a full antivirus scan this week",
                "Task 4: Review app permissions on your phone",
                "Task 5: Backup important files to external drive"
            };
        }

        public string GetAllTasks()
        {
            string result = "Security Reminders:\n\n";
            foreach (string task in securityTasks)
            {
                result += task + "\n\n";
            }
            return result;
        }

        // ADD THIS MISSING METHOD
        public string GetSecurityTask()
        {
            return GetAllTasks();
        }
    }
}