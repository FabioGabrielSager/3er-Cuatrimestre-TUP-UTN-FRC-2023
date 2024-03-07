using EjemploCQRS.Datos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EjemploCQRS.Servicios.Personas
{
    public class ExistePersonaServicio : IExistePersonaServicio
    {
        private readonly EfdatabaseFirstContext _contexto;

        public ExistePersonaServicio(EfdatabaseFirstContext contexto)
        {
            _contexto = contexto;
        }
        public async Task Validar(Persona persona)
        {
            bool existePersona = await _contexto.Personas.AnyAsync((x) =>
            x.Nombre == persona.Nombre &&
                    x.Apellido == persona.Apellido
                );
            if (existePersona)
            {
                throw new Exception("La persona ya existe");
            }
        }
    }

    public interface IExistePersonaServicio
    {
        Task Validar(Persona persona);
    }
}
