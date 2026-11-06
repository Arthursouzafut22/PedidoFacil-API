using System.ComponentModel.DataAnnotations;

namespace PedidoFacil.Application.DTOS.Categoria
{
    public record CriarCategoriaDTO
    (
        [Required(ErrorMessage = "Nome da categoria é obrigátorio.")]
        string Nome,

        [Required(ErrorMessage = "A ordem da categoria é obrigátorio.")]
        int Ordem 
    );
}
