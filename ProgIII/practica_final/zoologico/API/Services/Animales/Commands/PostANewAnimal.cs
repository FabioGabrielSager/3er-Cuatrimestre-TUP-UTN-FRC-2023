using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using MediatR;

namespace API.Services.Animales.Commands
{
    public class PostANewAnimal
    {
        public class PostANewAnimalCommand : IRequest<RespuestaBase>{
            public int PaisId { get; set; }
            public int ContinenteId { get; set; }
            public Guid ZooId { get; set;}
            public int FamiliaId { get; set; }
            public string Nombre { get; set; }
            public string NombreCientifico { get; set; }
            public string Sexo { get; set; }
            public int AnioDeNacimiento { get; set; }
            public bool PeligroDeExtincion { get; set; }
        }

        public class PostANewAnimalCommandHandler : IRequestHandler<PostANewAnimalCommand, RespuestaBase>
        {
            private readonly ZoosContext _context;
            public PostANewAnimalCommandHandler(ZoosContext context)
            {
                _context = context;
            }
            public async Task<RespuestaBase> Handle(PostANewAnimalCommand request, CancellationToken cancellationToken)
            {
                RespuestaBase result = new();

                try
                {
                    Animal animal = new Animal(){
                        PaisId = request.PaisId,
                        ContinenteId = request.ContinenteId,
                        ZooId = request.ZooId,
                        FamiliaId = request.FamiliaId,
                        Nombre = request.Nombre,
                        NombreCientifico = request.NombreCientifico,
                        Sexo = request.Sexo,
                        AnioDeNacimiento = request.AnioDeNacimiento,
                        PeligroDeExtincion = request.PeligroDeExtincion
                    };
                    await _context.Animales.AddAsync(animal, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);

                    result.Ok = true;
                    result.StatusCode = System.Net.HttpStatusCode.OK;
                    result.MensajeInfo = "Animal agregado correctamente";

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