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
        BlogContext db = new BlogContext();

        public ActionResult Index()//recebe id da view index caso opcao seja update
        {
           
            return View(db.Post.ToList());
        }

        public ActionResult adicionaPost(int? id)
        {
            if (id > 0)//update
            {
                var add_Post = db.Post.FirstOrDefault(x => x.Id == id);
                return View(add_Post); // abre view adicionaPost cm campos preenchidos para alteraçao
            }
            else
                return View(new Post());// abre view adicionaPost com campos vazios 
        }

        [HttpPost]
        public ActionResult adicionaPost(Post post)
        {
            if(post.Id > 0)
            {
                db.Entry(post).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }
            else
            {
                db.Post.Add(post);
                db.SaveChanges();
            }
          
            return RedirectToAction("Index");
        }

        public ActionResult RemovePost(int id)
        {
            var post = db.Post.Find(id);
            db.Post.Remove(post);
            db.SaveChanges();//metodo da classe Dbcontext



            return RedirectToAction("Index");
        }


      

        public ActionResult Categoria([Bind(Prefix = "id")]string categoria)
        {
            var lista = db.Post.Where(post => post.Categoria.Contains(categoria)).ToList(); 
            return View("index",lista);
        }

        

      
    }
}