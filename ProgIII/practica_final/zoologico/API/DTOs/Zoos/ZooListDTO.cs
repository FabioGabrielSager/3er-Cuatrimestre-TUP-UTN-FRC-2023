using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.Zoos
{
    public class ZooListDTO : RespuestaBase
    {
        public List<ZooStandard> Zoos { get; set;}
    }
}