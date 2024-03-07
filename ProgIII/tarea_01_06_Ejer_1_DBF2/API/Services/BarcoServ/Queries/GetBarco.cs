using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using API.Data;
using API.DTOs.BarcoDTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Services.BarcoServ.Queries
{
    public class GetBarco
    {
        public class GetBarcoQuery : IRequest<BarcoConNombreYApellidoDeSocioDTO>{

        }

        public class GetBarcoHandler : IRequestHandler<GetBarcoQuery, BarcoConNombreYApellidoDeSocioDTO>
        {
            private readonly ApplicationContext _context;

            public GetBarcoHandler(ApplicationContext context){
                _context = context;
            }

            public async Task<BarcoConNombreYApellidoDeSocioDTO> Handle(GetBarcoQuery request, CancellationToken cancellationToken)
            {  
                BarcoConNombreYApellidoDeSocioDTO result = new BarcoConNombreYApellidoDeSocioDTO();
                try
                {
                    var response = await _context.Barcos
                    .Include((b) => b.IdSocioNavigation)
                    .Where((b) => b.NroMatricula == 10 && b.Nombre.StartsWith("S") &&
                    b.Cuota >= 100 && b.IdSocioNavigation.Nombre.Equals("Raul") &&
                    b.IdSocioNavigation.Apellido.Equals("Perez")).FirstOrDefaultAsync(cancellationToken: cancellationToken);

                    if(response != null){
                        result.Barco = new BarcoDTO
                        {
                            Nombre = response.Nombre,
                            NroAmarre = response.NroAmarre,
                            NroMatricula = response.NroMatricula,
                            Cuota = response.Cuota,
                            Id = response.Id
                        };
                        result.NombreYApellidoSocio = $"{response.IdSocioNavigation.Nombre} {response.IdSocioNavigation.Apellido}";

                        result.Ok = true;
                        result.StatusCode = HttpStatusCode.OK;
                        result.MensajeInfo = "Barco encontrado";
                    }
                    else{
                        result.Ok = false;
                        result.StatusCode = HttpStatusCode.NotFound;
                        result.MensajeInfo = "Barco no encontrado";
                    }
                }
                catch (System.Exception e)
                {
                        result.Ok = false;
                        result.StatusCode = HttpStatusCode.InternalServerError;
                        result.MensajeInfo = e.Message;
                        result.Error = e.StackTrace;
                }
                return result;
            }
        }

    }
}