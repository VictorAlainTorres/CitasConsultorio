using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CitasConsultorio.Controllers
{
    public class PacientesController : Controller
    {
        // GET: Pacientes
        public ActionResult Index()
        {
            return View();
        }
    }
}