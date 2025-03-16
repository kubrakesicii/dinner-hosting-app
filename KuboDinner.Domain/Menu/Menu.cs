using KuboDinner.Domain.Dinner.ValueObjects;
using KuboDinner.Domain.HostAggregate.ValueObjects;
using KuboDinner.Domain.Menu.Events;
using KuboDinner.Domain.Menu.ValueObjects;
using KuboDinner.Domain.MenuAggregate.Entities;
using KuboDinner.Domain.MenuReview.ValueObjects;
using KuboDinner.Domain.SeedWork;

namespace KuboDinner.Domain.Menu
{
    public sealed class Menu : AggregateRoot<MenuId, Guid>
    {

        private Menu(MenuId id, string name, string description, AverageRating averageRating, 
            HostId hostId, List<MenuSection> sections) : base(id)
        {
            Sections = _sections.AsReadOnly().ToList();
            DinnerIds = _dinnerIds.AsReadOnly().ToList();
            MenuReviewIds = _menuReviewIds.AsReadOnly().ToList();
            Name = name;
            Description = description;
            AverageRating = averageRating;
            HostId = hostId;
            Sections = sections;
        }

        private Menu() { }

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


        // While creating Menu, sections and items within it will be created //Video-14
        public static Menu Create(HostId hostId,string name, string description, List<MenuSection> sections) 
        { 
            var menu = new Menu(
                MenuId.CreateUnique(), 
                name, description,
                AverageRating.CreateNew(),
                hostId,
                sections ?? new());

            menu.AddDomainEvent(new MenuCreated(menu));
            return menu;
        }

    }
}
