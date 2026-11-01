using System.ComponentModel.DataAnnotations;

namespace PedidoFacil.Application.DTOS.Login
{
    public record RefreshDTO
    (
        [Required(ErrorMessage = "É obrigatório informar o Refresh Token.")]
        string RefreshToken
    );
}
