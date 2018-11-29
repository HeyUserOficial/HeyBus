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
        RepositoryFuncionario repFunc = new RepositoryFuncionario();
        RepositoryCliente repCli = new RepositoryCliente();

        [HttpGet]
        public ActionResult LoginCliente()
        {
            if(Session["cliente_logado"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginCliente(Acesso cli)
        {
            if (ModelState.IsValid)
            {
                var autenticacaoCli = repCli.Login_Cliente(cli);
                if (autenticacaoCli == true)
                {
                    var g = repCli.RetornaNome(cli.login_Acesso);
                    var k = repCli.RetornaId(cli.login_Acesso);
                    Session["cliente_logado"] = g;
                    Session["id_Cliente"] = k;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("ContaErradaCli", "Login está incorreto!");
                }
            }
            return View(cli);
        }

        public ActionResult LogoutCli()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult LoginFuncionario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginFuncionario(Acesso func)
        {
            if (ModelState.IsValid)
            {
                var autenticacaoFunc = repFunc.Login_Func(func);
                if(autenticacaoFunc == true)
                {
                    var t = repFunc.RetornarNome(func.login_Acesso);
                    Session["func_logado"] = t;
                    return RedirectToAction("IndexFunc", "Funcionarios");
                }
                else
                {
                    ModelState.AddModelError("ContaErradaFunc", "Login está incorreto!");
                }
            }
            return View(func);
        }

        public ActionResult LogoutFunc()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}