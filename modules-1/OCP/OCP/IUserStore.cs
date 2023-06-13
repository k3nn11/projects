using OCP.Domain;
using System.Collections.Generic;

namespace OCP
{
    public interface IUserStore
    {
        IEnumerable<User> Users { get; }
    }

    public class UserStore : IUserStore
    {
        public IEnumerable<User> Users { get; } = new List<User>();
    //    {
    //        new User ( Roles.Admin, false, new Subscription()),
    //        new User ( Roles.Normal, false, new Subscription()),
    //        new User ( Roles.Normal, true, new Subscription() ),
    //        new User ( Roles.Admin, true, new Subscription()),
    //    };
    }
}
