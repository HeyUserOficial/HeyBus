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
    {/*
        RepositoryCliente repCli = new RepositoryCliente();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost, Route("Cadastrar")]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Cliente cli)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repCli.Insert_Foreign_Cliente(cli);
                    repCli.Insert_Cliente(cli);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, e.Message);
            }
            return View(cli);
        }
     */}
}