using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Application.Abstractions.Queries
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery where TResult : class
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}
