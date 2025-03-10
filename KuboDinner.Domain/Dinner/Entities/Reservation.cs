using KuboDinner.Domain.Bill.ValueObjects;
using KuboDinner.Domain.Dinner.ValueObjects;
using KuboDinner.Domain.Guest.ValueObjects;

namespace KuboDinner.Domain.Dinner.Entities
{
    public class Reservation {

        public ReservationId Id { get; private set; }
        public DinnerId DinnerId { get; private set; }
        public BillId BillId { get; private set; }
        public GuestId GuestId { get; private set; }
      }
}

