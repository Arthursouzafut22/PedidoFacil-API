using PedidoFacil.Application.Common.Responses;
using PedidoFacil.Application.DTOS.Categoria;

namespace PedidoFacil.Application.Interfaces
{
    public interface ICategoriaService
    {
        Task<ApiResposta<CategoriaRespostaDTO>> CadastrarCategoria(CriarCategoriaDTO categoria, Guid usuarioId);
        Task<ApiResposta<IEnumerable<CategoriaRespostaDTO>>> BuscarTodasCategoria(Guid usuarioId);
        Task<ApiResposta<CategoriaRespostaDTO>> BuscarCategoriaPorId(Guid? id, Guid? usuarioId);
        Task<ApiResposta<CategoriaRespostaDTO>> AtualizarCategoria(AtualizarCategoriaDTO dto, Guid? id, Guid? usuarioId);
        Task<ApiResposta<CategoriaRespostaDTO>> DeletarCategoria(Guid? id, Guid? usuarioId);
    }
}

