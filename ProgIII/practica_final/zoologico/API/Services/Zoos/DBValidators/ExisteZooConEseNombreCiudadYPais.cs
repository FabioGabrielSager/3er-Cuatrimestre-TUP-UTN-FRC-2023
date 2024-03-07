using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Services.Zoos.DBValidators
{
    public class ExisteZooConEseNombreCiudadYPais : IExisteZooConEseNombreCiudadYPais
    {
            private readonly ZoosContext _context;
            public ExisteZooConEseNombreCiudadYPais(ZoosContext context)
            {
                _context = context;
            }

        public async Task Validar(Zoo zoo)
        {
            bool existe = await _context.Zoos
            .Where(
                z => z.Nombre.Equals(zoo.Nombre) && z.PaisId == zoo.PaisId && z.CiudadId == zoo.CiudadId
            )
            .AnyAsync();
            if(existe)
            {
                throw new Exception("Ese zoologico ya se encuentra registrado");
            }
        }
    }
}