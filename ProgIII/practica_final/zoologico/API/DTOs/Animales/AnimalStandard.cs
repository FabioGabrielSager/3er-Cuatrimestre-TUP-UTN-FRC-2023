using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.Animales
{
    public class AnimalStandard
    {
        public string Pais { get; set; }
        public string Continente { get; set; }
        public string Nombre { get; set; }
        public string NombreCientifico { get; set; }
        public string Sexo { get; set; }
        public string Familia { get; set; }
        public int AnioDeNacimiento { get; set; }
        public bool PeligroDeExtincion { get; set; }
    }
}