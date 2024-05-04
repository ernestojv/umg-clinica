using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UMG_Clinica.Models
{
    [Table("Consulta_Medicina")]
    public class Consulta_Medicina
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("ID_Consulta")]
        [ForeignKey("Consulta")]
        public int IdConsulta { get; set; }
        public virtual Consulta Consulta { get; set; }

        [Column("ID_Medicamento")]
        [ForeignKey("Medicamento")]
        public int IdMedicamento { get; set; }
        public virtual Medicamento Medicamento { get; set; }

        [Column("Indicaciones")]
        public string Indicaciones { get; set; }
    }
}