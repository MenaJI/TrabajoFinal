using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiREST.Entities
{
    public class InscripcionCarrera
    {
        public int Id { get; set; }
        [ForeignKey("Carrera")]
        public int Fk_Carrera { get; set; }
        public Carreras Carrera { get; set; }
    }
}