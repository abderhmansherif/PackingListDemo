using Microsoft.Extensions.DependencyInjection;
using PackingList.Application.Abstractions.Queries;
using PackingList.Application.Queries;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PackingList.Shared.Queries
{
    public static class Extensions
    {
        public static IServiceCollection AddQueries(this IServiceCollection services)
        {
            var assembly = Assembly.GetCallingAssembly();
            services.Scan(s => s.FromAssemblies(assembly)
                    .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());

            services.AddScoped<IQueryDispatcher, QueryDispatcher>();

            return services;
        }
    }
}
