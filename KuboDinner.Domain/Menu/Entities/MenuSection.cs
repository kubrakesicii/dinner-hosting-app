using KuboDinner.Domain.Menu.Entities;
using KuboDinner.Domain.Menu.ValueObjects;
using KuboDinner.Domain.SeedWork;

namespace KuboDinner.Domain.MenuAggregate.Entities
{
    public sealed class MenuSection : Entity<MenuSectionId>
    {
        private MenuSection() {
        }

        private readonly List<MenuItem> _items = new();
        public IReadOnlyList<MenuItem> Items { get;}

        public string Name { get; private set; }
        public string Description { get; private set; }
        public MenuId MenuId { get; private set; }


        private MenuSection(MenuSectionId id, string name, string description) : base(id)
        {
            Items = _items;
            Name = name;
            Description = description;
        }

        public static MenuSection Create(string name, string description)
        {
            return new(MenuSectionId.CreateUnique(), name, description);
        }
    }
}
