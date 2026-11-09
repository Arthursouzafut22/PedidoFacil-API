using Microsoft.EntityFrameworkCore;
using PedidoFacil.Domain.Interfaces;
using PedidoFacil.Domain.Models;
using PedidoFacil.Infrastructure.Data;

namespace PedidoFacil.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;
        public UsuarioRepository(AppDbContext context) => _context = context;

        public async Task<Usuario> Criar(Usuario usuario)
        {
            await _context.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> EmailJaExiste(string email) =>
           await _context.Clientes.AnyAsync(c => c.Email == email);

        public async Task<Usuario?> EncontrarUsuarioPorEmail(string email) =>
            await _context.Clientes.FirstOrDefaultAsync(c => c.Email == email);

        public async Task<Usuario?> EncontrarUsuarioPorId(Guid id) =>
            await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);
    }
}
