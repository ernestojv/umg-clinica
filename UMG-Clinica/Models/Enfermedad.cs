using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UMG_Clinica.Models {
    [Table("Enfermedad")]
    public class Enfermedad {
        [Key]
        [Column("ID_Enfermedad")]
        public int IdEnfermedad { get; set; }

        [Column("Nombre")]
        public string Nombre { get; set; }

        [Column("Descripcion")]
        public string Descripcion { get; set; }


    }
}