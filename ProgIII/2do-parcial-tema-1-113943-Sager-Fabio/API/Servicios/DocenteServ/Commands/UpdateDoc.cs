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

namespace API.Servicios.DocenteServ.Commands
{
    public class UpdateDoc
    {
            public class CommandUpdateDoc : IRequest<DocenteGuardadoDTO> {
                public int Id { get; set; }
                public string Nombre { get; set; }

                public string Apellido { get; set; }

                public int Edad { get; set; }

                public string Email { get; set; }
            }

            public class CommandUpdateDocValidator : AbstractValidator<CommandUpdateDoc>{
                public CommandUpdateDocValidator(){
                    RuleFor((r) => r.Nombre).NotEmpty().WithMessage("El nombre no puede ser nula");
                    RuleFor((r) => r.Apellido).NotEmpty().WithMessage("El apellido no puede ser nula");
                }
            }

            public class QueryGetDocentesHandler : IRequestHandler<CommandUpdateDoc, DocenteGuardadoDTO>
            {
                private readonly ApplicationContext _context;
                private readonly CommandUpdateDocValidator _validator;

                public QueryGetDocentesHandler(ApplicationContext context, CommandUpdateDocValidator validator){
                    _context = context;
                    _validator = validator;
                }
                
                public async Task<DocenteGuardadoDTO> Handle(CommandUpdateDoc request, CancellationToken cancellationToken)
                {
                    DocenteGuardadoDTO result = new DocenteGuardadoDTO();
                    try{
                        _validator.Validate(request);
                       
                        var responseDocente = await _context.Docentes.Where(
                        (d) => d.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
                        if(responseDocente != null){

                            responseDocente.Nombre = request.Nombre;
                            responseDocente.Apellido = request.Apellido;
                            responseDocente.Email = request.Email;
                            responseDocente.Edad = request.Edad;
                            
                            _context.Update(responseDocente);
                            await _context.SaveChangesAsync();

                            result.Ok = true;
                            result.StatusCode = HttpStatusCode.OK;
                            result.MensajeInfo = "Docente Modificado";
                            
                            Log log = new Log(){
                                FechaLog = DateOnly.Parse(DateTime.Now.ToString("yyyy-MM-dd")),
                                IdDocente = responseDocente.Id,
                                Log1 = ""
                            };

                            await _context.Logs.AddAsync(log);
                        }
                        else {
                            result.Ok = false;
                            result.Error = "No se econtro ningún docente";
                            result.StatusCode = HttpStatusCode.NotFound;
                        }
                    }
                    catch(Exception e){
                        result.Ok = false;
                        result.Error = e.Message;
                        result.StatusCode = HttpStatusCode.InternalServerError;
                    }
                    return result;
                }
        }
    }
}