using PackingList.Application.Abstractions.Commands;
using PackingList.Application.Exceptions;
using PackingList.Domain.Repositories;

namespace PackingList.Application.Commands.Handlers
{
    public class PackItemCommandHandler : ICommandHandler<PackItemCommand>
    {
        private readonly IPackingListRepository _repository;
        public PackItemCommandHandler(IPackingListRepository repository)
            => _repository = repository;
        
        public async Task HandleAsync(PackItemCommand command)
        {
            var (packinglistId, ItemName) = command;

            var packinglist = await _repository.GetAsync(packinglistId);

            if(packinglist is null)
            {
                throw new PackingListNotFoundException(packinglistId);
            }

            packinglist.PackItem(ItemName);

            await _repository.UpdateAsync(packinglist);
        }
    }
}
