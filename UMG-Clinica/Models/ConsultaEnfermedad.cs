using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UMG_Clinica.Models {
    [Table("Consulta_Enfermedad")]
    public class ConsultaEnfermedad {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("ID_Consulta")]
        [ForeignKey("Consulta")]
        public int IdConsulta { get; set; }
        public virtual Consulta Consulta { get; set; }

        [Column("ID_Enfermedad")]
        [ForeignKey("Enfermedad")]
        public int IdEnfermedad { get; set; }
        public virtual Enfermedad Enfermedad { get; set; }

    }
}