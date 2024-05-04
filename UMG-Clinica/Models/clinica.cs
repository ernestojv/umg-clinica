using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UMG_Clinica {
    [Table("clinica")]
    public class Clinica {
        [Key]
        [Column("ID_Clinica")]
        public int IdClinica { get; set; }

        [Column("Nombre")]
        public string Nombre { get; set; }
        [Column("Direccion")]
        public string Direccion { get; set; }
        [Column("Telefono")]
        public string Telefono { get; set; }

    }
}


