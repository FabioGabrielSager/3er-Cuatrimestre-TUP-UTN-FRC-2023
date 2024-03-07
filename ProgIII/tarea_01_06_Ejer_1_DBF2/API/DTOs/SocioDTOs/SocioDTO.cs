using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs.BarcoDTOs;

namespace API.DTOs.SocioDTOs
{
    public class SocioDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Apellido { get; set; }

        public string? Telefono { get; set; }
        public virtual List<BarcoDTO> barcos{ get; set; }
    }
}