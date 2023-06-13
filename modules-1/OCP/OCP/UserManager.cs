﻿using OCP.Domain;
using System;
using System.Linq;

namespace OCP
{
    public class UserManager
    {
        private readonly IUserStore userStore = new UserStore();

        public User[] GetAdmins() => this.userStore.Users.Where(u => u.Role == Roles.Admin).ToArray();

        public User[] GetPremiumUsers() => this.userStore.Users.Where(u => u.IsPremiumUser && u.Subscription.IsActive).ToArray();

        public User[] GetSimpleUsers() => this.userStore.Users.Where(u => u.Role != Roles.Admin && !u.IsPremiumUser).ToArray();

        public User[] GetSimpleUsersWhosSubscriptionHasExpired()
        {
            return UserFilter.ForUsersWith(this.GetSimpleUsers(), UserFilter.SubscriptionInactive).ToArray();

        }
    }
}
