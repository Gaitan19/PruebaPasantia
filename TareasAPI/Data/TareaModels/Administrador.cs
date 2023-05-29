using System;
using System.Collections.Generic;

namespace TareasAPI.Data.TareaModels;

public partial class Administrador
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Pwd { get; set; } = null!;

    public string AdminTipo { get; set; } = null!;
}
