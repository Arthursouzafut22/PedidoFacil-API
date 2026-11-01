using PedidoFacil.Domain.Models;

namespace PedidoFacil.Domain.Interfaces
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken?> ObterPorTokenAsync(string token);
        Task Adicionar(RefreshToken refreshToken);
        Task Atualizar(RefreshToken refreshToken);
    }
}
