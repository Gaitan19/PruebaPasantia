
using System.ComponentModel.DataAnnotations;



namespace TareasAPI.Data.TareaModels;

public partial class Tarea
{
    public int IdTarea { get; set; }

    [MaxLength(100, ErrorMessage = "La tarea debe de ser menor a 100 caracteres")]
    public string? Titulo { get; set; }

    
    
    
    public bool? estado_no_Completado { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public bool? EstadoEli { get; set; }
}
