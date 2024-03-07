using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class ListadoNivelsDTO : RespuestaBase
    {
        public List<NivelDTO> Niveles { get; set; }
    }
}