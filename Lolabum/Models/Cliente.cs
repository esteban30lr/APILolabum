using System;
using System.Collections.Generic;

namespace Lolabum.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public int IdPersona { get; set; }

    public string Usuario { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public virtual Persona IdPersonaNavigation { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
