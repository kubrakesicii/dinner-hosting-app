using KuboDinner.Domain.Dinner.ValueObjects;
using KuboDinner.Domain.HostAggregate.ValueObjects;
using KuboDinner.Domain.MenuAggregate.Entities;
using KuboDinner.Domain.MenuAggregate.ValueObjects;
using KuboDinner.Domain.SeedWork;

namespace KuboDinner.Domain.Menu
{
    public sealed class Menu : AggregateRoot<MenuId>
    {

        public Menu(MenuId id, string name, string description, float averageRating, 
            HostId hostId) : base(id)
        {
            Sections = _sections.AsReadOnly().ToList();
            DinnerIds = _dinnerIds.AsReadOnly().ToList();
            MenuReviewIds = _menuReviewIds.AsReadOnly().ToList();
            Name = name;
            Description = description;
            AverageRating = averageRating;
            HostId = hostId;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public float AverageRating { get; private set; }
        public HostId HostId { get; private set; }

        private readonly List<MenuSection> _sections = new();
        private readonly List<DinnerId> _dinnerIds = new();
        private readonly List<MenuReview.MenuReview> _menuReviewIds = new();

        public IReadOnlyList<MenuSection> Sections { get; private set; }
        public IReadOnlyList<DinnerId> DinnerIds { get; private set; }
        public IReadOnlyList<MenuReview.MenuReview> MenuReviewIds { get; private set; }

        public static Menu Create(string name, string description, float averageRating, 
            HostId hostId)
        { 
            return new(MenuId.CreateUnique(), name, description, averageRating, hostId);
        }

    }
}
