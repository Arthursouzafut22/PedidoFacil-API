using PedidoFacil.Application.Common.Responses;
using PedidoFacil.Application.DTOS.Cliente;

namespace PedidoFacil.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<ApiResposta<UsuarioRespostaDTO>> Registrar(CriarUsuarioDTO dto);
    }
}
