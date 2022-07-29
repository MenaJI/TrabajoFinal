using System.Collections.Generic;
using System.Threading.Tasks;
using ApiREST.Entities;


namespace ApiREST.Models
{
    public class DetalleInscripcionMateriaModel
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
        public string CarreraNombre {get; set; }
        
        public string PaisDeNacimiento { get; set; }
        public bool Discapacidad { get; set; }
        public string DiscapacidadDescripcion { get; set; }
        public bool PuebloOriginario { get; set; }
        public string Etnia { get; set; }
        public string Comunidad { get; set; }

        public string DomicilioCalle { get; set; }
        public string DomicilioNumero { get; set; }
        public string DomicilioPiso { get; set; }
        public string DomicilioDepartamento { get; set; }
        public string DomicilioTelefono { get; set; }
        public string DomicilioLocalidad { get; set; }

        public string OcupacionCalle { get; set; }
        public string OcupacionNumero { get; set; }
        public string OcupacionPiso { get; set; }
        public string OcupacionDepartamento { get; set; }
        public string OcupacionTelefono { get; set; }
        public string OcupacionLocalidad { get; set; }

        public List<string> MateriasCorrelativas { get;set; }
    }
}