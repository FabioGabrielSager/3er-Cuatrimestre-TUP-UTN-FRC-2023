using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Services.Zoos.Commands
{
    public class PutZoo
    {
        public class PutZooCommand : IRequest<RespuestaBase>{
            public Guid IdZoo {get; set;}
            public int CiudadId { get; set; }
            public int PaisId { get; set; }

            public string Nombre { get; set; }
            public double PresupuestoAnual { get; set; }
            public double TamanioEnM2 { get; set; }
        }

        public class PutZooCommandHandler : IRequestHandler<PutZooCommand, RespuestaBase>
        {
            private readonly ZoosContext _context;
            public PutZooCommandHandler(ZoosContext context)
            {
                _context = context;
            }
            public async Task<RespuestaBase> Handle(PutZooCommand request, CancellationToken cancellationToken)
            {
                RespuestaBase result = new();
                
                try
                {
                    var zooEnBD = await _context.Zoos
                    .Where(z => z.Id == request.IdZoo)
                    .FirstOrDefaultAsync(cancellationToken: cancellationToken);

                    if(zooEnBD != null){
                        zooEnBD.CiudadId = request.CiudadId;
                        zooEnBD.PaisId = request.PaisId;
                        zooEnBD.Nombre = request.Nombre;
                        zooEnBD.PresupuestoAnual = request.PresupuestoAnual;
                        zooEnBD.TamanioEnM2 = request.TamanioEnM2;

                        _context.Update(zooEnBD);
                        await _context.SaveChangesAsync(cancellationToken);

                        result.Ok = true;
                        result.StatusCode = System.Net.HttpStatusCode.OK;
                        result.MensajeInfo = "Zoo actualizado correctamente";
                    }
                    else {
                        result.Ok = true;
                        result.StatusCode = System.Net.HttpStatusCode.NotFound;
                        result.MensajeInfo = "No se econtro ningún zoo que coincida con esos atributos";
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