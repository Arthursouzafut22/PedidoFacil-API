using PedidoFacil.Domain.Models;

namespace PedidoFacil.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente> Criar(Cliente cliente);
        Task<bool> EmailJaExiste(string email);
        Task<Cliente?> EncontrarClientePorEmail(string email);
    }
}
