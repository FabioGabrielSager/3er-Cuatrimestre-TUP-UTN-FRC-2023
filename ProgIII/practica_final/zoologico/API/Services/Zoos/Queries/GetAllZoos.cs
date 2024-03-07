using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs.Zoos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Services.Zoos.Queries
{
    public class GetAllZoos
    {
        public class GetAllZoosQuery : IRequest<ZooListDTO>{

        }

        public class GetAllZoosQueryHandler : IRequestHandler<GetAllZoosQuery, ZooListDTO>
        {
            private readonly ZoosContext _context;
            public GetAllZoosQueryHandler(ZoosContext context)
            {
                _context = context;
            }
            
            public async Task<ZooListDTO> Handle(GetAllZoosQuery request, CancellationToken cancellationToken)
            {
                ZooListDTO result = new();
                try
                {
                    var zoos = await _context.Zoos
                    .Include(z => z.IdCiudadZooNavegation)
                    .Include(z => z.IdPaisZooNavegation)
                    .ToListAsync(cancellationToken: cancellationToken);
                    
                    if(zoos.Count > 0){
                        result.Zoos = zoos.Select(
                            zoo => new ZooStandard{
                                id = zoo.Id,
                                Nombre = zoo.Nombre,
                                Ciudad = zoo.IdCiudadZooNavegation.Nombre,
                                Pais = zoo.IdPaisZooNavegation.Nombre,
                                PresupuestoAnual = zoo.PresupuestoAnual,
                                TamanioEnM2 = zoo.TamanioEnM2
                            }
                        ).ToList();
                        result.Ok = true;
                        result.StatusCode = System.Net.HttpStatusCode.OK;
                    }
                    else {
                        result.Ok = false;
                        result.StatusCode = System.Net.HttpStatusCode.NotFound;
                        result.MensajeInfo = "No hay zoos cargados";
                    }
                }
                catch (System.Exception e)
                {
                    result.Ok = false;
                    result.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                    result.MensajeInfo = e.Message;
                    result.Error = e.StackTrace;
                }
                return result;
            }
        }
    }
}