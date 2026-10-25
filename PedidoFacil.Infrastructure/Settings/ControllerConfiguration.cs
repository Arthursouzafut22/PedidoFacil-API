using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace PedidoFacil.Infrastructure.Settings
{
    public static class ControllerConfiguration
    {
        public static IServiceCollection AddControllerConfiguration(
        this IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters
                    .Add(new JsonStringEnumConverter());
                })
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = context =>
                    {
                        var error = context.ModelState
                            .Values
                            .SelectMany(v => v.Errors)
                            .Select(e => e.ErrorMessage)
                            .FirstOrDefault();

                        return new BadRequestObjectResult(new
                        {
                            message = error
                        });
                    };
                }).AddMvcOptions(options =>
                {
                    options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
                        value => "O campo é obrigatório.");

                    options.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor(
                        (value, fieldName) => $"O valor '{value}' não é válido para o campo '{fieldName}'.");

                    options.ModelBindingMessageProvider.SetMissingKeyOrValueAccessor(
                        () => "O campo é obrigatório.");

                    options.ModelBindingMessageProvider.SetValueIsInvalidAccessor(
                        value => $"O valor '{value}' não é válido.");

                    options.ModelBindingMessageProvider.SetValueMustBeANumberAccessor(
                        fieldName => $"O campo '{fieldName}' deve ser um número.");

                    options.ModelBindingMessageProvider.SetMissingRequestBodyRequiredValueAccessor(
                        () => "É necessário enviar um corpo de requisição (body) não vazio.");
                });

            return services;
        }
    }
}
