using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiREST.Entities
{
    public class Alumnos : Personas
    {
        public virtual List<InscripcionCarrera> InscripcionCarreras { get; set; }

        public int CertificadoSaludId { get; set; }

        public int CertificadoSecundariaId { get; set; }

        public int FotoId { get; set; }
        [NotMapped]
        public string NombreCompleto
        {
            get { return this.Apellido + ' ' + this.Nombre; }
        }
    }
}