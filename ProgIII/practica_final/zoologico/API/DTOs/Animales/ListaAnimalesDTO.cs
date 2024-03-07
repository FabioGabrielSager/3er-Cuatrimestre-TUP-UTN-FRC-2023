using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.Animales
{
    public class ListaAnimalesDTO : RespuestaBase
    {
        public List<AnimalStandard> Animales { get; set; }
    }
}