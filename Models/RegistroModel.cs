using System.ComponentModel.DataAnnotations;

namespace ApiREST.Models
{
    public class RegistroModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string NombreUsuario { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Contraseña { get; set; }
    }
}