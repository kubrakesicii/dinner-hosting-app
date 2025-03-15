using KuboDinner.Domain.Menu;
using KuboDinner.Domain.Menu.Entities;
using KuboDinner.Domain.MenuAggregate.Entities;
using Microsoft.EntityFrameworkCore;

namespace KuboDinner.Infrastructure.Persistence.Context
{
    public class KuboDinnerDbContext : DbContext
    {
        public KuboDinnerDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuSection> MenuSections { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
    }
}
