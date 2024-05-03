using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UMG_Clinica.Models
{
    public class ClinicaDbContext : DbContext
    {
        public ClinicaDbContext() : base(ConfigurationManager.ConnectionStrings["dbClinica"].ConnectionString) { }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Cita> Cita { get; set; }
        public DbSet<Medicamento> Medicamento { get; set; } 
        public DbSet<Consulta_Medicina> Consulta_Medicina { get; set; } 
    }
}