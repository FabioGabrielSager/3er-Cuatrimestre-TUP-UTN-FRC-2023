using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Servicios.NivelsServ.queries
{
    public class GetNivels
    {
        public class GetNivelsQuery : IRequest<ListadoNivelsDTO>{}
        public class GetNivelsHandler : IRequestHandler<GetNivelsQuery, ListadoNivelsDTO>
        {
            private readonly ApplicationContext _context;

            public GetNivelsHandler(ApplicationContext context){
                _context = context;
            }

            public async Task<ListadoNivelsDTO> Handle(GetNivelsQuery request, CancellationToken cancellationToken)
            {
                ListadoNivelsDTO result = new();
                try
                {
                    var niveles = await _context.Nivels.ToListAsync(cancellationToken: cancellationToken);
                    result.Niveles = new List<NivelDTO>();
                    foreach (Nivel n in niveles)
                    {
                        result.Niveles.Add(new NivelDTO(){ Id = n.Id, Nombre = n.Nombre });
                    }
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