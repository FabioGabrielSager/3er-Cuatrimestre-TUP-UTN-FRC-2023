using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using API.DTOS.Common;
using AutoMapper;
using DB;
using MediatR;

namespace API.Services.Ciudades.Queries
{
    public class GetAllCities
    {
        public class GetAllCitiesQuery : IRequest<CitiesList>{}

        public class GetAllCitiesQueryHandler : IRequestHandler<GetAllCitiesQuery, CitiesList>
        {
            private readonly ZoosContext _context;
            private readonly IMapper _mapper;
            
            public GetAllCitiesQueryHandler(ZoosContext context, IMapper mapper){
                _context = context;
                _mapper = mapper;
            }

            public Task<CitiesList> Handle(GetAllCitiesQuery request, CancellationToken cancellationToken)
            {
                CitiesList result = new();

                try
                {
                    var response = _context.Ciudades.ToListAsync();
                    if(response.Count > 0){
                        result.Cities = response;
                        result.httpStatusCode = HttpStatusCode.OK;
                        result.ok = true;
                    }
                    else{
                        result.mensajeInfo = "No se encontraron ciudades";
                        result.httpStatusCode = HttpStatusCode.NotFound;
                        result.ok = false;
                    }
                }
                catch (System.Exception e)
                {
                    result.mensajeInfo = e.Message;
                    result.error = e.StackTrace;
                    result.httpStatusCode = HttpStatusCode.InternalServerError;
                    result.ok = false;
                }
                
                return result;
            }
        }
    }
}