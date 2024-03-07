using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using API.Data;
using API.DTOs.BarcoDTOs;
using API.DTOs.SocioDTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Services.SocioServ.Queries
{
    public class GetSocios
    {
        public class Query : IRequest<ListadoSociosDTO>{}

        public class Handler : IRequestHandler<Query, ListadoSociosDTO>
        {
            private readonly ApplicationContext _contexto;

            public Handler(ApplicationContext context){

                _contexto = context;
            }

            public async Task<ListadoSociosDTO> Handle(Query request, CancellationToken cancellationToken)
            {
                ListadoSociosDTO result = new ListadoSociosDTO();
                try{
                    var respuesta = await _contexto.Socios
                    .Include((s) => s.Barcos)
                    .ToListAsync(cancellationToken: cancellationToken);

                    result.Socios = respuesta.Select(socio => new SocioDTO{
                        Id = socio.Id,
                        Nombre = socio.Nombre,
                        Apellido = socio.Apellido,
                        Telefono = socio.Telefono,
                        barcos = socio.Barcos.Select(barco => new BarcoDTO{
                            Id = barco.Id,
                            NroMatricula = barco.NroMatricula,
                            Nombre = barco.Nombre,
                            NroAmarre = barco.NroAmarre,
                            Cuota = barco.Cuota
                        }).ToList()
                    }).ToList();

                    result.StatusCode = HttpStatusCode.OK;
                    result.Ok = true;
                }
                catch (Exception ex) {
                    result.Error = ex.Message;
                    result.StatusCode = HttpStatusCode.InternalServerError;
                    result.Ok = false;
                }

                return result;
            }
        }
    }
}