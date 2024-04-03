using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UMG_Clinica.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        [Column("Nombre_de_usuario")]
        public string NombreDeUsuario { get; set; }
        [Column("Contrasena")]
        public string Contrasena { get; set; }
        [Column("Nombre")]
        public string Nombre { get; set; }
    }
}