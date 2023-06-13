using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging_Library
{
    public static class LogEventLevel
    {
        public static void Information(string templatemessage)
        {
            EventLog.WriteEntry("Application", templatemessage, EventLogEntryType.Information);
            Console.WriteLine("Information logged: " + templatemessage);
        }

        public static void Warning(string templatemessage)
        {
            EventLog.WriteEntry("Application", templatemessage, EventLogEntryType.Warning);
            Console.WriteLine($"Warning logged" + templatemessage);
        }

        public static void Error(string templatemessage)
        {
            EventLog.WriteEntry("Application", templatemessage, EventLogEntryType.Error);
            Console.WriteLine("Error logged" + templatemessage);
        }
    }
}
