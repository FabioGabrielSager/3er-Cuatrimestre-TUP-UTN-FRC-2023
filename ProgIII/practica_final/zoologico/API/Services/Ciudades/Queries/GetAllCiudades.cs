using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Services.Ciudades.Queries
{
    public class GetAllCiudades
    {
        public class GetAllCiudadesQuery : IRequest<List<Ciudad>>{

        }
        public class GetAllCiudadesQueryHandler : IRequestHandler<GetAllCiudadesQuery, List<Ciudad>>
        {
            private readonly ZoosContext _context;
            public GetAllCiudadesQueryHandler(ZoosContext context)
            {
                _context = context;
            }
            public async Task<List<Ciudad>> Handle(GetAllCiudadesQuery request, CancellationToken cancellationToken)
            {
                List<Ciudad> result = new();

                try
                {
                    var ciudades = await _context.Ciudades.ToListAsync(cancellationToken: cancellationToken);

                    if(ciudades.Count > 0){
                        result = ciudades.Select(p => new Ciudad(){
                            Id = p.Id,
                            Nombre = p.Nombre
                        }).ToList();
                    }
                }
                catch (System.Exception e)
                {
                    throw;
                }

                return result;
            }
        }
    }
}