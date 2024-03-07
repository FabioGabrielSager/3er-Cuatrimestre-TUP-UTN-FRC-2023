using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs.Aviones;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Servicios.Aviones.Queries
{
    public class GetAviones
    {
        public class GetAvionesQuery : IRequest<ListadoAvionesDTO>{
            
        }

        public class GetAvionesQueryHandler : IRequestHandler<GetAvionesQuery, ListadoAvionesDTO>
        {
            private readonly ApplicationContext _context;

            public GetAvionesQueryHandler(ApplicationContext context){
                _context = context;
            }

            public async Task<ListadoAvionesDTO> Handle(GetAvionesQuery request, CancellationToken cancellationToken)
            {
                ListadoAvionesDTO result = new ListadoAvionesDTO();
                try
                {
                    var aviones = await _context.Aviones
                    .Include(a => a.IdFabricanteNavigation)
                    .Where(a => a.IdFabricanteNavigation.Nombre == "Boeing" || a.IdFabricanteNavigation.Nombre == "Airbus")
                    .ToListAsync(cancellationToken);

                    result.Aviones = aviones.Select(a => new AvionDTO(){
                        Id = a.Id,
                        Fabricante = a.IdFabricanteNavigation.Nombre,
                        CantidadAsientos = a.CantidadAsientos,
                        Modelo = a.Modelo,
                        CantidadMotores = a.CantidadMotores,
                        DatosVarios = a.DatosVarios
                    }).ToList();

                    result.Ok = true;
                    result.MensajeInfo = aviones.Count == 0 ? "No se encontraron aviones" : $"Se recuperaron {aviones.Count} aviones";
                    result.StatusCode = System.Net.HttpStatusCode.OK;
                }
                catch (System.Exception e)
                {
                    result.Ok = false;
                    result.MensajeInfo = e.Message;
                    result.Error = e.StackTrace;
                    result.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                }
                return result;
            }
        }

    }
}