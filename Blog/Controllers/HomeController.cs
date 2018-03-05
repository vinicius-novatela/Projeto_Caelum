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
        public ActionResult Index()
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
    }
}