using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOS.Zoos;
using API.Services.Zoos.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ZoosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ZoosController(IMediator mediator){
            _mediator = mediator;
        }

        [HttpGet]
        [Route("ObtenerZoos/")]
        public Task<ZoosListDTO> GetAllZoos(){
            return _mediator.Send(new GetAllZoos.GetAllZoosQuery());
        }
    }
}