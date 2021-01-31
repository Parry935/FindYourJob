using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Database;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly ITokenService _tokenService;

        public AccountController(AppDbContext db, ITokenService tokenService)
        {
            _db= db;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(UserRegisterDto userRegisterDto)
        {
            if(await UserExists(userRegisterDto.Email))
            {
                return BadRequest("Email is taken");
            }

            using var hmac = new HMACSHA512();

            var user = new User
            {
                FirstName = userRegisterDto.FirstName,
                LastName = userRegisterDto.LastName,
                Email = userRegisterDto.Email.ToLower(),
                Phone = userRegisterDto.Phone,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userRegisterDto.Password)),
                PasswordSalt = hmac.Key
            };


            _db.users.Add(user);
            await _db.SaveChangesAsync();

            return new UserDto
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(UserLoginDto userLoginDto)
        {
            var user = await _db.users.SingleOrDefaultAsync(m=>m.Email == userLoginDto.Email);

            if(user == null)
            {
                return Unauthorized("Invalid email");
            }

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userLoginDto.Password));

            for(int i = 0; i<passwordHash.Length; i++)
            {
                if(passwordHash[i] != user.PasswordHash[i])
                     return Unauthorized("Invalid password");
            }

             return new UserDto
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user)
            };
        }

        private async Task<bool>UserExists(string Email)
        {
            return await _db.users.AnyAsync(m=>m.Email == Email.ToLower());
        }
    }
}