using System.Collections.Generic;
using ApiREST.Entities;

namespace ApiREST.Models
{
    public class InscripcionesMateriaModel
    {
        public string Status { get; set; }
        public string Mensaje {get;set;}
        public List<InscripcionesMateria> listaInscripciones { get; set; }
    }
}
