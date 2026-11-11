using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi;

namespace PedidoFacil.Infrastructure.Swagger
{
    public static class DependencyInjectionSwagger
    {
        public static IServiceCollection AddInfrastructureSwagger(this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "PedidoFacil.API",
                    Version = "v1",
                    Description = "API REST para gestão e pedidos de restaurantes."
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Informe apenas o token JWT (o prefixo 'Bearer' é adicionado automaticamente)."
                });

                c.OperationFilter<AuthorizeCheckOperationFilter>();

                c.TagActionsBy(api =>
                {
                    var controller = api.ActionDescriptor.RouteValues["controller"];

                    return controller switch
                    {
                        "Autenticacao" => new[] { "Autenticação" },
                        "Categorias" => new[] { "Categorias" },
                        "Candidacys" => new[] { "Candidaturas" },
                        "Produtos" => new[] { "Produtos" },
                        _ => new[] { controller! }
                    };
                });
            });

            return services;
        }
    }
}
