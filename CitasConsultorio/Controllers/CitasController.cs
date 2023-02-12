using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CitasConsultorio.Controllers
{
    public class CitasController : Controller
    {
        // GET: Cita
        public ActionResult Index()
        {
            return View();
        }
    }
}