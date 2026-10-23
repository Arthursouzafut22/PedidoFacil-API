namespace PedidoFacil.Domain.Models
{
    public class Categoria
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = string.Empty;
        public int Ordem { get; set; }
        public List<Produto> Produtos { get; set; } = new();
    }
}
