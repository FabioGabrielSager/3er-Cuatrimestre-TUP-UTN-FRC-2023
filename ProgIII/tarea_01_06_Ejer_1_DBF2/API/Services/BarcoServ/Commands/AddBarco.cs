using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using API.Data;
using API.DTOs.BarcoDTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Services.BarcoServ.Commands
{
    public class AddBarco
    {
        public class AddBarcoCommand : IRequest<BarcoGuardadoDTO>{
                public int NroMatricula { get; set; }
                public string Nombre { get; set; } = null!;
                public int NroAmarre { get; set; }
                public double Cuota { get; set; }
                public int IdSocio { get; set; }
        }

        public class AddBarcoHandler : IRequestHandler<AddBarcoCommand, BarcoGuardadoDTO>
        {
            private readonly ApplicationContext _contexto;
            
            public AddBarcoHandler(ApplicationContext contexto) {
                _contexto = contexto;
            }

            public async Task<BarcoGuardadoDTO> Handle(AddBarcoCommand request, CancellationToken cancellationToken)
            {
                BarcoGuardadoDTO result = new();
                try{
                    var socio = await _contexto.Socios.Where(s => s.Id == request.IdSocio).FirstOrDefaultAsync(cancellationToken: cancellationToken);

                    if(socio == null){
                        result.Error = "No hay un socio registrado con id " + request.IdSocio;
                        result.StatusCode = HttpStatusCode.NotFound;
                        result.Ok = false;
                    }else{
                        Barco response = new(){ NroMatricula = request.NroMatricula, Cuota = request.Cuota, IdSocio
                            = request.IdSocio, IdSocioNavigation = socio, Nombre=request.Nombre, NroAmarre = request.NroAmarre};

                    await _contexto.Barcos.AddAsync(response, cancellationToken);
                    await _contexto.SaveChangesAsync(cancellationToken);

                    result.Barco = new BarcoDTO(){
                            Id = response.Id,
                            NroMatricula = response.NroMatricula,
                            Nombre = response.Nombre,
                            NroAmarre = response.NroAmarre,
                            Cuota = response.Cuota,
                        };
                    result.Ok = true;
                    result.StatusCode = HttpStatusCode.OK;
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