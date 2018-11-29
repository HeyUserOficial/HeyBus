using HeyBus.Models;
using HeyBus.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeyBus.Controllers
{
    [Route("Funcionarios")]
    public class FuncionariosController : Controller
    {
        RepositoryFuncionario repFunc = new RepositoryFuncionario();
        
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Cadastrar")]
        public ActionResult Cadastrar(Funcionario func)
        {
            if (ModelState.IsValid)
            {
                repFunc.Insert_Func(func);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Alterar(int id)
        {
            return View(repFunc.BuscarPorId(id));
        }

        [HttpPost]
        [ActionName("Alterar")]
        public ActionResult Alterar(Funcionario func)
        {
            if (ModelState.IsValid)
            {
                repFunc.Update_Func(func);
                return RedirectToAction("IndexFunc");
            }
            return View();
        }

        public ActionResult Consultar()
        {           
            List<Funcionario> func = repFunc.Consultar_Func().ToList();
            return View(func);
        }

        public ActionResult ListaFunc()
        {
            List<Funcionario> func = repFunc.Consultar_Func().ToList();
            return View(func);
        }

        public ActionResult IndexFunc()
        {
            return View();
        }

        public JsonResult GetFiltrarDados(string Filtros, string ValorFiltro)
        {
            List<Funcionario> func = new List<Funcionario>();
            if (Filtros == "ID")
            {
                try
                {
                    int ID = Convert.ToInt32(ValorFiltro);
                    func = repFunc.ProcurarPorID(ID).ToList();
                }
                catch (FormatException)
                {
                    Console.WriteLine("{0} Não é um ID ", ValorFiltro);
                }
                return Json(func, JsonRequestBehavior.AllowGet);
            }
            else if (Filtros == "CPF")
            {
                func = repFunc.ProcurarPorCPF(ValorFiltro).ToList();
                return Json(func, JsonRequestBehavior.AllowGet);
            }
            else
            {
                func = repFunc.ProcurarPorNome(ValorFiltro).ToList();
                return Json(func, JsonRequestBehavior.AllowGet);
            }
        }
    }
}