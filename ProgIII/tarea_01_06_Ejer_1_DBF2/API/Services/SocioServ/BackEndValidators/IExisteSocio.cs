using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;

namespace API.Services.SocioServ.BackEndValidators
{
    public interface IExisteSocio
    {
        Task Validar(Socio socio);
    }
}