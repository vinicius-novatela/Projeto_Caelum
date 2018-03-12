using Blog.Infra;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Blog.RepositorioBase
{
    public class PostDao: IDisposable
    {
        

            private BlogContext _db;

            public PostDao(BlogContext db)
            {
               this._db = db;
            }

            public IEnumerable<Post> PostsMaisRecentes()
            {
                return _db.Post.OrderByDescending(p => p.DataPublicacao);
            }

            public void add( Post p)
            {
                _db.Post.Add(p);
                _db.SaveChanges();
            }

           

            public void upDate(Post p)
            {
                _db.Entry(p).State = EntityState.Modified;
                _db.SaveChanges();
            }

            public void Remove(int id)
            {
                var post = _db.Post.Where(p => p.Id == id).FirstOrDefault();
                _db.Post.Remove(post);
                _db.SaveChanges();
            }

            public void publicaPost (int id)
            {
                var post = _db.Post.Where(p => p.Id == id).FirstOrDefault();
                //verificar se post!= null
                post.Publicado = true;
                post.DataPublicacao = DateTime.Now;
                _db.SaveChanges();
            }
            public void Dispose()
            {
                _db.Dispose();
            }
            

        }
    
}