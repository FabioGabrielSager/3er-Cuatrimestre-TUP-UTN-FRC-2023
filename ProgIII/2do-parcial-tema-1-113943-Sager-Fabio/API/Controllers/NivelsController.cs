using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Servicios.NivelsServ.Commands;
using API.Servicios.NivelsServ.queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NivelsController : ControllerBase
    {
        private IMediator _mediator;

        public NivelsController(IMediator mediator){
            _mediator = mediator;
        }

        [HttpGet]
        [Route("/obtenerNiveles/")]
        public Task<ListadoNivelsDTO> ObtenerNiveles(){
            return _mediator.Send(new GetNivels.GetNivelsQuery());
        }

        [HttpGet]
        [Route("/getNivelById/{id}")]
        public Task<NivelConDocentesDTO> GetNivelById(int id){
            return _mediator.Send(new GetNivelById.GetNivelByIdQuery(){Id = id});
        }

        [HttpGet]
        [Route("/obtenerNivelesConDocentes/")]
        public Task<ListadoNivelsConDocentesDTO> GetNivelsConDocentesDTO(){
            return _mediator.Send(new GetNivelsConDocentes.GetNivelsConDocentesQuery());
        }

        [HttpDelete]
        [Route("/BorrarNivelByIdONombre/")]
        public Task<RespuestaBase> BorrarNivelByIdONombre([FromBody] DeleteNivelNombreOrId.DeleteNivelNombreOrIdCommand cmd){
            return _mediator.Send(cmd);
        }
    }
}