using LojaNet.UI.Web.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages.Html;
using Microsoft.Owin.Security;

namespace LojaNet.UI.Web.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        [HttpGet]

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            var usuarioStore = new UserStore<IdentityUser>();
            // ele vai gerenciar, recebendo um usuario, o usuario strore é onde ele vai garvar
            var usuarioGerenciador = new UserManager<IdentityUser>(usuarioStore);
            var usuario = usuarioGerenciador.Find(loginViewModel.Nome, loginViewModel.Senha);
            if(usuario == null) ModelState.AddModelError("", "nome de usuario ou senha invalido");
            else
            {
                var gerenciadorDeAutentificacao = HttpContext.GetOwinContext().Authentication;
                var identidadUsuario = usuarioGerenciador.CreateIdentity(usuario, DefaultAuthenticationTypes.ApplicationCookie);
                gerenciadorDeAutentificacao.SignIn(new AuthenticationProperties { }, identidadUsuario);
                Response.Redirect("~/");
            }
            return View();
        }
        [HttpGet]

        public ActionResult Registro()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registro(NovoUsuarioViewModel novoUsuarioViewModel)
        {
            if (string.IsNullOrEmpty(novoUsuarioViewModel.Nome)) ModelState.AddModelError("", "O nome deve ser informado");
            if (string.IsNullOrEmpty(novoUsuarioViewModel.Senha) &&
                (novoUsuarioViewModel.Senha != novoUsuarioViewModel.ConfirmarSenha))
            {
                ModelState.AddModelError("", "Senhas divergentes");
            }

            if (ModelState.IsValid) 
            {
                // Gravar a infromação
                var usuarioStore = new UserStore<IdentityUser>();
                // ele vai gerenciar, recebendo um usuario, o usuario strore é onde ele vai garvar
                var usuarioGerenciador = new UserManager<IdentityUser>(usuarioStore);
                // Criar um usuario,  no caso o nome dele no login
                var usuario = new IdentityUser() { UserName = novoUsuarioViewModel.Nome };
                // Criação dele no banco
                var resultado = usuarioGerenciador.Create(usuario, novoUsuarioViewModel.Senha);
                if (resultado.Succeeded)
                {
                    var gerenciadorDeAutentificacao = HttpContext.GetOwinContext().Authentication;
                    //Tipo um cracha
                    var identidadUsuario = usuarioGerenciador.CreateIdentity(usuario, DefaultAuthenticationTypes.ApplicationCookie);
                    gerenciadorDeAutentificacao.SignIn(new AuthenticationProperties { }, identidadUsuario);
                    Response.Redirect("~/");
                }
            }
            return View(novoUsuarioViewModel);
        }
    }
}