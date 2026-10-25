using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PedidoFacil.Application.Interfaces;
using PedidoFacil.Application.Services.Cliente;
using PedidoFacil.Domain.Interfaces;
using PedidoFacil.Infrastructure.Data;
using PedidoFacil.Infrastructure.Repositories;

namespace PedidoFacil.Infrastructure.Settings
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var stringConnection = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(stringConnection);
            });

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteService, ClienteService>();

            return services;
        }
    }
}
