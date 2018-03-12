using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class LoginViewModel// apenas transporta dados entre view e controlador
    {
        [Required][Display (Name = "Usuario")]
        public string LoginName { get; set; }

        [Required] [Display(Name = "senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}