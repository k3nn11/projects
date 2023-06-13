using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection_UnmanagedResources
{
    public static class UpdateFiles
    {
        public static string ReadFileContent(string filePath)
        {
            string result;
            List<string> concatenated = new List<string>();
            try
        {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line = null;
                    while ((line = sr.ReadLine()) != null)
                    {
                        concatenated.Add(line);
                    }

                    return result = string.Join("\n", concatenated);
                }
            }
             catch (Exception ex)
            {
                Console.WriteLine($"Failed to update new content {ex.Message}");
                return null;
            }
        }

        public static void UpdateFileContent(string filePath, string currentContent, string newContent)
        {
            if (File.Exists(filePath))
            {
                List<string> currentLines = new List<string>(currentContent.Split('\n'));
                List<string> newContentLines = new List<string>(newContent.Split('\n'));

                int currentIndex = 0;
                int newIndex = 0;

                while (currentIndex < currentLines.Count && newIndex < newContentLines.Count)
                {
                    if (currentLines[currentIndex] == newContentLines[newIndex])
                    {
                        currentIndex++;
                        newIndex++;
                    }
                    else
                    {
                        if (currentIndex + 1 < currentLines.Count && currentLines[currentIndex + 1] == newContentLines[newIndex])
                        {
                            currentLines.RemoveAt(currentIndex);
                        }
                        else if (newIndex + 1 < newContentLines.Count && currentLines[currentIndex] == newContentLines[newIndex + 1])
                        {
                            currentLines.Insert(currentIndex, newContentLines[newIndex]);
                            currentIndex++;
                        }
                        else
                        {
                            currentLines[currentIndex] = newContentLines[newIndex];
                            currentIndex++;
                        }

                        newIndex++;
                    }
                }

                while (newIndex < newContentLines.Count)
                {
                    currentLines.Add(newContentLines[newIndex]);
                    newIndex++;
                }

                string updatedContent = string.Join("\n", currentLines);
                using ( StreamWriter writer = new StreamWriter(filePath) )
                {
                    writer.WriteLine(updatedContent);
                }
            }
        }
    }
}
