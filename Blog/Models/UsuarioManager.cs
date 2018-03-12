
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.Infra;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Blog.Models
{   //classe que representa o gerenciamento de contas              
    public class UsuarioManager: UserManager<Usuario>
    {   
    //construtor da classe     instancia tipo  
        public  UsuarioManager(IUserStore<Usuario> store): base(store)
        {
              
        }

       // metodo para criar instancia da classe  UsuarioManager
        public static UsuarioManager create()
        {
            var userStore = new UserStore<Usuario>(new BlogContext());
            return new UsuarioManager(userStore);
        }
    }
}