using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace TareasAPI.Data.DTOs;

public class AdminDto
{
    [Required]
    [EmailAddress]
    [SwaggerSchema("El correo")]
    public string Correo { get; set; } = null!;

    [Required]
    [SwaggerSchema("La contraseña del administrador")]
    public string Pwd { get; set; } = null!;
}