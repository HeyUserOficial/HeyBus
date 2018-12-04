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
    public class ViagensController : Controller
    {
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader dr;
        RepositoryViagem repViagem = new RepositoryViagem();
        Conexao conn = new Conexao();
        // GET: Viagens
        [HttpGet]
        public ActionResult Consultar()
        {
            List<Viagem> viagem = repViagem.Consultar_Viagens().ToList();
            return View(viagem);
        }

        public ActionResult ConsultarViagens()
        {
            List<Viagem> viagem = repViagem.Consultar_Viagens().ToList();
            return View(viagem);
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            Viagem viag = new Viagem();
            ViewBag.viacao = new SelectList(repViagem.ProcurarOnibus(), "oni.id_Onibus", "oni.viacao_Onibus");
            ViewBag.destino = new SelectList(repViagem.ProcurarRota(), "rot.id_Rota", "rot.destino_Rota");
            viag.oni.id_Onibus = Convert.ToInt32(Request["viacao"]);
            viag.rot.id_Rota = Convert.ToInt32(Request["destino"]);
            return View(viag);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Cadastrar")]
        public ActionResult Cadastrar(Viagem vi)
        {
            vi.oni.id_Onibus = Convert.ToInt32(Request["viacao"]);
            vi.rot.id_Rota = Convert.ToInt32(Request["destino"]);
            repViagem.Insert_Viagem(vi);
            return View(vi);
        }


        [HttpGet]
        public ActionResult BuscarViagemCompleta(DateTime? dataPartida, string origem, string destino, DateTime? dataVolta)
        {
            List<Viagem> listaViag = new List<Viagem>();
            if (dataPartida.HasValue && dataVolta.HasValue)
            {
                listaViag = repViagem.PesquisarViagemCompleto(dataPartida, origem, destino, dataVolta).ToList();
            }
            return View(listaViag);
        }

        [HttpGet]
        public ActionResult BuscarViagemIda(DateTime? dataPartida, string origem, string destino)
        {
            List<Viagem> listaViag = new List<Viagem>();
            listaViag = repViagem.PesquisarViagemIda(dataPartida, origem, destino).ToList();
            return View(listaViag);
        }

        [HttpGet]
        public ActionResult BuscarViagemDestino(string origem, string destino)
        {
            List<Viagem> listaViag = new List<Viagem>();
            listaViag = repViagem.PesquisarViagemDestino(origem, destino).ToList();
            return View(listaViag);
        }

        [HttpGet]
        public ActionResult FiltroTeste()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FiltroTeste(Viagem v)
        {
           repViagem.PesquisarViagemCompleto(v.data_Ida, v.rot.origem_Rota, v.rot.destino_Rota, v.data_Volta);
           Response.Redirect("BuscarViagemCompleta?dataPartida=" +v.data_Ida.ToString("MM/dd/yyyy")+"&origem="+v.rot.origem_Rota + "&Destino=" + v.rot.destino_Rota + "&dataVolta="+ v.data_Volta.ToString("MM/dd/yyyy"));
           return View(v);
        }
    }
}