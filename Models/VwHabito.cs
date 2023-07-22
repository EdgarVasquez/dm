using System;
using System.Collections.Generic;

namespace prueba.Models;

public partial class VwHabito
{
    public int Id { get; set; }

    public bool Estatus { get; set; }

    public int IdUsuarioCrea { get; set; }

    public DateTime? FechaCrea { get; set; }

    public DateTime? FechaModifica { get; set; }

    public int IdUsuarioModifica { get; set; }

    public string? Descripcion { get; set; }

    public double? Precio { get; set; }
}
