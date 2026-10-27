using PedidoFacil.Application.Common.Responses;
using PedidoFacil.Application.DTOS.Login;

namespace PedidoFacil.Application.Interfaces
{
    public interface ILoginService
    {
        Task<ApiResposta<LoginRespostaDTO>> Login(LoginDTO dto);
    }
}
