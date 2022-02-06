using ApiREST.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiREST.Entities
{
    public class Docentes : Personas
    {
        [NotMapped]
        public string NombreCompleto
        {
            get { return this.Apellido + ' ' + this.Nombre; }
        }
    }
}