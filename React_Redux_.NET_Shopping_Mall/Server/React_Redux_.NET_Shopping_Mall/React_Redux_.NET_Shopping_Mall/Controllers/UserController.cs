using React_Redux_.NET_Shopping_Mall.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace React_Redux_.NET_Shopping_Mall{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserRegister userRegister)
        {
            User user = new User();
            PasswordSet pwset = CreatePasswordHash(userRegister.Password);

            List<User> users = _db.Users.Where(x => x.Email == user.Email).ToList();
            if (users.Count > 0)
            {
                return BadRequest("Email already used!");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    user.Name = userRegister.Name;
                    user.Email = userRegister.Email;
                    user.PasswordHash = passwordHash;
                    user.PasswordSalt = passwordSalt;

                    await _db.Users.AddAsync(user);
                    _db.SaveChanges();
                    return Ok(user);
                }
                else
                {
                    return NotFound("Registation failed!");
                }
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(UserLogin userLogin)
        {
            List<User> user = _db.Users.Where(x => x.Email == userLogin.Email).ToList();

            if (!VerifyPasswordHash(userLogin.Password, user[0].PasswordHash, user[0].PasswordSalt))
            {
                return BadRequest("Wrong password!");
            }

            string token = CreateToken(user[0]);
            return Ok(token);
        }
    }
}