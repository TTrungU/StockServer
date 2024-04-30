using Application.Models.User;
using Application.Queries;
using Infracstructure.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace StockServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController :ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserResponse>))]
        public async Task<IActionResult> GetAllUser()
        {
            var query = new GetAllUserQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(UserResponse))]
        public async Task<IActionResult> GetUser(int userId)
        {
            var query = new GetUserQuery(userId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

    }

   
}
