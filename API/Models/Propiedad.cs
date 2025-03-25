using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Propiedad
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public int UsuarioId { get; set; }

    public virtual ICollection<Mantenimiento> Mantenimientos { get; set; } = new List<Mantenimiento>();

    public virtual Usuario Usuario { get; set; } = null!;
}
