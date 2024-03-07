using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace API.DTOs.BarcoDTOs
{
    public class BarcoConNombreYApellidoDeSocioDTO : ResultadoBase
    {
        public BarcoDTO Barco {get; set;}
        public string NombreYApellidoSocio {get; set;}
    }
}