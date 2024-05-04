using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using UMG_Clinica.Models;

namespace UMG_Clinica {

    [Table("Consulta")]
    public class Consulta {
        [Key]
        [Column("ID_Consulta")]
        public int IdConsulta { get; set; }

        [Column("Observaciones")]
        public string Observaciones { get; set; }


        [Column("Fecha")]
        public DateTime Fecha { get; set; }

        [Column("ID_Clinica")]
        [ForeignKey("Clinica")]
        public string IdClinica { get; set; }
        public virtual Clinica Clinica { get; set; }


        [Column("ID_Paciente")]
        [ForeignKey("Paciente")]
        public int IdPaciente { get; set; }
        public virtual Paciente Paciente { get; set; }


        [Column("ID_Empleado")]
        [ForeignKey("Empleado")]
        public int IdEmpleado { get; set; }
        public virtual Empleado Empleado { get; set; }


        [Column("ID_Cita")]
        [ForeignKey("Cita")]
        public int IdCita { get; set; }
        public virtual Cita Cita { get; set; }

    }
}

