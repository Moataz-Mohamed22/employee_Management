using CQRS_lib.CQRS.Queries;
using CQRS_lib.Data;
using CQRS_lib.Data.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_lib.CQRS.Handlers
{
    public class GetItemsListHandler : IRequestHandler<GetAllQuery, List<Item>>
    {
        private readonly AppDbContext _context;

        public GetItemsListHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Item>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_context.Items.ToList());
        }
    }
}
