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

     //  [StringLength(50)] [Required]
       public string Titulo { get; set; }

     //  [Required] 
       public string Resumo { get; set; }

       public string Categoria { get; set; }
       public DateTime? DataPublicacao { get; set; }
       public bool Publicado { get; set;}
       public virtual Usuario Autor { get; set; }




    }
}