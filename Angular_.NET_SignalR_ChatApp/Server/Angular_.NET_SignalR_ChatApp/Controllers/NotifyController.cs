using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Angular_.NET_SignalR_ChatApp.Hubs;
using Angular_.NET_SignalR_ChatApp.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace Angular_.NET_SignalR_ChatApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotifyController : ControllerBase
    {
        public readonly IHubContext<NotifyHub> _hub;

        public NotifyController(IHubContext<NotifyHub> hub)
        {
            _hub = hub;
        }

        [HttpPost]
        public async Task<ActionResult<List<Message>>> Post(Message msg)
        {
            _hub.Clients.All.SendAsync("chatStation1", msg);
            return Ok();
        }

        //[HttpGet]
        //public async Task<ActionResult<List<Message>>> Get()
        //{
        //    return Ok(msg);
        //}

        //[HttpPost]
        //public async Task<ActionResult<List<Message>>> Post(Message message)
        //{
        //    //var messageTemp = new Message() { User = "Night", MsgScript = "test message " + Guid.NewGuid().ToString() };
        //    try
        //    {
        //        List<Message> msgSet = new List<Message>();



        //        Message newMsg = new Message() { User = message.User, MsgScript = message.MsgScript };
        //        msg.Add(newMsg);
        //        _hub.Clients.All.BroadcastMessage(message);
        //        return Ok();
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.ToString());
        //    }
        //}
    }
}
