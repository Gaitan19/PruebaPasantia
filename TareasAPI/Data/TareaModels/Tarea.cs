using System;
using System.Collections.Generic;

namespace TareasAPI.Data.TareaModels;

public partial class Tarea
{
    public int IdTarea { get; set; }

    public string? Titulo { get; set; }

    public bool? Estado { get; set; }

    public bool? EstadoEli { get; set; }
}
