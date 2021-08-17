using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using ApiREST.Entities;

namespace ApiRest.Entities
{
    public class Materias
    {
        public int Id { get; set; }

        public string Descrip { get; set; }

        public bool Activa { get; set; }

        public int HorasCatSem { get; set; }

        public int HorasCatAnu { get; set; }

        [ForeignKey("Fk_Anio")] public int Fk_Anio { get; set; }
        public Anios Anio { get; set; }

        [ForeignKey("Fk_Regimen")] public int Fk_Regimen { get; set; }
        public Regimenes Regimen { get; set; }

        [ForeignKey("Fk_Campo")] public int Fk_Campo { get; set; }
        public Campos Campo { get; set; }

        [ForeignKey("Fk_Carrera")] public int Fk_Carrera { get; set; }
        public Carreras Carrera { get; set; }

        public virtual ICollection<Materias> Correlativas { get; set; }







    }
}