using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Servicios.DocenteServ.Commands
{
    public class DeleteDocente
    {
        public class DeleteDocenteCommand : IRequest<RespuestaBase>{
            public int Id { get; set;}
        }

        public class DeleteDocenteCommandValidator : AbstractValidator<DeleteDocenteCommand>{
            public DeleteDocenteCommandValidator(){
                RuleFor(r => r.Id).NotEmpty().WithMessage("El Id no puede ser nulo");
            }
        }

        public class DeleteDocenteHandler : IRequestHandler<DeleteDocenteCommand, RespuestaBase>
        {
            private readonly ApplicationContext _context;
            private readonly DeleteDocenteCommandValidator _validator;

            public DeleteDocenteHandler(ApplicationContext context, DeleteDocenteCommandValidator validator){
                _context = context;
                _validator = validator;
            }

            public async Task<RespuestaBase> Handle(DeleteDocenteCommand request, CancellationToken cancellationToken)
            {   
                _validator.Validate(request);
                RespuestaBase result = new();
                try
                {
                    var docente = await _context.Docentes
                    .Include(d => d.IdNivelNavigation)
                    .Where(d => d.Id == request.Id)
                    .FirstOrDefaultAsync(cancellationToken: cancellationToken);

                    if(docente != null){
                        _context.Docentes.Remove(docente);
                        await _context.SaveChangesAsync(cancellationToken);

                        Log log = new Log(){
                            Log1 = $"Se elimino docente {docente.Id}, nombre {docente.Nombre} apellido {docente.Apellido}",
                            IdDocente = docente.Id,
                            FechaLog = DateOnly.Parse(DateTime.Now.ToString("yyyy/MM/dd"))
                        };
                        await _context.Logs.AddAsync(log, cancellationToken);
                        await _context.SaveChangesAsync(cancellationToken);

                        result.Ok = true;
                        result.MensajeInfo = "Se elimino el docente correctamente";
                        result.StatusCode = System.Net.HttpStatusCode.OK;
                    }
                    else {
                        result.Ok = false;
                        result.Error = $"No se encontro un docente con id {request.Id}";
                        result.MensajeInfo = $"No se encontro un docente con id {request.Id}";
                        result.StatusCode = System.Net.HttpStatusCode.NotFound;
                    }
                }
                catch (System.Exception e)
                {
                    result.Ok = false;
                    result.Error = e.StackTrace;
                    result.MensajeInfo = e.Message;
                    result.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                }
                return result;
            }
        }
    }
}