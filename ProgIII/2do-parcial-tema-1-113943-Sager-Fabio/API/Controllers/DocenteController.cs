using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Servicios.DocenteServ.Commands;
using API.Servicios.DocenteServ.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocenteController : ControllerBase
    {
        private IMediator _mediator;

        public DocenteController(IMediator mediator){
            _mediator = mediator;
        }

        [HttpGet]
        [Route("/getDoc/")]
        public Task<DocenteGuardadoDTO> getDocById(){
            return _mediator.Send(new GetDocentesEjer1.QueryGetDocente());
        }

        [HttpGet]
        [Route("/getInfoDocentes/")]
        public Task<RespuestaBase> GetInfoDocentes(){
            return _mediator.Send(new GetInfoDocentes.GetInfoDocentesQuery());
        }

        [HttpPut]
        [Route("/modificarDoc/")]
        public Task<DocenteGuardadoDTO> modificarDoc([FromBody] UpdateDoc.CommandUpdateDoc cmd){
            return _mediator.Send(cmd);
        }

        [HttpPost]
        [Route("/postDocente/")]
        public Task<DocenteGuardadoDTO> PostDoc([FromBody] PostDocente.PostDocenteCommand cmd){
            return _mediator.Send(cmd);
        }

        [HttpDelete]
        [Route("/eliminarDoc/{id}")]
        public Task<RespuestaBase> DeletDoc(int id){
            return _mediator.Send(new DeleteDocente.DeleteDocenteCommand(){ Id = id});
        }
    }
}