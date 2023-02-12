using CitasConsultorio.Models;
using CitasConsultorio.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CitasConsultorio.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public ActionResult Index()
        {
            List<UsuarioListar> usuarios;
            using (var db = new ConsultorioEntities())
            {
                usuarios = (from a in db.Usuario
                            where a.Activo
                            select new UsuarioListar
                            {
                                IdUsuario = a.IdUsuario,
                                Username = a.Username,
                                NombrePersona = a.Persona.NombrePersona
                            }).ToList();
            }

            return View(usuarios);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UsuarioAgregar model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new ConsultorioEntities())
            {
                Persona persona;
                if (model.IdPersona == 0)
                {
                    persona = new Persona
                    {
                        NombrePersona = model.NombrePersona,
                        Sexo = model.Sexo,
                        Edad = model.Edad,
                        Activo = true
                    };

                    db.Persona.Add(persona);
                }
                else
                {
                    persona = db.Persona.Find(model.IdPersona);

                    persona.NombrePersona = model.NombrePersona;
                    persona.Sexo = model.Sexo;
                    persona.Edad = model.Edad;

                    db.Entry(persona).State = System.Data.Entity.EntityState.Modified;
                }

                var usuario = new Usuario
                {
                    Persona = persona,
                    Username = model.Username,
                    Password = model.Password,
                    Activo = true
                };

                db.Usuario.Add(usuario);

                db.SaveChanges();

                ViewBag.MensajeUsuarioAgregado = "Se ha agregado correctamente el usuario " + model.Username;
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Update(int Id)
        {
            UsuarioEditar model;

            using (var db = new ConsultorioEntities())
            {
                var usuario = db.Usuario.Find(Id);

                model = new UsuarioEditar
                {
                    IdPersona = usuario.IdPersona,
                    IdUsuario = usuario.IdUsuario,
                    NombrePersona = usuario.Persona.NombrePersona,
                    Edad = usuario.Persona.Edad,
                    Sexo = usuario.Persona.Sexo,
                    Username = usuario.Username,
                };
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Update(UsuarioEditar model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new ConsultorioEntities())
            {
                Persona persona = db.Persona.Find(model.IdPersona);

                persona.NombrePersona = model.NombrePersona;
                persona.Sexo = model.Sexo;
                persona.Edad = model.Edad;

                if (model.Password != "")
                {
                    Usuario usuario = db.Usuario.Find(model.IdUsuario);

                    usuario.Password = model.Password;

                    db.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
                }
                

                db.Entry(persona).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
            }

            ViewBag.MensajeUsuarioEditado = "Se ha editado correctamente el usuario " + model.Username;

            return View(model);
        }

        [HttpPost]
        public JsonResult Delete(int Id)
        {
            ViewBag.MensajeUsuarioEliminado = null;
            using (var db = new ConsultorioEntities())
            {
                Usuario usuario = db.Usuario.Find(Id);

                usuario.Activo = false;

                db.Entry(usuario).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();

                ViewBag.MensajeUsuarioEliminado = "El usuario " + usuario.Username + " ha sido eliminado";
            }
            return Json(new { Eliminado = true}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ListarPersonas(string prefix)
        {
            using (var db = new ConsultorioEntities())
            {
                var personas = (from a in db.Persona
                            where a.NombrePersona.Contains(prefix)
                            select new { IdPersona = a.IdPersona, NombrePersona = a.NombrePersona, Sexo = a.Sexo, Edad = a.Edad }).ToList();
                return Json(personas, JsonRequestBehavior.AllowGet);
            }
        }
    }
}