using HeyBus.Models;
using HeyBus.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeyBus.Controllers
{
    public class OnibusController : Controller
    {
        RepositoryOnibus repBus = new RepositoryOnibus();

        // GET: Onibus
        public ActionResult Consultar()
        {
            List<Onibus> bus = repBus.Consultar_Onibus().ToList();
            return View(bus);
        }

        public ActionResult Consultar_Bus()
        {
            List<Onibus> bus = repBus.Consultar_Onibus().ToList();
            return View(bus);
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Cadastrar")]
        public ActionResult Cadastrar_Bus(Onibus bus)
        {
            if (ModelState.IsValid)
            {
                repBus.Cadastrar_Onibus(bus);
                return RedirectToAction("Consultar");
            }
            return View();
        }
        
        public ActionResult Atualizar(int id)
        {
            return View(repBus.Consultar_OnibusID(id));
        }

        [HttpPost]
        [ActionName ("Atualizar")]
        public ActionResult AtualizarOni(Onibus bus)
        {
            if (ModelState.IsValid)
            {
                repBus.Update_Onibus(bus);
                return RedirectToAction("Consultar");
            }
            return View();
        }
    }
}