using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRP
{
    public class UserValidator
    {
        private IUserStore store;

        public UserValidator(IUserStore store)
        {
            this.store = store;
        }

        private string name;

        public void ValidateUser(string name)
        {
            var userExists = this.store.FindUserByName(name) != null;

            if (userExists)
            {
                throw new Exception($"The name {name} is already taken");
            }
        }
    }
}
