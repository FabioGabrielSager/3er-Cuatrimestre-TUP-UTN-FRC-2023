using EjemploCQRS.Dtos;
using MediatR;

namespace EjemploCQRS.Servicios.Personas
{
    public class GuardarPersonaCommand : IRequest<PersonaGuardada>
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public long TipoDocumentoId { get; set; }
    }
}
