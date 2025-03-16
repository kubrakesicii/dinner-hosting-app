using KuboDinner.Domain.Bill.ValueObjects;
using KuboDinner.Domain.Common.SeedWork;
using KuboDinner.Domain.Dinner.ValueObjects;
using KuboDinner.Domain.Guest.ValueObjects;
using KuboDinner.Domain.HostAggregate.ValueObjects;

namespace KuboDinner.Domain.Bill
{
    public class Bill : AggregateRoot<BillId, Guid>
    {
        public Bill(BillId id, ValueObjects.Price totalPrice, DinnerId dinnerId, GuestId guestId, HostId hostId) : base(id)
        {
            Id = BillId.CreateUnique();
            TotalPrice = totalPrice;
            DinnerId = dinnerId;
            GuestId = guestId;
            HostId = hostId;
        }

        public ValueObjects.Price TotalPrice { get; private set; }
        public DinnerId DinnerId { get; private set; }
        public GuestId GuestId { get; private set; }
        public HostId HostId { get; private set; }

    }
}
