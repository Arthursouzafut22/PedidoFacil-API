using PedidoFacil.Application.Common.Responses;
using PedidoFacil.Application.DTOS.Categoria;

namespace PedidoFacil.Application.Interfaces
{
    public interface ICategoriaService
    {
        Task<ApiResposta<CategoriaRespostaDTO>> CadastrarCategoria(CriarCategoriaDTO categoria);
        Task<ApiResposta<IEnumerable<CategoriaRespostaDTO>>> BuscarTodasCategoria();
    }
}
