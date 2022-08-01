using System;

namespace ApiREST.Entities
{
    public class Periodos : BaseEntity
    {
        public DateTime FechaIncio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}