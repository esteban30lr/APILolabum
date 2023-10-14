using System;
using System.Collections.Generic;

namespace Lolabum.Models;

public partial class PedidoCreacionModel
{
    public int IdPedido { get; set; }

    public string Pedido1 { get; set; } = null!;

    public int IdCliente { get; set; }

    public int IdVehiculos { get; set; }

    public int IdFactura { get; set; }

}
