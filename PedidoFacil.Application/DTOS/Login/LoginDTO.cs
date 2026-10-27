using System.ComponentModel.DataAnnotations;

namespace PedidoFacil.Application.DTOS.Login
{
    public record LoginDTO
    (
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        string Email,

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres.")]
        string Senha
    );
}
