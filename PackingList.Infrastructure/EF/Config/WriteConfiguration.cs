using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PackingList.Domain.ValueObjects;
using PackingList.Infrastructure.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Infrastructure.EF.Config
{
    internal sealed class WriteConfiguration : IEntityTypeConfiguration<Domain.Entities.PackingList>, IEntityTypeConfiguration<PackingListItem>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.PackingList> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasConversion(x => x.Value, v => new Domain.ValueObjects.PackingListId(v));

            var localizationComverter = new ValueConverter<PackingListLocalization, string>
                (l => l.ToString(), v => PackingListLocalization.Create(v));

            var nameConverter = new ValueConverter<PackingListName, string>(x => x.Value, v => new PackingListName(v));

            builder.Property(typeof(PackingListName), "_name")
                    .HasConversion(nameConverter)
                    .HasColumnName("Name");


            builder.Property(typeof(PackingListLocalization), "_localization")
                    .HasConversion(localizationComverter)
                    .HasColumnName("Localization");


            builder.HasMany(typeof(PackingListItem), "_items")
                    .WithOne(); 

            builder.ToTable("PackingLists", "Packit");
        }

        public void Configure(EntityTypeBuilder<PackingListItem> builder)
        {
            builder.Property<Guid>("Id");
            builder.HasKey("Id");          
            builder.Property(x => x.Name);
            builder.Property(x => x.Quantity);
            builder.Property(x => x.IsPacked);

        }
    }
}
