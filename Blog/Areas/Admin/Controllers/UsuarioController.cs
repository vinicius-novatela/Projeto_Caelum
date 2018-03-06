using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Models;
using Microsoft.AspNet.Identity.Owin;
using System.Security.Claims;
using Microsoft.AspNet.Identity;

namespace Blog.Areas.Admin.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Admin/Usuario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Usuario model)
        {
            if (ModelState.IsValid)
            {
                //instancia classe UsuarioManager
                UsuarioManager manager = HttpContext.GetOwinContext().GetUserManager<UsuarioManager>();
                Usuario usuario = manager.Find(model.loginName, model.Password);
                if(usuario != null)
                {
                    ClaimsIdentity identity = manager.CreateIdentity(usuario, DefaultAuthenticationTypes.ApplicationCookie);
                    HttpContext.GetOwinContext().Authentication.SignIn(new Microsoft.Owin.Security.AuthenticationProperties() { }, identity);
                }return View("Index", "admin");
            }
            else
                return View(model);

        }

    }
}