using Angular_.NET_SignalR_ChatApp.Data;
using Angular_.NET_SignalR_ChatApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Angular_.NET_SignalR_ChatApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDatabaseContext _db;

        public UserController(AppDatabaseContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<AppDatabaseContext>>> Get()
        {
            return Ok(await _db.Users.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<AppDatabaseContext>>> Get(int id)
        {
            var user = _db.Users.Find(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<List<AppDatabaseContext>>> Post(User data)  //Dataset dataset
        {
            DateTime dt = DateTime.Now; 
            data.CreatedAt = dt;
            data.UpdatedAt = dt;
            _db.Users.Add(data);
            await _db.SaveChangesAsync();
            return Ok(data);
        }

        [HttpPut]
        public async Task<ActionResult<List<AppDatabaseContext>>> Put(User data)
        {
            DateTime dt = DateTime.Now;
            data.UpdatedAt = dt;
            _db.Users.Update(data);
            _db.SaveChanges();
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<AppDatabaseContext>>> Delete(int id)
        {
            var data = _db.Users.Find(id);
            _db.Users.Remove(data);
            await _db.SaveChangesAsync();
            return Ok(data);
        }

        [HttpPatch]
        public async Task<ActionResult<List<AppDatabaseContext>>> Truncate()
        {
            _db.Database.ExecuteSqlRaw("TRUNCATE TABLE Users");
            return Ok();
        }
    }
}
