using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MaratonaAspNetCore.Models.Model;
using ProjetoBase.AcessoDados;
using MaratonaAspNetCore.Dados.AcessoDados.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using MaratonaAspNetCore.Services.Filters;
using MaratonaAspNetCore.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace MaratonaAspNetCore.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProdutosController : Controller
    {
        private readonly ProdutoRepositorio banco;
        private readonly TipoProdutoRepositorio banco_tipo;

        public ProdutosController(ProdutoRepositorio ctx, TipoProdutoRepositorio ctx_tipo)
        {
            banco = ctx;
            banco_tipo = ctx_tipo;
        }

        public IActionResult Index()
        {
            var listaProdutos = banco.dbset.Include(p => p.Tipo).ToList();

            return View(listaProdutos);
        }
        [HttpGet]
        public IActionResult AddEdit(int? id)
        {

            var listaTipos = banco_tipo.SelecionarTodos().Select(t => new SelectListItem { Value = t.Id.ToString(), Text = t.Nome }).ToList();
            var produto = new Produto();

            ViewBag.Tipos = listaTipos;
            if (id != null)
            {
                produto = banco.SelecionarPorId(id);
            }

            return View(produto);
        }

        [HttpPost]
        public IActionResult AddEdit(Produto produto)
        {
            if (ModelState.IsValid)
            {
                if (produto.Id == 0)
                {
                    banco.Inserir(produto);
                    banco.SalvarAlteracoes();

                    return RedirectToAction(nameof(ProdutosController.Index));
                }
                else
                {
                    banco.Atualizar(produto);
                    banco.SalvarAlteracoes();

                    return RedirectToAction(nameof(ProdutosController.Index));
                }
                
            }

            var listaTipos = banco_tipo.SelecionarTodos().Select(t => new SelectListItem { Value = t.Id.ToString(), Text = t.Nome }).ToList();
            ViewBag.Tipos = listaTipos;

            return View(produto);
        }
        [HttpDelete]
        public IActionResult Excluir(int id)
        {
            var produto = banco.SelecionarPorId(id);

            if (produto == null)
            {
                return NotFound();
            }

            banco.Excluir(produto);
            banco.SalvarAlteracoes();

            return NoContent();
        }


    }
}
