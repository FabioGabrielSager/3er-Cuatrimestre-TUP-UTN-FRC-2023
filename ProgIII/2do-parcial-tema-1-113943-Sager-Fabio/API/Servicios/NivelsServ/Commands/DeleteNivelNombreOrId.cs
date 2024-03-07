using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Servicios.NivelsServ.Commands
{
    public class DeleteNivelNombreOrId
    {
        public class DeleteNivelNombreOrIdCommand : IRequest<RespuestaBase>{
            public int Id { get; set; }
            public string Nombre { get; set; }
        }

        public class DeleteNivelNombreOrIdValidator : AbstractValidator<DeleteNivelNombreOrIdCommand>{
            public DeleteNivelNombreOrIdValidator(){
                RuleFor(d => d.Id).NotEmpty()
                .Unless(d => !string.IsNullOrEmpty(d.Nombre)).WithMessage("El campo Nombre debe estar lleno si la ID está vacía");
            }
        }

        public class DeleteNivelNombreOrIdHandler : IRequestHandler<DeleteNivelNombreOrIdCommand, RespuestaBase>
        {
            private readonly ApplicationContext _context;
            private readonly DeleteNivelNombreOrIdValidator _validator;

            public DeleteNivelNombreOrIdHandler(ApplicationContext context, DeleteNivelNombreOrIdValidator validator){
                _context = context;
                _validator = validator;
            }
            public async Task<RespuestaBase> Handle(DeleteNivelNombreOrIdCommand request, CancellationToken cancellationToken)
            {
                RespuestaBase result = new();
                try
                {
                    var nivel = await _context.Nivels
                    .Include(n => n.Docentes)
                    .Where(n => n.Id == request.Id || n.Nombre == request.Nombre)
                    .FirstOrDefaultAsync(cancellationToken: cancellationToken);

                    if(nivel != null){
                        _context.Docentes.RemoveRange(nivel.Docentes);
                        _context.Nivels.Remove(nivel);
                        await _context.SaveChangesAsync(cancellationToken);

                        result.Ok = true;
                        result.StatusCode = System.Net.HttpStatusCode.OK;
                        result.MensajeInfo = "Se elimino el email correctamente";
                    }
                    else {
                        result.Ok = false;
                        result.StatusCode = System.Net.HttpStatusCode.NotFound;
                        result.MensajeInfo = $"No se encontro un nivel con id {request.Id} o nombre {request.Nombre}";
                        result.Error = $"No se encontro un nivel con id {request.Id} o nombre {request.Nombre}";
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