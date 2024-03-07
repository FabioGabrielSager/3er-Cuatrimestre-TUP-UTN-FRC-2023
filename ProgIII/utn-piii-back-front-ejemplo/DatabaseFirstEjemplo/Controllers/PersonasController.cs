using DatabaseFirstEjemplo.Dtos;
using DatabaseFirstEjemplo.Models;
using DatabaseFirstEjemplo.Servicios.Persona;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace DatabaseFirstEjemplo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public Task<ListadoPersonas> ObtenerPersonas()
        {
            var respuesta = _mediator.Send(new ConsultarPersonasQuery());
            return respuesta;
        }

        [HttpPost]
        public async Task<PersonaGuardada> CrearPersona([FromBody] GuardarPersonaDto dto)
        {
            /*
             * DESARROLLAR EL ENDPOINT PARA CREAR PERSONA
             * 
             * Convertir el DTO en una entidad Persona
             * 
             * Llamar al método asincronico para agregar una persona en la base de datos
             * 
             * Confirmar los cambios
             * 
             * En el objeto de respuesta cargar el DTO de persona con 
             * los datos de la persona guardada (ID actualizado por la base de datos)
             * 
             * Cargar los restantes atributos de la entidad RespuestaBase según corresponda
             * 
             * Tener en cuenta que hay que manejar el caso de error y devolver la respuesta indicando el mismo.
             */

            return null;
        }

        [HttpPut("{id}")]
        public async Task<PersonaGuardada> ModificarPersona(long id, [FromBody] PersonaDto dto)
        {
            /*
             * DESARROLLAR EL ENDPOINT PARA MODIFICAR PERSONA
             * 
             * Obtener la Persona según el ID especificado desde el contexto
             * 
             * Reemplazar los valores de la Persona obtenida por los valores provenientes del DTO
             * 
             * Llamar al método del contexto para actualizar la persona modificada previamente
             * 
             * Confirmar los cambios
             * 
             * Cargar en la respuesta el DTO correspondiente a los datos de la persona y 
             * los atributos de la RespuestaBase.
             * 
             * Tener en cuenta que hay que manejar el caso de error y devolver la respuesta indicando el mismo.
             */

            return null;
        }
        
        [HttpDelete("{id}")]
        public async Task<RespuestaBase> BorrarPersona(long id)
        {
            /*
             * DESARROLLAR EL ENDPOINT PARA ELIMINAR UNA PERSONA
             * 
             * Obtener la Persona según el ID especificado desde el contexto
             * 
             * Llamar al método  del contexto para borrar la persona obtenida anteriormente
             * 
             * Confirmar los cambios
             * 
             * Cargar en la respuesta los atributos de la RespuestaBase.
             * 
             * Tener en cuenta que hay que manejar el caso de error y devolver la respuesta indicando el mismo.
             */

            return null;
        }
    }
}
