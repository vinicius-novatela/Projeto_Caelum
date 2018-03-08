using Blog.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Blog.Infra
{
    public class BlogContext : IdentityDbContext<Usuario>
    {
        public BlogContext() : base("name=blog") { }
        public DbSet<Post> Post { get; set; }
        public DbSet<Usuario> Usuario { get; set; }





        public static BlogContext Create()
        {
            return new BlogContext();
        }

    }
}