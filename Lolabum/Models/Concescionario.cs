using System;
using System.Collections.Generic;

namespace Lolabum.Models;

public partial class Concescionario
{
    public int IdConcesionario { get; set; }

    public string Nombre { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public int? Telefono { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
}
