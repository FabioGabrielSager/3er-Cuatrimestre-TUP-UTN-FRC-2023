using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.DTOs.Zoos;
using API.Services.Zoos.Commands;
using API.Services.Zoos.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/zoosController")]
    public class ZoosController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public ZoosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("/obtenerZoos")]
        public Task<ZooListDTO> ObtenerZoos(){
            return _mediator.Send(new GetAllZoos.GetAllZoosQuery());
        }

        [HttpPost]
        [Route("/agregarZoo")]
        public Task<RespuestaBase> AgregarZoo([FromBody] PostANewZoo.PostANewZooCommand cmd){
            return _mediator.Send(cmd);
        }

        [HttpPut]
        [Route("/actualizarZoo")]
        public Task<RespuestaBase> ActualizarZoo([FromBody] PutZoo.PutZooCommand cmd){
            return _mediator.Send(cmd);
        }
    }
}