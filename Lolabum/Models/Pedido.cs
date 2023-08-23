using System;
using System.Collections.Generic;

namespace Lolabum.Models;

public partial class Pedido
{
    public int IdPedido { get; set; }

    public string Pedido1 { get; set; } = null!;

    public int IdCliente { get; set; }

    public int IdVehiculos { get; set; }

    public int IdFactura { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Factura IdFacturaNavigation { get; set; } = null!;

    public virtual Vehiculo IdVehiculosNavigation { get; set; } = null!;
}
