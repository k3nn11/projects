using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveInfo_Prak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var drives = DriveInfo.GetDrives();
            //foreach (var drive in drives)
            //{
            //    Console.WriteLine(drive.Name);
            //    Console.WriteLine(drive.TotalSize);
            //    Console.WriteLine(drive.TotalFreeSpace);
            //    Console.WriteLine(drive.AvailableFreeSpace);
            //    Console.WriteLine(drive.DriveFormat);
            //}
            var  name = "TempDir";
            Directory.CreateDirectory(name);
            Console.WriteLine(Directory.GetFiles(name));

        }
    }
}
