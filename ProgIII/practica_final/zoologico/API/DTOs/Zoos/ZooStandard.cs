using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.Zoos
{
    public class ZooStandard
    {   
        public Guid id { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }

        public string Nombre { get; set; }
        public double PresupuestoAnual { get; set; }
        public double TamanioEnM2 { get; set; }
    }
}