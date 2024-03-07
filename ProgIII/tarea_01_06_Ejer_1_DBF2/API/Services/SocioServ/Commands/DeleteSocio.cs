using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using API.Data;
using API.DTOs.SocioDTOs;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Services.SocioServ.Commands
{
    public class DeleteSocio
    {
        public class DeleteSocioCommand : IRequest<SocioGuardadoDTO>{
            public int Id { get; set; }
        }

        public class DeleteSocioValidator : AbstractValidator<DeleteSocioCommand>{
            public DeleteSocioValidator(){
                RuleFor((s) => s.Id).NotEmpty().WithMessage("La id no puede estar vacia");
            }
        }

        public class DeleteSocioHandler : IRequestHandler<DeleteSocioCommand, SocioGuardadoDTO>
        {
            private readonly ApplicationContext _context;
            private readonly DeleteSocioValidator _validator;

            public DeleteSocioHandler(ApplicationContext context, DeleteSocioValidator validator){
                _context = context;
                _validator = validator;
            }
            public async Task<SocioGuardadoDTO> Handle(DeleteSocioCommand request, CancellationToken cancellationToken)
            {
                _validator.Validate(request);
                SocioGuardadoDTO result = new();

                using(var transaction = _context.Database.BeginTransaction()){
                    try{
                        var socioResponse = await _context.Socios
                        .Include((s) => s.Barcos)
                        .FirstOrDefaultAsync((s) => s.Id == request.Id, cancellationToken: cancellationToken);
                        
                        if(socioResponse != null) {
                            _context.Barcos.RemoveRange(socioResponse.Barcos);

                            _context.Socios.Remove(socioResponse);

                            await _context.SaveChangesAsync(cancellationToken);
                            transaction.Commit();

                            result.Socio = new SocioDTO(){
                                Id = socioResponse.Id,
                                Nombre = socioResponse.Nombre,
                                Apellido = socioResponse.Apellido,
                                Telefono = socioResponse.Telefono
                            };
                            result.Ok = true;
                            result.StatusCode = HttpStatusCode.OK;
                            result.MensajeInfo = "El socio fue eliminado correctamente";
                        }
                        else{
                            result.Ok = false;
                            result.StatusCode = HttpStatusCode.NotFound;
                            result.Error = $"El socio de id {request.Id} no existe";
                        }
                    }
                    catch(Exception ex){
                        transaction.Rollback();
                        result.Error = ex.Message;
                        result.StatusCode = HttpStatusCode.InternalServerError;
                        result.Ok = false;
                    }
                }
                
                return result;
            }
        }
    }
}
