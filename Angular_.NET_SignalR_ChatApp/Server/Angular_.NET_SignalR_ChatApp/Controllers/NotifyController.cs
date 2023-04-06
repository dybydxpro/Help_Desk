using Angular_.NET_SignalR_ChatApp.Hubs;
using Angular_.NET_SignalR_ChatApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Angular_.NET_SignalR_ChatApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotifyController : ControllerBase
    {
        public readonly IHubContext<NotifyHub, ITypedHubClient> _hub;

        public NotifyController(IHubContext<NotifyHub, ITypedHubClient> hub)
        {
            _hub = hub;
        }

        [HttpGet]
        public async Task<ActionResult<List<Message>>> Get() 
        {
            var message = new Message() { User = "Night", MsgScript = "test message " + Guid.NewGuid().ToString() };
            try
            {
                _hub.Clients.All.BroadcastMessage(message);
                return Ok();
            }
            catch (Exception e)
            {
                 e.ToString();
                return BadRequest(e.ToString());
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<Message>>> Post(Message message)
        {
            try
            {
                _hub.Clients.All.BroadcastMessage(message);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
}
