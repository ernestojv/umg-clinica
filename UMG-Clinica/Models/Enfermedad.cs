using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UMG_Clinica.Models
{
    [Table("Enfermedad")]
    public class NEnfermedad
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Enfermedad")]
        public int ID_NEnfermedad { get; set; }
        public ConsultaE ConsultaE { get; set; }

        [ForeignKey("Enfermedad")]
        public int ID_NEnfermedad { get; set; }
        public NEnfermedad Enfermedad { get; set; }

        public string Indicaciones { get; set; }
    }
}