using Microsoft.EntityFrameworkCore;
using MaratonaAspNetCore.AcessoDados.TypeConfiguration;
using MaratonaAspNetCore.Dados.AcessoDados.TypeConfiguration;
using MaratonaAspNetCore.Models.Model;

namespace ProjetoBase.AcessoDados
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<TipoProduto> TipoProdutos { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public ApplicationContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server = localhost; Database = ProjetoBaseMVC; Trusted_Connection = True;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("MANC");
            modelBuilder.ApplyConfiguration(new ProdutoTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TipoProdutoTypeConfiguration());
        }
    }
}
