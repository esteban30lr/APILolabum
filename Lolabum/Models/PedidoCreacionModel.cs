﻿using System;
using System.Collections.Generic;

namespace Lolabum.Models;

public partial class PedidoCreacionModel
{
    public int IdPedido { get; set; }

    public string pedido { get; set; } = null!;

    public int IdCliente { get; set; }

    public int IdVehiculos { get; set; }

}
