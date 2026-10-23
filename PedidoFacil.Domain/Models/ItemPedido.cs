namespace PedidoFacil.Domain.Models
{
    public class ItemPedido
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid PedidoId { get; set; }
        public Pedido Pedido { get; set; } = null!;
        public Guid ProdutoId { get; set; }
        public Produto Produto { get; set; } = null!;
        public string? Observacao { get; set; }
        public int Quantidade { get; set; }
        public string NomeProduto { get; set; } = string.Empty;
        public decimal PrecoUnitario { get; set; }
        public decimal SubTotal => Quantidade * PrecoUnitario;
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
    }
}
