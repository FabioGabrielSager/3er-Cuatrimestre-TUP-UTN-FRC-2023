using EjemploCQRS.Datos;
using EjemploCQRS.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EjemploCQRS.Servicios.Personas
{
    public class ConsultarPersonasHandler
        : IRequestHandler<ConsultarPersonasQuery, ListadoPersonas>
    {
        private readonly EfdatabaseFirstContext _contexto;

        public ConsultarPersonasHandler(EfdatabaseFirstContext contexto)
        {
            _contexto = contexto;
        }
        public async Task<ListadoPersonas> Handle(ConsultarPersonasQuery request, 
            CancellationToken cancellationToken)
        {
            ListadoPersonas respuesta = new ListadoPersonas();
            try
            {
                var listado = await _contexto.Personas.ToListAsync();

                List<PersonaDto> listadoDto = new List<PersonaDto>();
                foreach (var persona in listado)
                {
                    listadoDto.Add(new PersonaDto
                    {
                        Id = persona.Id,
                        NombreCompleto = $"{persona.Nombre}, {persona.Apellido}",
                    });
                }

                respuesta.Exito = true;
                respuesta.Personas = listadoDto;
                respuesta.Codigo = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                respuesta.Exito = false;
                respuesta.Error = ex.Message;
                respuesta.Codigo = HttpStatusCode.InternalServerError;
            }

            return respuesta;
        }
    }
}
