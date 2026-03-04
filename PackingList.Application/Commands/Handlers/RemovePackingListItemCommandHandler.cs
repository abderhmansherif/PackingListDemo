using PackingList.Application.Abstractions.Commands;
using PackingList.Application.Exceptions;
using PackingList.Application.Services;
using PackingList.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Application.Commands.Handlers
{
    public class RemovePackingListItemCommandHandler : ICommandHandler<RemovePackingListItemCommand>
    {
        private readonly IPackingListRepository _repository;
        private readonly IPackingListReadService _packingListReadService;

        public RemovePackingListItemCommandHandler(IPackingListRepository repository, 
                                                   IPackingListReadService packingListReadService)
        {
            _repository = repository;
            _packingListReadService = packingListReadService;
        }
        public async Task HandleAsync(RemovePackingListItemCommand command)
        {
            var (packinglistId, PackingItemName) = command;

            var packinglist = await _repository.GetAsync(packinglistId);

            if(packinglist is null)
            {
                throw new PackingListNotFoundException(packinglistId);
            }

            packinglist.RemoveItem(PackingItemName);

            await _repository.UpdateAsync(packinglist);
        }
    }
}
