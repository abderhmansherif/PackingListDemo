using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PackingList.Infrastructure.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Infrastructure.EF.Config
{
    internal sealed class ReadConfiguration : IEntityTypeConfiguration<PackingListReadModel>, 
                                                IEntityTypeConfiguration<PackingListItemReadModel>
    {
        public void Configure(EntityTypeBuilder<PackingListReadModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("PackingLists", schema: "Packit");

            builder.HasMany(x => x.Items)
                   .WithOne(x => x.PackingListReadModel)
                   .HasForeignKey(x => x.PackingListId);

            builder.Property(x => x.Localization)
                .HasConversion(x => x.ToString(), v => LocalizationReadModel.Create(v))
                .HasColumnName("Localization");
        }

        public void Configure(EntityTypeBuilder<PackingListItemReadModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("PackingListItems", schema: "Packit");
        }
    }
}
