using Microsoft.AspNetCore.Http;
using PedidoFacil.Application.Common.Responses;

namespace PedidoFacil.Application.Interfaces
{
    public interface ISupaBaseService
    {
        Task<ApiResposta<string>> SalvarImagem(IFormFile imagem);
    }
}
