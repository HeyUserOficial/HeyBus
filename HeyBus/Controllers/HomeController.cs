using HeyBus.Connection;
using HeyBus.Models;
using HeyBus.Repository;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeyBus.Controllers
{
    public class HomeController : Controller
    {
        Conexao conn = new Conexao();
        MySqlCommand cmd;
        MySqlDataReader dr;
        RepositoryCliente repCli = new RepositoryCliente();

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
    }
}