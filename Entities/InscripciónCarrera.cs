using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiREST.Entities
{
    public class InscripcionCarrera
    {
        public int Id { get; set; }
        public int Fk_Carrera { get; set; }
        [ForeignKey("Fk_Carrera")]
        public Carreras Carrera { get; set; }
    }
}