using System;
using System.Collections.Generic;

namespace API.Data;

public partial class Socio
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Apellido { get; set; }

    public string? Telefono { get; set; }

    public virtual ICollection<Barco> Barcos { get; set; } = new List<Barco>();
}
