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
    public class PostDocente
    {
        public class PostDocenteCommand : IRequest<DocenteGuardadoDTO>{
            public string Nombre { get; set; }

            public string Apellido { get; set; }

            public int Edad { get; set; }

            public string Email { get; set; }

            public string Nivel { get; set; }
        }

        public class PostDocenteValidator : AbstractValidator<PostDocenteCommand>{
            public PostDocenteValidator(){
                RuleFor(d => d.Nombre).NotEmpty().WithMessage("El nombre no puede esta vacia");
                RuleFor(d => d.Apellido).NotEmpty().WithMessage("El apellido no puede esta vacia");
                RuleFor(d => d.Edad).NotEmpty().WithMessage("La edad no puede esta vacia")
                .GreaterThan(18).WithMessage("La edad debe ser mayor a 18");
                RuleFor(d => d.Email).EmailAddress().WithMessage("Debe ingresar un Email valido");
                RuleFor(d => d.Nivel).Matches(@"^[A-Z].*").WithMessage("El nivel debe comenzar con mayuscula");
            }
        }

        public class PostDocenteHandler : IRequestHandler<PostDocenteCommand, DocenteGuardadoDTO>
        {
            private readonly ApplicationContext _context;
            private readonly PostDocenteValidator _validator;

            public PostDocenteHandler(ApplicationContext context, PostDocenteValidator validator){
                _context = context;
                _validator = validator;
            }

            public async Task<DocenteGuardadoDTO> Handle(PostDocenteCommand request, CancellationToken cancellationToken)
            {
                _validator.Validate(request);
                DocenteGuardadoDTO result = new();
                try
                {
                    var nivel = await _context.Nivels
                    .Where(n => n.Nombre == request.Nivel).FirstOrDefaultAsync(cancellationToken: cancellationToken);

                    if(nivel != null){

                        Docente docenteNuevo = new Docente(){
                            Nombre = request.Nombre,
                            Apellido = request.Apellido,
                            Edad = request.Edad,
                            Email = request.Email,
                            IdNivel = nivel.Id,
                            IdNivelNavigation = nivel
                        };

                        await _context.Docentes.AddAsync(docenteNuevo, cancellationToken);
                        await _context.SaveChangesAsync(cancellationToken);

                        Log log = new Log(){
                            IdDocente = docenteNuevo.Id,
                            Log1 = "Se agrego un nuevo docente",
                            FechaLog = DateOnly.Parse(DateTime.Now.ToString("yyyy-MM-dd"))
                        };

                        await _context.Logs.AddAsync(log, cancellationToken);
                        await _context.SaveChangesAsync(cancellationToken);

                        result.docente = new DocenteDTO(){
                            Id = docenteNuevo.Id,
                            Nombre = docenteNuevo.Nombre,
                            Apellido = docenteNuevo.Apellido,
                            Edad = docenteNuevo.Edad,
                            Email = docenteNuevo.Email,
                            Nivel = docenteNuevo.IdNivelNavigation.Nombre
                        };
                        result.StatusCode = System.Net.HttpStatusCode.OK;
                        result.Ok = true;
                        result.MensajeInfo = "Se guardo el docente correctamente";
                    }
                    else{
                        result.Ok = false;
                        result.StatusCode = System.Net.HttpStatusCode.NotFound;
                        result.Error = $"No existe el nivel  \"{request.Nivel}\"";
                        result.MensajeInfo = $"No existe el nivel  \"{request.Nivel}\"";
                    }
                }
                catch (System.Exception e)
                {
                    result.Ok = false;
                    result.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                    result.Error = e.StackTrace;
                    result.MensajeInfo = e.Message;
                }
                return result;
            }
        }
    }
}