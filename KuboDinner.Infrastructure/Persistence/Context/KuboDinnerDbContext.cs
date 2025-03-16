using KuboDinner.Domain.Common.SeedWork;
using KuboDinner.Domain.Menu;
using KuboDinner.Domain.Menu.Entities;
using KuboDinner.Domain.Menu.ValueObjects;
using KuboDinner.Domain.MenuAggregate.Entities;
using KuboDinner.Infrastructure.Persistence.Configurations;
using KuboDinner.Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KuboDinner.Infrastructure.Persistence.Context
{
    public class KuboDinnerDbContext : DbContext
    {
        private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;
        public KuboDinnerDbContext(DbContextOptions options, PublishDomainEventsInterceptor publishDomainEventsInterceptor) : base(options)
        {
            _publishDomainEventsInterceptor = publishDomainEventsInterceptor;
        }


        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuSection> MenuSections { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Ignore<List<IDomainEvent>>()
                .ApplyConfiguration(new MenuConfiguration());
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(KuboDinnerDbContext).Assembly);

            // Make all primary keys generated once, in a one place
            modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties())
                .Where(p => p.IsPrimaryKey()).ToList()
                .ForEach(p => p.ValueGenerated = ValueGenerated.Never);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_publishDomainEventsInterceptor);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
