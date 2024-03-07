using EjemploCQRS.Dtos;
using MediatR;

namespace EjemploCQRS.Servicios.Personas
{
    public class ConsultarPersonasQuery : IRequest<ListadoPersonas>
    {
    }
}
