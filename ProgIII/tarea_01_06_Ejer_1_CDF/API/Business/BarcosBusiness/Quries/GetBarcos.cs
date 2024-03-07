using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using Clases.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Business.BarcosBusiness.Quries
{
    public class GetBarcos
    {
        public class Query : IRequest<IEnumerable<Barco>> {}

        public class Handler : IRequestHandler<Query, IEnumerable<Barco>>
        {
            private readonly ContextDB _context;

            public Handler(ContextDB context) { _context = context; }

            public async Task<IEnumerable<Barco>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Barcos.ToListAsync(cancellationToken);
            }
        }
    }
}