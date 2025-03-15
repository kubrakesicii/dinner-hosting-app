using KuboDinner.Domain.Dinner.ValueObjects;
using KuboDinner.Domain.HostAggregate.ValueObjects;
using KuboDinner.Domain.Menu.ValueObjects;
using KuboDinner.Domain.MenuAggregate.Entities;
using KuboDinner.Domain.MenuAggregate.ValueObjects;
using KuboDinner.Domain.MenuReview.ValueObjects;
using KuboDinner.Domain.SeedWork;

namespace KuboDinner.Domain.Menu
{
    public sealed class Menu : AggregateRoot<MenuId>
    {

        public Menu(MenuId id, string name, string description, AverageRating averageRating, 
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
        public AverageRating AverageRating { get; private set; }
        public HostId HostId { get; private set; }

        private readonly List<MenuSection> _sections = new();
        private readonly List<DinnerId> _dinnerIds = new();
        private readonly List<MenuReviewId> _menuReviewIds = new();

        public IReadOnlyList<MenuSection> Sections { get; private set; }
        public IReadOnlyList<DinnerId> DinnerIds { get; private set; }
        public IReadOnlyList<MenuReviewId> MenuReviewIds { get; private set; }

        public static Menu Create(string name, string description, AverageRating averageRating, 
            HostId hostId)
        { 
            return new(MenuId.CreateUnique(), name, description, averageRating, hostId);
        }

    }
}
