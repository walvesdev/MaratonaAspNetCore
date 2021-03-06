﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MaratonaAspNetCore.AcessoDados.TypeConfiguration
{
    public abstract class AbstractTypeConfiguration<T> : IEntityTypeConfiguration<T> where T:class
    {
        internal EntityTypeBuilder<T> builder;

        public void Configure(EntityTypeBuilder<T> builder)
        {
            this.builder = builder;
            ConfiguararNomeTabela();
            ConfiguararCamposTabela();
            ConfiguararChavePrimaria();
            ConfiguararChaveEstrangeira();
        }

        internal abstract void ConfiguararChaveEstrangeira();
        internal abstract void ConfiguararChavePrimaria();
        internal abstract void ConfiguararCamposTabela();
        internal abstract void ConfiguararNomeTabela();
        
    }
}
