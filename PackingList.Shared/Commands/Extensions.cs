using Microsoft.Extensions.DependencyInjection;
using PackingList.Application.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PackingList.Shared.Commands
{
    public static class Extensions
    {
        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            var assembly = Assembly.GetCallingAssembly();
            services.Scan(s => s.FromAssemblies(assembly)
                    .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());


            return services;
        }
    }
}
