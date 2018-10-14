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
        /*private readonly ClientesRepository _repositorio; 
        // GET: Cliente
        
       /* public ClientesController(IConfiguration config)
        {
            _repositorio = new ClientesRepository(configuration.);
        }
        public ActionResult Index()
        {
            return View(_repositorio.GetAll());
        }

        [Route ("Details/{id}")]
        public ActionResult Details(int id)
        {
            return View(_repositorio.GetById(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, Route("Cadastrar")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Cliente cli)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repositorio.Create(cli);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, e.Message);
            }

            return View(cli);
        }

        [HttpPost, Route("Editar/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromRoute] int id, [FromForm] Cliente cli)
        {
            if(id != cli.id_Cliente)
                return BadRequest();

            var cod = _repositorio.GetById(id);

            if (cod == null)
            {
                return NotFound();
            }

            try
            {
                if (ModelState.IsValid)
                {
                    _repositorio.Update(cli);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
            }
            return cod;
        }

        [HttpPost, Route("Deletar/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Cliente cli)
        {
            if (id != cli.id_Cliente)
                return BadRequest();

            if (_repositorio.GetById(id) == null)
                return NotFound();

            try
            {
                _repositorio.Delete(cli);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(cli);
            }
        }*/
     }
}