using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Application.Abstractions.Queries
{
    public interface IQueryDispatcher
    {
        Task<TResult> DispatchAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery where TResult:class; 
    }
}
