using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Servicios.Usuarios.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuariosController(IMediator mediator){
            _mediator = mediator;
        }

        [HttpPost]
        [Route("LoginUser")]
        public Task<RespuestaBase> LoguearUsuario([FromBody] LoginUsuario.LoginUsuarioCommand cmd){
            return _mediator.Send(cmd);
        }

    }
}