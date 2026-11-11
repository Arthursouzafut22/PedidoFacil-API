using Microsoft.AspNetCore.Http;
using PedidoFacil.Application.Common.Responses;
using PedidoFacil.Application.Interfaces;

namespace PedidoFacil.Application.Services.SupaBase
{
    public class SupaBaseService : ISupaBaseService
    {
        public async Task<ApiResposta<string>> SalvarImagem(IFormFile imagem)
        {
            if (imagem is null)
            {

            }
            return ApiResposta<string>.Ok("", "");
        }
    }
}
