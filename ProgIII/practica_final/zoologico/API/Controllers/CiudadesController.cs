using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Services.Ciudades.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/Ciudades")]
    public class CiudadesController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public CiudadesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("/obtenerCiudades")]
        public Task<List<Ciudad>> ObtenerCiudades(){
            return _mediator.Send(new GetAllCiudades.GetAllCiudadesQuery());
        }
    }
}