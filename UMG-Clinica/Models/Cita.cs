using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UMG_Clinica.Models {
    [Table("Cita")]
    public class Cita {
        [Key]
        [Column("ID_Cita")]
        public int idCita { get; set; }
        [Column("Fecha_Hora")]
        public DateTime fechaHora { get; set; }
        [Column("Estado")]
        public string estado { get; set; }
        [Column("ID_Clinica")]
        public int idClinica { get; set; }
        [Column("ID_Paciente")]
        public int idPaciente { get; set; }
        [Column("ID_Empleado")]
        public int idEmpleado { get; set; }
    }
}