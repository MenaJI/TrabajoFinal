using System.ComponentModel.DataAnnotations;

namespace ApiREST.Models
{
    public class RegistroModel
    {
        [Required(ErrorMessage = "EL nombre de usuario es requerido.")]
        public string NombreUsuario { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "El Email es requerido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida.")]
        public string Contraseña { get; set; }
    }
}