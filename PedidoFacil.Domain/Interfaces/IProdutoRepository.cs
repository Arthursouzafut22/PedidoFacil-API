using PedidoFacil.Domain.Models;

namespace PedidoFacil.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> BuscarProdutos();
        Task<Produto?> BuscarProdutoPorId(Guid? id);
        Task<Produto?> Cadastrar(Produto produto);
        Task<Produto?> Atualizar(Produto produto);
        Task Deletar(Produto produto);
    }
}
