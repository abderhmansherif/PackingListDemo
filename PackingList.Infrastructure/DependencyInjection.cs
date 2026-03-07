using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PackingList.Domain.Repositories;
using PackingList.Infrastructure.EF;
using PackingList.Infrastructure.EF.Repositories;
using PackingList.Shared.Queries;

namespace PackingList.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddQueries();
            services.AddDbContext(configuration);


            return services;
        }
    }
}
