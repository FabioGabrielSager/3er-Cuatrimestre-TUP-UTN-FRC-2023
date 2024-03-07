using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.BarcoDTOs
{
    public class BarcoDTO
    {
        public int Id { get; set; }

        public int NroMatricula { get; set; }

        public string Nombre { get; set; }

        public int NroAmarre { get; set; }

        public double Cuota { get; set; }

    }
}