using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;

namespace API.DTOs.BarcoDTOs
{
    public class BarcoGuardadoDTO : ResultadoBase
    {
        public BarcoDTO Barco { get; set; }
    }
}