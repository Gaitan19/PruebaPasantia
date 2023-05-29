using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TareasAPI.Data.TareaModels;

public partial class Tarea
{
    public int IdTarea { get; set; }

    public string? Titulo { get; set; }

    public bool? EstadoNoCompletado { get; set; }

   [JsonIgnore]
    public bool? EstadoEli { get; set; }
}
