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
    [Route ("Clientes")]
    public class ClientesController : Controller
    {
        RepositoryCliente repCli = new RepositoryCliente();

        //GET
        public ActionResult Index()
        {
            RepositoryCliente repCli = new RepositoryCliente();
            List<Cliente> cli = repCli.Consultar_Cliente().ToList();
            return View(cli);
        }

        public ActionResult ClienteLista()
        {
            RepositoryCliente repCli = new RepositoryCliente();
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
                RepositoryCliente repCli = new RepositoryCliente();
                repCli.Insert_Cliente(cli);

                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Atualizar()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Atualizar")]
        public ActionResult Atualizar(Cliente cli)
        {
            if (ModelState.IsValid)
            {
                RepositoryCliente repCli = new RepositoryCliente();
                repCli.Update_Cliente(cli);

                return RedirectToAction("Index");
            }
            return View();
        }
    }
}