using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HeyBus.Controllers
{
    public class SharedController : Controller
    {
        // GET: Shared
        public ActionResult _Layout()
        {
            if (Session["cliente_logado"] == null)
            {

            }
            else
            {
                ViewBag.Nome = Session["cliente_logado"];              
                return View();
            }
            return View();
        }
    }
}