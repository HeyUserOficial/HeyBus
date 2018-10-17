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

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Cadastrar(Cliente cli)
        {
            return View(cli);
        }
     }
}