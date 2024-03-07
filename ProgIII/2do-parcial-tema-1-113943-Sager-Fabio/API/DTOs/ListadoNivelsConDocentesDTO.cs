using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class ListadoNivelsConDocentesDTO : RespuestaBase
    {
        public List<NivelConDocentesDTO> Niveles { get; set; }
    }
}