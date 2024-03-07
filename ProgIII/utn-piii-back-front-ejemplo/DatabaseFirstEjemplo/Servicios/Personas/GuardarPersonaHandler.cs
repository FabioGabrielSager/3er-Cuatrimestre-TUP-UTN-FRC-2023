using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseFirstEjemplo.Dtos;
using DatabaseFirstEjemplo.Models;
using MediatR;

namespace DatabaseFirstEjemplo.Servicios.Personas
{
    public class GuardarPersonaHandler : IRequestHandler<GuardarPersonaCommand, PersonaGuardada>
    {
        private readonly EfdatabaseFirstContext _contexto;
        public GuardarPersonaHandler(EfdatabaseFirstContext efdatabaseFirstContext){
            _contexto = efdatabaseFirstContext;
        }
        public Task<PersonaGuardada> Handle(GuardarPersonaCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}