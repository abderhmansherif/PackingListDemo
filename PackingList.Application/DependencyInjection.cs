using Microsoft.Extensions.DependencyInjection;
using PackingList.Application.Abstractions.Commands;
using PackingList.Application.Abstractions.Queries;
using PackingList.Application.Commands;
using PackingList.Application.Queries;
using PackingList.Domain.Factories;
using PackingList.Domain.Policies;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace PackingList.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<IPackingListFactory, PackingListFactory>();

            services.AddScoped<ICommandDispatcher, CommandDispatcher>();

            services.AddScoped<IQueryDispatcher, QueryDispatcher>();

            services.Scan(s => s.FromAssemblies(typeof(IPackingListPolicy).Assembly)
                        .AddClasses(c => c.AssignableTo(typeof(IPackingListPolicy)))
                        .AsImplementedInterfaces()
                        .WithSingletonLifetime());

            services.Scan(s => s.FromAssemblies(typeof(ICommandHandler<>).Assembly)
                        .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
                        .AsImplementedInterfaces()
                        .WithScopedLifetime());

            services.Scan(s => s.FromAssemblies(typeof(IQueryHandler<,>).Assembly)
                        .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
                        .AsImplementedInterfaces()
                        .WithScopedLifetime());

            return services;
        }
    }
}
