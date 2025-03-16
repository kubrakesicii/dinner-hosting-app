using KuboDinner.Domain.Common.SeedWork;
using KuboDinner.Domain.Dinner.ValueObjects;
using KuboDinner.Domain.HostAggregate.ValueObjects;
using KuboDinner.Domain.Menu.ValueObjects;
using KuboDinner.Domain.UserAggregate.ValueObjects;

namespace KuboDinner.Domain.Host
{
    public sealed class Host : AggregateRoot<HostId, Guid>
    {
        public Host(HostId id, UserId userId, string firstName, string lastName, string profileImage, float averageRating) : base(id)
        {
            UserId = userId;
            DinnerIds = _dinnerIds.AsReadOnly().ToList();
            MenuIds = _menuIds.AsReadOnly().ToList();
            FirstName = firstName;
            LastName = lastName;
            ProfileImage = profileImage;
            AverageRating = averageRating;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string ProfileImage { get; private set; }
        public float AverageRating { get; private set; }
        public IReadOnlyList<DinnerId> DinnerIds { get; private set; }
        private readonly List<DinnerId> _dinnerIds = new();

        public IReadOnlyList<MenuId> MenuIds { get; private set; }
        private readonly List<MenuId> _menuIds = new();

        public UserId UserId { get; private set; }

    }
}
