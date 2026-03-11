using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PackingList.Domain.ValueObjects;

namespace PackingList.Infrastructure.EF.Config
{
    internal sealed class WriteConfiguration : IEntityTypeConfiguration<Domain.Entities.PackingList>, IEntityTypeConfiguration<PackingListItem>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.PackingList> builder)
        {
            builder.HasKey(pl => pl.Id);

            var localizationConverter = new ValueConverter<PackingListLocalization, string>(l => l.ToString(),
                l => PackingListLocalization.Create(l));

            var packingListNameConverter = new ValueConverter<PackingListName, string>(pln => pln.Value,
                pln => new PackingListName(pln));

            builder
                .Property(pl => pl.Id)
                .HasConversion(id => id.Value, id => new PackingListId(id));

            builder
                .Property(typeof(PackingListLocalization), "_localization")
                .HasConversion(localizationConverter)
                .HasColumnName("Localization");

            builder
                .Property(typeof(PackingListName), "_name")
                .HasConversion(packingListNameConverter)
                .HasColumnName("Name");

            builder.HasMany(typeof(PackingListItem), "_items");

            builder.ToTable("PackingLists", "packit");
        }

        public void Configure(EntityTypeBuilder<PackingListItem> builder)
        {
            builder.Property<Guid>("Id");
            builder.Property(pi => pi.Name);
            builder.Property(pi => pi.Quantity);
            builder.Property(pi => pi.IsPacked);
            builder.ToTable("PackingItems", "packit");
        }
    }
}
