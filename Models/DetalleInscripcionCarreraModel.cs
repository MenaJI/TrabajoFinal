using System.Collections.Generic;
using System.Threading.Tasks;
using ApiREST.Entities;


namespace ApiREST.Models
{
    public class DetalleInscripcionCarrera
    {
        public string UserNameAlumno { get; set; }
        public string NombreAlumno { get; set; }
        public string ApellidoAlumno { get; set; }
        public string NumeroDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string GeneroAlumno {get; set; }
        public string Localidad { get; set; }
        public string EstadoCivil { get; set; }
        public string Nacionalidad { get; set; }
    }
}