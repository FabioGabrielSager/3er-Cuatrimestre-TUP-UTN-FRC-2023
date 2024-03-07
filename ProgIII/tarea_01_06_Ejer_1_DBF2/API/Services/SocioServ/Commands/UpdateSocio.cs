using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using API.Data;
using API.DTOs.SocioDTOs;
using API.Services.SocioServ.BackEndValidators;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Services.SocioServ.Commands
{
    public class UpdateSocio
    {
        public class UpdateSocioCommand : IRequest<SocioGuardadoDTO>{
            public int Id { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Telefono { get; set; }
        }

        public class UpdateSocioValidator : AbstractValidator<UpdateSocioCommand>{
            public UpdateSocioValidator(){
                RuleFor((s) => s.Id).NotEmpty().WithMessage("La id no puede estar vacia");
            }
        }

        public class UpdateSocioHandler : IRequestHandler<UpdateSocioCommand, SocioGuardadoDTO>
        {
            private readonly ApplicationContext _context;
            private readonly UpdateSocioValidator _validator;

            public UpdateSocioHandler(ApplicationContext context, UpdateSocioValidator validator){
                _context = context;
                _validator = validator;
            }
            public async Task<SocioGuardadoDTO> Handle(UpdateSocioCommand request, CancellationToken cancellationToken)
            {
                _validator.Validate(request);
                SocioGuardadoDTO result = new();
                try{
                    var socioResponse = await _context.Socios.FirstOrDefaultAsync((s) => s.Id == request.Id, cancellationToken: cancellationToken);
                    
                    if(socioResponse != null) {
                        socioResponse.Nombre = request.Nombre;
                        socioResponse.Apellido = request.Apellido;
                        socioResponse.Telefono = request.Telefono;

                        _context.Update(socioResponse);
                        await _context.SaveChangesAsync(cancellationToken);

                        result.Socio = new SocioDTO(){
                            Id = socioResponse.Id,
                            Nombre = socioResponse.Nombre,
                            Apellido = socioResponse.Apellido,
                            Telefono = socioResponse.Telefono
                        };
                        result.Ok = true;
                        result.StatusCode = HttpStatusCode.OK;
                    }
                    else{
                        throw new Exception($"El socio de id {request.Id} no existe");
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