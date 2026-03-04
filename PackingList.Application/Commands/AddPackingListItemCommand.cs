using System;
using System.Collections.Generic;
using System.Text;
using PackingList.Application.Abstractions.Commands;

namespace PackingList.Application.Commands
{
    public record AddPackingListItemCommand(Guid PackingListId, string NItemame, int ItemQuantity) : ICommand;
  
}
