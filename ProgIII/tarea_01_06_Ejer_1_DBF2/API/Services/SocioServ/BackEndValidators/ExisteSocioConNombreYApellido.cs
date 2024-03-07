using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Services.SocioServ.BackEndValidators
{
    public class ExisteSocioConNombreYApellido : IExisteSocio
    {
        private readonly ApplicationContext _context;
        public ExisteSocioConNombreYApellido(ApplicationContext context){
            _context = context;
        }
        public async Task Validar(Socio socio)
        {
            bool existe = await _context.Socios.AnyAsync((s) => s.Nombre == socio.Nombre && s.Apellido == socio.Apellido);
            if(existe){
                throw new Exception($"El socio de apellido {socio.Apellido} y nombre {socio.Nombre} ya existe");
            }
        }
    }
}