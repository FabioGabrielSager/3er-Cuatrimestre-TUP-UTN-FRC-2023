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
    public class GetBarcoById
    {
        public class GetBarcoQuery : IRequest<BarcoConNombreYApellidoDeSocioDTO>{
            public int Id { get; set;}
        }

        public class GetBarcoQueryHandler : IRequestHandler<GetBarcoQuery, BarcoConNombreYApellidoDeSocioDTO>
        {
            private readonly ApplicationContext _contexto;
            
            public GetBarcoQueryHandler(ApplicationContext contexto) {
                _contexto = contexto;
            }
            public async Task<BarcoConNombreYApellidoDeSocioDTO> Handle(GetBarcoQuery request, CancellationToken cancellationToken)
            {
                BarcoConNombreYApellidoDeSocioDTO result = new();
                try{
                    var response = await _contexto.Barcos.
                    Where((b) => b.Id == request.Id)
                    .Include((b) => b.IdSocioNavigation)
                    .FirstOrDefaultAsync(cancellationToken: cancellationToken);
                    
                    if(response != null){
                        result.Barco = new BarcoDTO(){
                            Id = response.Id,
                            NroMatricula = response.NroMatricula,
                            Nombre = response.Nombre,
                            NroAmarre = response.NroAmarre,
                            Cuota = response.Cuota,
                        };                        
                        result.NombreYApellidoSocio = $"{response.IdSocioNavigation.Nombre} {response.IdSocioNavigation.Apellido}";

                        result.Ok = true;
                        result.StatusCode = HttpStatusCode.OK;
                    }
                    else {
                        result.Error = "Barco no encontrado";
                        result.Ok = false;
                        result.StatusCode = HttpStatusCode.NotFound;
                    }

                }
                catch(Exception ex){
                    result.Error = ex.Message;
                    result.StatusCode = HttpStatusCode.InternalServerError;
                    result.Ok = false;
                }
                return result;
            }
        }
    }
}