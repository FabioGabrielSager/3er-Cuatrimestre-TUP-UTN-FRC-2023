using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Clases.Models
{
    [Table("barcos")]
    public class Barco
    {
        public int Id { get; set; }

        public int NroMatricula { get; set; }

        public string Nombre { get; set; } = null!;

        public int NroAmarre { get; set; }

        public double Cuota { get; set; }

        [ForeignKey("idSocio")]
        public virtual Socio IdSocioNavigation { get; set; } = null!;

    }
}