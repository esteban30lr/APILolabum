using System;
using System.Collections.Generic;

namespace Lolabum.Models;

public partial class Factura
{
    public int IdFactura { get; set; }

    public DateTime FechaFactura { get; set; }

    public bool State { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
