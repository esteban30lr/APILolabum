using System;
using System.Collections.Generic;

namespace Lolabum.Models;

public partial class VistaClienteConDato
{
    public int IdCliente { get; set; }

    public string Usuario { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public int IdPersona { get; set; }

    public string ClienteNombre { get; set; } = null!;

    public string ClienteApellido { get; set; } = null!;
}
