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
            //injeta objetos(UsuarioManager) em cada requisiçao HTTP
            app.CreatePerOwinContext<UsuarioManager>(() => {
                BlogContext contexto = new BlogContext();
                UserStore<Usuario> userStore = new UserStore<Usuario>(contexto);
                return new UsuarioManager(userStore);
            });
            //define tipo de autenticaçao a ser usada na aplicaçao ,cookies de sessao
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {   //tipo de autenticaçao padrao
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                //rota necessaria
                LoginPath = new PathString("/Usuario/Login")
            });


        }
    }



}