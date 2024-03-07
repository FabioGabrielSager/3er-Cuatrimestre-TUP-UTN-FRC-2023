using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Business.BarcosBusiness.Quries;
using Clases.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BarcoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BarcoController(IMediator mediator){
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getBarcos")]
        public async Task<IEnumerable<Barco>> GetBarcos(){
            return await _mediator.Send(new GetBarcos.Query());
        }

        [HttpGet]
        [Route("getBarcoById/{id}")]
        public async Task<Barco> GetBarcoById(int id){
            return await _mediator.Send(new GetBarcoById.Query{Id = id});
        }
    }
}