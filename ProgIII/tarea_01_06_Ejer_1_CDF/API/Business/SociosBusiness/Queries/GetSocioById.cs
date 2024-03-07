using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using Clases.Models;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Business.SociosBusiness.Queries
{
    public class GetSocioById
    {
        
        public class Query : IRequest<Socio>{
            public int Id { get; set; }
        }

        public class GetSocioByIdQueryValidation : AbstractValidator<Query> {
            public GetSocioByIdQueryValidation(){
                RuleFor(g => g.Id).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Query, Socio>
        {
            private readonly ContextDB _context;

            public Handler(ContextDB context)
            {
                _context = context;
            }
            
            public async Task<Socio> Handle(Query request, CancellationToken cancellationToken)
            {
                try{
                    var socio = await _context.Socios.FirstOrDefaultAsync(s => s.Id == request.Id);
                    if(socio != null)
                        return socio;
                    else
                        throw new ArgumentNullException("No existe persona con id: " + request.Id);
                }
                catch(Exception ex){
                    throw;
                }
            }
        }
    }
}