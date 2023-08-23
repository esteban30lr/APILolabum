using System;
using System.Collections.Generic;

namespace Lolabum.Models;

public partial class Vehiculo
{
    public int IdVehiculos { get; set; }

    public string Nombre { get; set; } = null!;

    public string Precio { get; set; } = null!;

    public int? IdCategoria { get; set; }

    public int? IdConcesionario { get; set; }

    public virtual Categorium? IdCategoriaNavigation { get; set; }

    public virtual Concescionario? IdConcesionarioNavigation { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
