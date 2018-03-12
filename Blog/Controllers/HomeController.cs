using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Infra;
using Blog.Models;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {   
<<<<<<< HEAD
        public ActionResult Index()//substituir  BlogContext pela classe PostDal
=======
        public ActionResult Index()
>>>>>>> dbc8f2a52c79f0bfbeb99ab83b9a33b9899aaf4d
        {
            BlogContext db = new BlogContext();
            return View(db.Post.ToList());
        }          
        public ActionResult Categoria([Bind(Prefix = "id")]string categoria)
        {
            BlogContext db = new BlogContext();
            var lista = db.Post.Where(post => post.Categoria.Contains(categoria)).ToList(); 
            return View("index",lista);
        }


        public ActionResult Busca(string termo)//busca por titulo ou resumo
        {
            BlogContext db = new BlogContext();
            var model = db.Post.Where(p => (p.Publicado) && (p.Titulo.Contains(termo) || p.Resumo.Contains(termo)))
                .Select(p => p)
                .ToList();
            return View("Index", model);
        }

    }
}