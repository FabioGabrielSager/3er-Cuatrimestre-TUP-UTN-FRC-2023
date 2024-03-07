using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Servicios.NivelsServ.queries
{
    public class GetNivelById
    {
        public class GetNivelByIdQuery : IRequest<NivelConDocentesDTO>{
            public int Id { get; set;}
        }

        public class GetNivelByIdQueryValidator : AbstractValidator<GetNivelByIdQuery>{
            public GetNivelByIdQueryValidator(){
                RuleFor(n => n.Id).NotEmpty().GreaterThan(0).WithMessage("El id no puede estar vacio o ser menor a 1");
            }
        }

        public class GetNivelByIdHandler : IRequestHandler<GetNivelByIdQuery, NivelConDocentesDTO>{
            private readonly ApplicationContext _context;
            private readonly GetNivelByIdQueryValidator _validator;

            public GetNivelByIdHandler(ApplicationContext context, GetNivelByIdQueryValidator validator){
                _context = context;
                _validator = validator;
            }

            public async Task<NivelConDocentesDTO> Handle(GetNivelByIdQuery request, CancellationToken cancellationToken)
            {
                _validator.Validate(request);
                NivelConDocentesDTO result = new();
                
                try
                {
                    var nivel = await _context.Nivels
                    .Include(n => n.Docentes)
                    .Where(n => n.Id == request.Id)
                    .FirstOrDefaultAsync(cancellationToken: cancellationToken);

                    if (nivel != null){
                        result.docentes = nivel.Docentes.Select(n => new DocenteDTO(){
                            Id = n.Id,
                            Nombre = n.Nombre,
                            Apellido = n.Apellido,
                            Edad = n.Edad,
                            Email = n.Email,
                            Nivel = nivel.Nombre
                        }).ToList();
                        result.Nombre = nivel.Nombre;

                        result.MensajeInfo = "Nivel encontrado";
                        result.StatusCode = System.Net.HttpStatusCode.OK;
                        result.Ok = true;
                    }
                    else{
                        result.MensajeInfo = "No se encontro un nivel con id " + request.Id;
                        result.StatusCode = System.Net.HttpStatusCode.NotFound;
                        result.Ok = false;
                    }
                }
                catch (System.Exception e)
                {
                    result.MensajeInfo = e.Message;
                    result.Error = e.StackTrace;
                    result.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                    result.Ok = false;
                }
                return result;
            }
        }
    }
}