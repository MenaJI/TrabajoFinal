using System.ComponentModel.DataAnnotations;

namespace ApiREST.DTOs
{
    public class Login_DTO
    {
        [Required(ErrorMessage = "User Name is required")]
        public string nombreusuario { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string contraseña { get; set; }
    }
}