using Application.Commands;
using Application.Models.Notification;
using Application.Models.User;
using Application.Queries;
using Application.Queries.Handler;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace StockServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NotificationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<NotificationResponse>))]
        [Route("UserId")]
        public async Task<IActionResult> GetNotification(int userId)
        {
            var query = new GetNotificationQuery(userId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotificaiton(CreateNotificationRequest request)
        {
            var command = new CreateNotificationCommand(request);
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveNotificaiton(int id)
        {
            var command = new RemoveNotificaitonCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
