using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace PedidoFacil.Infrastructure.Swagger
{
    public class AuthorizeCheckOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var metadata = context.ApiDescription.ActionDescriptor.EndpointMetadata;

            var hasAuthorize = metadata.OfType<AuthorizeAttribute>().Any();
            var allowAnonymous = metadata.OfType<AllowAnonymousAttribute>().Any();

            if (!hasAuthorize || allowAnonymous)
                return;

            operation.Responses ??= new OpenApiResponses();
            operation.Responses.TryAdd("401", new OpenApiResponse { Description = "Não autorizado" });
            operation.Responses.TryAdd("403", new OpenApiResponse { Description = "Acesso negado" });

            operation.Security ??= new List<OpenApiSecurityRequirement>();
            operation.Security.Add(new OpenApiSecurityRequirement
            {
                [new OpenApiSecuritySchemeReference("Bearer", context.Document)] = new List<string>()
            });
        }
    }
}
