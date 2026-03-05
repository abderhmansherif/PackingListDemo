using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Application.Abstractions.Commands
{
    public interface ICommandHandler<TCommand> where TCommand: ICommand
    {
        Task HandleAsync(TCommand command);
    }
}
