using HeyBus.Models;
using HeyBus.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeyBus.Controllers
{
    public class RotasController : Controller
    {
        RepositoryRota repRota = new RepositoryRota();

        [HttpGet]
        public ActionResult Consultar()
        {
            List<Rota> rota = repRota.Consultar_Rotas().ToList();
            return View(rota);
        }

        public ActionResult ConsultarRotas()
        {
            List<Rota> rota = repRota.Consultar_Rotas().ToList();
            return View(rota);
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();          
        }

        [HttpPost]
        [ActionName ("Cadastrar")]
        public ActionResult CadastrarRotas(Rota rot)
        {
            if (ModelState.IsValid)
            {
                repRota.Insert_Rota(rot);
                return RedirectToAction("Consultar");
            }
            return View();
        }

        public ActionResult Alterar(int id)
        {
            return View(repRota.Consultar_Rota(id));
        }

        [HttpPost]
        [ActionName("Alterar")]
        public ActionResult AlterarRota(Rota rot)
        {
            if (ModelState.IsValid)
            {
                repRota.Update_Rota(rot);
                RedirectToAction("Consultar");
            }
            return View();
        }

        public JsonResult GetFiltrarDados(string Filtros, string ValorFiltro)
        {
            List<Rota> rot = new List<Rota>();
            if (Filtros == "ID")
            {
                try
                {
                    int ID = Convert.ToInt32(ValorFiltro);
                    rot = repRota.ProcurarPorID(ID).ToList();
                }
                catch (FormatException)
                {
                    Console.WriteLine("{0} Não é um ID ", ValorFiltro);
                }
                return Json(rot, JsonRequestBehavior.AllowGet);
            }
            else if (Filtros == "Destino")
            {
                rot = repRota.ProcurarPorDestino(ValorFiltro).ToList();
                return Json(rot, JsonRequestBehavior.AllowGet);
            }
            else
            {
                rot = repRota.ProcurarPorOrigem(ValorFiltro).ToList();
                return Json(rot, JsonRequestBehavior.AllowGet);
            }
        }
    }
}