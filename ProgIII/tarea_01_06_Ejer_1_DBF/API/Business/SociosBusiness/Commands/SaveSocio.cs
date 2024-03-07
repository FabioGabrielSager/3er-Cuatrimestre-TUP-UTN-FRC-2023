using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using FluentValidation;
using MediatR;

namespace API.Business.SociosBusiness.Commands
{
    public class SaveSocio
    {
        public class SaveSocioCommand : IRequest<Socio>{
            public string Nombre { get; set; } = null!;

            public string? Apellido { get; set; }

            public string? Telefono { get; set; }
        }

        public class SaveSocioCommandValidation : AbstractValidator<SaveSocioCommand> {
            public SaveSocioCommandValidation(){
                RuleFor(s => s.Nombre).NotEmpty();
                RuleFor(s => s.Nombre).MaximumLength(100);
                RuleFor(s => s.Apellido).NotEmpty();
                RuleFor(s => s.Telefono).NotEmpty();
            }
        }

        public class SaveSocioHandler : IRequestHandler<SaveSocioCommand, Socio>
        {
            private readonly PrograDataBaseFirstContext _context;
            private readonly SaveSocioCommandValidation _validation;

            public SaveSocioHandler(PrograDataBaseFirstContext context, SaveSocioCommandValidation validation)
            {
                _context = context;
                _validation = validation;
            }
            public async Task<Socio> Handle(SaveSocioCommand request, CancellationToken cancellationToken)
            {
                _validation.Validate(request);
                try{
                    Socio socio = new Socio();
                    socio.Nombre = request.Nombre;
                    socio.Apellido = request.Apellido;
                    socio.Telefono = request.Telefono;

                    await _context.Socios.AddAsync(socio);
                    await _context.SaveChangesAsync();

                    return socio;
                }
                catch(Exception ex){
                    throw ex;
                }
            }
        }
    }
}