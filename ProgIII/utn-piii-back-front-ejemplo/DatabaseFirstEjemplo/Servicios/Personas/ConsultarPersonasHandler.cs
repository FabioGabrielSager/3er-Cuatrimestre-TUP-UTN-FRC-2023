using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DatabaseFirstEjemplo.Dtos;
using DatabaseFirstEjemplo.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirstEjemplo.Servicios.Personas
{
    public class ConsultarPersonasHandler : IRequestHandler<ConsultarPersonasQuery, ListadoPersonas>
    {
        private readonly EfdatabaseFirstContext _contexto;
        public ConsultarPersonasHandler(EfdatabaseFirstContext efdatabaseFirstContext){
            _contexto = efdatabaseFirstContext;
        }
        public async Task<ListadoPersonas> Handle(ConsultarPersonasQuery request, CancellationToken cancellationToken)
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
                        NombreCompleto = string.Format("{0}, {1}",
                            persona.Nombre,
                            persona.Apellido)
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