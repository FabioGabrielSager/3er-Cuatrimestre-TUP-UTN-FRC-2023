using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using API.DTOs;
using API.DTOs.AuthDtos;

namespace API.Services.Imps
{
    public class AuthenticationService : IAuthenticationService
    {
        public async Task<TokenAuthResponseDTO> AuthenticateAndGetToken()
        {
            string apiUrl = "https://prog3.nhorenstein.com/api/usuario/LoginUsuarioWeb";
            string nombreUsuario = "asd";
            string password = "asd";
            
            TokenAuthResponseDTO result = new TokenAuthResponseDTO();

            try {
                // Usamos using cn HttpCli para asegurarnos de que se liberen los recursos implicados una vez 
                // terminada la ejecución del bloque asociado.
                using (HttpClient client = new HttpClient())
                {
                    // Creamos objeto anonimo el cual contiene la información necesaria para la auntenticación y 
                    // va a ser serializado durante el post.
                    var authData = new { nombreUsuario, password };
                    var authResponse = await client.PostAsJsonAsync(apiUrl, authData);
                    
                    if (authResponse.IsSuccessStatusCode)
                    {
                        var authResult = await authResponse.Content.ReadFromJsonAsync<TokenAuthResponseDTO>();
                        result = authResult;
                    }
                    else 
                    {
                        var authError = await authResponse.Content.ReadFromJsonAsync<ValidationErrorResponseDTO>();
                        foreach(List<String> errors in authError.Errors.Values){
                            foreach (String error in errors)
                            {
                                result.Error += " " + error;
                            }
                        }
                        result.MensajeInfo = authError.Title;
                        result.Ok = false;
                        result.StatusCode = authError.Status;
                    }
                }
            }
            catch (Exception ex) {
                result.Error = ex.Message;
                result.Ok = false;
                result.StatusCode = HttpStatusCode.InternalServerError;
            }
            
            return result;
        }
    }
}