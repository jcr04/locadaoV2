using locadao.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace locadao.Infrastructure
{
    public class LocadaoDbContext : DbContext
    {
        public LocadaoDbContext(DbContextOptions<LocadaoDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Agencia> Agencias { get; set; }
        public DbSet<Aluguel> Alugueis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração das entidades e seus relacionamentos
            modelBuilder.Entity<Agencia>()
                .HasMany(a => a.Veiculos)
                .WithOne(v => v.Agencia)
                .HasForeignKey(v => v.AgenciaId);

            modelBuilder.Entity<Agencia>()
                .HasMany(a => a.Alugueis)
                .WithOne(al => al.Agencia)
                .HasForeignKey(al => al.AgenciaId);

            modelBuilder.Entity<Aluguel>()
                .HasOne(al => al.Cliente)
                .WithMany()
                .HasForeignKey(al => al.ClienteId);

            modelBuilder.Entity<Aluguel>()
                .HasOne(al => al.Veiculo)
                .WithMany()
                .HasForeignKey(al => al.VeiculoId);
        }
    }
}
