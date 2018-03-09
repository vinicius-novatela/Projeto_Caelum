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

        [Required]
        [Display(Name = "Usuario")]
        public string loginName { get; set; }

        [Required]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        internal Task<ClaimsIdentity> GenerateUserIdentityAsync(UsuarioManager manager)
        {
            throw new NotImplementedException();
        }
    }
}