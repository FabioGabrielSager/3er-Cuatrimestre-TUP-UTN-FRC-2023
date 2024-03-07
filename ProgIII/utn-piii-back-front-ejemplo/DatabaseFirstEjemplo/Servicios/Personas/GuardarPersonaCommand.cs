using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseFirstEjemplo.Dtos;
using MediatR;

namespace DatabaseFirstEjemplo.Servicios.Personas
{
    public class GuardarPersonaCommand : IRequest<PersonaGuardada>
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public long TipoDocumentoId { get; set; }
    }
}