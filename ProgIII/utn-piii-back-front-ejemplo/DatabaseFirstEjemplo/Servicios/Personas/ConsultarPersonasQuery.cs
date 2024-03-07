using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseFirstEjemplo.Dtos;
using MediatR;

namespace DatabaseFirstEjemplo.Servicios.Personas
{
    public class ConsultarPersonasQuery : IRequest<ListadoPersonas>
    {
    }
}