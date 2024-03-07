using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.AuthDtos;

namespace API.Services
{
    public interface IAuthenticationService{
        Task<TokenAuthResponseDTO> AuthenticateAndGetToken();
    }
}