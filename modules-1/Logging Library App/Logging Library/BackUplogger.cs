using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace Logging_Library
{
    public class BackUplogger
    {
        private static string _writeCount;
        private static int _currentWrites = 0;
        private static int _sequenceNumber = 0;
        private static string _logfilename;

        public BackUplogger(string filePath, string writecount)
        {
            _writeCount = writecount;
            _logfilename = filePath;
        }

        public void CreatebackupFile(object obj, BackupEventArgs e)
        {
            if (int.TryParse(_writeCount, out int writeCounter))
            {
                if (Math.Max(writeCounter, _currentWrites) == _currentWrites )
                {
                    Console.WriteLine($"Created a backup file at {e.Backuptime}");
                    RollingInterval();
                    _currentWrites = 0;
                    return;
                }
                else
                {
                    _currentWrites++;
                    return;
                }
            }
        }

        private static void RollingInterval()
        {
            string newFilePath = GenerateFilePath();

            File.Copy( _logfilename, newFilePath, true);
            //File.WriteAllText(newFilePath, string.Empty);
        }

        private static string GenerateFilePath()
        {
            _sequenceNumber++;
            string directory = Path.GetDirectoryName(_logfilename);
            string fileName = Path.GetFileNameWithoutExtension(_logfilename);
            string extension = Path.GetExtension(_logfilename);
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            string filePath = Path.Combine(directory, $"{fileName}_{_sequenceNumber}_{timestamp}{extension}");
            return filePath;
        }
    }
}
