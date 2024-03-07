using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOS.Animales
{
    public class StandardAnimal
    {
        public string nombre { get; set; }
        public string NombreCientifico { get; set; }
        public string Familia { get; set; }
        public bool PeligroDeExtinsion { get; set; }
    }
}