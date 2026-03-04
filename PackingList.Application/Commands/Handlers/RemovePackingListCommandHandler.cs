using PackingList.Application.Abstractions.Commands;
using PackingList.Application.Exceptions;
using PackingList.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Application.Commands.Handlers
{
    public class RemovePackingListCommandHandler : ICommandHandler<RemovePackingListCommand>
    {
        private readonly IPackingListRepository _repository;

        public RemovePackingListCommandHandler(IPackingListRepository repository)
            => _repository = repository;
        public async Task HandleAsync(RemovePackingListCommand command)
        {
            var packinglist = await _repository.GetAsync(command.PackingListId);

            if(packinglist is null)
            {
                throw new PackingListNotFoundException(command.PackingListId);
            }

            await _repository.DeleteAsync(packinglist);
        }
    }
}
