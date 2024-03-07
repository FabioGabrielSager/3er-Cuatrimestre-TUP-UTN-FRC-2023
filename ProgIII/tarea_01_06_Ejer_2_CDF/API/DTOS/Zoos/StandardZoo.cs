using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOS.Zoos
{
    public class StandardZoo
    {
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public double TamanioEnM2 { get; set; }
        public double PresupuestoAnual { get; set; }

    }
}