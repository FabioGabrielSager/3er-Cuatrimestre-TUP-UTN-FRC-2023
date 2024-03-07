using EjemploCQRS.Datos;
using EjemploCQRS.Dtos;
using EjemploCQRS.Servicios.Personas;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EjemploCQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonasController(
            IMediator mediator
        )
        {
            _mediator = mediator;
        }

        [HttpGet]
        public Task<ListadoPersonas> ObtenerPersonas()
        {
            var request = new ConsultarPersonasQuery();
            var respuesta = _mediator.Send(request);
            return respuesta;
        }

        [HttpPost]
        public Task<PersonaGuardada> CrearPersona([FromBody] GuardarPersonaCommand dto)
        {
            var respuesta = _mediator.Send(dto);
            return respuesta;
        }
    }
}
