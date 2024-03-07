using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using MediatR;

namespace API.Services.Animales.Commands
{
    public class PutAnimal
    {
        public class PostANewAnimalCommand : IRequest<RespuestaBase>{
            public string Pais { get; set; }
            public string Continente { get; set; }
            public string Familia { get; set; }
            public string Nombre { get; set; }
            public string NombreCientifico { get; set; }
            public string Sexo { get; set; }
            public int AnioDeNacimiento { get; set; }
            public bool PeligroDeExtincion { get; set; }
        }
    }
}