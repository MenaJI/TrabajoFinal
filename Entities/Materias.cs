using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace ApiREST.Entities
{
    public class Materias : BaseEntity
    {
        public string Descrip { get; set; }

        public bool Activa { get; set; }

        public int HorasCatSem { get; set; }

        public int HorasCatAnu { get; set; }

        [ForeignKey("Anio")] public int Fk_Anio { get; set; }
        public Anios Anio { get; set; }

        [ForeignKey("Regimen")] public int Fk_Regimen { get; set; }
        public Regimenes Regimen { get; set; }

        [ForeignKey("Campo")] public int Fk_Campo { get; set; }
        public Campos Campo { get; set; }

        [ForeignKey("Carrera")] public int Fk_Carrera { get; set; }
        public Carreras Carrera { get; set; }
        public virtual ICollection<Materias> Correlativas { get; set; }
    }
}