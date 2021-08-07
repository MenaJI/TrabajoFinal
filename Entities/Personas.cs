using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiREST.Entities
{
    public class Personas
    {
        public int Id { get; set; }
        // public Usuario usuario {get; set;}
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Fk_TipoDoc { get; set; }
        [ForeignKey("Fk_TipoDoc")]
        public TiposDocs TipoDoc { get; set; }
        public double NroDocumento { get; set; }
        public int Fk_Genero { get; set; }
        [ForeignKey("Fk_Genero")]
        public Generos Genero { get; set; }
        public int Fk_Localidad { get; set; }
        [ForeignKey("Fk_Localidad")]
        public Localidades Localidad { get; set; }
        public int Fk_Nacionalidad { get; set; }
        [ForeignKey("Fk_Nacionalidad")]
        public Nacionalidades Nacionalidad { get; set; }
        public int Fk_EstadoCivil { get; set; }
        [ForeignKey("Fk_EstadoCivil")]
        public EstadosCiviles EstadoCivil { get; set; }
        public string Fk_Usuario { get; set; }
        [ForeignKey("Fk_Usuario")]
        public Usuarios Usuario { get; set; }
    }
}