
using PackingList.Application.Abstractions.Commands;

namespace PackingList.Application.Commands
{
    public record RemovePackingListItemCommand(Guid PackingListId, string ItemName) : ICommand;
    
}
