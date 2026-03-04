using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Application.Commands
{
    public record RemovePackingListCommand(Guid PackingListId): Abstractions.Commands.ICommand;

}
