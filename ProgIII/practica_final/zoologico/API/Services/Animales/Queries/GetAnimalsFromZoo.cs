using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs.Animales;
using API.Services.Zoos.DBValidators;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Services.Animales.Queries
{
    public class GetAnimalsFromZoo
    {
        public class GetAnimalsFromZooQuery : IRequest<ListaAnimalesDTO>{
            public string NombreZoo { get; set; }
            public string PaisZoo { get; set; }
            public string CiudadZoo { get; set; }
        }

        public class GetAnimalsFromZooQueryHandler : IRequestHandler<GetAnimalsFromZooQuery, ListaAnimalesDTO>
        {
            private readonly ZoosContext _context;
            public GetAnimalsFromZooQueryHandler(ZoosContext context)
            {
                _context = context;
            }
            public async Task<ListaAnimalesDTO> Handle(GetAnimalsFromZooQuery request, CancellationToken cancellationToken)
            {
                ListaAnimalesDTO result = new();
                try
                {
                    var dbResponse = await _context.Animales
                        .Include(a => a.ContinenteIdNavegation)
                        .Include(a => a.PaisIdNavegation)
                        .Include(a => a.FamiliaIdNavegation)
                        .Include(a => a.ZooIdNavegation)
                        .Where(a => a.ZooIdNavegation.IdCiudadZooNavegation.Nombre == request.CiudadZoo
                        && a.ZooIdNavegation.IdPaisZooNavegation.Nombre == request.PaisZoo &&
                        a.ZooIdNavegation.Nombre == request.NombreZoo)
                        .ToListAsync(cancellationToken: cancellationToken);

                    if(dbResponse != null){                        
                    result.Animales = dbResponse.Select(a => new AnimalStandard(){
                            Nombre = a.Nombre,
                            NombreCientifico = a.NombreCientifico,
                            Pais = a.PaisIdNavegation.Nombre,
                            PeligroDeExtincion = a.PeligroDeExtincion,
                            AnioDeNacimiento = a.AnioDeNacimiento,
                            Familia = a.FamiliaIdNavegation.Nombre,
                            Continente = a.ContinenteIdNavegation.Nombre,
                            Sexo = a.Sexo
                        }).ToList();

                        result.StatusCode = System.Net.HttpStatusCode.OK;
                        result.Ok = true;
                    }
                    else{
                        result.Ok = false;
                        result.StatusCode = System.Net.HttpStatusCode.NotFound;
                        result.MensajeInfo = "No se encontro el Zoo indicado";
                    }
                }
                catch (System.Exception e)
                {
                    result.Ok = false;
                    result.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                    result.MensajeInfo = e.Message;
                    result.Error = e.StackTrace;
                }
                return result;
            }
        }
    }
}