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
        RepositoryViagem repViagem = new RepositoryViagem();

        [HttpGet]
        public ActionResult Index()
        {            
            return View();           
        }

        [HttpPost]
        public ActionResult Index(Viagem v)
        {
            if (v.data_Volta == Convert.ToDateTime("01/01/0001") && v.data_Ida == Convert.ToDateTime("01/01/0001") && v.rot.origem_Rota != null && v.rot.destino_Rota != null)
            {
                repViagem.PesquisarViagemCompleto(v.data_Ida, v.rot.origem_Rota, v.rot.destino_Rota, v.data_Volta);
                Response.Redirect("~/Viagens/BuscarViagemCompleta?dataPartida=" + v.data_Ida.ToString("MM/dd/yyyy") + "&origem=" + v.rot.origem_Rota + "&Destino=" + v.rot.destino_Rota + "&dataVolta=" + v.data_Volta.ToString("MM/dd/yyyy"));
            }
            else if (v.data_Volta == null && v.data_Ida == null && v.rot.origem_Rota != null && v.rot.destino_Rota != null)
            {
                repViagem.PesquisarViagemDestino(v.rot.origem_Rota, v.rot.destino_Rota);
                Response.Redirect("~/Viagens/BuscarViagemDestino?origem=" + v.rot.origem_Rota + "&Destino=" + v.rot.destino_Rota);
            }
            else if (v.data_Volta != null && v.data_Ida != null && v.rot.origem_Rota != null && v.rot.destino_Rota != null)
            {
                repViagem.PesquisarViagemCompleto(v.data_Ida, v.rot.origem_Rota, v.rot.destino_Rota, v.data_Volta);
                Response.Redirect("~/Viagens/BuscarViagemCompleta?dataPartida=" + v.data_Ida.ToString("MM/dd/yyyy") + "&origem=" + v.rot.origem_Rota + "&Destino=" + v.rot.destino_Rota + "&dataVolta=" + v.data_Volta.ToString("MM/dd/yyyy"));
            }
            else if (v.data_Volta == null)
            {
                repViagem.PesquisarViagemIda(v.data_Ida, v.rot.origem_Rota, v.rot.destino_Rota);
                Response.Redirect("~/Viagens/BuscarViagemIda?dataPartida=" + v.data_Ida.ToString("MM/dd/yyyy") + "&origem=" + v.rot.origem_Rota + "&Destino=" + v.rot.destino_Rota);
            }
            else
            {
                Response.Redirect("~/Viagens/");
            }
            return View(v);
        }

        public ActionResult Sobre()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Sobre(Viagem v)
        {
            if (v.data_Volta == Convert.ToDateTime("01/01/0001") && v.data_Ida == Convert.ToDateTime("01/01/0001") && v.rot.origem_Rota != null && v.rot.destino_Rota != null)
            {
                repViagem.PesquisarViagemCompleto(v.data_Ida, v.rot.origem_Rota, v.rot.destino_Rota, v.data_Volta);
                Response.Redirect("~/Viagens/BuscarViagemCompleta?dataPartida=" + v.data_Ida.ToString("MM/dd/yyyy") + "&origem=" + v.rot.origem_Rota + "&Destino=" + v.rot.destino_Rota + "&dataVolta=" + v.data_Volta.ToString("MM/dd/yyyy"));
            }
            else if (v.data_Volta == null && v.data_Ida == null && v.rot.origem_Rota != null && v.rot.destino_Rota != null)
            {
                repViagem.PesquisarViagemDestino(v.rot.origem_Rota, v.rot.destino_Rota);
                Response.Redirect("~/Viagens/BuscarViagemDestino?origem=" + v.rot.origem_Rota + "&Destino=" + v.rot.destino_Rota);
            }
            else if (v.data_Volta != null && v.data_Ida != null && v.rot.origem_Rota != null && v.rot.destino_Rota != null)
            {
                repViagem.PesquisarViagemCompleto(v.data_Ida, v.rot.origem_Rota, v.rot.destino_Rota, v.data_Volta);
                Response.Redirect("~/Viagens/BuscarViagemCompleta?dataPartida=" + v.data_Ida.ToString("MM/dd/yyyy") + "&origem=" + v.rot.origem_Rota + "&Destino=" + v.rot.destino_Rota + "&dataVolta=" + v.data_Volta.ToString("MM/dd/yyyy"));
            }
            else if (v.data_Volta == null)
            {
                repViagem.PesquisarViagemIda(v.data_Ida, v.rot.origem_Rota, v.rot.destino_Rota);
                Response.Redirect("~/Viagens/BuscarViagemIda?dataPartida=" + v.data_Ida.ToString("MM/dd/yyyy") + "&origem=" + v.rot.origem_Rota + "&Destino=" + v.rot.destino_Rota);
            }
            else
            {
                Response.Redirect("~/Viagens/");
            }
            return View(v);
        }

        public ActionResult Servicos()
        {
            ViewBag.Message = "Your service description page.";
            return View();
        }
        [HttpPost]
        public ActionResult Servicos(Viagem v)
        {
            if (v.data_Volta == Convert.ToDateTime("01/01/0001") && v.data_Ida == Convert.ToDateTime("01/01/0001") && v.rot.origem_Rota != null && v.rot.destino_Rota != null)
            {
                repViagem.PesquisarViagemCompleto(v.data_Ida, v.rot.origem_Rota, v.rot.destino_Rota, v.data_Volta);
                Response.Redirect("~/Viagens/BuscarViagemCompleta?dataPartida=" + v.data_Ida.ToString("MM/dd/yyyy") + "&origem=" + v.rot.origem_Rota + "&Destino=" + v.rot.destino_Rota + "&dataVolta=" + v.data_Volta.ToString("MM/dd/yyyy"));
            }
            else if (v.data_Volta == null && v.data_Ida == null && v.rot.origem_Rota != null && v.rot.destino_Rota != null)
            {
                repViagem.PesquisarViagemDestino(v.rot.origem_Rota, v.rot.destino_Rota);
                Response.Redirect("~/Viagens/BuscarViagemDestino?origem=" + v.rot.origem_Rota + "&Destino=" + v.rot.destino_Rota);
            }
            else if (v.data_Volta != null && v.data_Ida != null && v.rot.origem_Rota != null && v.rot.destino_Rota != null)
            {
                repViagem.PesquisarViagemCompleto(v.data_Ida, v.rot.origem_Rota, v.rot.destino_Rota, v.data_Volta);
                Response.Redirect("~/Viagens/BuscarViagemCompleta?dataPartida=" + v.data_Ida.ToString("MM/dd/yyyy") + "&origem=" + v.rot.origem_Rota + "&Destino=" + v.rot.destino_Rota + "&dataVolta=" + v.data_Volta.ToString("MM/dd/yyyy"));
            }
            else if (v.data_Volta == null)
            {
                repViagem.PesquisarViagemIda(v.data_Ida, v.rot.origem_Rota, v.rot.destino_Rota);
                Response.Redirect("~/Viagens/BuscarViagemIda?dataPartida=" + v.data_Ida.ToString("MM/dd/yyyy") + "&origem=" + v.rot.origem_Rota + "&Destino=" + v.rot.destino_Rota);
            }
            else
            {
                Response.Redirect("~/Viagens/");
            }
            return View(v);
        }

        public ActionResult Onibus()
        {
            ViewBag.Message = "Your bus service description page.";
            return View();
        }
        [HttpPost]
        public ActionResult Onibus(Viagem v)
        {
            if (v.data_Volta == Convert.ToDateTime("01/01/0001") && v.data_Ida == Convert.ToDateTime("01/01/0001") && v.rot.origem_Rota != null && v.rot.destino_Rota != null)
            {
                repViagem.PesquisarViagemCompleto(v.data_Ida, v.rot.origem_Rota, v.rot.destino_Rota, v.data_Volta);
                Response.Redirect("~/Viagens/BuscarViagemCompleta?dataPartida=" + v.data_Ida.ToString("MM/dd/yyyy") + "&origem=" + v.rot.origem_Rota + "&Destino=" + v.rot.destino_Rota + "&dataVolta=" + v.data_Volta.ToString("MM/dd/yyyy"));
            }
            else if (v.data_Volta == null && v.data_Ida == null && v.rot.origem_Rota != null && v.rot.destino_Rota != null)
            {
                repViagem.PesquisarViagemDestino(v.rot.origem_Rota, v.rot.destino_Rota);
                Response.Redirect("~/Viagens/BuscarViagemDestino?origem=" + v.rot.origem_Rota + "&Destino=" + v.rot.destino_Rota);
            }
            else if (v.data_Volta != null && v.data_Ida != null && v.rot.origem_Rota != null && v.rot.destino_Rota != null)
            {
                repViagem.PesquisarViagemCompleto(v.data_Ida, v.rot.origem_Rota, v.rot.destino_Rota, v.data_Volta);
                Response.Redirect("~/Viagens/BuscarViagemCompleta?dataPartida=" + v.data_Ida.ToString("MM/dd/yyyy") + "&origem=" + v.rot.origem_Rota + "&Destino=" + v.rot.destino_Rota + "&dataVolta=" + v.data_Volta.ToString("MM/dd/yyyy"));
            }
            else if (v.data_Volta == null)
            {
                repViagem.PesquisarViagemIda(v.data_Ida, v.rot.origem_Rota, v.rot.destino_Rota);
                Response.Redirect("~/Viagens/BuscarViagemIda?dataPartida=" + v.data_Ida.ToString("MM/dd/yyyy") + "&origem=" + v.rot.origem_Rota + "&Destino=" + v.rot.destino_Rota);
            }
            else
            {
                Response.Redirect("~/Viagens/");
            }
            return View(v);
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