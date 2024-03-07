using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Clases.Models
{
    [Table("socios")]
    public class Socio
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Apellido { get; set; }

        public string? Telefono { get; set; }

        public virtual ICollection<Barco> Barcos { get; set; } = new List<Barco>();
    }
}