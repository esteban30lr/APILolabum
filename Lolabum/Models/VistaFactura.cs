using System;
using System.Collections.Generic;

namespace Lolabum.Models;

public partial class VistaFactura
{
    public int IdFactura { get; set; }

    public DateTime FechaFactura { get; set; }

    public int IdCliente { get; set; }

    public string Nombre1 { get; set; } = null!;

    public string? Correo { get; set; }
}
