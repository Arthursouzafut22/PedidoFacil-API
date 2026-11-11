using Microsoft.AspNetCore.Http;
using PedidoFacil.Application.Common.Responses;
using PedidoFacil.Application.DTOS.Produto;

namespace PedidoFacil.Application.Interfaces
{
    public interface IProdutoService
    {
        Task<ApiResposta<ProdutoRespostaDTO>> CadastrarProduto(
            CadastrarProdutoDTO dto, IFormFile imagemProduto, Guid usuarioId);
    }
}
