using CitasConsultorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CitasConsultorio.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Entrar(string username, string password)
        {
            try
            {
                using (var db = new ConsultorioEntities())
                {
                    var usuario = (from a in db.Usuario
                                  where a.Username == username && a.Password == password && a.Activo == true
                                  select a).FirstOrDefault();

                    if (usuario == null)
                    {
                        return Content("El Usuario o la Contraseña no son válidos.");
                    } else
                    {
                        Session["usuario"] = usuario;
                        return Content("1");
                    }
                }
            }
            catch (Exception ex)
            {
                return Content("Error: " + ex.Message);
            }
        }
    }
}