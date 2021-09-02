using System.Collections.Generic;

namespace ApiRest.Entities
{
    public class InscripcionMaterias
    {
        public int id { get; set; }
        public int fecha { get; set; }
        public int activo { get; set; }
        public Alumnos Alumnos { get; set; }
        public Cursos Cursos { get; set; }
        public Materias Materias { get; set; }
    }
}