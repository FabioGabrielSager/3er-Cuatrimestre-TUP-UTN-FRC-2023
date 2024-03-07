using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs.SocioDTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Services.SocioServ.Queries
{
    public class GetSocioByNombreYApellido
    {
        public class Query : IRequest<SocioGuardadoDTO>{
            public string Nombre {get; set;}
            public string Apellido {get; set;}
        }

        public class Handler : IRequestHandler<Query, SocioGuardadoDTO>
        {
            private readonly ApplicationContext _context;

            public Handler(ApplicationContext context){
                _context = context;
            }

            public async Task<SocioGuardadoDTO> Handle(Query request, CancellationToken cancellationToken)
            {
                SocioGuardadoDTO result = new();
                try{
                    var response = await _context.Socios.FirstOrDefaultAsync((s) => s.Nombre == request.Nombre &&
                    s.Apellido == request.Apellido);

                    if(response != null)
                    {
                        result.Socio = new SocioDTO{
                            Id = response.Id,
                            Nombre = response.Nombre,
                            Apellido = response.Apellido,
                            Telefono = response.Telefono
                        };
                        result.Ok = true;
                        result.StatusCode = System.Net.HttpStatusCode.OK;
                    }
                    else
                    {
                        result.Error=$"El socio con nombre {request.Nombre} y apellido {request.Apellido} no esta registrado";
                        result.Ok = false;
                        result.StatusCode = System.Net.HttpStatusCode.NotFound;
                    }
                }
                catch(Exception ex){
                    result.Error=ex.Message;
                    result.Ok = false;
                    result.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                }
                return result;
            }
        }
    }
}