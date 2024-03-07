using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Business.SociosBusiness.Queries;
using API.Data;
using Clases.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static API.Business.SociosBusiness.Queries.GetSocioById;
using static API.Business.SociosBusiness.Queries.GetSocios;

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

        // Get Generico
        [HttpGet]
        [Route("getSocios")]
        public async Task<IEnumerable<Socio>> GetSocios(){
            return await _mediator.Send(new GetSocios.Query());
        }

        // Get con filtro
        [HttpGet]
        [Route("getById/{id}")]
        public async Task<Socio> GetSocioById(int id){
            return await _mediator.Send(new GetSocioById.Query { Id = id});
        }
    }
}