using System;
using System.Collections.Generic;

namespace API.Data;

public partial class Nivel
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Docente> Docentes { get; set; } = new List<Docente>();
}
