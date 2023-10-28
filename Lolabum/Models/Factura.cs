using System;
using System.Collections.Generic;

namespace Lolabum.Models;

public partial class Factura
{
    public int IdFactura { get; set; }

    public DateTime FechaFactura { get; set; }

    public bool? EstadoFactura { get; set; }

    public bool? Estado { get; set; }

    public int? IdCliente { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
