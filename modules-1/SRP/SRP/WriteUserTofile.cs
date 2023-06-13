using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace SRP
{
    public class  WriteUserToFile
    {
        public void SaveToFile(User user,string fileName)
        {
            File.WriteAllText(fileName, JsonConvert.SerializeObject(user));
        }
    }
    
}
