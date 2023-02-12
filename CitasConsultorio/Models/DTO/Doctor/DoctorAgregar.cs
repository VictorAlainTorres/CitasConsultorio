using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CitasConsultorio.Models.DTO.Doctor
{
    public class DoctorAgregar
    {
        public int IdPersona { get; set; }

        [Required]
        [Display(Name = "Turno")]
        public int IdTurno { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "El Nombre del Doctor debe contener al menos 3 caracteres y máximo 150", MinimumLength = 3)]
        [Display(Name = "Nombre del Doctor")]
        public string NombrePersona { get; set; }

        [Required]
        public int Edad { get; set; }

        [Required]
        public bool Sexo { get; set; }
    }
}