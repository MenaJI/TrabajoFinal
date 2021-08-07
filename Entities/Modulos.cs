using System.ComponentModel.DataAnnotations.Schema;

namespace ApiREST.Entities
{
    public class Modulos
    {
        public int Id { get; set; }
        public int Fk_Dia { get; set; }
        [ForeignKey("Fk_Dia")]
        public Dias Dia { get; set; }
        public int Fk_Horario { get; set; }
        [ForeignKey("Fk_Horario")]
        public Horarios Horario { get; set; }
        public bool Estado { get; set; }
    }
}