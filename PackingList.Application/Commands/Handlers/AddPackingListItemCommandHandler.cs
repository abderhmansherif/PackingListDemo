using PackingList.Application.Abstractions.Commands;
using PackingList.Application.Services;
using PackingList.Domain.Factories;
using PackingList.Domain.Repositories;
using System;
using System.Collections.Generic;
using PackingList.Domain.ValueObjects;
using PackingList.Application.Exceptions;
namespace PackingList.Application.Commands.Handlers
{
    public class AddPackingListItemCommandHandler : ICommandHandler<AddPackingListItemCommand>
    {
        private readonly IPackingListRepository _repository;
        private readonly IPackingListReadService _packingListReadService;

        public AddPackingListItemCommandHandler(IPackingListRepository repository,
                                                IPackingListReadService service)
        {
            _repository = repository;
            _packingListReadService = service;
        }
        public async Task HandleAsync(AddPackingListItemCommand command)
        {
            var (packingListId, ItemName, ItemQuantity) = command;

            var packingList = await _repository.GetAsync(packingListId);

            if(packingList is null)
            {
                throw new PackingListNotFoundException(packingListId);
            }

            packingList.AddItem(new PackingListItem(ItemName, ItemQuantity));

            await _repository.UpdateAsync(packingList);
        }
    }
}
