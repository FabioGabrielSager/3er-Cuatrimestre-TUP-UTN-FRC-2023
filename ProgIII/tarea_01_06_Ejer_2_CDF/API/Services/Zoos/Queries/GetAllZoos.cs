using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOS.Zoos;
using DB;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Services.Zoos.Queries
{
    public class GetAllZoos
    {
        public class GetAllZoosQuery : IRequest<ZoosListDTO>{

        }

        public class GetAllZoosHandler : IRequestHandler<GetAllZoosQuery, ZoosListDTO>
        {
            private readonly ZoosContext _context;

            public GetAllZoosHandler(ZoosContext context){
                _context = context;
            }

            public async Task<ZoosListDTO> Handle(GetAllZoosQuery request, CancellationToken cancellationToken)
            {
                ZoosListDTO result = new();

                try
                {
                    var response = await _context.Zoos
                    .Include(b => b.Ciudad)
                    .Include(b => b.Pais)
                    .ToListAsync(cancellationToken: cancellationToken);

                    if(response.Count > 0){
                        result.zoos = response.Select( z => new StandardZoo(){
                            Nombre = z.Nombre,
                            Ciudad = z.Ciudad.Nombre,
                            Pais = z.Pais.Nombre,
                            TamanioEnM2 = z.TamanioEnM2,
                            PresupuestoAnual = z.PresupuestoAnual
                        }).ToList();
                        result.httpStatusCode = System.Net.HttpStatusCode.OK;
                        result.ok = true;
                    }
                    else {
                        result.ok = false;
                        result.httpStatusCode = System.Net.HttpStatusCode.NotFound;
                        result.mensajeInfo = "No hay zoologicos cargados";
                    }
                }
                catch (System.Exception e)
                {
                    result.ok = false;
                    result.httpStatusCode = System.Net.HttpStatusCode.InternalServerError;
                    result.mensajeInfo = e.Message;
                    result.error = e.StackTrace;
                }
            return result;
            }
        }

    }
}