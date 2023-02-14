using CitasConsultorio.Models;
using CitasConsultorio.Models.DTO.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CitasConsultorio.Controllers
{
    public class DoctoresController : Controller
    {
        // GET: Doctores
        public ActionResult Index()
        {
            List<DoctorListar> lista;
            using (var db = new ConsultorioEntities())
            {
                lista = (from a in db.Doctor
                         where a.Activo
                         select new DoctorListar
                         {
                             IdDoctor = a.IdDoctor,
                             NombrePersona = a.Persona.NombrePersona,
                             Edad = a.Persona.Edad,
                             Sexo = a.Persona.Sexo ? "Masculino" : "Femenino",
                             Turno = a.Turno.NombreTurno
                         }).ToList();
            }

            return View(lista);
        }

        [HttpGet]
        public ActionResult Create()
        {
            using (var db = new ConsultorioEntities())
            {
                var turnos = (from a in db.Turno
                              where a.Activo == true
                              select new { a.IdTurno, a.NombreTurno }).ToList();
                ViewBag.Turnos = turnos;
            }

            return View();
        }

        [HttpPost]
        public ActionResult Create(DoctorAgregar model)
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

                var doctor = new Doctor
                {
                    Persona = persona,
                    IdTurno = model.IdTurno,
                    Activo = true
                };

                db.Doctor.Add(doctor);

                db.SaveChanges();

                ViewBag.MensajeDoctorAgregado = "Se ha agregado correctamente el Doctor " + model.NombrePersona;
            }

            ViewBag.Turnos = new Turno[0];
            return View(model);
        }

        [HttpGet]
        public ActionResult Update(int Id)
        {
            DoctorEditar model;

            using (var db = new ConsultorioEntities())
            {
                var doctor = db.Doctor.Find(Id);

                model = new DoctorEditar
                {
                    IdPersona = doctor.IdPersona,
                    IdDoctor = doctor.IdDoctor,
                    IdTurno = doctor.IdTurno,
                    NombrePersona = doctor.Persona.NombrePersona,
                    Edad = doctor.Persona.Edad,
                    Sexo = doctor.Persona.Sexo 
                };

                var turnos = (from a in db.Turno
                              where a.Activo == true
                              select new { a.IdTurno, a.NombreTurno }).ToList();
                ViewBag.Turnos = turnos;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Update(DoctorEditar model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new ConsultorioEntities())
            {
                var persona = db.Persona.Find(model.IdPersona);

                persona.NombrePersona = model.NombrePersona;
                persona.Sexo = model.Sexo;
                persona.Edad = model.Edad;

                var doctor = db.Doctor.Find(model.IdDoctor);

                doctor.IdTurno = model.IdTurno;

                db.Entry(persona).State = System.Data.Entity.EntityState.Modified;
                db.Entry(doctor).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
            }

            ViewBag.MensajeDoctorEditado = "Se ha editado correctamente el Doctor " + model.NombrePersona;
            ViewBag.Turnos = new Turno[0];

            return View(model);
        }

        [HttpPost]
        public JsonResult Delete(int Id)
        {
            using (var db = new ConsultorioEntities())
            {
                var doctor = db.Doctor.Find(Id);

                doctor.Activo = false;

                db.Entry(doctor).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
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