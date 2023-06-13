using OCP.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

// I want 


namespace OCP
{
    public static class UserFilter
    {
        public static bool SubscriptionInactive(User user)
        {
            return !user.Subscription.IsActive;
        }

        public static bool SubscriptionActive(User user)
        {
            return user.Subscription.IsActive;
        }

        public static IEnumerable<User> ForUsersWith(IEnumerable<User> users, Func<User, bool> filter)
        {
            return users.Where(u => filter(u));
        }

        public static IEnumerable<User> ForUsersWithMany(IEnumerable<User> users, Func<User,bool>[] filters)
        {
            return users.Where(u =>
            {
                foreach (var filter in filters) {
                    if (!filter(u)) {
                        return false;
                    }
                }
                return true;
            });
        }
    }
}
