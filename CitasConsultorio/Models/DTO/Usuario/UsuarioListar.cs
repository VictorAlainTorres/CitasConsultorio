using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CitasConsultorio.Models.DTO
{
    public class UsuarioListar
    {
        public int IdUsuario { get; set; }
        public string Username { get; set; }
        public string NombrePersona { get; set; }
    }
}