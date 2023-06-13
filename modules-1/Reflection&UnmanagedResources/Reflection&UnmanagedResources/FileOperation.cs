using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection_UnmanagedResources
{
    public static class FileOperation
    {
        // Used this for populating the text files to test the code.

        public static void CreateFile(string fileName, User user)
        {
            string filepath = Path.Combine(Environment.CurrentDirectory, fileName);
            using ( StreamWriter writer = new StreamWriter(filepath))
            {
                writer.WriteLine(user.Name);
                writer.WriteLine(user.Age);
                writer.WriteLine(user.Password);
                writer.WriteLine(user.Email);
                writer.Flush();
            }
        }

        //public static void DeleteFile(string fileName)
        //{
        //    using ( StreamReader reader = new StreamReader(fileName))
        //    {
        //        string line;
        //        while (( line = reader.ReadLine()) != null )
        //        {
        //            line = line.Remove(0, line.Length);
        //            File.Delete(fileName);
        //            Console.WriteLine(line);
        //        }
        //    }
        //}
    }
}
