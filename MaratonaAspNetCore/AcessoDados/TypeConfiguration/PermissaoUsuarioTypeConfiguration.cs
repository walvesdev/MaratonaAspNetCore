using MaratonaAspNetCore.Models.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetoBase.AcessoDados
{
    public class PermissaoUsuarioTypeConfiguration : IEntityTypeConfiguration<PermissaoUsuario>
    {
        public void Configure(EntityTypeBuilder<PermissaoUsuario> builder)
        {
            builder.ToTable("PermissaoAcesso");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.NivelAcesso).HasColumnType("Varchar(50)").IsRequired();
            


        }
    }
}