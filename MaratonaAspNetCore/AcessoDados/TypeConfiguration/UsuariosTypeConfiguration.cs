using MaratonaAspNetCore.Models.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetoBase.AcessoDados
{
    public class UsuariosTypeConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).HasColumnType("Varchar(100)").IsRequired();
            builder.Property(p => p.NomeLogin).HasColumnType("Varchar(50)").IsRequired();
            builder.Property(p => p.Permissao).HasColumnType("Varchar(50)").IsRequired();
            builder.Property(p => p.Email).HasColumnType("Varchar(100)").IsRequired();
            builder.Property(p => p.Senha).HasColumnType("Varchar(100)").IsRequired();


        }
    }
}