using Microsoft.EntityFrameworkCore;
using PedidoFacil.Domain.Interfaces;
using PedidoFacil.Domain.Models;
using PedidoFacil.Infrastructure.Data;

namespace PedidoFacil.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;
        public ClienteRepository(AppDbContext context) => _context = context;

        public async Task<Cliente> Criar(Cliente cliente)
        {
            await _context.AddAsync(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<bool> EmailJaExiste(string email) =>
           await _context.Clientes.AnyAsync(c => c.Email == email);

        public async Task<Cliente?> EncontrarClientePorEmail(string email) =>
            await _context.Clientes.FirstOrDefaultAsync(c => c.Email == email);

    }
}
