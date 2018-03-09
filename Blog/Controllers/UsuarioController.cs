using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Models;
using System.Security.Claims;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace Blog.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Autenticacao
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult registro()
        {
            return View();
        }

        public ActionResult Registro(RegistroViewModel model)
        {
            // RegistroViewModel apenas transporta dados entre  view e controlador(nao salva no banco)
            if (ModelState.IsValid)
            {
                Usuario usu = new Usuario();
                usu.UserName = model.LoginName;
                usu.Email = model.Email;

                UsuarioManager manager = HttpContext.GetOwinContext().GetUserManager<UsuarioManager>();
                IdentityResult resultado = manager.Create(usu, model.Senha);
                if (resultado.Succeeded)
                {
                    return RedirectToAction("index");
                }
                else
                {
                    foreach (string erro in resultado.Errors)
                    {
                        ModelState.AddModelError("", erro);
                    }
                }
            }
            return View(model);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                UsuarioManager manager = HttpContext.GetOwinContext().GetUserManager<UsuarioManager>(); //instancia classe UsuarioManager
                Usuario usuario = manager.Find(model.LoginName, model.Password);//busca no banco
                if (usuario != null)// usuario encontrado 
                {   //metodo createIdentity recebe parametros(instancia Usuario, tipo de autenticaçao por cookie de sessao)
                    ClaimsIdentity identity = manager.CreateIdentity(usuario, DefaultAuthenticationTypes.ApplicationCookie);
                    //metodo SignIn cria uma sessao para o usuario
                    HttpContext.GetOwinContext().Authentication.SignIn(new Microsoft.Owin.Security.AuthenticationProperties() { }, identity);

                    return View("Index", "Admin");//usuario nao encontrado
                }
                //
                return View(model);
            }
            else
                return View(model);
        }
    }
}