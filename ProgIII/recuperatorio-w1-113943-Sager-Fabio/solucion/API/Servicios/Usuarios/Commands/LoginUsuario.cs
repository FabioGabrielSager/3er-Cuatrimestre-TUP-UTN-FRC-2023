using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Servicios.Usuarios.Commands
{
    public class LoginUsuario
    {
        public class LoginUsuarioCommand : IRequest<RespuestaBase>{
            public string Usuario { get; set; }

            public string Password { get; set; }

            public string Rol { get; set; }
        }

        public class LoginUsuarioCommandValidator : AbstractValidator<LoginUsuarioCommand>{
            public LoginUsuarioCommandValidator(){
                RuleFor(a=> a.Usuario).NotEmpty().WithMessage("Debe ingresar un usuario");
                RuleFor(a => a.Password).NotEmpty().WithMessage("Debe ingresar un password");
                RuleFor(a => a.Rol).NotEmpty().WithMessage("Debe ingresar un rol");
            }
        }

        public class LoginUsuarioCommandHandler : IRequestHandler<LoginUsuarioCommand, RespuestaBase>
        {
            private readonly ApplicationContext _context;
            private readonly LoginUsuarioCommandValidator _validator;

            public LoginUsuarioCommandHandler(ApplicationContext context, LoginUsuarioCommandValidator validator){
                _context = context;
                _validator = validator;
            }

            public async Task<RespuestaBase> Handle(LoginUsuarioCommand request, CancellationToken cancellationToken)
            {
                _validator.Validate(request);
                RespuestaBase result = new();

                try
                {
                    var rol = await _context
                    .Roles
                    .Where(r => r.Nombre == request.Rol)
                    .FirstOrDefaultAsync(cancellationToken: cancellationToken);

                    if(rol != null){
                        bool existeUsuario = await _context
                        .Usuarios.AnyAsync(u => u.NombreUsuario == request.Usuario && u.Password == request.Password &&
                        u.IdRol == rol.Id, cancellationToken: cancellationToken);

                        if(existeUsuario){
                            result.Ok = true;
                            result.MensajeInfo = "Usuario encontrado, puede ingresar";
                            result.StatusCode = System.Net.HttpStatusCode.OK;
                        }
                        else{
                            result.Ok = false;
                            result.MensajeInfo = "Usuario no encontrado, no puede ingresar";
                            result.StatusCode = System.Net.HttpStatusCode.NotFound;
                        }
                    }
                    else{
                        result.Ok = false;
                        result.MensajeInfo = "Rol no encontrado, no puede ingresar";
                        result.StatusCode = System.Net.HttpStatusCode.NotFound;
                    }

                }
                catch (System.Exception e)
                {
                    result.Ok = false;
                    result.MensajeInfo = e.Message;
                    result.Error = e.StackTrace;
                    result.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                }
                return result;
            }
        }
    }
}