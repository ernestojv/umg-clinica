using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMG_Clinica
{
    internal interface Consulta
    
    {
        [Table("Consulta")]
        public class Consulta
        {
            [Key]
            [Column("ID_Consulta")]
            public int idConsulta { get; set; }
            [Column("Fecha")]
            public DateTime Fecha{ get; set; }
            [Column("Observaciones")]
            public string Id_clinica { get; set; }
            [Column("ID_Clinica")]
            public int idClinica { get; set; }
            [Column("ID_Paciente")]
            public int idPaciente { get; set; }
            [Column("ID_Empleado")]
            public int idDoctor { get; set; }
            [Column("ID_Doctor")]
            public int idcita { get; set; }

        }
    }

}
