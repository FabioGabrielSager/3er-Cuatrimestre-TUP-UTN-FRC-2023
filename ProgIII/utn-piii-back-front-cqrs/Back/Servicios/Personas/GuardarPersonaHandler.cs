using EjemploCQRS.Datos;
using EjemploCQRS.Dtos;
using MediatR;
using System.Net;

namespace EjemploCQRS.Servicios.Personas
{
    public class GuardarPersonaHandler
        : IRequestHandler<GuardarPersonaCommand, PersonaGuardada>
    {
        private readonly EfdatabaseFirstContext _contexto;
        private readonly IExistePersonaServicio _existePersonaServicio;

        public GuardarPersonaHandler(
            EfdatabaseFirstContext contexto,
            IExistePersonaServicio existePersonaServicio
        )
        {
            _contexto = contexto;
            _existePersonaServicio = existePersonaServicio;
        }
        public async Task<PersonaGuardada> Handle(GuardarPersonaCommand request, 
            CancellationToken cancellationToken)
        {
            PersonaGuardada respuesta = new PersonaGuardada();
            try
            {
                Persona persona = new Persona
                {
                    Nombre = request.Nombre,
                    Apellido = request.Apellido,
                    TipoDocumentoId = request.TipoDocumentoId
                };

                await _existePersonaServicio.Validar(persona);

                await _contexto.Personas.AddAsync(persona);
                await _contexto.SaveChangesAsync();

                respuesta.Persona = new PersonaDto
                {
                    Id = persona.Id,
                    NombreCompleto = $"{persona.Nombre}, {persona.Apellido}",
                };
                respuesta.Exito = true;
                respuesta.Codigo = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                respuesta.Error = ex.Message;
                respuesta.Exito = false;
                respuesta.Codigo = HttpStatusCode.InternalServerError;
            }

            return respuesta;
        }
    }
}
