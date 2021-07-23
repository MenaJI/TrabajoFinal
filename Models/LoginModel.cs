using System.ComponentModel.DataAnnotations;

namespace ApiREST.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Contraseña { get; set; }
    }
}