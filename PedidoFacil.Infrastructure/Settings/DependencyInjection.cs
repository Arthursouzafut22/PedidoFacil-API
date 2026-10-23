using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PedidoFacil.Infrastructure.Data;

namespace PedidoFacil.Infrastructure.Settings
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var stringConnection = configuration.GetConnectionString("StringConnection");

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(stringConnection);
            });

            return services;
        }
    }
}
