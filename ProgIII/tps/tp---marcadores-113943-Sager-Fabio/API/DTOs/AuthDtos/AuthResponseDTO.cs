using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.AuthDtos
{
    public class AuthResponseDTO : BaseResponse
    {
        public string IdUsuario { get; set; }
        public string Token { get; set; }
        public string EmailUsuario { get; set; }
        public string UrlImagen { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int IdRol { get; set; }
        public string RolName { get; set; }

    }
}