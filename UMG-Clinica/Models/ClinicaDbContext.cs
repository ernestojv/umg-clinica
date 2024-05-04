using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UMG_Clinica.Models {
    public class ClinicaDbContext : DbContext {
        public ClinicaDbContext() : base(ConfigurationManager.ConnectionStrings["dbClinica"].ConnectionString) { }
        public DbSet<Cita> Cita { get; set; }

        public DbSet<Clinica> Clinica { get; set; }

        public DbSet<Consulta> Consulta { get; set; }

        public DbSet<ConsultaEnfermedad> ConsultaEnfermedad { get; set; }

        public DbSet<ConsultaMedicina> ConsultaMedicina { get; set; }

        public DbSet<Empleado> Empleado { get; set; }

        public DbSet<Enfermedad> Enfermedad { get; set; }
        public DbSet<Medicamento> Medicamento { get; set; }

        public DbSet<Paciente> Paciente { get; set; }

        public DbSet<Usuario> Usuario { get; set; }
    }
}