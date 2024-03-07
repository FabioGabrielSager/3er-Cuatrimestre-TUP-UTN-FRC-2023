using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using FluentValidation;
using MediatR;
using MediatR.Pipeline;
using Microsoft.EntityFrameworkCore;

namespace API.Servicios.DocenteServ.Queries
{
    public class GetDocentesEjer1
    {
        public class QueryGetDocente : IRequest<DocenteGuardadoDTO> {
        }

        public class QueryGetDocentesHandler : IRequestHandler<QueryGetDocente, DocenteGuardadoDTO>
        {
            private readonly ApplicationContext _context;

            public QueryGetDocentesHandler(ApplicationContext context){
                _context = context;
            }
            
            public async Task<DocenteGuardadoDTO> Handle(QueryGetDocente request, CancellationToken cancellationToken)
            {
                DocenteGuardadoDTO result = new DocenteGuardadoDTO();
                try{
                    var responseDocente = await _context.Docentes
                    .Include((d) => d.IdNivelNavigation)
                    .Where(
                        (d) => d.Edad <= 40 && d.Edad >= 30 && d.Email.Contains("outlook")
                        && d.IdNivelNavigation.Nombre == "Secundario").FirstOrDefaultAsync(cancellationToken);
                    
                    if(responseDocente != null){
                        
                        result.docente = new DocenteDTO(){
                            Id = responseDocente.Id,
                            Nombre = responseDocente.Nombre,
                            Apellido = responseDocente.Apellido,
                            Edad = responseDocente.Edad,
                            Email = responseDocente.Email,
                            Nivel = responseDocente.IdNivelNavigation.Nombre
                        };
                        result.Ok = true;
                        result.StatusCode = HttpStatusCode.OK;
                        result.MensajeInfo = "Docente encontrado";
                        
                    }
                    else {
                        result.Ok = false;
                        result.Error = "No se econtro ningún docente";
                        result.StatusCode = HttpStatusCode.NotFound;
                    }
                }
                catch(Exception e){
                    result.Ok = false;
                    result.Error = e.StackTrace;
                    result.MensajeInfo = e.Message;
                    result.StatusCode = HttpStatusCode.InternalServerError;
                }
                return result;
            }
        }
    }
}