using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CitasConsultorio.Models.DTO.Doctor
{
    public class DoctorListar
    {
        public int IdDoctor { get; set; }
        public string NombrePersona { get; set; }
        public string Sexo { get; set; }
        public int Edad { get; set; }
        public string Turno { get; set; }
    }
}