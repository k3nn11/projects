namespace OCP.Domain
{
    public class User
    {
        public string Role { get; set; }

        public bool IsPremiumUser { get; set; }

        public Subscription Subscription { get; set; }

        public User(string Role, bool IsPremiumUser, Subscription subscription)
        {
            this .Role = Role;
            this .Subscription = subscription;
            this .IsPremiumUser = IsPremiumUser;
        }
}
}
