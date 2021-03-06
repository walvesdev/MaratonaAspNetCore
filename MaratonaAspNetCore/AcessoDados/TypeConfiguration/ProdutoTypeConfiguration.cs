﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MaratonaAspNetCore.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaratonaAspNetCore.Dados.AcessoDados.TypeConfiguration
{
    class ProdutoTypeConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.Tipo).WithMany(t => t.Produtos).HasForeignKey(p => p.TipoProdutoId).OnDelete(DeleteBehavior.ClientSetNull);
            builder.Property(p => p.Nome).HasColumnType("Varchar(100)").IsRequired();
            builder.Property(p => p.Descricao).HasColumnType("Varchar(300)");
            builder.Property(p => p.Valor).HasColumnType("decimal(18, 2)");

        }
    }
}
