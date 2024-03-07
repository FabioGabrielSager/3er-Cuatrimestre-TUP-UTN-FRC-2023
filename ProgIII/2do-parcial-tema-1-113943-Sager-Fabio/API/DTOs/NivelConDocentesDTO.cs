using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class NivelConDocentesDTO : RespuestaBase
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public List<DocenteDTO> docentes{ get; set; }
    }
}