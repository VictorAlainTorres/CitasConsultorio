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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ConsultorioEntities : DbContext
    {
        public ConsultorioEntities()
            : base("name=ConsultorioEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<EstatusAtencion> EstatusAtencion { get; set; }
        public virtual DbSet<Paciente> Paciente { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<Turno> Turno { get; set; }
        public virtual DbSet<Cita> Cita { get; set; }
    }
}
