﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Areas.Admin.Controllers
{
    public class AutenticacaoController : Controller
    {
        // GET: Admin/Autenticacao
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult login()
        {
            return View();
        }

    }
}