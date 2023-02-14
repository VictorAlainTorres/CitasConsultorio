using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CitasConsultorio.Models.DTO.Cita
{
    public class CitaListar
    {
        public int IdCita { get; set; }
        public string NombrePaciente { get; set; }
        public string NombreDoctor { get; set; }
        public string EstatusAtencion { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dddd, dd MMMM yyyy h:mm tt}")]
        public DateTime FechaHora { get; set; }
    }
}