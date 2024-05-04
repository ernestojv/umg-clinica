using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UMG_Clinica.Models {
    public class Paciente {
        [Key]
        [Column("ID_Paciente")]
        public int IdPaciente { get; set; }

        [Column("Nombre")]
        public string Nombre { get; set; }

        [Column("Edad")]
        public int Edad { get; set; }

        [Column("Sexo")]
        public string Sexo { get; set; }

        [Column("Numero_de_telefono")]
        public string NumeroDeTelefono { get; set; }
    }
}
