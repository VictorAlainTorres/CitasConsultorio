using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CitasConsultorio.Models.DTO.Paciente
{
    public class PacienteListar
    {
        public int IdPaciente { get; set; }
        public string NombrePersona { get; set; }
        public string Sexo { get; set; }
        public int Edad { get; set; }

    }
}