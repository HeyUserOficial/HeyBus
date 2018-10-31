using HeyBus.Models;
using HeyBus.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeyBus.Controllers
{
    public class ViagensController : Controller
    {
        RepositoryViagem repViagem = new RepositoryViagem();
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

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ActionName ("Cadastrar")]
        public ActionResult CadastrarViagem(Viagem viag)
        {
            if (ModelState.IsValid)
            {
                repViagem.Insert_Viagem(viag);
                return RedirectToAction("Consultar");
            }
            return View();
        }
    }
}