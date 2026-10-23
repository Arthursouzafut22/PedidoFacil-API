using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PedidoFacil.Domain.Models
{

    public class ItemPedido
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid PedidoId { get; set; }

        [ForeignKey(nameof(PedidoId))]
        public Pedido Pedido { get; set; } = null!;
        public Guid ProdutoId { get; set; }

        [ForeignKey(nameof(ProdutoId))]
        public Produto Produto { get; set; } = null!;
        public string? Observacao { get; set; }
        public int Quantidade { get; set; }
        public string NomeProduto { get; set; } = string.Empty;
        public decimal PrecoUnitario { get; set; }
        public decimal SubTotal => Quantidade * PrecoUnitario;
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
    }
}
