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
                    var provider = options.ModelBindingMessageProvider;

                    provider.SetValueMustNotBeNullAccessor(
                        value => "O campo é obrigatório.");

                    provider.SetMissingBindRequiredValueAccessor(
                        fieldName => $"O campo '{fieldName}' é obrigatório.");

                    provider.SetMissingKeyOrValueAccessor(
                        () => "O campo é obrigatório.");

                    provider.SetMissingRequestBodyRequiredValueAccessor(
                        () => "É necessário enviar um corpo de requisição (body) não vazio.");

                    provider.SetAttemptedValueIsInvalidAccessor(
                        (value, fieldName) => $"O valor '{value}' não é válido para o campo '{fieldName}'.");

                    provider.SetUnknownValueIsInvalidAccessor(
                        fieldName => $"O valor informado não é válido para o campo '{fieldName}'.");

                    provider.SetValueIsInvalidAccessor(
                        value => $"O valor '{value}' não é válido.");

                    provider.SetValueMustBeANumberAccessor(
                        fieldName => $"O campo '{fieldName}' deve ser um número.");

                    provider.SetNonPropertyAttemptedValueIsInvalidAccessor(
                        value => $"O valor '{value}' não é válido.");

                    provider.SetNonPropertyUnknownValueIsInvalidAccessor(
                        () => "O valor informado não é válido.");

                    provider.SetNonPropertyValueMustBeANumberAccessor(
                        () => "O valor deve ser um número.");
                });

            return services;
        }
    }
}
