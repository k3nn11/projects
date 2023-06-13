using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Logging_Library
{
    public class LogManager
    {
        public static async Task WriteToFile(string logFilePath, string message)
        {
            using ( StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                await writer.WriteLineAsync($"{DateTime.Now} {message}");
            }
        }
    }
}
