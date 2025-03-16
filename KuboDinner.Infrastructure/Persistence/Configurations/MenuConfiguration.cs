using KuboDinner.Domain.HostAggregate.ValueObjects;
using KuboDinner.Domain.Menu;
using KuboDinner.Domain.Menu.Entities;
using KuboDinner.Domain.Menu.ValueObjects;
using KuboDinner.Domain.MenuAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KuboDinner.Infrastructure.Persistence.Configurations
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            ConfigureMenusTable(builder);
            ConfigureMenuSectionsTable(builder);
            ConfigureMenuDinnerIdsTable(builder);
            ConfigureMenuReviewIdsTable(builder);
        }


        public void ConfigureMenusTable(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menus");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => MenuId.CreateUnique())
                .HasMaxLength(50);

            builder.Property(x => x.Name)
                .HasMaxLength(50);
            builder.Property(x => x.Description)
                .HasMaxLength(150);

            builder.Property(x => x.HostId)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => HostId.CreateUnique());

            builder.OwnsOne(x => x.AverageRating); 
        }

        public void ConfigureMenuSectionsTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(x => x.Sections, sb =>  // OwnedNavigationBuilder
            {
                sb.ToTable("MenuSections");
                sb.WithOwner().HasForeignKey("MenuId");
                sb.HasKey(ms => new { ms.Id, ms.MenuId });

                sb.Property(s => s.Id)
                    .ValueGeneratedNever()
                    .HasConversion(
                        secId => secId.Value,
                        value => MenuSectionId.CreateUnique())
                    .HasMaxLength(50);

                sb.Property(x => x.Name).HasMaxLength(50);
                sb.Property(x => x.Description).HasMaxLength(150);

                sb.Property(i => i.MenuId)
                       .HasConversion(
                           mId => mId.Value,
                           value => new MenuId(value));

                sb.OwnsMany(x => x.Items, itemBuilder =>
                {
                    itemBuilder.ToTable("MenuItems");
                    itemBuilder.WithOwner().HasForeignKey(mi => new { mi.MenuSectionId, mi.MenuId });
                    itemBuilder.HasKey(mi => new { mi.Id, mi.MenuSectionId, mi.MenuId });

                    itemBuilder.Property(i => i.Id)
                        .ValueGeneratedNever()
                        .HasConversion(
                            itemId => itemId.Value,
                            value => MenuItemId.CreateUnique())
                        .HasMaxLength(50);
     
                    itemBuilder.Property(i => i.MenuSectionId)
                        .HasConversion(
                            secId => secId.Value,
                            value => new MenuSectionId(value));

                    itemBuilder.Property(i => i.MenuId)
                        .HasConversion(
                            mId => mId.Value,
                            value => new MenuId(value));

                    itemBuilder.Property(x => x.Name).HasMaxLength(50);
                    itemBuilder.Property(x => x.Description).HasMaxLength(150);
                });

                sb.Navigation(s => s.Items)
                   .HasField("_items") 
                   .UsePropertyAccessMode(PropertyAccessMode.Field);
            });

            builder.Metadata.FindNavigation(nameof(Menu.Sections))!.SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        public void ConfigureMenuDinnerIdsTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(x => x.DinnerIds, dinnerIdBuilder =>
            {
                dinnerIdBuilder.ToTable("MenuDinnerIds");
                dinnerIdBuilder.WithOwner().HasForeignKey("MenuId");
                dinnerIdBuilder.HasKey("Id");

                dinnerIdBuilder.Property(d => d.Value)
                    .HasColumnName("DinnerId")
                    .ValueGeneratedNever()
                    .HasMaxLength(50);

            });    
        }

        public void ConfigureMenuReviewIdsTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(x => x.MenuReviewIds, reviewIdBuilder =>
            {
                reviewIdBuilder.ToTable("MenuReviewIds");
                reviewIdBuilder.WithOwner().HasForeignKey("MenuId");
                reviewIdBuilder.HasKey("Id");

                reviewIdBuilder.Property(d => d.Value)
                    .HasColumnName("MenuReviewId")
                    .ValueGeneratedNever()
                    .HasMaxLength(50);

            });

            builder.Metadata.FindNavigation(nameof(Menu.MenuReviewIds))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

    }
}
