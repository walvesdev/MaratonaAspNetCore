using ProjetoBase.AcessoDados;
using ProjetoBase.AcessoDados.Repositorios;
using MaratonaAspNetCore.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaratonaAspNetCore.Dados.AcessoDados.Repositorios
{
    public class UsuarioRepositorio : Repositorio<Usuario, int?>
    {
        public UsuarioRepositorio(ApplicationContext context) : base(context)
        {
        }
    }
}
