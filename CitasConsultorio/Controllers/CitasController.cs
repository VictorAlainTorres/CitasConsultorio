using CitasConsultorio.Models;
using CitasConsultorio.Models.DTO.Cita;
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
            List<CitaListar> lista;
            using (var db = new ConsultorioEntities())
            {
                lista = (from a in db.Cita
                         where a.IdEstatusAtencion != 2 && a.EstatusAtencion.Activo
                         orderby a.IdEstatusAtencion, a.FechaHoraInicio
                         select new CitaListar
                         {
                             IdCita = a.IdCita,
                             NombrePaciente = a.Paciente.Persona.NombrePersona,
                             NombreDoctor = a.Doctor.Persona.NombrePersona,
                             EstatusAtencion = a.EstatusAtencion.NombreEstatusAtencion,
                             FechaHora = a.FechaHoraInicio
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
        public ActionResult Create(CitaAgregar model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new ConsultorioEntities())
            {
                var cita = new Cita
                {
                    IdPaciente = model.IdPaciente,
                    IdDoctor = model.IdDoctor,
                    IdEstatusAtencion = 1,
                    FechaHoraInicio = model.FechaHoraInicio,
                    FechaHoraFin = model.FechaHoraInicio.AddMinutes(20),
                    PesoPaciente = model.PesoPaciente,
                    Alergias = model.Alergias ?? "",
                    FechaInsert = DateTime.Now,
                    IdUsuarioInsert = ((Usuario)Session["usuario"]).IdUsuario,
                    AntecedentesMedicos = "",
                    Diagnostico = "",
                    Receta = "",
                    Sintomas = ""
                };

                db.Cita.Add(cita);

                db.SaveChanges();

                ViewBag.MensajeCitaAgregada = "Se ha añadido la cita con Id " + cita.IdCita;
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Update(int Id)
        {
            CitaEditar model;

            using (var db = new ConsultorioEntities())
            {
                var cita = db.Cita.Find(Id);

                model = new CitaEditar
                {
                    IdCita = cita.IdCita,
                    FechaHoraInicio = cita.FechaHoraInicio,
                    NombrePaciente = cita.Paciente.Persona.NombrePersona,
                    NombreDoctor = cita.Doctor.Persona.NombrePersona,
                    Edad = cita.Paciente.Persona.Edad,
                    Sexo = cita.Paciente.Persona.Sexo ? "Masculino" : "Femenino",
                    PesoPaciente = cita.PesoPaciente,
                    Alergias = cita.Alergias,
                    AntecedentesMedicos = cita.AntecedentesMedicos,
                    Sintomas = cita.Sintomas,
                    Diagnostico = cita.Diagnostico,
                    Receta = cita.Receta,
                };
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Update(CitaEditar model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new ConsultorioEntities())
            {
                var cita = db.Cita.Find(model.IdCita);

                cita.AntecedentesMedicos = model.AntecedentesMedicos;
                cita.Sintomas = model.Sintomas;
                cita.Diagnostico = model.Diagnostico;
                cita.IdEstatusAtencion = 3;
                cita.Receta = model.Receta;
                cita.FechaUpdate = DateTime.Now;
                cita.IdUsuarioUpdate = ((Usuario)Session["usuario"]).IdUsuario;

                db.Entry(cita).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
            }

            ViewBag.MensajeCitaAtendida = "La cita con Id " + model.IdCita + " ha sido atendida";

            return View(model);
        }

        [HttpPost]
        public JsonResult Delete(int Id)
        {
            using (var db = new ConsultorioEntities())
            {
                var cita = db.Cita.Find(Id);

                cita.IdEstatusAtencion = 2;
                cita.FechaDelete = DateTime.Now;
                cita.IdUsuarioDelete = ((Usuario)Session["usuario"]).IdUsuario;

                db.Entry(cita).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
            }

            return Json(new { Cancelada = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ListarPacientes(string prefix)
        {
            using (var db = new ConsultorioEntities())
            {
                var personas = (from a in db.Persona
                                join b in db.Paciente on a equals b.Persona
                                where a.NombrePersona.Contains(prefix) && a.Activo && b.Activo
                                select new { IdPersona = b.IdPaciente, NombrePersona = a.NombrePersona, Sexo = a.Sexo, Edad = a.Edad }).ToList();
                return Json(personas, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult ListarDoctores(string prefix)
        {
            using (var db = new ConsultorioEntities())
            {
                var personas = (from a in db.Persona
                                join b in db.Doctor on a equals b.Persona
                                where a.NombrePersona.Contains(prefix) && a.Activo && b.Activo
                                select new { IdPersona = b.IdDoctor, NombrePersona = a.NombrePersona }).ToList();
                return Json(personas, JsonRequestBehavior.AllowGet);
            }
        }
    }
}