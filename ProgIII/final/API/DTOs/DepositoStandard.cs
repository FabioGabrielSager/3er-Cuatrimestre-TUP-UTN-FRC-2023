using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class DepositoStandard
    {
        public string Nombre { get; set; }
        public int MetrosCuadrados { get; set; }
        public string calle { get; set; }
        public string numero { get; set; }
        public string Barrio { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
    }
}