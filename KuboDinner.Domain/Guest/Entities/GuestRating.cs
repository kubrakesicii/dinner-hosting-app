using KuboDinner.Domain.Dinner.ValueObjects;
using KuboDinner.Domain.Guest.ValueObjects;
using KuboDinner.Domain.HostAggregate.ValueObjects;
using KuboDinner.Domain.SeedWork;

namespace KuboDinner.Domain.Guest.Entities
{
    public sealed class GuestRating : Entity<GuestRatingId>
    {
        public DinnerId DinnerId { get; private set; }
        public HostId HostId { get; private set; }

        public GuestRating(GuestRatingId id, DinnerId dinnerId, HostId hostId) : base(id)
        {
            DinnerId = dinnerId;
            HostId = hostId;
        }

        public static GuestRating Create(DinnerId dinnerId, HostId hostId)
        {
            return new GuestRating(GuestRatingId.CreateUnique(), dinnerId, hostId);
        }
    }
}
