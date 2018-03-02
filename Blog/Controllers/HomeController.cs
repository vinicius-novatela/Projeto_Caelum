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
        public ActionResult PublicaPost(int id) 
        {
            BlogContext db = new BlogContext();
            var post = db.Post.Find(id);
            post.Publicado = true;
            post.DataPublicacao = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult adicionaPost(int? id)//abre view p/ (add id == null  ou uppdate id > 0)
        {
            BlogContext db = new BlogContext();           
            if (id > 0)//registro ja existe ,faz update
            {
                var add_Post = db.Post.FirstOrDefault(x => x.Id == id);
                return View(add_Post); // abre view adicionaPost com campos preenchidos para alteraçao
            }
            else //novo registro              
            return View(new Post());// abre view adicionaPost com campos vazios e passando instancia post
        }

        [HttpPost]
        public ActionResult adicionaPost(Post post)
        {           
            BlogContext db = new BlogContext();
            if (post.Id > 0)//update
            {
                if (ModelState.IsValid)//valida entradas do usuario
                {
                    db.Entry(post).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else//erro validações,
                {
                    return View(post); //abre novamente a view passando referencia post
                }              
            }
            else//add novo registro
            {
                if (ModelState.IsValid) { 
                   db.Post.Add(post);              
                   db.SaveChanges();
                   return RedirectToAction("Index");
                }
                else//erro add dados
                {
                    return View(post);// abre novamente a view passando referencia post
                }
            }           
        }

        public  ActionResult Busca(string termo)//busca por titulo ou resumo
        {
            BlogContext db = new BlogContext();
            var model = db.Post.Where(p => (p.Publicado) && (p.Titulo.Contains(termo) || p.Resumo.Contains(termo)))
                .Select(p => p)
                .ToList();
            return View("Index",model);

                
                
        }

        [HttpPost]
        public ActionResult CategoriaAutocomplete(string term)
        {
            BlogContext db = new BlogContext();

            var model = db.Post.Where(p => p.Categoria.Contains(term))//pega registros que contem o termo enviado como argumento de entrada
            .Select(p => new { x = p.Categoria })//cria objeto anonimo para cada campo retornado
            .Distinct()//sem categorias repetidas
            .ToList();
            return Json(model);
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