using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MaratonaAspNetCore.Models;
using ProjetoBase.AcessoDados;
using MaratonaAspNetCore.Dados.AcessoDados.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace MaratonaAspNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProdutoRepositorio banco;

        public HomeController(ProdutoRepositorio ctx)
        {
            banco = ctx;
        }

        public IActionResult Index()
        {
            var listaProdutos = banco.dbset.Include(p => p.Tipo).ToList();

            return View(listaProdutos);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
