using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PackingList.Infrastructure.EF.Config;
using PackingList.Infrastructure.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Infrastructure.EF.Contexts
{
    internal class ReadDbContext: DbContext
    {
        public ReadDbContext(DbContextOptions<ReadDbContext> options):base(options)
        {
        }
        public DbSet<PackingListReadModel> PackingLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var configuration = new ReadConfiguration();

            modelBuilder.ApplyConfiguration<PackingListReadModel>(configuration);
            modelBuilder.ApplyConfiguration<PackingListItemReadModel>(configuration);
        }
        
    }
}
