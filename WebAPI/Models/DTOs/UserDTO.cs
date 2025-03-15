using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.DTOs
{
    public class UserDTO
    {
        public string Nombre { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Se requiere un correo valido")]
        [EmailAddress(ErrorMessage = "Correo Invalido")]
        public string Correo { get; set; }
        [Required(ErrorMessage = "Se requiere una contrasena")]
        public string Clave { get; set; }
    }
}
