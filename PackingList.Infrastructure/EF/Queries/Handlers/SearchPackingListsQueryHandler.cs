using Microsoft.EntityFrameworkCore;
using PackingList.Application.Abstractions.Queries;
using PackingList.Application.DTO;
using PackingList.Application.Queries;
using PackingList.Infrastructure.EF.Contexts;
using PackingList.Infrastructure.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Infrastructure.EF.Queries.Handlers
{
    internal class SearchPackingListsQueryHandler : IQueryHandler<SearchPackingListsQuery, IEnumerable<PackingListDTO>>
    {
        private readonly DbSet<PackingListReadModel> _packingLists;
        public SearchPackingListsQueryHandler(ReadDbContext readDbContext)
            => _packingLists = readDbContext.PackingLists;
        
        public async Task<IEnumerable<PackingListDTO>> HandleAsync(SearchPackingListsQuery query)
        {
            var packingLists = _packingLists.Include(pl => pl.Items).AsNoTracking().AsQueryable();
            
            if (!string.IsNullOrEmpty(query.searchPhrase))
            {
                packingLists = packingLists.Where(pl => 
                    Microsoft.EntityFrameworkCore.EF.Functions.Like(pl.Name, $"%{query.searchPhrase}%"));
            }

            await packingLists.ToListAsync();

            return packingLists.Select(pl => pl.AsDTO());
        }
    }
}
