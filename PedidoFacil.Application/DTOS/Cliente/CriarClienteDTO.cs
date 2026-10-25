using System.ComponentModel.DataAnnotations;

namespace PedidoFacil.Application.DTOS.Cliente
{
    public record CriarClienteDTO(
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        string Nome,

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        string Email,

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres.")]
        string Senha,

        [Required(ErrorMessage = "A confirmação de senha é obrigatória.")]
        string ConfirmarSenha,

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [RegularExpression(@"^\d{10,11}$", ErrorMessage = "Telefone inválido. Use DDD + número (10 ou 11 dígitos).")]
        string Telefone
    );
}
