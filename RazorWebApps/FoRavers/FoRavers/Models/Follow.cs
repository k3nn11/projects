namespace FoRavers.Models
{
    public class Follow : EntityBase
    {
        public Guid TargetId { get; set; } = Guid.NewGuid();

        public Guid UserId { get; set; } = Guid.NewGuid();

        public Target Target { get; set; }

        public User User { get; set; } = null!;

        public Promoter Promoter { get; set; } = null!;

        public Venue Venue { get; set; } = null!;
    }
}
