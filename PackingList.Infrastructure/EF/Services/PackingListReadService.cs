using Microsoft.EntityFrameworkCore;
using PackingList.Application.DTO;
using PackingList.Application.Services;
using PackingList.Infrastructure.EF.Contexts;
using PackingList.Infrastructure.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Infrastructure.EF.Services
{
    internal class PackingListReadService : IPackingListReadService
    {
        private readonly DbSet<PackingListReadModel> _packingLists;
        public PackingListReadService(ReadDbContext readDbContext)
            => _packingLists = readDbContext.PackingLists;
        public async Task<bool> ExistsPackingListNameAsync(string PackingListName)
            =>  await _packingLists.AnyAsync(pl => pl.Name == PackingListName);
    
    }
}
