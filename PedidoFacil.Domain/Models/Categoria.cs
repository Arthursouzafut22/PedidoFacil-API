namespace PedidoFacil.Domain.Models
{
    public class Categoria
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;
        public string Nome { get; set; } = string.Empty;
        public int Ordem { get; set; }
        public List<Produto> Produtos { get; set; } = new();
    }
}
