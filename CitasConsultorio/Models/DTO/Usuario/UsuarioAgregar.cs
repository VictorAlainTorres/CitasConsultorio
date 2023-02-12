using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CitasConsultorio.Models.DTO
{
    public class UsuarioAgregar
    {
        public int IdPersona { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "El Nombre de la Persona debe contener al menos 3 caracteres y máximo 150", MinimumLength = 3)]
        [Display(Name = "Nombre")]
        public string NombrePersona { get; set; }

        [Required]
        public int Edad { get; set; }

        [Required]
        public bool Sexo { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "El Usuario debe contener al menos 3 caracteres y máximo 20", MinimumLength = 3)]
        [Display(Name = "Usuario")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Las contraseñas no coincidieron")]
        [Display(Name = "Confirmar Contraseña")]
        public string ConfirmPassword { get; set; }
    }
}