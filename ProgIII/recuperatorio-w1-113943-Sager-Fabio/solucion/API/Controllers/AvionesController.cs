using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.Aviones;
using API.Servicios.Aviones.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AvionesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AvionesController(IMediator mediator){
            _mediator = mediator;
        }

        [HttpGet]
        [Route("ObtenerAviones/")]
        public Task<ListadoAvionesDTO> ObtenerAviones(){
            return _mediator.Send(new GetAviones.GetAvionesQuery());
        }
    }
}