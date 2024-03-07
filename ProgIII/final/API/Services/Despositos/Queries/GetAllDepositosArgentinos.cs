using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Services.Despositos.Queries
{
    public class GetAllDepositosArgentinos
    {
        public class GetAllDepositosArgentinosQuery : IRequest<ListadoDespositosDTO>{
            
        }

        public class GetAllDepositosArgentinosQueryHandler : IRequestHandler<GetAllDepositosArgentinosQuery, ListadoDespositosDTO>
        {
            private readonly ApplicationContext _context;

            public GetAllDepositosArgentinosQueryHandler(ApplicationContext context){
                _context = context;
            }

            public async Task<ListadoDespositosDTO> Handle(GetAllDepositosArgentinosQuery request, CancellationToken cancellationToken)
            {
                ListadoDespositosDTO result = new();

                try
                {
                    var depositos = await _context.Deposito
                    .Include(d => d.BarrioIdNavegation)
                    .Include(d => d.BarrioIdNavegation.CiudadIdNavegation)
                    .Include(d => d.BarrioIdNavegation.CiudadIdNavegation.PaisIdNavegation)
                    .Where(d => d.BarrioIdNavegation.CiudadIdNavegation.PaisIdNavegation.Nombre == "Argentina")
                    .ToListAsync(cancellationToken: cancellationToken);

                    if(depositos.Count > 0){
                        result.Depositos = depositos.Select(d => new DepositoStandard{
                            Nombre = d.Nombre,
                            MetrosCuadrados = d.MetrosCuadrados,
                            calle = d.calle,
                            numero = d.numero,
                            Barrio = d.BarrioIdNavegation.Nombre,
                            Ciudad = d.BarrioIdNavegation.CiudadIdNavegation.Nombre,
                            Pais = d.BarrioIdNavegation.CiudadIdNavegation.PaisIdNavegation.Nombre
                        }).ToList();

                        result.Ok = true;
                        result.StatusCode = System.Net.HttpStatusCode.OK;
                        result.MensajeInfo = "Despositos recuperados...";
                    }
                    else{
                        result.Ok = false;
                        result.StatusCode = System.Net.HttpStatusCode.NotFound;
                        result.MensajeInfo = "No se encontraron depositos...";
                        result.Error = "No se encontraron depositos...";
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