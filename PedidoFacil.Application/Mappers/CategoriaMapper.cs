using PedidoFacil.Application.DTOS.Categoria;
using PedidoFacil.Domain.Models;

namespace PedidoFacil.Application.Mappers
{
    public class CategoriaMapper
    {
        public static Categoria ModeloCategoria(CriarCategoriaDTO dto)
        {
            return new Categoria
            {
                Nome = dto.Nome,
                Ordem = dto.Ordem
            };
        }

        public static CategoriaRespostaDTO MapearParaCategoriaRespostaDTO(Categoria categoria)
        {
            return new CategoriaRespostaDTO
             (
                categoria.Id,
                categoria.Nome,
                categoria.Ordem
             );
        }
    }
}
