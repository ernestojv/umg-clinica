using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UMG_Clinica.Models
{
    [Table("Enfermedad")]
    public class Enfermedad
    {
        [Key]
        public int ID_Enfermedad { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre_del_paciente { get; set; }

        [StringLength(255)]
        public string Descripcion { get; set; }

        public int Indicaciones { get; set; }

    }
}