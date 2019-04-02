using MaratonaAspNetCore.Dados.AcessoDados.Repositorios;
using MaratonaAspNetCore.Models;
using Microsoft.EntityFrameworkCore;
using ProjetoBase.AcessoDados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaratonaAspNetCore.Services
{
    public class DBInitializer
    {
        private ProdutoRepositorio banco;

        public DBInitializer(ProdutoRepositorio repositorio)
        {
            banco = repositorio;
        }

        public void Init()
        {
            banco.context.Database.Migrate();

            if (!banco.SelecionarTodos().Any())
            {
                var alimentacao = new TipoProduto() { Nome = "Alimentação" };
                var higiene = new TipoProduto() { Nome = "Higiene" };
                var vestuario = new TipoProduto() { Nome = "Vestuario" };

                var produtos = new List<Produto>()
                {
                    new Produto(){Nome="Picanha", Tipo = alimentacao, Valor= 100.00M},
                    new Produto(){Nome="Fralda", Tipo = higiene, Valor= 30.00M},
                    new Produto(){Nome="camisa", Tipo = vestuario, Valor = 90.00M},
                };

                banco.dbset.AddRange(produtos);
                banco.SalvarAlteracoes();
            }
        }
    }
}
