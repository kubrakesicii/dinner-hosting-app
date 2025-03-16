using KuboDinner.Domain.Common.SeedWork;
using KuboDinner.Domain.Guest.ValueObjects;
using KuboDinner.Domain.HostAggregate.ValueObjects;
using KuboDinner.Domain.UserAggregate.ValueObjects;

namespace KuboDinner.Domain.User
{
    public class User : AggregateRoot<UserId, Guid>
    {
        public User(UserId id, HostId hostId, GuestId guestId): base(id)
        {
            Id = UserId.CreateUnique();
            HostId = hostId;
            GuestId = guestId;
        }

        public HostId HostId { get; private set; }
        public GuestId GuestId { get; private set; }
    }
}
