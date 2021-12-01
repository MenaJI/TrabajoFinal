using System.ComponentModel.DataAnnotations;

namespace ApiREST.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string nombreusuario { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        public string contraseña { get; set; }
    }
}