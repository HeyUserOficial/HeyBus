using HeyBus.Connection;
using HeyBus.Models;
using HeyBus.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace HeyBus.Controllers
{
    [Route("Clientes")]
    public class ClientesController : Controller
    {/*
        RepositoryCliente repCli = new RepositoryCliente();

        //GET
        // GET: Clientes
        public ActionResult Consultar()
        {
            List<Cliente> cli = repCli.Consultar_Cliente().ToList();
            return View(cli);
        }

        public ActionResult ClienteLista()
        {
            List<Cliente> cli = repCli.Consultar_Cliente().ToList();
            return View(cli);
        }

        //GET
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Cadastrar")]
        public ActionResult Cadastrar(Cliente cli)
        {
            if (ModelState.IsValid)
            {
                repCli.Insert_Cliente(cli);

                return RedirectToAction("Consultar");
            }

            return View();
        }

        public ActionResult Atualizar(int id)
        {
            return View(repCli.ConsultarPorId(id));
        }

        [HttpPost]
        [ActionName("Atualizar")]
        public ActionResult AtualizarCli(Cliente cli)
        {
            if (ModelState.IsValid)
            {
                repCli.Update_Cliente(cli);

                return RedirectToAction("Consultar");
            }
            return View();
        }
<<<<<<< HEAD
    */}
}
=======
    }
}    
>>>>>>> 302a6d4822827d78abbf2dfce2dc1988f736b803
