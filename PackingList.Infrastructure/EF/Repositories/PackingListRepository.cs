using Microsoft.EntityFrameworkCore;
using PackingList.Domain.Repositories;
using PackingList.Domain.ValueObjects;
using PackingList.Infrastructure.EF.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Infrastructure.EF.Repositories
{
    internal class PackingListRepository : IPackingListRepository
    {
        private readonly DbSet<Domain.Entities.PackingList> _packingLists;
        private readonly WriteDbContext _writeDbContext;

        public PackingListRepository(WriteDbContext writeDbContext)
        {
            _packingLists = writeDbContext.PackingLists;
            _writeDbContext = writeDbContext;
        }

        public Task<Domain.Entities.PackingList> GetAsync(PackingListId id)
            => _packingLists.Include("_items").SingleOrDefaultAsync(pl => pl.Id == id);

        public async Task InsertAsync(Domain.Entities.PackingList packingList)
        {
            await _packingLists.AddAsync(packingList);
            await _writeDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Domain.Entities.PackingList packingList)
        {
            _packingLists.Update(packingList);
            await _writeDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Domain.Entities.PackingList packingList)
        {
            _packingLists.Remove(packingList);
            await _writeDbContext.SaveChangesAsync();
        }
    }
}
