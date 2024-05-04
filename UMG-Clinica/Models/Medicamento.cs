using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UMG_Clinica.Models
{
    [Table("Medicamento")]
    public class Medicamento
    {
        [Key]
        [Column("ID_Medicamento")]
        public int IdMedicamento { get; set; }

        [Column("Nombre")]
        public string Nombre { get; set; }

        [Column("Descripcion")]
        public string Descripcion { get; set; }

        [Column("Stock")]
        public int Stock { get; set; }

        [Column("Precio")]
        public decimal Precio { get; set; }
    }
}