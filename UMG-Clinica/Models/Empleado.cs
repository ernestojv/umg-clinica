using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UMG_Clinica.Models {
    [Table("Empleado")]
    public class Empleado {
        [Key]
        [Column("ID_Empleado")]
        public int IdEmpleado { get; set; }

        [Column("Nombre")]
        public string Nombre { get; set; }

        [Column("Puesto")]
        public string Puesto { get; set; }

        [Column("Numero_de_telefono")]
        public string NumeroDeTelefono { get; set; }

        [Column("dpi")]
        public string Dpi { get; set; }

        [Column("Nombre_de_usuario")]
        [ForeignKey("Usuario")]
        public string NombreDeUsuario { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
