using Microsoft.Extensions.DependencyInjection;
using PackingList.Application.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Shared.Commands
{
    public static class Extensions
    {
        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            services.Scan(s => s.FromAssemblies(typeof(ICommandHandler<>).Assembly)
                    .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());


            return services;
        }
    }
}
