using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection_UnmanagedResources
{
    public class User
    {
       private string _name;
       private string _password;
       private string _email;
       private int _age;

       public User(string name, string password, string email, int age)
       {
            _name = name;
            _password = password;
            _email = email;
            _age = age;
       }

       public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                if (value == null)
                {
                    value = $"The value of {nameof(User)} cannot be changed to null";
                }

                _name = value;
            }
        }

       public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                if (value == null)
                {
                    value = $"The value of {nameof(User)} cannot be changed to null";
                }

                _password = value;
            }
        }

       public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                if (!_email.Equals(value))
                {
                    _email = value;
                }
            }
        }

       public int Age
        {
            get
            {
                return _age;
            }

            set
            {
                if (value == null)
                {
                    value = 0;
                }

                _age = value;
            }
        }
    }
}
