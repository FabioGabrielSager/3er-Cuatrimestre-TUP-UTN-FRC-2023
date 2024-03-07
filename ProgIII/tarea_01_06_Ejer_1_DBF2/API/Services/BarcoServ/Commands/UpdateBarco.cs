using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using API.Data;
using API.DTOs.BarcoDTOs;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Services.BarcoServ.Commands
{
    public class UpdateBarco
    {
            public class UpdateBarcoCommand : IRequest<BarcoConNombreYApellidoDeSocioDTO>{
                public int Id { get; set; }

                public int NroMatricula { get; set; }

                public string Nombre { get; set; }

                public int NroAmarre { get; set; }

                public double Cuota { get; set; }
            }

            public class UpdateBarcoValidator : AbstractValidator<UpdateBarcoCommand>{
                public UpdateBarcoValidator() { 
                    RuleFor((r) => r.Id).NotEmpty().WithMessage("La ID no puede estar vacia");
                    RuleFor((r) => r.NroMatricula).NotEmpty().WithMessage("El nro. matricula no puede esta vacia");
                    RuleFor((r) => r.Nombre).NotEmpty().WithMessage("El nro. matricula no puede estar vacia")
                    .MinimumLength(3).WithMessage("El nombre debe tener como minimo tres caracteres");
                    RuleFor((r) => r.NroAmarre).NotEmpty().WithMessage("El nro. matricula no puede esta vacia");
                    RuleFor((r) => r.Cuota).NotEmpty().WithMessage("El nro. matricula no puede estar vacia")
                    .GreaterThan(0).WithMessage("La cuota debe ser mayor a 0");
                }
            }

            public class UpdateBarcoHandler : IRequestHandler<UpdateBarcoCommand, BarcoConNombreYApellidoDeSocioDTO>
            {
                private readonly ApplicationContext _context;
                private readonly UpdateBarcoValidator _validator;

                public UpdateBarcoHandler(ApplicationContext context, UpdateBarcoValidator validator){
                    _context = context;
                    _validator = validator;
                }

                public async Task<BarcoConNombreYApellidoDeSocioDTO> Handle(UpdateBarcoCommand request, CancellationToken cancellationToken)
                {
                    _validator.Validate(request);
                    BarcoConNombreYApellidoDeSocioDTO result = new();

                    using(var transaction = _context.Database.BeginTransaction()){
                    try
                    {
                        var response = await _context.Barcos
                        .Include((b) => b.IdSocioNavigation)
                        .Where((b) => b.Id == request.Id).FirstOrDefaultAsync(cancellationToken);

                        if(response != null){
                            result.Barco = new BarcoDTO
                            {
                                Nombre = response.Nombre = request.Nombre,
                                NroAmarre = response.NroAmarre = request.NroAmarre,
                                NroMatricula = response.NroMatricula = request.NroMatricula,
                                Cuota = response.Cuota = request.Cuota
                            };
                            result.NombreYApellidoSocio = $"{response.IdSocioNavigation.Nombre} {response.IdSocioNavigation.Apellido}";
                            _context.Update(response);
                            await _context.SaveChangesAsync();
                            transaction.Commit();

                            result.Ok = true;
                            result.StatusCode = HttpStatusCode.OK;
                            result.MensajeInfo = "Barco guardado correctamente";
                        }
                        else{
                            result.Ok = false;
                            result.StatusCode = HttpStatusCode.NotFound;
                            result.MensajeInfo = $"No se encontro ningún barco con id {request.Id}";
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
}