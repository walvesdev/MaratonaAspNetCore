using ProjetoBase.AcessoDados;
using ProjetoBase.AcessoDados.Repositorios;
using MaratonaAspNetCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaratonaAspNetCore.Dados.AcessoDados.Repositorios
{
    public class TipoProdutoRepositorio : Repositorio<TipoProduto, int?>
    {
        public TipoProdutoRepositorio(ApplicationContext context) : base(context)
        {
        }
    }
}
