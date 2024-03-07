using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Services.Ciudades.Queries;
using API.Services.Paises.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/Paises")]
    public class PaisesController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public PaisesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("/obtenerPaises")]
        public Task<List<Pais>> ObtenerPaises(){
            return _mediator.Send(new GetAllPaises.GetAllPaisesQuery());
        }
    }
}