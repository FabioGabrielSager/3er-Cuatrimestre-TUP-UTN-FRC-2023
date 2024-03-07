using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using API.Data;
using API.DTOs.SocioDTOs;
using API.Services.SocioServ.BackEndValidators;
using FluentValidation;
using MediatR;

namespace API.Services.SocioServ.Commands
{
    public class AddSocio
    {
        public class AddSocioCommand : IRequest<SocioGuardadoDTO>{
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string Telefono { get; set; }
        }

        public class AddSocioValidation : AbstractValidator<AddSocioCommand>{
            public AddSocioValidation(){
                RuleFor((regla) => regla.Nombre).NotEmpty().WithMessage("El nombre no debe estar vacio");
                RuleFor((regla) => regla.Apellido).NotEmpty().WithMessage("El apellido no debe estar vacio");
                RuleFor((regla) => regla.Telefono).MaximumLength(20);
            }
        }

        public class AddSocioHandler : IRequestHandler<AddSocioCommand, SocioGuardadoDTO>
        {
            private readonly ApplicationContext _contexto;
            private readonly AddSocioValidation _validator;
            private readonly IExisteSocio _existeSocio;

            public AddSocioHandler(ApplicationContext context, AddSocioValidation validation,
            IExisteSocio existeSocio){
                _contexto = context;
                _validator = validation;
                _existeSocio = existeSocio;
            }
            public async Task<SocioGuardadoDTO> Handle(AddSocioCommand request, CancellationToken cancellationToken)
            {
                _validator.Validate(request);
                SocioGuardadoDTO result = new SocioGuardadoDTO();
                try{
                    Socio socio = new Socio(){ Nombre = request.Nombre, Apellido = request.Apellido, Telefono = request.Telefono };
                    
                    await _existeSocio.Validar(socio);

                    await _contexto.Socios.AddAsync(socio, cancellationToken);
                    await _contexto.SaveChangesAsync(cancellationToken);

                    result.Socio = new SocioDTO{
                        Nombre = socio.Nombre,
                        Apellido = socio.Apellido,
                        Telefono = socio.Telefono,
                        Id = socio.Id
                    };
                    result.Ok = true;
                    result.StatusCode = HttpStatusCode.OK;
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