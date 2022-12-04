using Microsoft.EntityFrameworkCore;

namespace dotnet_order_app.Models
{
    public class MyDbContext : DbContext
    {

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pedido>()
            .HasOne(a => a.Pagamento)
            .WithOne(a => a.Pedido)
            .HasForeignKey<Pagamento>(c => c.PedidoId);
        }

        public DbSet<Boleto> Boletos { get; set; }
        public DbSet<CartaoDeCredito> Cartoes { get; set; }
        public DbSet<Consumidor> Consumidores { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}