using System.Text.Json.Serialization;

namespace PedidoFacil.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatusEntregaWebhook
    {
        [JsonStringEnumMemberName("Pendente")]
        Pendente,

        [JsonStringEnumMemberName("Enviado")]
        Enviado,

        [JsonStringEnumMemberName("Falhou")]
        Falhou
    }
}
