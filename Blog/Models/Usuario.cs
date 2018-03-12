using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Usuario:IdentityUser //outros ususario herdam da classe IdentyUser
    {
       // [Key]
       // public int id { get; set; }

        public DateTime UltimoLogin { get; set; }

<<<<<<< HEAD
        //[Required]
        //[Display(Name = "Usuario")]
        //public string loginName { get; set; }

        //[Required]
        //[Display(Name = "Senha")]
        //[DataType(DataType.Password)]
        //public string Password { get; set; }
=======
        [Required]
        [Display(Name = "Usuario")]
        public string loginName { get; set; }

        [Required]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
>>>>>>> dbc8f2a52c79f0bfbeb99ab83b9a33b9899aaf4d

        public virtual ICollection<Post> Posts { get; set; }

        internal Task<ClaimsIdentity> GenerateUserIdentityAsync(UsuarioManager manager)
        {
            throw new NotImplementedException();
        }
    }
}