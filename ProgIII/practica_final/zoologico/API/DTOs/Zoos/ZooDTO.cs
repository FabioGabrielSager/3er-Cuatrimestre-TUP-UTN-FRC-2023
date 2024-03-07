using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.Zoos
{
    public class ZooDTO : RespuestaBase
    {
        public ZooStandard zoo { get; set; }
    }
}