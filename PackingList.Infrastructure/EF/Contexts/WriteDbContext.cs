using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using PackingList.Domain.Entities;
using PackingList.Infrastructure.EF.Config;

namespace PackingList.Infrastructure.EF.Contexts
{
    internal class WriteDbContext : DbContext
    {
        public DbSet<Domain.Entities.PackingList> PackingLists { get; set; }


        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var configuration = new WriteConfiguration();
            modelBuilder.ApplyConfiguration<Domain.Entities.PackingList>(configuration);
            modelBuilder.ApplyConfiguration<Domain.ValueObjects.PackingListItem>(configuration);
        }

    }
}
