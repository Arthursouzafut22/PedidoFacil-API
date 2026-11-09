using PedidoFacil.Domain.Models;

namespace PedidoFacil.Domain.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> BuscarCategorias(Guid usuarioId);
        Task<Categoria?> BuscarCategoriaPorId(Guid? id);
        Task<Categoria?> Cadastrar(Categoria categoria);
        Task<Categoria?> Atualizar(Categoria categoria);
        Task Deletar(Categoria categoria);
        Task<Categoria?> EncontrarCategoriaPorNome(string nome, Guid? usuarioId);
        Task<Categoria?> EncontrarCategoriaPorOrdem(int ordem, Guid? usuarioId);
    }
}
