using PedidoFacil.Domain.Enums;

namespace PedidoFacil.Domain.Models
{
    public class WebhookEntrega
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Evento { get; set; } = string.Empty;
        public string Payload { get; set; } = string.Empty;
        public StatusEntregaWebhook Status { get; set; } = StatusEntregaWebhook.Pendente;
        public int Tentativas { get; set; }
        public DateTime ProximaTentativaEm { get; set; } = DateTime.UtcNow;
        public int? UltimoStatusHttp { get; set; }
        public string? UltimoErro { get; set; }
        public DateTime CriadaEm { get; set; } = DateTime.UtcNow;
        public DateTime? EnviadaEm { get; set; }
        public Guid AssinaturaId { get; set; }
        public WebhookAssinatura Assinatura { get; set; } = null!;
        public Guid PedidoId { get; set; }
        public Pedido Pedido { get; set; } = null!;
    }
}
