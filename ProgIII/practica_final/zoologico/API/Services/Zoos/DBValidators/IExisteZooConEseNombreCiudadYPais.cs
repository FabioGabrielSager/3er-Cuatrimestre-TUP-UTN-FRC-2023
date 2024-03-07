using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;

namespace API.Services.Zoos.DBValidators
{
    public interface IExisteZooConEseNombreCiudadYPais
    {
        public Task Validar(Zoo zoo);
    }
}