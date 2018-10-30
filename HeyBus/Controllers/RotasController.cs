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
        // GET: Rotas
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
                RedirectToAction("");
            }
        }
    }
}