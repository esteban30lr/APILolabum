using System;
using System.Collections.Generic;

namespace Lolabum.Models;

public partial class VistaPedidoConDato
{
    public int IdPedido { get; set; }

    public string Pedido { get; set; } = null!;

    public int IdCliente { get; set; }

    public string ClienteNombre { get; set; } = null!;

    public string ClienteApellido { get; set; } = null!;

    public int IdVehiculos { get; set; }

    public string VehiculoNombre { get; set; } = null!;

    public string VehiculoPrecio { get; set; } = null!;

    public int IdConcesionario { get; set; }

    public string ConcesionarioNombre { get; set; } = null!;

    public string ConcesionarioDireccion { get; set; } = null!;

    public int IdFactura { get; set; }

    public DateTime FechaFactura { get; set; }
}
