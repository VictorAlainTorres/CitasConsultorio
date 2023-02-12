using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CitasConsultorio.Models.DTO
{
    public class UsuarioEditar
    {
        public int IdPersona { get; set; }

        [Display(Name = "#")]
        public int IdUsuario { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "El Nombre de la Persona debe contener al menos 3 caracteres y máximo 150", MinimumLength = 3)]
        [Display(Name = "Nombre")]
        public string NombrePersona { get; set; }

        [Required]
        public int Edad { get; set; }

        [Required]
        public bool Sexo { get; set; }

        [Required]
        [Display(Name = "Usuario")]
        [Editable(false)]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Nueva Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Las contraseñas no coincidieron")]
        [Display(Name = "Confirmar Contraseña")]
        public string ConfirmPassword { get; set; }
    }
}