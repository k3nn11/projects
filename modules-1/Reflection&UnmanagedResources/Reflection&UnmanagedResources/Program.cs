using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection_UnmanagedResources
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string originalFilePath = "original.txt";
            string localFilePath = "local.txt";
            string remoteFilePath = "remote.txt";
            //User user = new User("Ken", "hdwhd9s", "example.gmail.com", 25);
            //{
            //    Name = "jojo",
            //    Age = 12,
            //    Password = "uruf-ds",
            //    Email = "bb@gmail.com"
            //};
            //FileOperation.CreateFile(originalFilePath, user); //TO DO work on this part
            //FileOperation.CreateFile(localFilePath, user);
            DateTime originallastmodified = GetLastModifiedDate(originalFilePath);
            string filepath = FileSynchronization(originalFilePath, localFilePath, remoteFilePath);
            DateTime lastmodified = GetLastModifiedDate(filepath);
            if (DateTime.Compare(lastmodified, originallastmodified) > 0)
            {
                string originalContent = UpdateFiles.ReadFileContent(originalFilePath);
                string localcontent = UpdateFiles.ReadFileContent(filepath);
                UpdateFiles.UpdateFileContent(originalFilePath, originalContent, localcontent);
            }
        }

        public static DateTime GetLastModifiedDate(string filePath)
        {
            DateTime lastmodified = new DateTime();
            if (File.Exists(filePath))
            {
                lastmodified = File.GetLastWriteTime(filePath);
            }

            return lastmodified;
        }

        public static string FileSynchronization(string originalFile, string localFilePath, string remoteFilePath)
        {
            if (!File.Exists(localFilePath) && File.Exists(remoteFilePath))
            {
                return string.Empty;
            }

            DateTime originallastmodified = GetLastModifiedDate(originalFile);
            DateTime locallastmodified = GetLastModifiedDate(localFilePath);
            DateTime remotelastmodified = GetLastModifiedDate(remoteFilePath);
            if ( originallastmodified > locallastmodified && originallastmodified > remotelastmodified)
            {
                Console.WriteLine("The original file was modified most recently. No chnages to the files.");
                return null;
            }

            if ( locallastmodified > remotelastmodified)
            {
                Console.WriteLine("The Local file has been modified more recently than the remote file ");
                Console.WriteLine("Would you like to overwrite the remote file? Y/N");
                while (true)
                {
                    string answer = Console.ReadLine().ToUpper();

                    if (answer != string.Empty )
                    {
                        //answer.ToUpper();
                        if (answer != "Y" && answer != "N")
                        {
                            Console.WriteLine("Enter a valid choice: Y/N");
                            continue;
                        }

                        if (answer == "Y")
                        {
                            File.Copy(localFilePath, remoteFilePath, true);
                            Console.WriteLine("Remote file has been overwritten");
                            return localFilePath;
                        }
                        else
                        {
                            Console.WriteLine("File synchronization cancelled");
                            Console.WriteLine("Both files have been saved");
                            string remotecontents = UpdateFiles.ReadFileContent(remoteFilePath);
                            string localcontents = UpdateFiles.ReadFileContent(localFilePath);
                            UpdateFiles.UpdateFileContent(localFilePath, localcontents, remotecontents);
                            return localFilePath;
                        }
                    }
                }
            }
            else if (locallastmodified < remotelastmodified)
            {
                Console.WriteLine("The remote file has been mofified more recently than the local file ");
                Console.WriteLine("Would you like to overwrite the local file? Y/N");
                while (true)
                {
                    string answer = Console.ReadLine();

                    if (answer != string.Empty)
                    {
                        answer.ToUpper();
                        if (answer != "Y" && answer != "N")
                        {
                            Console.WriteLine("Enter a valid choice");
                            continue;
                        }

                        if (answer == "Y")
                        {
                            File.Copy(localFilePath, remoteFilePath, true);
                            Console.WriteLine("Local file has been overwritten");
                            return localFilePath;
                        }
                        else
                        {
                            Console.WriteLine("File synchronization cancelled");
                            Console.WriteLine("Both files have been saved");
                            string remotecontents = UpdateFiles.ReadFileContent(remoteFilePath);
                            string localcontents = UpdateFiles.ReadFileContent(localFilePath);
                            UpdateFiles.UpdateFileContent(localFilePath, localcontents, remotecontents);
                            return localFilePath;
                        }
                    }
                }
            }
            else
            {
                string remotecontents = UpdateFiles.ReadFileContent(remoteFilePath);
                string localcontents = UpdateFiles.ReadFileContent(localFilePath);
                UpdateFiles.UpdateFileContent(localFilePath, localcontents, remotecontents);
                return localFilePath;
            }
        }
    }
}
