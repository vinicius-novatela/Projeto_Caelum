using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Post
    {  [Key]
       public int Id { get; set; }
       public string Titulo { get; set; }
       public string Resumo { get; set; }
       public string Categoria { get; set; }
       public DateTime? DataPublicacao { get; set; }
       public byte Publicado { get; set;}




    }
}