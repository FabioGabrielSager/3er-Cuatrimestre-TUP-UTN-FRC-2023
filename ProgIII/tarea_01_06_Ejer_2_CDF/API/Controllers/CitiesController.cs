using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOS.Common;
using API.Services.Ciudades.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController : ControllerBase
    {

        private readonly IMediator _mediator;

        public CitiesController(IMediator mediator){
            _mediator = mediator;
        }

        [HttpGet]
        [Route("/obtener_ciudades")]
        public Task<CitiesList> ObtenerCiudades(){
            return _mediator.Send(new GetAllCities.GetAllCitiesQuery());
        }
    }
}