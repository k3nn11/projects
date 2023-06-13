using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Refelection
{
    public class Program
    {
        static void Main(string[] args)
        {
            User user = new User("Kennnedy Githua Njuguna", 25);
            void print(MemberInfo[] members)
            {
                foreach (var member in members)
                {
                    Console.WriteLine(member);
                }
            }
            Type type = typeof(User);
            Console.WriteLine(type.FullName);
            //print(type.GetDefaultMembers());
            //print(type.GetProperties());
            //print(type.GetConstructors());
            //print(type.GetMethods());
            //print(type.GetFields(BindingFlags.NonPublic|BindingFlags.Instance));
            print(type.GetMember("set_Age",MemberTypes.Method,BindingFlags.NonPublic|BindingFlags.Instance));
            var usertype = type.GetProperty("Name");
            var usertypeattr = usertype.GetCustomAttribute<MaxLengthAttribute>();
            // var usertypeattre = usertype.GetCustomAttribute<MaxLengthAttribute>();
            try
            {
                usertypeattr.Validate(user.Name, "Name");
            }
            catch (ValidationException e)
            {

                Console.WriteLine($"Error {e.Message}");
            }
        }
    }   
}
