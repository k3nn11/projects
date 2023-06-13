using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog.Events;

namespace logging
{
    public class Program
    {
        static void Main(string[] args)
        {
            //string name = Console.ReadLine();
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
                .WriteTo.File("error.txt", LogEventLevel.Error)
                .CreateLogger();
            // Log.Information(name);

            //Console.ReadLine();
            try
            {
                Phone phone = new Phone("Samsung", "Galaxy");
                phone.Model = null;
                phone.Model = "Iphone";
                //throw new Exception();
            }
            catch (Exception)
            {

                Log.Fatal("Something went wrong");
            }
        }
    }
}
