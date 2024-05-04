using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UMG_Clinica.Models {
    [Table("Cita")]
    public class Cita {
        [Key]
        [Column("ID_Cita")]
        public int IdCita { get; set; }

        [Column("Fecha_Hora")]
        public DateTime FechaHora { get; set; }

        [Column("Estado")]
        public string Estado { get; set; }

        [Column("ID_Clinica")]
        [ForeignKey("Clinica")]
        public int IdClinica { get; set; }
        public virtual Clinica Clinica { get; set; }

        [Column("ID_Paciente")]
        [ForeignKey("Paciente")]
        public int IdPaciente { get; set; }
        public virtual Paciente Paciente { get; set; }

        [Column("ID_Empleado")]
        [ForeignKey("Empleado")]
        public int IdEmpleado { get; set; }
        public virtual Empleado Empleado { get; set; }

    }
}