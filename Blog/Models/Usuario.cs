using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Usuario:IdentityUser
    {   
        [Key]
        public int id { get; set; }

        public DateTime ultimoLogin { get;set; }

        [Required][Display(Name ="Usuario")]
        public string loginName { get; set; }

       
        [Required] [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}