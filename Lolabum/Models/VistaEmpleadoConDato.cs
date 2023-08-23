using System;
using System.Collections.Generic;

namespace Lolabum.Models;

public partial class VistaEmpleadoConDato
{
    public int IdEmpleado { get; set; }

    public string Usuario { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public int IdPersona { get; set; }

    public string EmpleadoNombre { get; set; } = null!;

    public string EmpleadoApellido { get; set; } = null!;
}
