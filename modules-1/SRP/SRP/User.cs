using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace SRP
{
    public class User
    {
        private UserValidator validator;

        public User(UserValidator validator)
        {
            this.validator = validator;
        }

        private string _name;
        public string Name
        {
            get
            { return _name; }
            set
            {
                this.validator.ValidateUser(value);
                this._name = value;
            }
        }

        public void SaveToFile(string fileName)
        {
            File.WriteAllText(fileName, JsonConvert.SerializeObject(this));
        }
    }
}
