using PedidoFacil.Domain.Models;

namespace PedidoFacil.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> Criar(Usuario cliente);
        Task<bool> EmailJaExiste(string email);
        Task<Usuario?> EncontrarUsuarioPorEmail(string email);
        Task<Usuario?> EncontrarUsuarioPorId(Guid id);
    }
}
