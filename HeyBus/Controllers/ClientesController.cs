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
    public class ClientesController : Controller
    {
        Cliente cli = new Cliente();
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Teste()
        {
            RepositorioCliente clienteRep = new RepositorioCliente();
            cli.cpf_Cliente = "132424";
            cli.nome_Cliente = "Yuri";
            cli.nascimento_Cliente = DateTime.Now;
            cli.cel_Cliente = "111111";
            cli.tel_Cliente = "292929";
            cli.email_Cliente = "yuri@";

            if (clienteRep.Insert_Cliente(cli))
            {
                return View("Funcionou");
            }
            else
            {
                return View("Nao");
            }
        }

    }

}