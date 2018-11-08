﻿using HeyBus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeyBus.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Sobre()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Servicos()
        {
            ViewBag.Message = "Your service description page.";
            return View();
        }

        public ActionResult Onibus()
        {
            ViewBag.Message = "Your bus service description page.";
            return View();
        }

        public ActionResult Duvidas()
        {
            ViewBag.Message = "Your doubts page.";

            return View();
        }
        public ActionResult Contato()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult testePerfil()
        {
            return View();
        }

    }
}