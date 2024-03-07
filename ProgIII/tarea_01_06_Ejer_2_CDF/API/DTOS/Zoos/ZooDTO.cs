using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOS.Zoos
{
    public class ZooDTO : RespuestaBase
    {
        public StandardZoo zoo { get; set; }
    }
}