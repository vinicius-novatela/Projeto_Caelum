﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class RegistroViewModel
    {
        [Required]
        public String LoginName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required][DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required] [Compare("senha")]
        public string ConfirmaSenha { get; set; }

    }
}