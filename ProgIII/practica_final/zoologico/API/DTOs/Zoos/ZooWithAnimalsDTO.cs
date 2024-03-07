using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.Animales;

namespace API.DTOs.Zoos
{
    public class ZooWithAnimalsDTO : RespuestaBase
    {
        public ZooStandard zoo { get; set; }
        public List<AnimalStandard> Animales { get; set; }
    }
}