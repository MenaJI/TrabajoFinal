using System.Collections.Generic;
using System.Threading.Tasks;
using ApiREST.Entities;
using ApiREST.Models;
namespace ApiREST.Models
{
    public class AlumnosModel
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoDocumento { get; set; }
        public double NumeroDocumento { get; set; }
        public string Genero { get; set; }
        public string Localidad { get; set; }
        public string Nacionalidad { get; set; }
        public string EstadoCivil { get; set; }
        public string NombreUsuario { get; set; }
        public string PaisNacimiento { get; set; }


        // Discapacidad
        public bool Discapacidad { get; set; }
        public string DiscapacidadDescripcion { get; set; }

        // Ocupacion
        public string Ocupacion { get; set; }
        public DireccionesModel OcupacionDireccion {get;set;}


        // PuebloOriginario
        public bool PuebloOriginario { get; set; }
        public string Etnia {get;set;}
        public string Comunidad {get;set;}

        // Domicilio
        public DireccionesModel Domicilio {get;set;}
        public List<InscripcionCarrera> InscripcionesCarrera { get; set; }
    }

    public class DireccionesModel {
        // Domicilio
        public int Id { get; set; }
        public string Calle {get;set;}
        public string Numero {get;set;}
        public string Piso {get;set;}
        public string Dpto {get;set;}
        public string Localidad {get;set;}
        public string Telefono { get; set; }
    }
}