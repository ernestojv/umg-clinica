using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UMG_Clinica.Models
{
    [Table("ConsultaMedicina")]
    public class Consulta_Medicina
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Consulta")]
        public int ID_Consulta { get; set; }
        public Consulta Consulta { get; set; }

        [ForeignKey("Medicamento")]
        public int ID_Medicamento { get; set; }
        public Medicamento Medicamento { get; set; }

        public string Indicaciones { get; set; }
    }
}