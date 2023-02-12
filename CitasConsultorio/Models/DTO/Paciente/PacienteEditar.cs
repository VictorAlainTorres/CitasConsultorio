using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CitasConsultorio.Models.DTO.Paciente
{
    public class PacienteEditar
    {
        public int IdPersona { get; set; }

        [Display(Name = "#")]
        public int IdPaciente { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "El Nombre del Paciente debe contener al menos 3 caracteres y máximo 150", MinimumLength = 3)]
        [Display(Name = "Nombre del Paciente")]
        public string NombrePersona { get; set; }

        [Required]
        public int Edad { get; set; }

        [Required]
        public bool Sexo { get; set; }
    }
}