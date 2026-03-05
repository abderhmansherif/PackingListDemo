using PackingList.Application.Abstractions.Queries;
using PackingList.Application.DTO;
using PackingList.Application.Exceptions;
using PackingList.Application.Services;
using PackingList.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Application.Queries.Handlers
{
    public class GetPackingListQueryHandler : IQueryHandler<GetPackingListQuery, PackingListDTO>
    {
        private readonly IPackingListRepository _repository;
        private readonly IPackingListReadService _packingListReadService;
        public GetPackingListQueryHandler(IPackingListRepository repository, IPackingListReadService packingListReadService)
        {
            _repository = repository;
            _packingListReadService = packingListReadService;
        }

        public async Task<PackingListDTO> HandleAsync(GetPackingListQuery query)
        {
            var packinglist = await _repository.GetAsync(query.PackingListId);

            if(packinglist is null)
            {
                throw new PackingListNotFoundException(query.PackingListId);
            }

        }
    }
}
