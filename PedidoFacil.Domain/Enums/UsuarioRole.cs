using System.Text.Json.Serialization;

namespace PedidoFacil.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UsuarioRole
    {
        [JsonStringEnumMemberName("Administrador")]
        Administrador,

        [JsonStringEnumMemberName("Cliente")]
        Cliente
    }
}
