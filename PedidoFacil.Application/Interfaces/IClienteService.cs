using PedidoFacil.Application.Common.Responses;
using PedidoFacil.Application.DTOS.Cliente;

namespace PedidoFacil.Application.Interfaces
{
    public interface IClienteService
    {
        Task<ApiResposta<ClienteRespostaDTO>> Registrar(CriarClienteDTO dto);
    }
}
