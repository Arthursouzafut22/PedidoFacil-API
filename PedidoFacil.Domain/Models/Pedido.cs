using PedidoFacil.Domain.Enums;
using PedidoFacil.Domain.Exceptions;

namespace PedidoFacil.Domain.Models
{
    public class Pedido
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;
        public StatusPedido Status { get; private set; } = StatusPedido.Pendente;
        public decimal ValorTotal { get; private set; }
        public string Endereco { get; set; } = string.Empty;
        public List<ItemPedido> Itens { get; set; } = new();
        public List<WebhookEntrega> WebhookEntregas { get; set; } = new();
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public DateTime AtualizadoEm { get; private set; } = DateTime.UtcNow;

        public void AdicionarItem(Produto produto, int quantidade, string? observacao = null)
        {
            if (Status != StatusPedido.Pendente)
                throw new DomainException("Só é possível adicionar itens a pedidos pendentes.");
            if (quantidade <= 0)
                throw new DomainException("A quantidade deve ser maior que zero.");
            if (!produto.Disponivel)
                throw new DomainException($"O produto '{produto.Nome}' está indisponível.");

            Itens.Add(new ItemPedido
            {
                ProdutoId = produto.Id,
                NomeProduto = produto.Nome,       
                PrecoUnitario = produto.Preco,    
                Quantidade = quantidade,
                Observacao = observacao
            });

            ValorTotal = Itens.Sum(i => i.SubTotal);
        }

        public void Aceitar()
        {
            if (Status != StatusPedido.Pendente)
                throw new DomainException("Só é possível aceitar pedidos pendentes.");
            MudarStatus(StatusPedido.EmPreparo);
        }

        public void Recusar()
        {
            if (Status != StatusPedido.Pendente)
                throw new DomainException("Só é possível recusar pedidos pendentes.");
            MudarStatus(StatusPedido.Recusado);
        }

        public void SairParaEntrega()
        {
            if (Status != StatusPedido.EmPreparo)
                throw new DomainException("O pedido precisa estar em preparo.");
            MudarStatus(StatusPedido.SaiuParaEntrega);
        }

        public void Entregar()
        {
            if (Status != StatusPedido.SaiuParaEntrega)
                throw new DomainException("O pedido precisa ter saído para entrega.");
            MudarStatus(StatusPedido.Entregue);
        }

        public void Cancelar()
        {
            if (Status != StatusPedido.Pendente)
                throw new DomainException("Só é possível cancelar pedidos que ainda não foram aceitos.");
            MudarStatus(StatusPedido.Cancelado);
        }

        private void MudarStatus(StatusPedido novo)
        {
            Status = novo;
            AtualizadoEm = DateTime.UtcNow;
        }
    }
}