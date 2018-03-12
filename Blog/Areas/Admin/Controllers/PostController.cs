using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Infra;
using Blog.Models;
using Blog.RepositorioBase;

namespace Blog.Areas.Admin.Controllers
{
    [Authorize]//restringe acesso / exige login no sistema
    public class PostController : Controller
    {
        private BlogContext _db;
        private PostDao _repos_Base;


        public PostController()
        {
            _db = new BlogContext();
            _repos_Base = new PostDao(_db);
        }


        // GET: Admin/Post
        public ActionResult Index()
        {
            return View(_db.Post.ToList());
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
        
        public ActionResult PublicaPost(int id)
        {
             _repos_Base.publicaPost(id);
            return RedirectToAction("Index");
        }
        public ActionResult RemovePost(int id)
        {
            _repos_Base.Remove(id);
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
                _repos_Base.upDate(post);
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
                _repos_Base.add(post);
                return RedirectToAction("Index");
            }
            else//erro add dados
            {
                return View(post);// abre novamente a view passando referencia post
            }
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);

        }


    }
}


