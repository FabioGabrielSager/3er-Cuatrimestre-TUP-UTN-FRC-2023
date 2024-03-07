using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using Clases.Models;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Business.BarcosBusiness.Quries
{
    public class GetBarcoById
    {
        public class Query : IRequest<Barco>{
            public int Id { get; set; }
        }

        public class GetSocioByIdQueryValidation : AbstractValidator<Query> {
            public GetSocioByIdQueryValidation(){
                RuleFor(g => g.Id).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Query, Barco>
        {
            private readonly ContextDB _context;

            public Handler(ContextDB context)
            {
                _context = context;
            }
            
            public async Task<Barco> Handle(Query request, CancellationToken cancellationToken)
            {
                try{
                    var barco = await _context.Barcos.FirstOrDefaultAsync(b => b.Id == request.Id);
                    if(barco != null)
                        return barco;
                    else
                        throw new ArgumentNullException("No existe barco con id: " + request.Id);
                }
                catch(Exception ex){
                    throw;
                }
            }
        }
    }
}