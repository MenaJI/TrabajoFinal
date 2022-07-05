using System.Collections.Generic;
using ApiREST.Entities;

namespace ApiREST.Models
{
    public class InscripcionesMateriasModel
    {
        public string userName { get; set; }
        public string estado { get; set; }
        public List<Cursos> cursos { get; set; }
    }
}
