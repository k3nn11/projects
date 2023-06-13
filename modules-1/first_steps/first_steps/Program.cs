using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace first_steps
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstName = "Kennedy Githua";
            string lastName = "Njuguna";
            int age = (DateTime.Now - new DateTime(1997, 10, 24)).Days / 365;
            int daysRemaning = (new DateTime(2023, 6, 10) - DateTime.Now).Days;
            Console.WriteLine("My name is {0} {1}. There are {2} days remaining for me to become a .Net developer.\n I will be {3} years old", firstName, lastName, daysRemaning, age);
            Console.ReadKey();
        }
    }
}
