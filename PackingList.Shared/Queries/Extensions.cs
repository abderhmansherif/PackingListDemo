using Microsoft.Extensions.DependencyInjection;
using PackingList.Application.Abstractions.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Shared.Queries
{
    public static class Extensions
    {
        public static IServiceCollection AddQueries(this IServiceCollection services)
        {
            services.Scan(s => s.FromAssemblies(typeof(IQueryHandler<,>).Assembly)
                    .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());

            return services;
        }
    }
}
