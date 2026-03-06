using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PackingList.Infrastructure.EF.Contexts;
using PackingList.Infrastructure.EF.Options;
using PackingList.Shared.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace PackingList.Infrastructure.EF
{
    public static class Extensions
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var option = configuration.GetOption<SqlServerConfiguration>("sqlserver");

            services.AddDbContext<ReadDbContext>(ctx => ctx.UseSqlServer(option.ConnectionString));
            services.AddDbContext<WriteDbContext>(ctx => ctx.UseSqlServer(option.ConnectionString));

            return services;
        }
    }
}
