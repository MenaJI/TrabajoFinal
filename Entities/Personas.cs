using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ApiREST.Entities
{
    public class Personas : BaseEntity
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        [ForeignKey("TipoDoc")]
        public int Fk_TipoDoc { get; set; }
        public TiposDocs TipoDoc { get; set; }
        public double NroDocumento { get; set; }
        [ForeignKey("Genero")]
        public int Fk_Genero { get; set; }
        public Generos Genero { get; set; }
        [ForeignKey("Localidad")]
        public int Fk_Localidad { get; set; }
        public Localidades Localidad { get; set; }
        [ForeignKey("Nacionalidad")]
        public int Fk_Nacionalidad { get; set; }
        public Nacionalidades Nacionalidad { get; set; }

        [ForeignKey("EstadoCivil")]
        public int Fk_EstadoCivil { get; set; }

        public EstadosCiviles EstadoCivil { get; set; }

        public bool PuebloOriginario { get; set; }

        public string Etnia { get; set; }

        public string Comunidad { get; set; }
    
        [Column("PaisNacimientoId")]
        public Paises PaisNacimiento { get; set; }

        public string Ocupacion { get; set; }

        public bool Discapacidad { get; set; }

        public string TipoDiscapacidad { get; set; }

        [Column("DireccionOcupacionId")]
        public Direcciones DireccionOcupacion { get; set; }

        [Column("DireccionDomicilioId")]
        public Direcciones DireccionDomicilio { get; set; }

        public string NombreUsuario { get; set; }
    }
}