using CitasConsultorio.Models;
using CitasConsultorio.Models.DTO.Paciente;
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
            List<PacienteListar> lista;
            using (var db = new ConsultorioEntities())
            {
                lista = (from a in db.Paciente
                            where a.Activo
                            select new PacienteListar
                            {
                                IdPaciente = a.IdPaciente,
                                NombrePersona = a.Persona.NombrePersona,
                                Edad = a.Persona.Edad,
                                Sexo = a.Persona.Sexo ? "Masculino" : "Femenino"
                            }).ToList();
            }

            return View(lista);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PacienteAgregar model)
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

                var paciente = new Paciente
                {
                    Persona = persona,
                    Activo = true
                };

                db.Paciente.Add(paciente);

                db.SaveChanges();

                ViewBag.MensajePacienteAgregado = "Se ha agregado correctamente el paciente " + model.NombrePersona;
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Update(int Id)
        {
            PacienteEditar model;

            using (var db = new ConsultorioEntities())
            {
                var paciente = db.Paciente.Find(Id);

                model = new PacienteEditar
                {
                    IdPersona = paciente.IdPersona,
                    IdPaciente = paciente.IdPaciente,
                    NombrePersona = paciente.Persona.NombrePersona,
                    Edad = paciente.Persona.Edad,
                    Sexo = paciente.Persona.Sexo,
                };
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Update(PacienteEditar model)
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

                db.Entry(persona).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
            }

            ViewBag.MensajePacienteEditado = "Se ha editado correctamente el paciente " + model.NombrePersona;

            return View(model);
        }

        [HttpPost]
        public JsonResult Delete(int Id)
        {
            ViewBag.MensajePacienteEliminado = null;
            using (var db = new ConsultorioEntities())
            {
                var paciente = db.Paciente.Find(Id);

                paciente.Activo = false;

                db.Entry(paciente).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();

                ViewBag.MensajePacienteEliminado = "El paciente " + paciente.Persona.NombrePersona + " ha sido eliminado";
            }
            return Json(new { Eliminado = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ListarPersonas(string prefix)
        {
            using (var db = new ConsultorioEntities())
            {
                var personas = (from a in db.Persona
                                where a.NombrePersona.Contains(prefix) && a.Activo == true
                                select new { IdPersona = a.IdPersona, NombrePersona = a.NombrePersona, Sexo = a.Sexo, Edad = a.Edad }).ToList();
                return Json(personas, JsonRequestBehavior.AllowGet);
            }
        }

    }
}