using MaratonaAspNetCore.Dados.AcessoDados.Repositorios;
using MaratonaAspNetCore.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaratonaAspNetCore.Services.Helpers;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace MaratonaAspNetCore.Controllers
{
    public class ContaController : Controller
    {
        private readonly UsuarioRepositorio banco;
        private readonly PermissaoUsuarioRepositorio permissaoUsuarioRepositorio;


        public ContaController(UsuarioRepositorio ctx, PermissaoUsuarioRepositorio permissaoUsuarioRepositorio)
        {
            banco = ctx;
            this.permissaoUsuarioRepositorio = permissaoUsuarioRepositorio;
        }

        public IActionResult Login(string returnUrl) => View(new LoginVM() { ReturnUrl = returnUrl});

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM login)
        {
            if (login == null || string.IsNullOrEmpty(login.NomeLogin) || string.IsNullOrEmpty(login.Senha))
            {
                ModelState.AddModelError("NomeLogin", "Digite um nome de usuário!");
                ModelState.AddModelError("Senha", "Digite uma senha!!");
                return View();
            }
            var usuario = banco.dbset.FirstOrDefault(u => u.NomeLogin.ToLower() == login.NomeLogin.ToLower());

            if (usuario == null)
            {
                ModelState.AddModelError("NomeLogin", "Usuario não localizado");
            }
            else
            {
                if (login.Senha.Encrypt() != usuario.Senha)
                {
                    ModelState.AddModelError("Senha", "Senha incorreta!");
                }
            }

            if (ModelState.IsValid)
            {
                var permissao = permissaoUsuarioRepositorio.SelecionarPorId(usuario.PermissaoUsuarioId);



                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, usuario.NomeLogin));
                identity.AddClaim(new Claim(ClaimTypes.Name, usuario.Nome));
                identity.AddClaim(new Claim(ClaimTypes.Role, permissao.NivelAcesso));

                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
                {
                    IsPersistent = login.Lembrar
                    
                });

                if (!string.IsNullOrEmpty(login.ReturnUrl) && Url.IsLocalUrl(login.ReturnUrl))
                {
                    return Redirect(login.ReturnUrl);
                }

                return RedirectToAction("Index", "Produtos");
            }

            return View(login);
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Conta");
        }
         public IActionResult AcessoNegado()
        {
            return View();
        }

    }
}
