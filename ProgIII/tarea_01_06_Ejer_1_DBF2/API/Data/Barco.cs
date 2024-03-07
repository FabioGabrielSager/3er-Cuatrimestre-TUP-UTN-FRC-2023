using System;
using System.Collections.Generic;

namespace API.Data;

public partial class Barco
{
    public int Id { get; set; }

    public int NroMatricula { get; set; }

    public string Nombre { get; set; } = null!;

    public int NroAmarre { get; set; }

    public double Cuota { get; set; }

    public int IdSocio { get; set; }

    public virtual Socio IdSocioNavigation { get; set; } = null!;
}
