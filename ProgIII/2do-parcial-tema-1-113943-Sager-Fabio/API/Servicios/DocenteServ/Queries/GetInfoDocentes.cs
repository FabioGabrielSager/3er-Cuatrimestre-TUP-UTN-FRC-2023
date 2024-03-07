using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Servicios.DocenteServ.Queries
{
    public class GetInfoDocentes
    {
        public class GetInfoDocentesQuery : IRequest<RespuestaBase>{

        }

        public class GetInfoDocentesHandler : IRequestHandler<GetInfoDocentesQuery, RespuestaBase>
        {  
            private readonly ApplicationContext _context;

            public GetInfoDocentesHandler(ApplicationContext context){
                _context = context;
            }

            public async Task<RespuestaBase> Handle(GetInfoDocentesQuery request, CancellationToken cancellationToken)
            {
                RespuestaBase result = new();
                try
                {
                    var docentes = await _context.Docentes.ToListAsync(cancellationToken);
                    var docentesDeNivelSecu = await _context.Docentes
                    .Include(d => d.IdNivelNavigation)
                    .Where(d => d.IdNivelNavigation.Nombre == "Secundario").ToListAsync(cancellationToken);

                    result.StatusCode = HttpStatusCode.OK;
                    result.Ok = true;
                    result.MensajeInfo = $"La cantidad de docentes es de: {docentes.Count} y de este total {docentesDeNivelSecu.Count} son de nivel secundario";
                }
                catch (System.Exception e)
                {
                    result.StatusCode = HttpStatusCode.InternalServerError;
                    result.Ok = false;
                    result.MensajeInfo = e.Message;
                    result.Error = e.StackTrace;
                }
                return result;
            }
        }
    }
}