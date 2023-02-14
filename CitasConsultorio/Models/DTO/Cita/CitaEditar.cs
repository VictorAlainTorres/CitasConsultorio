using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CitasConsultorio.Models.DTO.Cita
{
    public class CitaEditar
    {
        public int IdCita { get; set; }

        [Display(Name = "Fecha y Hora de la Cita")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dddd, dd MMMM yyyy h:mm tt}")]
        public DateTime FechaHoraInicio { get; set; }

        [Display(Name = "Paciente")]
        public string NombrePaciente { get; set; }
        [Display(Name = "Doctor")]
        public string NombreDoctor { get; set; }

        public int Edad { get; set; }
        public string Sexo { get; set; }

        [Display(Name = "Peso del Paciente")]
        public decimal PesoPaciente { get; set; }

        public string Alergias { get; set; }

        [Required]
        [Display(Name = "Antecedentes Medicos")]
        public string AntecedentesMedicos { get; set; }

        [Required]
        public string Sintomas { get; set; }

        [Required]
        public string Diagnostico { get; set; }

        [Required]
        public string Receta { get; set; }
    }
}