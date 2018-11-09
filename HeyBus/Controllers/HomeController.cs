using HeyBus.Models;
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

            Cliente cliente = new Cliente();
            cliente.id_Cliente = 1;
            cliente.nome_Cliente = "yuri";
            cliente.tel_Cliente = "1194487-121";

            Session["clientelogado"] = cliente;

            string login = "";

            if (Session["login_yuri"] != null)
            {
                login = Session["login_yuri"].ToString();
            }
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