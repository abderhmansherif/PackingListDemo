using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Application.Abstractions.Commands
{
    public interface ICommandDispatcher
    {
        Task DispatchAsync<TCommand> (TCommand command) where TCommand : ICommand;
    }
}
