using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Infra;
using Blog.Models;
<<<<<<< HEAD
using Blog.RepositorioBase;
=======
>>>>>>> dbc8f2a52c79f0bfbeb99ab83b9a33b9899aaf4d

namespace Blog.Areas.Admin.Controllers
{
    [Authorize]//restringe acesso / exige login no sistema
    public class PostController : Controller
    {
        private BlogContext _db;
<<<<<<< HEAD
        private PostDao _repos_Base;

=======
>>>>>>> dbc8f2a52c79f0bfbeb99ab83b9a33b9899aaf4d

        public PostController()
        {
            _db = new BlogContext();
<<<<<<< HEAD
            _repos_Base = new PostDao(_db);
        }


        // GET: Admin/Post
        public ActionResult Index()
        {
            return View(_db.Post.ToList());
        }

=======
        }


>>>>>>> dbc8f2a52c79f0bfbeb99ab83b9a33b9899aaf4d
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
<<<<<<< HEAD
        
        public ActionResult PublicaPost(int id)
        {
             _repos_Base.publicaPost(id);
=======
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
>>>>>>> dbc8f2a52c79f0bfbeb99ab83b9a33b9899aaf4d
            return RedirectToAction("Index");
        }
        public ActionResult RemovePost(int id)
        {
<<<<<<< HEAD
            _repos_Base.Remove(id);
=======
            var post = _db.Post.Find(id);
            _db.Post.Remove(post);
            _db.SaveChanges();//metodo da classe Dbcontext
>>>>>>> dbc8f2a52c79f0bfbeb99ab83b9a33b9899aaf4d
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
<<<<<<< HEAD
                _repos_Base.upDate(post);
=======
                _db.Entry(post).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
>>>>>>> dbc8f2a52c79f0bfbeb99ab83b9a33b9899aaf4d
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
<<<<<<< HEAD
                _repos_Base.add(post);
=======
                _db.Post.Add(post);
                _db.SaveChanges();
>>>>>>> dbc8f2a52c79f0bfbeb99ab83b9a33b9899aaf4d
                return RedirectToAction("Index");
            }
            else//erro add dados
            {
                return View(post);// abre novamente a view passando referencia post
            }
        }

<<<<<<< HEAD

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);

        }


=======
>>>>>>> dbc8f2a52c79f0bfbeb99ab83b9a33b9899aaf4d
    }
}


