using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Business.SociosBusiness.Queries
{
    public class GetSocioById
    {
        public class GetSocioByIdQuery : IRequest<Socio>{
            public int Id { get; set; }
        }

        public class GetSocioByIdQueryValidation : AbstractValidator<GetSocioByIdQuery> {
            public GetSocioByIdQueryValidation(){
                RuleFor(g => g.Id).NotEmpty();
            }
        }

        public class GetSocioByIdHandler : IRequestHandler<GetSocioByIdQuery, Socio>
        {
            private readonly PrograDataBaseFirstContext _context;
            private readonly GetSocioByIdQueryValidation _validation;

            public GetSocioByIdHandler(PrograDataBaseFirstContext context, GetSocioByIdQueryValidation validation)
            {
                _context = context;
                _validation = validation;
            }
            public async Task<Socio> Handle(GetSocioByIdQuery request, CancellationToken cancellationToken)
            {
                _validation.Validate(request);
                try{
                    var socio = await _context.Socios.FirstOrDefaultAsync(s => s.Id == request.Id);
                    if(socio != null)
                        return socio;
                    else
                        throw new ArgumentNullException(nameof(socio));
                }
                catch(Exception ex){
                    throw ex;
                }
            }
        }
    }
}