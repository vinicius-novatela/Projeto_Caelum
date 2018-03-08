using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.Infra;
using Microsoft.Owin.Security.Cookies;
using Blog.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;







namespace Blog.App_Start
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
          //  UserStore store = new UserStore<Usuario>(new BlogContext());
           // UsuarioManager manager = new UsuarioManager(store);
            app.CreatePerOwinContext<UsuarioManager>(UsuarioManager.create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Usuario/Login"),
            });
        }


    }
}