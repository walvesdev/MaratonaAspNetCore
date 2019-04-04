using ProjetoBase.AcessoDados;
using ProjetoBase.AcessoDados.Repositorios;
using MaratonaAspNetCore.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaratonaAspNetCore.Dados.AcessoDados.Repositorios
{
    public class ProdutoRepositorio : Repositorio<Produto, int?>
    {
        public ProdutoRepositorio(ApplicationContext context) : base(context)
        {
        }
    }
}
