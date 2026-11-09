using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PedidoFacil.Application.Interfaces;
using PedidoFacil.Application.Services.Categoria;
using PedidoFacil.Application.Services.Cliente;
using PedidoFacil.Application.Services.Login;
using PedidoFacil.Application.Services.Token;
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

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ICategoriaService, CategoriaService>();

            return services;
        }
    }
}
