namespace PedidoFacil.Domain.Models
{
    public class RefreshToken
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ClienteId { get; set; }
        public string Token { get; set; } = string.Empty;
        public DateTime DataExpiracao { get; set; }
        public bool EstaRevogado { get; set; }
        public bool EstaExpirado => DateTime.UtcNow >= DataExpiracao;
        public bool EstaValido => !EstaRevogado && !EstaExpirado;
    }
}
