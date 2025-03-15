using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models;

public partial class User
{
    [Key]
    public int IdUsuario { get; set; }

    [Required(ErrorMessage = "Se requiere un nombre")]
    public string? Nombre { get; set; }

    [Display(Name = "Email")]
    [Required(ErrorMessage = "Se requiere un correo valido")]
    [EmailAddress(ErrorMessage = "Correo Invalido")]
    public string? Correo { get; set; }

    [Required(ErrorMessage = "Se requiere un correo valido")]
    public string? Clave { get; set; }
}
