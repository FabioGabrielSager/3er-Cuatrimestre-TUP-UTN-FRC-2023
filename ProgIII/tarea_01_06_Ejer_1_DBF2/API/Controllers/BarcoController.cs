using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.BarcoDTOs;
using API.Services.BarcoServ.Commands;
using API.Services.BarcoServ.Queries;
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


        [HttpPost]
        [Route("AgregarBarco")]
        public Task<BarcoGuardadoDTO> guardarBarco([FromBody] AddBarco.AddBarcoCommand addBarcoCommand){
            return _mediator.Send(addBarcoCommand);
        }

        [HttpGet]
        [Route("GetBarcoById/{id}")]
        public Task<BarcoConNombreYApellidoDeSocioDTO> GetBarcoById (int id){
            return _mediator.Send(new GetBarcoById.GetBarcoQuery(){Id = id});
        }

        [HttpGet]
        [Route("GetBarco")]
        public Task<BarcoConNombreYApellidoDeSocioDTO> GetBarco(){
            return _mediator.Send(new GetBarco.GetBarcoQuery());
        }

        [HttpPut]
        [Route("UpdateBarco")]
        public Task<BarcoConNombreYApellidoDeSocioDTO> UpdateBarco([FromBody] UpdateBarco.UpdateBarcoCommand command){
            return _mediator.Send(command);
        }
    }
}