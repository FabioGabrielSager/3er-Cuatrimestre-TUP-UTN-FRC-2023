using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Services.Despositos.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/Depositos")]
    public class DepositosController : ControllerBase
    {
        public readonly IMediator _mediator;

        public DepositosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("/obtenerDepositos")]
        public Task<ListadoDespositosDTO> ObtenerDepositos(){
            return _mediator.Send(new GetAllDespositos.GetAllDepositosQuery());
        }

        [HttpGet]
        [Route("/obtenerDepositosArgentinos")]
        public Task<ListadoDespositosDTO> ObtenerDepositosArgentinos(){
            return _mediator.Send(new GetAllDepositosArgentinos.GetAllDepositosArgentinosQuery());
        }
    }
}