using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseFirstEjemplo.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirstEjemplo.Servicios.Personas
{
    public class ExistePersonaServicio : IExistePersonaServicio
    {
        private readonly EfdatabaseFirstContext _context;

        public ExistePersonaServicio(EfdatabaseFirstContext efdatabaseFirstContext){
            _context = efdatabaseFirstContext;
        }


        public async Task ValidarAsync(Persona persona)
        {
            bool existePersona = await _context.Personas.AnyAsync((x) => 
            x.Nombre == persona.Nombre && x.Apellido == persona.Apellido);
            if(existePersona)
                throw new Exception("La persona ya existe");
        }
    }

    public interface IExistePersonaServicio{
        Task ValidarAsync(Persona persona);
    }
}