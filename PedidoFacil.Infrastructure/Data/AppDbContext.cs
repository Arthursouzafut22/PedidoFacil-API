using Microsoft.EntityFrameworkCore;
using PedidoFacil.Domain.Models;

namespace PedidoFacil.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Categoria> Categorias => Set<Categoria>();
        public DbSet<Produto> Produtos => Set<Produto>();
        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<Pedido> Pedidos => Set<Pedido>();
        public DbSet<ItemPedido> ItensPedido => Set<ItemPedido>();
        public DbSet<WebhookAssinatura> WebhookAssinaturas => Set<WebhookAssinatura>();
        public DbSet<WebhookEntrega> WebhookEntregas => Set<WebhookEntrega>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ---------- Categoria ----------
            modelBuilder.Entity<Categoria>(e =>
            {
                e.ToTable("categoria");
                e.Property(x => x.Nome).IsRequired().HasMaxLength(100);
            });

            // ---------- Produto ----------
            modelBuilder.Entity<Produto>(e =>
            {
                e.ToTable("produto");
                e.Property(x => x.Nome).IsRequired().HasMaxLength(150);
                e.Property(x => x.Descricao).HasMaxLength(500);
                e.Property(x => x.ImagemUrl).HasMaxLength(500);
                e.Property(x => x.Preco).HasPrecision(10, 2);
                e.HasOne(x => x.Categoria)
                 .WithMany(c => c.Produtos)
                 .HasForeignKey(x => x.CategoriaId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            // ---------- Cliente ----------
            modelBuilder.Entity<Cliente>(e =>
            {
                e.ToTable("cliente");
                e.Property(x => x.Nome).IsRequired().HasMaxLength(150);
                e.Property(x => x.Email).IsRequired().HasMaxLength(200);
                e.Property(x => x.SenhaHash).IsRequired();
                e.Property(x => x.Telefone).HasMaxLength(20);
                e.HasIndex(x => x.Email).IsUnique();
            });

            // ---------- Pedido ----------
            modelBuilder.Entity<Pedido>(e =>
            {
                e.ToTable("pedido");
                e.Property(x => x.ValorTotal).HasPrecision(10, 2);
                e.Property(x => x.Endereco).IsRequired().HasMaxLength(300);
                e.Property(x => x.Status).HasConversion<string>().HasMaxLength(30);
                e.HasOne(x => x.Cliente)
                 .WithMany(c => c.Pedidos)
                 .HasForeignKey(x => x.ClienteId)
                 .OnDelete(DeleteBehavior.Restrict);
                e.HasIndex(x => x.Status);
                e.HasIndex(x => x.ClienteId);
            });

            // ---------- ItemPedido ----------
            modelBuilder.Entity<ItemPedido>(e =>
            {
                e.ToTable("item_pedido");
                e.Property(x => x.NomeProduto).IsRequired().HasMaxLength(150);
                e.Property(x => x.PrecoUnitario).HasPrecision(10, 2);
                e.Property(x => x.Observacao).HasMaxLength(300);
                e.HasOne(x => x.Pedido)
                 .WithMany(p => p.Itens)
                 .HasForeignKey(x => x.PedidoId)
                 .OnDelete(DeleteBehavior.Cascade);
                e.HasOne(x => x.Produto)
                 .WithMany()
                 .HasForeignKey(x => x.ProdutoId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            // ---------- WebhookAssinatura ----------
            modelBuilder.Entity<WebhookAssinatura>(e =>
            {
                e.ToTable("webhook_assinatura");
                e.Property(x => x.Url).IsRequired().HasMaxLength(500);
                e.Property(x => x.Segredo).IsRequired().HasMaxLength(200);
                e.Property(x => x.Eventos).IsRequired().HasMaxLength(500);
            });

            // ---------- WebhookEntrega ----------
            modelBuilder.Entity<WebhookEntrega>(e =>
            {
                e.ToTable("webhook_entrega");
                e.Property(x => x.Evento).IsRequired().HasMaxLength(100);
                e.Property(x => x.Payload).IsRequired();
                e.Property(x => x.Status).HasConversion<string>().HasMaxLength(30);
                e.Property(x => x.UltimoErro).HasMaxLength(1000);

                // 1 assinatura -> N entregas
                e.HasOne(x => x.Assinatura)
                 .WithMany(a => a.Entregas)
                 .HasForeignKey(x => x.AssinaturaId)
                 .OnDelete(DeleteBehavior.Cascade);

                // 1 pedido -> N entregas
                e.HasOne(x => x.Pedido)
                 .WithMany(p => p.WebhookEntregas)
                 .HasForeignKey(x => x.PedidoId)
                 .OnDelete(DeleteBehavior.Cascade);

                // O dispatcher busca sempre "pendentes cuja hora de tentar já chegou"
                e.HasIndex(x => new { x.Status, x.ProximaTentativaEm });
            });
        }
    }
}

