using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Servicios.NivelsServ.queries
{
    public class GetNivelsConDocentes
    {
        public class GetNivelsConDocentesQuery : IRequest<ListadoNivelsConDocentesDTO>{}
        public class GetNivelsConDocentesHandler : IRequestHandler<GetNivelsConDocentesQuery, ListadoNivelsConDocentesDTO>
        {
            private readonly ApplicationContext _context;

            public GetNivelsConDocentesHandler(ApplicationContext context){
                _context = context;
            }

            public async Task<ListadoNivelsConDocentesDTO> Handle(GetNivelsConDocentesQuery request, CancellationToken cancellationToken)
            {
                ListadoNivelsConDocentesDTO result = new();
                try
                {
                    var niveles = await _context.Nivels
                    .Include(x => x.Docentes)
                    .ToListAsync(cancellationToken: cancellationToken);

                    result.Niveles = niveles.Select(x => new NivelConDocentesDTO(){
                        Id = x.Id,
                        Nombre = x.Nombre,
                        docentes = x.Docentes.Select(d => new DocenteDTO(){
                            Id = d.Id,
                            Nombre = d.Nombre,
                            Edad = d.Edad,
                            Apellido = d.Apellido,
                            Email = d.Email,
                            Nivel = x.Nombre 
                        }).OrderBy(x => x.Id).ToList()
                    }).ToList();

                    result.Ok = true;
                    result.StatusCode = System.Net.HttpStatusCode.OK;
                    result.MensajeInfo = niveles.Count > 0? "Niveles recuperados" : "No hay ningún nivel cargado";
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