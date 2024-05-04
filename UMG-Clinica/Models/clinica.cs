using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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


