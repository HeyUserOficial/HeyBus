using HeyBus.Models;
using HeyBus.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeyBus.Controllers
{
    public class AcessoController : Controller
    {
        RepositoryCliente repCli = new RepositoryCliente();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Cliente cli)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var autenticacao = repCli.Login_Cliente(cli);
                    if (autenticacao.Equals("Bem Vindo!"))
                    {
                        Session["cliente_Logado"] = cli;
                        return RedirectToAction("Index","Home");
                    }
                    else if (autenticacao.Equals("Sua senha está incorreta!"))
                    {
                        ModelState.AddModelError(string.Empty, autenticacao);
                    }
                    else if (autenticacao.Equals("Nome do usuário não encontrado!"))
                    {
                        ModelState.AddModelError(string.Empty, autenticacao);
                    }
                }

            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
            }
            return View(cli);
        }
    }
}