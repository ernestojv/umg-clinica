using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMG_Clinica {
    [Table("clinica")]
    public class Clinica {
        [Key]
        [Column("ID_clinica")]
        public int Nombre { get; }
        [Column("Nombre")]
        public int Direccion { get; }
        [Column("Direccion")]
        public string Telefono { get; set; }

    }
}


