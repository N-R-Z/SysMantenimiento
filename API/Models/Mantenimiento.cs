using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Mantenimiento
{
    public int Id { get; set; }

    public string Tipo { get; set; } = null!;

    public DateOnly FechaProgramada { get; set; }

    public string Estado { get; set; } = null!;

    public int? ProveedorId { get; set; }

    public int PropiedadId { get; set; }

    public virtual Propiedad Propiedad { get; set; } = null!;

    public virtual Proveedor? Proveedor { get; set; }
}
