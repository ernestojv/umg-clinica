using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UMG_Clinica.Models
{
    [Table("ConsultaEnfermedad")]
    public class Consulta_Enfermedad
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("ConsultaE")]
        public int ID_ConsultaE { get; set; }
        public ConsultaE ConsultaE { get; set; }

        [ForeignKey("Enfermedad")]
        public int ID_Enfermedad { get; set; }
        public Enfermedad Enfermedad { get; set; }

        public string Indicaciones { get; set; }
    }
}