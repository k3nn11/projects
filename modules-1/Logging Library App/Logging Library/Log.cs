using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging;

namespace Logging_Library
{
    public class Log : BackupEventArgs
    {
        public event BackupEventHandler BackupEvent;

        public async Task LogAsync(string message, LogLevel loglevel, string logFilePath)
        {
            if (loglevel == LogLevel.Error || loglevel == LogLevel.Warning || loglevel == LogLevel.Information)
            {
                string logEntry = $"{DateTime.Now}, {loglevel}, {message}";
                using ( StreamWriter writer = File.AppendText(logFilePath))
                {
                    writer.WriteLine(logEntry);
                }
            }

            OnBackupEvent();
        }

        protected virtual void OnBackupEvent()
        {
            if (BackupEvent != null)
            {
                BackupEvent(this, new BackupEventArgs { Backuptime = DateTime.Now});
            }
        }
    }
}
