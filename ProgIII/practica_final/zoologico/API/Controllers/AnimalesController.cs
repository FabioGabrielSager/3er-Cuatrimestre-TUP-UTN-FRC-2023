using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.DTOs.Animales;
using API.Services.Animales.Commands;
using API.Services.Animales.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/Animales")]
    public class AnimalesController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public AnimalesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("ObtenerAnimalesDeZoo/{nombreZoo}/ciudad/{ciudad}/pais/{pais}")]
        public Task<ListaAnimalesDTO> ObtenerAnimalesDeZoo(string nombreZoo, string ciudad, string pais){
            return _mediator.Send(new GetAnimalsFromZoo.GetAnimalsFromZooQuery(){
                NombreZoo = nombreZoo,
                CiudadZoo = ciudad,
                PaisZoo = pais
            });
        }

        [HttpPost]
        [Route("AgregarAnimal")]
        public Task<RespuestaBase> AgregarAnimal(PostANewAnimal.PostANewAnimalCommand cmd){
            return _mediator.Send(cmd);
        }
    }
}