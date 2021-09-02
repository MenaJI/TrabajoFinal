using System.Collections.Generic;

namespace ApiREST.Entities
{
    public class InscripcionMateria 
    {
        public int id { get; set; }
        public int fecha { get; set; }
        public int activo { get; set; }
        public Alumnos Alumnos { get; set; }

        public Curso Curso { get; set; }
        public Materias Materias { get; set; }
    }
}