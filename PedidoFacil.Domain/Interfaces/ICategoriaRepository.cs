using PedidoFacil.Domain.Models;

namespace PedidoFacil.Domain.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> BuscarCategorias();
        Task<Categoria?> BuscarCategoriaPorId(Guid id);
        Task<Categoria?> Cadastrar(Categoria categoria);
        Task<Categoria?> Atualizar(Categoria categoria);
        Task Deletar(Guid id);
        Task<Categoria?> EncontrarCategoriaPorNome(string nome);
        Task<Categoria?> EncontrarCategoriaPorOrdem(int ordem);
    }
}
