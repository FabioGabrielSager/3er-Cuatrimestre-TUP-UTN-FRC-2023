using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.MarksDtos;
using API.Services;
using API.Services.Markers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/Marker")]
    public class MarkersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MarkersController(IMediator mediator){
            _mediator = mediator;
        }
        
        [HttpGet]
        [Route("/GetMarcadores")]
        public Task<MarkerListDto> GetMarkers(){
            return _mediator.Send(new GetAllMarkers.Query());
        }
    }
}