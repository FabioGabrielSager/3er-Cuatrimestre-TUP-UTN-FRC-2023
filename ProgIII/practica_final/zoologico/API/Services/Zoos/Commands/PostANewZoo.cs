using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Services.Zoos.DBValidators;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Services.Zoos.Commands
{
    public class PostANewZoo
    {
        public class PostANewZooCommand : IRequest<RespuestaBase>{
            public string Ciudad { get; set; }
            public string Pais { get; set; }

            public string Nombre { get; set; }
            public double PresupuestoAnual { get; set; }
            public double TamanioEnM2 { get; set; }
        }

        public class PostANewZooCommandValidator : AbstractValidator<PostANewZooCommand>{
            public PostANewZooCommandValidator(){
                RuleFor(z => z.Nombre).NotEmpty().WithMessage("Debe ingresar un nombre");
                RuleFor(z => z.Ciudad).NotEmpty().WithMessage("Debe ingresar un ciudad");
                RuleFor(z => z.Pais).NotEmpty().WithMessage("Debe ingresar un pais");
                RuleFor(z => z.TamanioEnM2).NotEmpty().WithMessage("Debe ingresar un tamaño")
                .GreaterThan(0).WithMessage("El tamaño debe ser mayor a 0");
            }
        }

        public class PostANewZooCommandHandler : IRequestHandler<PostANewZooCommand, RespuestaBase>
        {
            private readonly ZoosContext _context;
            private readonly PostANewZooCommandValidator _validator;
            private readonly IExisteZooConEseNombreCiudadYPais _DbValidator;
            public PostANewZooCommandHandler(ZoosContext context, PostANewZooCommandValidator validator,
            IExisteZooConEseNombreCiudadYPais DbValidator
            )
            {
                _context = context;
                _validator = validator;
                _DbValidator = DbValidator;
            }
            
            public async Task<RespuestaBase> Handle(PostANewZooCommand request, CancellationToken cancellationToken)
            {
                _validator.Validate(request);
                RespuestaBase result = new();
                try
                {
                    var ciudad = await _context.Ciudades
                    .Where(c => c.Nombre == request.Ciudad)
                    .FirstOrDefaultAsync(cancellationToken: cancellationToken);
                    var pais = await _context.Paises
                    .Where(c => c.Nombre == request.Pais)
                    .FirstOrDefaultAsync(cancellationToken: cancellationToken);

                    if(ciudad != null && pais != null){
                        Zoo newZoo = new Zoo{
                            Nombre = request.Nombre,
                            CiudadId = ciudad.Id,
                            PaisId = pais.Id,
                            PresupuestoAnual = request.PresupuestoAnual,
                            TamanioEnM2 = request.TamanioEnM2
                        };

                        await _DbValidator.Validar(newZoo);

                        await _context.Zoos.AddAsync(newZoo, cancellationToken);
                        await _context.SaveChangesAsync(cancellationToken);
                        
                        result.Ok = true;
                        result.StatusCode = System.Net.HttpStatusCode.OK;
                    }
                    else{
                        result.Ok = false;
                        result.StatusCode = System.Net.HttpStatusCode.NotFound;
                        result.MensajeInfo = "La ciudad o pais ingresado no esta contemplado";
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