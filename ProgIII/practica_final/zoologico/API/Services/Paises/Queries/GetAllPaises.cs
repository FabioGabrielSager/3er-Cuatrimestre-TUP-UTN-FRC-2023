using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Services.Paises.Queries
{
    public class GetAllPaises
    {
        public class GetAllPaisesQuery : IRequest<List<Pais>>{

        }
        public class GetAllPaisesQueryHandler : IRequestHandler<GetAllPaisesQuery, List<Pais>>
        {
            private readonly ZoosContext _context;
            public GetAllPaisesQueryHandler(ZoosContext context)
            {
                _context = context;
            }
            public async Task<List<Pais>> Handle(GetAllPaisesQuery request, CancellationToken cancellationToken)
            {
                List<Pais> result = new();

                try
                {
                    var paises = await _context.Paises.ToListAsync(cancellationToken: cancellationToken);

                    if(paises.Count > 0){
                        result = paises.Select(p => new Pais(){
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