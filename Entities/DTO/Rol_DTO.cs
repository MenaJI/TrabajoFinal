using System.ComponentModel.DataAnnotations;

namespace ApiREST.Entities.DTOs
{
    public class Rol_DTO
    {
        [Required(ErrorMessage = "El 'Nombre' del 'Rol' es requerido. ")]
        public string Nombre { get; set; }
    }
}