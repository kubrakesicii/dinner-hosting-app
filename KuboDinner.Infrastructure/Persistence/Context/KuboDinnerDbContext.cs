using KuboDinner.Domain.Menu;
using KuboDinner.Domain.Menu.Entities;
using KuboDinner.Domain.Menu.ValueObjects;
using KuboDinner.Domain.MenuAggregate.Entities;
using KuboDinner.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<AverageRating>(); // Ensure it's NOT an entity

            modelBuilder.ApplyConfiguration(new MenuConfiguration());
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(KuboDinnerDbContext).Assembly);

            // Make all primary keys generated once, in a one place
            modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties())
                .Where(p => p.IsPrimaryKey()).ToList()
                .ForEach(p => p.ValueGenerated = ValueGenerated.Never);
        }
    }
}
