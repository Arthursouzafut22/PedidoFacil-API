using PedidoFacil.Domain.Interfaces;
using PedidoFacil.Domain.Models;

namespace PedidoFacil.Infrastructure.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        public Task<Produto?> Atualizar(Produto produto)
        {
            throw new NotImplementedException();
        }

        public Task<Produto?> BuscarProdutoPorId(Guid? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Produto>> BuscarProdutos()
        {
            throw new NotImplementedException();
        }

        public Task<Produto?> Cadastrar(Produto produto)
        {
            throw new NotImplementedException();
        }

        public Task Deletar(Produto produto)
        {
            throw new NotImplementedException();
        }
    }
}
