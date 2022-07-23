using System.ComponentModel.DataAnnotations.Schema;

namespace ApiREST.Entities
{
    public class Direcciones : BaseEntity
    {
        public string Calle { get; set; }
        public string Numero { get;set; }
        public string Piso { get;set; }
        public string Departamento { get;set; }
        public string Barrio { get;set; }
        
        [Column("LocalidadId")]
        public Localidades Localidad { get;set; }
        public string Telefono { get; set; }
    }
}