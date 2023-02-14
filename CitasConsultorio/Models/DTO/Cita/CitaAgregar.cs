using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CitasConsultorio.Models.DTO.Cita
{
    public class CitaAgregar
    {
        [Range(1, int.MaxValue, ErrorMessage = "No ha seleccionado un Paciente")]
        public int IdPaciente { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "No ha seleccionado un Doctor")]
        public int IdDoctor { get; set; }

        [Display(Name = "Fecha y Hora de la Cita")]
        [Required(ErrorMessage = "Favor de ingresar la Fecha y Hora de la Cita")]
        public DateTime FechaHoraInicio { get; set; }

        [Display(Name = "Paciente")]
        public string NombrePaciente { get; set; }
        [Display(Name = "Doctor")]
        public string NombreDoctor { get; set; }

        public int Edad { get; set; }
        public string Sexo { get; set; }

        [Required]
        [Display(Name = "Peso del Paciente")]
        public decimal PesoPaciente { get; set; }
        public string Alergias { get; set; }
    }
}