using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using API.DTOs.AuthDtos;
using API.DTOs.MarksDtos;
using MediatR;

namespace API.Services.Markers.Queries
{
    public class GetAllMarkers
    {
        public class Query : IRequest<MarkerListDto>{}

        public class Handler : IRequestHandler<Query, MarkerListDto>
        {
            private readonly IAuthenticationService _authService;

            public Handler(IAuthenticationService authenticationService){
                _authService = authenticationService;
            }

            MarkerListDto result = new MarkerListDto();

            public async Task<MarkerListDto> Handle(Query request, CancellationToken cancellationToken)
            {
                string apiUrl = "https://prog3.nhorenstein.com/api/marcador/GetMarcadores"; 

                try{
                    String token = "";
                    TokenAuthResponseDTO tokenAuthResponseDTO = 
                    _authService.AuthenticateAndGetToken().Result;
                    
                    if(tokenAuthResponseDTO.Ok){
                        token = tokenAuthResponseDTO.Token;
                    }
                    else
                        throw new Exception("No se pudo obtener el token de autorización");

                    using (HttpClient client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                        var response = await client.GetAsync(apiUrl);

                        if (response.IsSuccessStatusCode)
                        {
                            var markers = await response.Content.ReadFromJsonAsync<MarkerListDto>();
                            return markers;
                        }
                        
                        result.Error = response.ReasonPhrase;
                        result.Ok = false;
                        result.StatusCode = response.StatusCode;
                    }
                }
                catch(Exception ex){
                    result.Error = ex.Message;
                    result.Ok = false;
                    result.StatusCode = HttpStatusCode.InternalServerError;
                }

                return result;
            }
        }
    }
}