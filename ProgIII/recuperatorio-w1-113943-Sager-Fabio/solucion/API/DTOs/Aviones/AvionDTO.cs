using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.Aviones
{
    public class AvionDTO
    {
        public int Id { get; set; }
        public string Fabricante { get; set; }

        public int CantidadAsientos { get; set; }

        public string Modelo { get; set; }

        public int CantidadMotores { get; set; }

        public string DatosVarios { get; set; }
    }
}