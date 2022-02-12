using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiREST.Entities
{
    public class Alumnos : Personas
    {
        public int CertificadoSaludId { get; set; }
        public int CertificadoSecundariaId { get; set; }
        public int FotoId { get; set; }
        public virtual ICollection<InscripcionCarrera> InscripcionCarreras { get; set; }

        [NotMapped]
        public string NombreCompleto
        {
            get { return this.Apellido + ' ' + this.Nombre; }
        }
    }
}