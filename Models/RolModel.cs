using System.ComponentModel.DataAnnotations;

namespace ApiREST.Models
{
    public class RolModel
    {
        [Required(ErrorMessage = "El 'Nombre' del 'Rol' es requerido. ")]
        public string Nombre { get; set; }
    }
}