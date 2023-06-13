using System;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics.Tracing;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Logging;

namespace Logging_Library
{
    public static class Program
    {
        private static readonly IConfiguration Configuration = new ConfigurationBuilder()
           .AddJsonFile("Appsettings.json")
           .Build();

        private static string _MaxWriteCount = Configuration["logging:MaxLogWrites"];
        private static string _logFilePath = Configuration["logging:LogFile"];

        public static async Task Main(string[] args)
        {
            if (string.IsNullOrEmpty(_logFilePath))
            {
                Console.WriteLine("The log file is not provided");
                return;
            }

            var logLevelvalue = GetLogLevel(Configuration["logging:LogLevel"]);

            string getUserinput = await LogUserInput();
            await Console.Out.WriteLineAsync("Your Input mesage is input message: " + getUserinput);
            await LogInformation();
        }

        private static LogLevel GetLogLevel(string level)
        {
            switch (level)
            {
                case "Trace":
                    return LogLevel.Trace;
                case "Debug":
                    return LogLevel.Debug;
                case "Information":
                    return LogLevel.Information;
                case "Warning":
                    return LogLevel.Warning;
                case "Error":
                    return LogLevel.Error;
                case "Critical":
                    return LogLevel.Critical;
            }

            return LogLevel.None;
        }

        private async static Task<string> LogUserInput()
        {
            BackUplogger backUplogger = new BackUplogger(_logFilePath, _MaxWriteCount);
            await Console.Out.WriteLineAsync("Enter User Input: ");
            Log log = new Log();
            log.BackupEvent += backUplogger.CreatebackupFile;
            string userInput = Console.ReadLine();
            userInput.ToCharArray();
            int size = userInput.Length;
            if (!string.IsNullOrEmpty(userInput))
            {
                for (int i = 0; i < size; i++)
                {
                    if (userInput[i] == 'i')
                    {
                        await log.LogAsync("Logged in information", LogLevel.Information, _logFilePath);
                    }

                    if ((userInput[i] == 'w'))
                    {
                        await log.LogAsync("warning in the log", LogLevel.Warning, _logFilePath);
                    }

                    if ((userInput[i] == 'e'))
                    {
                        await log.LogAsync("Logged in an error", LogLevel.Error, _logFilePath);
                    }
                }
            }

            return userInput;
        }

        private async static Task LogInformation()
        {
            Log log = new Log();
            StartLogging();
            await log.LogAsync("The Log has been recorded sucessfully", LogLevel.Information, _logFilePath);
        }

        private static void StartLogging()
        {
            var logtimer = new System.Timers.Timer(1000);
            logtimer.Start();
            logtimer.Stop();
            logtimer.Dispose();
        }
    }
}

