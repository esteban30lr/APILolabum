using System;
using System.Collections.Generic;

namespace Lolabum.Models;

public partial class Persona
{
    public int IdPersona { get; set; }

    public int Identificacion { get; set; }

    public string Nombre1 { get; set; } = null!;

    public string? Nombre2 { get; set; }

    public string Apellido1 { get; set; } = null!;

    public string? Apellido2 { get; set; }

    public int Edad { get; set; }

    public string? Correo { get; set; }

    public int? Telefono { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
