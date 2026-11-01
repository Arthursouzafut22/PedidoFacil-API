using Microsoft.EntityFrameworkCore;
using PedidoFacil.Domain.Interfaces;
using PedidoFacil.Domain.Models;
using PedidoFacil.Infrastructure.Data;

namespace PedidoFacil.Infrastructure.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly AppDbContext _context;
        public RefreshTokenRepository(AppDbContext context) => _context = context;

        public async Task Adicionar(RefreshToken refreshToken)
        {
            await _context.RefreshToken.AddAsync(refreshToken);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(RefreshToken refreshToken)
        {
            _context.RefreshToken.Update(refreshToken);
            await _context.SaveChangesAsync();
        }

        public async Task<RefreshToken?> ObterPorTokenAsync(string token)
        {
            return await _context.RefreshToken.FirstOrDefaultAsync(x => x.Token == token);
        }
    }
}
