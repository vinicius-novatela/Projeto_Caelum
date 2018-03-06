using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Infra;
using Blog.Models;

namespace Blog.Areas.Admin.Controllers
{
    [Authorize]//restringe acesso / exige login no sistema
    public class PostController : Controller
    {
        private BlogContext _db;

        public PostController()
        {
            _db = new BlogContext();
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
        // GET: Admin/Post
        public ActionResult Index()
        {
            return View(_db.Post.ToList());
        }
        public ActionResult PublicaPost(int id)
        {
            var post = _db.Post.Find(id);
            post.Publicado = true;
            post.DataPublicacao = DateTime.Now;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult RemovePost(int id)
        {
            var post = _db.Post.Find(id);
            _db.Post.Remove(post);
            _db.SaveChanges();//metodo da classe Dbcontext
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)//abre view p/ (add id == null  ou uppdate id > 0)
        {
            var model = _db.Post.FirstOrDefault(x => x.Id == id);
            return View(model); // abre view adicionaPost com campos preenchidos para alteraçao         
        }

        [HttpPost]
        public ActionResult Edit(Post post)
        {
            if (ModelState.IsValid)//valida entradas do usuario
            {
                _db.Entry(post).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else//erro validações,
            {
                return View(post); //abre novamente a view passando referencia post
            }
        }

        public ActionResult novo()
        {
            return View(new Post());
        }

        [HttpPost]
        public ActionResult novo(Post post)
        {
            if (ModelState.IsValid)
            {
                _db.Post.Add(post);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else//erro add dados
            {
                return View(post);// abre novamente a view passando referencia post
            }
        }

    }
}


