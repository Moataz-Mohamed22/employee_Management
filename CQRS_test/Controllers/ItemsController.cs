using CQRS_lib.CQRS.Commands;
using CQRS_lib.CQRS.Queries;
using CQRS_lib.Data.Models;
using CQRS_lib.Repos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepo _repo;
        private readonly IMediator _mediarto;

      

        public ItemsController(IItemsRepo repo, IMediator mediarto)
        {
            _repo = repo;
            _mediarto = mediarto;
        }
        [HttpGet("Get-All")]
        public async Task<IActionResult> GetAll()
        {

            var res = await _mediarto.Send(new GetAllQuery());
            return Ok(res);
           
        }

        [HttpPost("Add")]
        public async Task<IActionResult>Add(Item item)
        {
            //_repo.AddItem(item);
            //return Ok(item);

            var res = await _mediarto.Send(new AddItemCommand(item));
            return Ok(res);
        }
    }
}
