using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Notificacion
{
    public int Id { get; set; }

    public string Mensaje { get; set; } = null!;

    public DateTime? FechaEnvio { get; set; }

    public int UsuarioId { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
