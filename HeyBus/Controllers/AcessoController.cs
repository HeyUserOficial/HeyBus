﻿using HeyBus.Models;
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
            return View();
        }

        [HttpPost]
        public ActionResult LoginCliente(Cliente cli)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var autenticacaoCli = repCli.Login_Cliente(cli);
                    if (autenticacaoCli.Equals("Bem Vindo!"))
                    {
                        Session["cliente_Logado"] = cli;
                        return RedirectToAction("Index","Home");
                    }
                    else if (autenticacaoCli.Equals("Sua senha está incorreta!"))
                    {
                        ModelState.AddModelError(string.Empty, autenticacaoCli);
                    }
                    else if (autenticacaoCli.Equals("Nome do usuário não encontrado!"))
                    {
                        ModelState.AddModelError(string.Empty, autenticacaoCli);
                    }
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
            }
            return View(cli);
        }

        [HttpGet]
        public ActionResult LoginFuncionario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginFuncionario(Funcionario func)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var autenticacaoFunc = repFunc.Login_Func(func);
                    if (autenticacaoFunc.Equals("Bem vindo!"))
                    {
                        Session["funcionario_Logado"] = func;
                        return RedirectToAction("Index", "Home");
                    }
                    else if (autenticacaoFunc.Equals("Sua senha está incorreta!"))
                    {
                        ModelState.AddModelError(string.Empty, autenticacaoFunc);
                    }
                    else if (autenticacaoFunc.Equals("Nome do usuário não encontrado!"))
                    {
                        ModelState.AddModelError(string.Empty, autenticacaoFunc);
                    }
                    }
                }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
            }
            return View(func);
        }

    }
}