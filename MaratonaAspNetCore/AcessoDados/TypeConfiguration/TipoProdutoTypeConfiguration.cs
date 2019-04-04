using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MaratonaAspNetCore.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaratonaAspNetCore.Dados.AcessoDados.TypeConfiguration
{
    class TipoProdutoTypeConfiguration : IEntityTypeConfiguration<TipoProduto>
    {
        public void Configure(EntityTypeBuilder<TipoProduto> builder)
        {
            builder.ToTable("TipoProduto");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).HasColumnType("Varchar(100)").IsRequired();
            builder.HasMany(p => p.Produtos).WithOne(p => p.Tipo);

        }
    }
}
