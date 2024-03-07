using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOS.Common
{
    public class CitiesList : RespuestaBase
    {
        public List<Ciudad> Cities { get; set; }
    }
}