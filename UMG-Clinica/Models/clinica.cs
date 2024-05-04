using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UMG_Clinica {
    [Table("clinica")]
    public class Clinica {
        [Key]
        [Column("ID_clinica")]
        public int Nombre { get; set; }
        [Column("Nombre")]
        public int Direccion { get; set; }
        [Column("Direccion")]
        public string Telefono { get; set; }

    }
}


