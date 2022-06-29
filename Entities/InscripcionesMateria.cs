using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiREST.Entities
{
    public class InscripcionesMateria : BaseEntity
    {
        public DateTime Fecha { get; set; }
        public bool Activo { get; set; }
        [ForeignKey("Curso")] public int Fk_Curso { get; set; }
        public Cursos Curso { get; set; }
        public Materias Materias { get; set; }
        [ForeignKey("Alumno")] public int Fk_Alumno { get; set; }
        public Alumnos Alumno { get; set; }

        [ForeignKey("Condicion")]
        public int Fk_Condicion { get; set; }
        public Condiciones Condicion { get; set; }
        public string Estado { get; set; }
        
        [NotMapped]
        public string CarreraNombre {get;set;}
    }
}