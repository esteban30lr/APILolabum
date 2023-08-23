using System;
using System.Collections.Generic;

namespace Lolabum.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public int IdPersona { get; set; }

    public string Usuario { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public virtual Persona IdPersonaNavigation { get; set; } = null!;
}
