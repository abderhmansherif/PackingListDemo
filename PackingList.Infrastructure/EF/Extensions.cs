using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PackingList.Application.Services;
using PackingList.Domain.Repositories;
using PackingList.Infrastructure.EF.Contexts;
using PackingList.Infrastructure.EF.Models;
using PackingList.Infrastructure.EF.Options;
using PackingList.Infrastructure.EF.Repositories;
using PackingList.Infrastructure.EF.Services;
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

            services.AddDbContext<ReadDbContext>(ctx => ctx.UseNpgsql(option.ConnectionString));
            services.AddDbContext<WriteDbContext>(ctx => ctx.UseNpgsql(option.ConnectionString));

            services.AddScoped<IPackingListRepository, PackingListRepository>();
            services.AddScoped<IPackingListReadService, PackingListReadService>();
            services.AddScoped<IWeatherService, DumbWeatherService>();



            return services;
        }
    }
}
