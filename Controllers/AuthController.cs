// Controllers/AuthController.cs
using api_pokelab.Data;
using api_pokelab.Models;
using api_pokelab.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using System.Security.Claims;

namespace api_pokelab.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(TokenService tokenService, PokeDbContext context) : ControllerBase
    {
        private readonly TokenService _tokenService = tokenService;
        private readonly PokeDbContext _context = context;

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLogin request)
        {
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
                return BadRequest("Username and password are required.");

            var user = _context.Users.SingleOrDefault(u => u.Username == request.Username);

            if (user == null)
            {
                return Unauthorized("Invalid username or password.");
            }
            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return Unauthorized("Invalid username or password.");
            }

                var token = _tokenService.GenerateToken(user.Username,
            [
                new (ClaimTypes.Name, user.Username),
                new (ClaimTypes.Email, user.Email),
                new (ClaimTypes.Role, "User") // TODO: Or set roles based on your logic
            ]);

                return Ok(new { Token = token });

        }
    }
}