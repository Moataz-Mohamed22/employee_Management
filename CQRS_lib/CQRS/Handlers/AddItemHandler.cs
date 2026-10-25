using CQRS_lib.CQRS.Commands;
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
    public class AddItemHandler : IRequestHandler<AddItemCommand, Item>
    {
        private readonly AppDbContext _context;

        public AddItemHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Item> Handle(AddItemCommand request, CancellationToken cancellationToken)
        {
         await   _context.Items.AddAsync(request.item);
            _context.SaveChanges();
            return await Task.FromResult(request.item);
        }
    }
}
