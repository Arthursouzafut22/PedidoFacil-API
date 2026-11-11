using Microsoft.EntityFrameworkCore;
using PedidoFacil.Domain.Interfaces;
using PedidoFacil.Domain.Models;
using PedidoFacil.Infrastructure.Data;

namespace PedidoFacil.Infrastructure.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;
        public CategoriaRepository(AppDbContext context) => _context = context;
        public async Task<Categoria?> Atualizar(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria?> BuscarCategoriaPorId(Guid? id)
        {
            return await _context.Categorias.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Categoria>> BuscarCategorias()
        {
            return await _context.Categorias.ToListAsync();
        }

        public async Task<Categoria?> Cadastrar(Categoria categoria)
        {
            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task Deletar(Categoria categoria)
        {
            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task<Categoria?> EncontrarCategoriaPorNome(string nome, Guid? usuarioId)
        {
            return await _context.Categorias.FirstOrDefaultAsync(x =>
                x.Nome.ToLower() == nome.ToLower() &&
                x.UsuarioId == usuarioId
            );
        }

        public async Task<Categoria?> EncontrarCategoriaPorOrdem(int ordem, Guid? usuarioId)
        {
            return await _context.Categorias.FirstOrDefaultAsync(x =>
                x.Ordem == ordem &&
                x.UsuarioId == usuarioId
            );
        }
    }
}
