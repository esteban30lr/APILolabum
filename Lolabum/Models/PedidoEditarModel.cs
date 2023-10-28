using System;
using System.Collections.Generic;

namespace Lolabum.Models;

public partial class PedidoEditarModel
{
    public int IdPedido { get; set; }

    public string pedido { get; set; } = null!;

    public int IdCliente { get; set; }

    public int IdVehiculos { get; set; }

    public int? IdFactura { get; set; }

    public bool? Estado { get; set; }


}
