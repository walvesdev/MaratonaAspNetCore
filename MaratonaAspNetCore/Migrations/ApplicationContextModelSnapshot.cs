﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoBase.AcessoDados;

namespace MaratonaAspNetCore.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("MANC")
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MaratonaAspNetCore.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCriacao");

                    b.Property<string>("Nome");

                    b.Property<int>("TipoProdutoId");

                    b.Property<decimal>("Valor")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("TipoProdutoId");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("MaratonaAspNetCore.Models.TipoProduto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCriacao");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("TipoProduto");
                });

            modelBuilder.Entity("MaratonaAspNetCore.Models.Produto", b =>
                {
                    b.HasOne("MaratonaAspNetCore.Models.TipoProduto", "Tipo")
                        .WithMany("Produtos")
                        .HasForeignKey("TipoProdutoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
