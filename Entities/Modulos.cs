using System.ComponentModel.DataAnnotations.Schema;

namespace ApiREST.Entities
{
    public class Modulos : BaseEntity
    {
        [ForeignKey("Dia")]
        public int Fk_Dia { get; set; }
        public Dias Dia { get; set; }
        [ForeignKey("Horario")]
        public int Fk_Horario { get; set; }
        public Horarios Horario { get; set; }
        public bool Estado { get; set; }
    }
}