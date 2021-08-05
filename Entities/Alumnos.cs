using System.Collections.Generic;

namespace ApiREST.Entities
{
    public class Alumnos
    {

        public int id {get; set; }
        public int CertificadoSalud { get; set; }

        public int CertificadoSecundaria { get; set; }

        public int Foto { get; set; }

        public ICollection<InscripcionCarrera> inscripcion { get; set; }
    }
}