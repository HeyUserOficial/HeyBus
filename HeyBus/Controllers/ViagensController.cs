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
            if (ModelState.IsValid)
            {
                vi.oni.id_Onibus = Convert.ToInt32(Request["viacao"]);
                vi .rot.id_Rota = Convert.ToInt32(Request["destino"]);
                repViagem.Insert_Viagem(vi);
            }
            return View(vi);
        }

        [HttpGet]
        public ActionResult ComprarPassagem(int id)
        {
            Viagem v = new Viagem();
            v.assentos.bancos = new int[v.assentos.banco];
            return View(repViagem.Detalhes_Viagem(id));
        }

        [HttpGet]
        public ActionResult BuscarViagemCompleta(DateTime? dataPartida, string origem, string destino, DateTime? dataVolta)
        {
            var listaViag = repViagem.PesquisarViagemCompleto(dataPartida, origem, destino, dataVolta);
            return View(listaViag);
        }

      

        [HttpGet]
        public ActionResult BuscarViagemIda(DateTime? dataPartida, string origem, string destino)
        {
            var g = repViagem.PesquisarViagemIda(dataPartida, origem, destino);
            return View(g);
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
        [ValidateAntiForgeryToken]
        public ActionResult FiltroTeste(DateTime? dataPartida, string origem, string destino, DateTime? dataVolta)
        {
            Viagem v = new Viagem();
            if (ModelState.IsValid)
            {
                repViagem.PesquisarViagemCompleto(v.data_Ida, v.rot.origem_Rota, v.rot.destino_Rota, v.data_Volta);
                RedirectToAction("BuscarViagemCompleta", new { dataPartida = v.data_Ida, origem = v.rot.origem_Rota, destino = v.rot.destino_Rota, dataVolta = v.data_Volta });
            }
            return View(v);
        }
    }
}
/*  [HttpGet]
        public ActionResult Cadastrar()
        {
            Viagem viag = new Viagem();
            viag.oni.PuxarOnibus = PegarOnibus();
            viag.oni.PuxarCategoria = PegarCategoria();
            viag.rot.PuxarRota = ew SelectList(PegarRota(), "Value", "Text");
            viag.rot.PuxarOrigem = new SelectList(PegarOrigem(), "Value", "Text");
            return View(viag);
        }

        [HttpPost]
        [ActionName("Cadastrar")]
        public ActionResult CadastrarViagem(Viagem viag)
        {
            if (ModelState.IsValid)
            {
                repViagem.Insert_Viagem(viag);
                return RedirectToAction("Consultar");
            }
            return View(viag);
        }

        public IEnumerable<SelectListItem> PegarOnibus()
        {
            var onibus = repViagem.ProcurarOnibus().
             Select(v => new SelectListItem
             {
                 Value = v.oni.id_Onibus.ToString(),
                 Text = v.oni.viacao_Onibus,
             });
            return new SelectList(onibus, "Value", "Text");
        }

        public IEnumerable<SelectListItem> PegarCategoria()
        {
            var v = TrazerCategoria().
                Select(c => new SelectListItem
                {
                    Value = c.oni.id_Onibus.ToString(),
                    Text = c.oni.categoria_Onibus,
                });
            return new SelectList(v, "Value", "Text");
        }


        public IEnumerable<SelectListItem> PegarRota()
        {
            var g = repViagem.ProcurarRota().
                Select(h => new SelectListItem
                {
                    Value = h.rot.id_Rota.ToString(),
                    Text = h.rot.destino_Rota
                });
            return new SelectList(g, "Value", "Text");
        }

        public IEnumerable<SelectListItem> PegarOrigem()
        {
            var j = ProcurarOrigem().
                Select(o => new SelectListItem
                {
                    Value = o.rot.id_Rota.ToString(),
                    Text = o.rot.origem_Rota
                });
            return new SelectList(j, "Value", "Text");
        }

        [NonAction]
        public IEnumerable<Viagem> ProcurarOrigem()

        {
            Viagem rota = new Viagem();
            List<Viagem> listaRota = new List<Viagem>();
            var b = PegarRota();
            try
            {
                using (cmd = new MySqlCommand("Select * from Rota where id_Rota = @id", Conexao.conexao))
                {
                    conn.abrirConexao();
                    cmd.Parameters.AddWithValue("@id", b.FirstOrDefault().Value);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        rota.rot.id_Rota = Convert.ToInt32(dr["id_Rota"]);
                        rota.rot.origem_Rota = dr["origem_Rota"].ToString();
                        listaRota.Add(rota);
                    }
                    dr.Close();
                    return listaRota;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
*/