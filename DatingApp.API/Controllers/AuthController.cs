using System.Threading.Tasks;
using DatingAPP.API.Data;
using DatingAPP.API.Dtos;
using DatingAPP.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatingAPP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            _repo = repo;

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto){

            if(string.IsNullOrEmpty(userForRegisterDto.Username) || string.IsNullOrEmpty(userForRegisterDto.Password))
            return BadRequest("Username or Password is empty");

            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if(await _repo.UserExists(userForRegisterDto.Username)) return BadRequest("User Already Exists");

            var UserToCreated = new User{
                Username = userForRegisterDto.Username
            };
            
            var CreatedUser = await _repo.Register(UserToCreated,userForRegisterDto.Password);

            return StatusCode(201);

        }
    }
}