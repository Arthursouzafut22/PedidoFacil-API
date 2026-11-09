using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Text.Json;

namespace PedidoFacil.Infrastructure.Settings
{
    public static class DependencyInjectionJWT
    {
        public static IServiceCollection AddInfrastructureJWT(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var secretKey = configuration.GetValue<string>("JwtSettings:SecretKey")
                ?? throw new InvalidOperationException("SecretKey não configurada.");

            JwtSecurityTokenHandler.DefaultMapInboundClaims = true;

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(secretKey)),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnChallenge = context =>
                        {
                            context.HandleResponse();

                            var mensagem = context.AuthenticateFailure switch
                            {
                                SecurityTokenExpiredException => "Token expirado. Faça login novamente.",
                                null => "Acesso negado! Token não informado.",
                                _ => "Token inválido."
                            };

                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            context.Response.ContentType = "application/json";

                            var resposta = JsonSerializer.Serialize(new
                            {
                                status = 401,
                                message = mensagem
                            });

                            return context.Response.WriteAsync(resposta);
                        },

                        OnForbidden = context =>
                        {
                            context.Response.StatusCode = StatusCodes.Status403Forbidden;
                            context.Response.ContentType = "application/json";

                            var resposta = JsonSerializer.Serialize(new
                            {
                                status = 403,
                                message = "Você não tem permissão para acessar este recurso."
                            });

                            return context.Response.WriteAsync(resposta);
                        }
                    };
                });

            return services;
        }
    }
}