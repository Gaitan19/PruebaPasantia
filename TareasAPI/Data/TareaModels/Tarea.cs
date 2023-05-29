
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace TareasAPI.Data.TareaModels;

public partial class Tarea
{
    [SwaggerSchema("El ID de la tarea")]
    public int IdTarea { get; set; }

    [Required]
    [StringLength(100)]
    [SwaggerSchema("El título de la tarea")]
    public string? Titulo { get; set; }

    [SwaggerSchema("Indica si la tarea está completada o no")]
    public bool? EstadoNoCompletado { get; set; }

[SwaggerSchema("Indica el estado de eliminación de la tarea")]
   [JsonIgnore]
    public bool? EstadoEli { get; set; }
}
