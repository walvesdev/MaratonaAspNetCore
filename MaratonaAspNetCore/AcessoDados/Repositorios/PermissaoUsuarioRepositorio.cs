using ProjetoBase.AcessoDados;
using ProjetoBase.AcessoDados.Repositorios;
using MaratonaAspNetCore.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaratonaAspNetCore.Dados.AcessoDados.Repositorios
{
    public class PermissaoUsuarioRepositorio : Repositorio<PermissaoUsuario, int?>
    {
        public PermissaoUsuarioRepositorio(ApplicationContext context) : base(context)
        {
        }
    }
}
