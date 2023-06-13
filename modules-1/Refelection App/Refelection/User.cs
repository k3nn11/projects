using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refelection
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
    public class AuthorAttribute : Attribute
    {
        [MaxLength(20)]
        public string Name { get; set; }
        public int Age { get; set; }

        public AuthorAttribute(string name, int age)
        {
            Name = name;
            this.Age = age;
        }
     

        public override string ToString()
        {
            return $"Name {Name} and {Age}";
        }
    }
}
