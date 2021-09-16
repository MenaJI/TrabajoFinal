using System.Collections.Generic;

namespace ApiREST.Entities
{
    public class Alumnos : Personas
    {
        public int CertificadoSaludId { get; set; }
        public int CertificadoSecundariaId { get; set; }
        public int FotoId { get; set; }
        public virtual ICollection<InscripcionCarrera> InscripcionCarreras { get; set; }
    }
}