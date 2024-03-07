using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using API.DTOs.SocioDTOs;
using API.Services.SocioServ.Commands;
using API.Services.SocioServ.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SocioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SocioController(IMediator mediator){
            _mediator = mediator;
        }

        [HttpGet]
        [Route("/obtenerSocios")]
        public Task<ListadoSociosDTO> ObtenerSocios() {
            return _mediator.Send(new GetSocios.Query());
        }

        [HttpGet]
        [Route("/obtenerSocioByNombreYApellido")]
        public Task<SocioGuardadoDTO> GetSocioByNombreYApellido([FromQuery] string nombre, [FromQuery] string apellido){
            GetSocioByNombreYApellido.Query query = new(){
                Nombre = nombre,
                Apellido = apellido
            };
            return _mediator.Send(query);
        }

        [HttpPost]
        [Route("/agregarSocio")]
        public Task<SocioGuardadoDTO> AgregarSocio([FromBody] AddSocio.AddSocioCommand dto){
            return _mediator.Send(dto);
        }

        [HttpPut]
        [Route("/actualizarSocio")]
        public Task<SocioGuardadoDTO> ActualizarSocio([FromBody] UpdateSocio.UpdateSocioCommand dto){
            return _mediator.Send(dto);
        }

        [HttpDelete]
        [Route("/eliminarSocio/{id}")]
        public Task<SocioGuardadoDTO> EliminarSocio(int id){
            return _mediator.Send(new DeleteSocio.DeleteSocioCommand(){Id=id});
        }
    }
}