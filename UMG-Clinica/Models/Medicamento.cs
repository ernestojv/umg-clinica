using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UMG_Clinica.Models
{
    [Table("Cita")]
    public class Medicamento
    {
        [Key]
        public int ID_Medicamento { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(255)]
        public string Descripcion { get; set; }

        public int Stock { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Precio { get; set; }
    }
}