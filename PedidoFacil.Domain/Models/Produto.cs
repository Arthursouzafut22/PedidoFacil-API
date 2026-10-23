using System.ComponentModel.DataAnnotations.Schema;

namespace PedidoFacil.Domain.Models
{
    public class Produto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string ImagemUrl { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public bool Disponivel { get; set; } = true;
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public Guid CategoriaId { get; set; }

        [ForeignKey(nameof(CategoriaId))]
        public Categoria Categoria { get; set; } = null!;
    }
}
