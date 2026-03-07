using Microsoft.Extensions.DependencyInjection;
using PackingList.Application.Abstractions.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Application.Queries
{
    public sealed class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider)
            => _serviceProvider = serviceProvider;

        public async Task<TResult> DispatchAsync<TQuery, TResult>(TQuery query) 
            where TQuery : IQuery where TResult : class
        {
            using var scope = _serviceProvider.CreateScope();

            var handler = scope.ServiceProvider.GetRequiredService<IQueryHandler<TQuery, TResult>>();

            return await handler.HandleAsync(query);
        }
    }
}
