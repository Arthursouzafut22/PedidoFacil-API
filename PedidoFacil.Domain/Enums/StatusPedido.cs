using System.Text.Json.Serialization;

namespace PedidoFacil.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatusPedido
    {
        [JsonStringEnumMemberName("Pendente")]
        Pendente,

        [JsonStringEnumMemberName("Em Preparo")]
        EmPreparo,

        [JsonStringEnumMemberName("Saiu Para Entrega")]
        SaiuParaEntrega,

        [JsonStringEnumMemberName("Entregue")]
        Entregue,

        [JsonStringEnumMemberName("Recusado")]
        Recusado,

        [JsonStringEnumMemberName("Cancelado")]
        Cancelado
    }
}
