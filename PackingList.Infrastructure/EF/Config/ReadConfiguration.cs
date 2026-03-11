using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PackingList.Infrastructure.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Infrastructure.EF.Config
{
    internal sealed class ReadConfiguration : IEntityTypeConfiguration<PackingListReadModel>, IEntityTypeConfiguration<PackingListItemReadModel>
    {
        public void Configure(EntityTypeBuilder<PackingListReadModel> builder)
        {
            builder.ToTable("PackingLists", "packit");
            builder.HasKey(pl => pl.Id);

            builder
                .Property(pl => pl.Localization)
                .HasConversion(l => l.ToString(), l => LocalizationReadModel.Create(l));

            builder
                .HasMany(pl => pl.Items)
                .WithOne(pi => pi.PackingListReadModel);
        }

        public void Configure(EntityTypeBuilder<PackingListItemReadModel> builder)
        {
            builder.ToTable("PackingItems", "packit");
        }
    }
}
