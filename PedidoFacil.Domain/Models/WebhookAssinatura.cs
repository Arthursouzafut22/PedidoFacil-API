namespace PedidoFacil.Domain.Models
{
    public class WebhookAssinatura
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Url { get; set; } = string.Empty;
        public string Segredo { get; set; } = string.Empty;
        public string Eventos { get; set; } = string.Empty;
        public bool Ativa { get; set; } = true;
        public DateTime CriadaEm { get; set; } = DateTime.UtcNow;
        public List<WebhookEntrega> Entregas { get; set; } = new();
    }
}
