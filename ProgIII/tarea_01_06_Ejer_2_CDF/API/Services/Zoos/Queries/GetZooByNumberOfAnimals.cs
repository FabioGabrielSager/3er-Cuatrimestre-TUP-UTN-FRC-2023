using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOS.Zoos;
using DB;
using FluentValidation;
using MediatR;

namespace API.Services.Zoos.Queries
{
    public class GetZooByNumberOfAnimals
    {
        public class Quiery : IRequest<ZooWithAnimals>{
            public int NumberOfAnimals { get; set; }
        }

        public class Validator : AbstractValidator<Quiery>{
            public Validator(){
                RuleFor(r => r.NumberOfAnimals)
                .GreaterThan(0)
                .WithMessage("Debe ingresar un numero mayor a 0")
                .NotEmpty()
                .WithMessage("Debe ingresar un valor");
            }
        }

        public class Handler : IRequestHandler<Quiery, ZooWithAnimals>
        {
            private readonly ZoosContext _context;
            private readonly Validator _validator;

            public Handler(ZoosContext context, Validator validator){
                _context = context;
                _validator = validator;
            }

            public Task<ZooWithAnimals> Handle(Quiery request, CancellationToken cancellationToken)
            {
                ZooWithAnimals result = new();

                throw new NotImplementedException();
            }
        }
    }
}