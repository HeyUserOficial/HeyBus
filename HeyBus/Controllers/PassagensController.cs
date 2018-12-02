using HeyBus.Models;
using HeyBus.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeyBus.Controllers
{

    public class PassagensController : Controller
    {
        RepositoryPassagem repPass = new RepositoryPassagem();
        // GET: Passagens

        public ActionResult Consultar()
        {
            List<Passagem> pass = repPass.Consultar_Passagens().ToList();
            return View(pass);
        }

        public ActionResult ConsultaPassagens()
        {
            List<Passagem> pass = repPass.Consultar_Passagens().ToList();
            return View(pass);
        }

        [HttpGet]
        public ActionResult Comprar(int id)
        {
            ViewBag.bancos = new SelectList(repPass.ProcurarBancos(), "assentos.id_Bancos", "assentos.num_Banco");
            return View(repPass.Detalhes_Viagem(id));
        }

        [HttpPost]
        [ActionName ("Comprar")]
        public ActionResult Comprar(Passagem pass)
        {
            repPass.Insert_Passagem(pass);
            return View(pass);
        }
    }
}