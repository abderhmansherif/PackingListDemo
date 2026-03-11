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
    public class GetPackingListQueryHandler : IQueryHandler<GetPackingListQuery, PackingListDTO>
    {
        private readonly DbSet<PackingListReadModel> _packingLists;
        public GetPackingListQueryHandler(ReadDbContext readDbContext)
            => _packingLists = readDbContext.PackingLists;

        public async Task<PackingListDTO> HandleAsync(GetPackingListQuery query)
            => _packingLists.Include(pl => pl.Items)
                            .Where(pl => pl.Id == query.PackingListId)
                            .AsNoTracking()
                            .Select(pl => pl.AsDTO())
                            .SingleOrDefault()!;  
    }
}
