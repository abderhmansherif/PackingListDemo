using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Application.Commands
{
    public record PackItemCommand(Guid PackingListId, string ItemName) : PackingList.Application.Abstractions.Commands.ICommand;
    
}
