using KuboDinner.Domain.Common.SeedWork;
using KuboDinner.Domain.Dinner.Entities;
using KuboDinner.Domain.Dinner.Enums;
using KuboDinner.Domain.Dinner.ValueObjects;
using KuboDinner.Domain.HostAggregate.ValueObjects;
using KuboDinner.Domain.Menu.ValueObjects;

namespace KuboDinner.Domain.Dinner
{
    public class Dinner : AggregateRoot<DinnerId,Guid>
    {
        public DinnerId Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime StartedDateTime { get; private set; }
        public DateTime EndedDateTime { get; private set; }
        public DateTime StartDateTime { get; private set; }
        public DateTime EndDateTime { get; private set; }
        public DinnerStatus Status { get; private set; }
        public bool IsPublic { get; private set; }
        public int MaxGuests { get; private set; }
        public ValueObjects.Price Price { get; private set; }

        public HostId HostId { get; private set; }
        public MenuId MenuId { get; private set; }
        public string ImageUrl { get; private set; }
        public Location Location { get; private set; }


        private readonly List<Reservation> _reservations = new();
        public IReadOnlyList<Reservation> Reservations { get; }

        private Dinner()
        {
        }
        public Dinner(DinnerId id, string name, string description, DateTime startedDateTime, DateTime endedDateTime,
            DateTime startDateTime, DateTime endDateTime, DinnerStatus status, bool ısPublic, int maxGuests, ValueObjects.Price price,
            HostId hostId, MenuId menuId, string imageUrl, Location location) : base(id)
        {
            Id = DinnerId.CreateUnique();
            Name = name;
            Description = description;
            StartedDateTime = startedDateTime;
            EndedDateTime = endedDateTime;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            Status = status;
            IsPublic = ısPublic;
            MaxGuests = maxGuests;
            Price = price;
            HostId = hostId;
            MenuId = menuId;
            ImageUrl = imageUrl;
            Location = location;

            Reservations = _reservations.AsReadOnly().ToList();
        }


    }
}
