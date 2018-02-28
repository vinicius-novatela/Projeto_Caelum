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
       

        public ActionResult Index()//recebe id da view index caso opcao seja update
        {
            BlogContext db = new BlogContext();

            return View(db.Post.ToList());
        }
        public ActionResult PublicaPost(int id) // nao salva no banco , por isso controller nao passa DataPublicacao
        {// quando dado esta no banco contrller recebe dados mais dados nao alterados que estao na model
            BlogContext db = new BlogContext();
            var post = db.Post.Find(id);
            post.Publicado = 1;
            post.DataPublicacao = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult adicionaPost(int? id)
        {
            BlogContext db = new BlogContext();
            if (id > 0)//update
            {
                var add_Post = db.Post.FirstOrDefault(x => x.Id == id);
                return View(add_Post); // abre view adicionaPost cm campos preenchidos para alteraçao
            }
            else
                return View(new Post());// abre view adicionaPost com campos vazios e passando instancia post
        }

        [HttpPost]
        public ActionResult adicionaPost(Post post)
        {
            BlogContext db = new BlogContext();
            if (post.Id > 0)
            {
                db.Entry(post).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                //if(post.Publicado == true)

            }
            else
            {
                if(post.Publicado == 1)
                {
                    post.DataPublicacao = DateTime.Now;
                }

                db.Post.Add(post);
                

                db.SaveChanges();
            }
          
            return RedirectToAction("Index");
        }

        public ActionResult RemovePost(int id)
        {
            BlogContext db = new BlogContext();
            var post = db.Post.Find(id);
            db.Post.Remove(post);
            db.SaveChanges();//metodo da classe Dbcontext



            return RedirectToAction("Index");
        }


      

        public ActionResult Categoria([Bind(Prefix = "id")]string categoria)
        {
            BlogContext db = new BlogContext();
            var lista = db.Post.Where(post => post.Categoria.Contains(categoria)).ToList(); 
            return View("index",lista);
        }

        

      
    }
}