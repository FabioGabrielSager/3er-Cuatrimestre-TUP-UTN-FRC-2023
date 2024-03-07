using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Business.SociosBusiness.Commands;
using API.Business.SociosBusiness.Queries;
using API.Data;
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

        [HttpPost]
        [Route("save")]
        public async Task<Socio> SaveSocio([FromBody] SaveSocio.SaveSocioCommand saveSocioCommand){
            return await _mediator.Send(saveSocioCommand);
        }

        [HttpGet]
        [Route("getById/{id}")]
        public async Task<Socio> GetSocioById(int id){
            return await _mediator.Send(new GetSocioById.GetSocioByIdQuery{Id = id});
        }
    }
}