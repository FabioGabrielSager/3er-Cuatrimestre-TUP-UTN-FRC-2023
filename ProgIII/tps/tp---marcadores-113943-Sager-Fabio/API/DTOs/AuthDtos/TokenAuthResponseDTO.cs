using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.AuthDtos
{
    public class TokenAuthResponseDTO : BaseResponse
    {
        public string Token { get; set; }
    }
}