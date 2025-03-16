using KuboDinner.Domain.Common.SeedWork;
using KuboDinner.Domain.Menu.ValueObjects;
using KuboDinner.Domain.MenuAggregate.Entities;

namespace KuboDinner.Domain.Menu.Entities
{
    public class MenuItem : Entity<MenuItemId>
    {
        private MenuItem() { }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public MenuSectionId MenuSectionId { get; private set; }
        public MenuId MenuId { get; private set; } 

        private MenuItem(MenuItemId id,string name, string description) : base(id)
        {
            Name = name;
            Description = description;
        }

        public static MenuItem Create(string name, string description)
        {
            return new(MenuItemId.CreateUnique() ,name, description);
        }
     
    }
}
