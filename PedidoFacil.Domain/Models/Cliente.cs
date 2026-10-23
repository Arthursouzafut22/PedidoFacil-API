
namespace PedidoFacil.Domain.Models
{
    public class Cliente
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string SenhaHash { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string? EnderecoPadrao { get; set; }
        public List<Pedido> Pedidos { get; set; } = new();
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
    }
}
