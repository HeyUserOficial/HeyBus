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
        RepositoryViagem repVi = new RepositoryViagem();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Sobre()
        {

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
        
        public ActionResult BuscarViagem()
        {
            Viagem v = new Viagem();
            if (ModelState.IsValid)
            {
                repVi.PesquisarViagemCompleto(v.data_Ida, v.rot.origem_Rota, v.rot.destino_Rota, v.data_Volta);
                RedirectToAction("BuscarViagemCompleta", "Viagens", new { v.data_Ida, v.rot.origem_Rota, v.rot.destino_Rota, v.data_Volta });
            }
            return View();
        }

        public ActionResult BuscarViagemIda()
        {
            Viagem v = new Viagem();
            if (ModelState.IsValid)
            {
                repVi.PesquisarViagemIda(v.data_Ida, v.rot.origem_Rota, v.rot.destino_Rota);
                RedirectToAction("BuscarViagemIda", "Viagens", new { v.data_Ida, v.rot.origem_Rota, v.rot.destino_Rota });
            }
            return View();
        }

        public ActionResult BuscarViagemDestino()
        {
            Viagem v = new Viagem();
            if (ModelState.IsValid)
            {
                repVi.PesquisarViagemDestino(v.rot.origem_Rota, v.rot.destino_Rota);
                RedirectToAction("BuscaViagemDestino","Viagens", new { v.rot.origem_Rota, v.rot.destino_Rota });
            }
            return View();
        }
    }
}