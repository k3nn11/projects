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

        public Follow() { }

        public Follow(Guid userId)
        {
            UserId = userId;
        }

        public void SetTarget(Target target, Guid targetId)
        {
            if(!Enum.TryParse<Target>(target.ToString(), ignoreCase:true, out var parsedTarget))
            {
                throw new ArgumentException($"Invalid target value: {target}");
            }
            Target = parsedTarget;
            TargetId = targetId;
        }

        public bool IsPromoterTarget() => Target == Target.Promoter;

        public bool IsVenueTarget() => Target == Target.Venue;
    }
}
