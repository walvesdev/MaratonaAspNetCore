using MaratonaAspNetCore.Dados.AcessoDados.Repositorios;
using MaratonaAspNetCore.Models.Model;
using Microsoft.EntityFrameworkCore;
using ProjetoBase.AcessoDados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaratonaAspNetCore.Services.Helpers;

namespace MaratonaAspNetCore.Services
{
    public class DBInitializer
    {
        private readonly ProdutoRepositorio produtoRepositorio;
        private readonly UsuarioRepositorio usuarioRepositorio;
        private readonly PermissaoUsuarioRepositorio permissaoUsuarioRepositorio;

        public DBInitializer(ProdutoRepositorio produtoRepositorio, UsuarioRepositorio usuarioRepositorio, PermissaoUsuarioRepositorio permissaoUsuarioRepositorio)
        {
            this.produtoRepositorio = produtoRepositorio;
            this.usuarioRepositorio = usuarioRepositorio;
            this.permissaoUsuarioRepositorio = permissaoUsuarioRepositorio;
        }

        public void Init()
        {
            produtoRepositorio.context.Database.Migrate();

            if (!produtoRepositorio.SelecionarTodos().Any())
            {
                var alimentacao = new TipoProduto() { Nome = "Alimentação" };
                var higiene = new TipoProduto() { Nome = "Higiene" };
                var vestuario = new TipoProduto() { Nome = "Vestuario" };

                var produtos = new List<Produto>()
                {
                    new Produto(){Nome="Picanha", Tipo = alimentacao, Valor= 100.00M, Descricao= "Descrição do produto."},
                    new Produto(){Nome="Fralda", Tipo = higiene, Valor= 30.00M, Descricao= "Descrição do produto."},
                    new Produto(){Nome="camisa", Tipo = vestuario, Valor = 90.00M, Descricao= "Descrição do produto."},
                };

                produtoRepositorio.dbset.AddRange(produtos);
                produtoRepositorio.SalvarAlteracoes();
            }



            if ((!usuarioRepositorio.SelecionarTodos().Any()) && (!permissaoUsuarioRepositorio.SelecionarTodos().Any()))
            {
                var admin = new PermissaoUsuario() { NivelAcesso = "Admin" };
                var usuario = new PermissaoUsuario() { NivelAcesso = "Usuario" };
                var master = new PermissaoUsuario() { NivelAcesso = "Master" };
                
                usuarioRepositorio.dbset.AddRange(new List<Usuario>
                {
                    new Usuario() { Nome = "Willian Alves", NomeLogin = "walvesdev", Email = "walvesdev@email.com", Permissao = usuario, Senha = "123456".Encrypt()},
                    new Usuario() { Nome = "Administrador", NomeLogin = "admin", Email = "admin@email.com", Permissao = admin, Senha = "123456".Encrypt() },
                    new Usuario() { Nome = "Master", NomeLogin = "master", Email = "master@email.com", Permissao = master, Senha = "123456".Encrypt() }

            });
                usuarioRepositorio.SalvarAlteracoes();
            }
        }
    }
}
