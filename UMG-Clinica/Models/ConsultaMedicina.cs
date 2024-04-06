using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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