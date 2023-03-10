//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CitasConsultorio.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cita
    {
        public int IdCita { get; set; }
        public int IdPaciente { get; set; }
        public int IdDoctor { get; set; }
        public int IdEstatusAtencion { get; set; }
        public System.DateTime FechaHoraInicio { get; set; }
        public System.DateTime FechaHoraFin { get; set; }
        public decimal PesoPaciente { get; set; }
        public string Alergias { get; set; }
        public string AntecedentesMedicos { get; set; }
        public string Sintomas { get; set; }
        public string Diagnostico { get; set; }
        public string Receta { get; set; }
        public System.DateTime FechaInsert { get; set; }
        public Nullable<System.DateTime> FechaUpdate { get; set; }
        public Nullable<System.DateTime> FechaDelete { get; set; }
        public int IdUsuarioInsert { get; set; }
        public Nullable<int> IdUsuarioUpdate { get; set; }
        public Nullable<int> IdUsuarioDelete { get; set; }
    
        public virtual Doctor Doctor { get; set; }
        public virtual EstatusAtencion EstatusAtencion { get; set; }
        public virtual Paciente Paciente { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Usuario Usuario1 { get; set; }
        public virtual Usuario Usuario2 { get; set; }
    }
}
