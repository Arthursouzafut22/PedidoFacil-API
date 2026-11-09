using PedidoFacil.Domain.Models;

namespace PedidoFacil.Application.Interfaces
{
    public interface ITokenService
    {
        string GerarToken(Usuario usuario);
        string GerarRefreshToken();
    }
}
