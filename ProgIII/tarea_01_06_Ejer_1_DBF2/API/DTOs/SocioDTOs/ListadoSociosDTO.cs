using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;

namespace API.DTOs.SocioDTOs
{
    public class ListadoSociosDTO : ResultadoBase
    {
        public List<SocioDTO> Socios { get; set; }
    }
}