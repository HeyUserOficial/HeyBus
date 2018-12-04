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
            Passagem pass = new Passagem();
            pass.viag.id_Viagem = id;
            ViewBag.bancos = new SelectList(repPass.ProcurarBancos(), "assentos.id_Bancos", "assentos.banco");
            return View(repPass.Detalhes_Viagem(id));
        }

        [HttpPost]
        [ActionName ("Comprar")]
        public ActionResult Comprar()
        {
            Passagem pass = new Passagem();
            pass.oni.id_Onibus = Convert.ToInt32(Request["bancos"]);
            pass.cli.id_Cliente = Convert.ToInt32(Session["id_Cliente"]);
            repPass.Insert_Passagem(pass);
            return View(pass);
        }
    }
}