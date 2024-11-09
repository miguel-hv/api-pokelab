// Controllers/AuthController.cs
using api_pokelab.Models;
using api_pokelab.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace api_pokelab.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(TokenService tokenService) : ControllerBase
    {
        private readonly TokenService _tokenService = tokenService;

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLogin request)
        {
            // For demo purposes, use hardcoded username and password. Replace this with real validation logic.
            if (request.Username == "testuser" && request.Password == "password123")
            {
                var token = _tokenService.GenerateToken(request.Username,
            [
                new (ClaimTypes.Name, request.Username),
                new (ClaimTypes.Role, "User") // TODO: Or set roles based on your logic
            ]);

                return Ok(new { Token = token });
            }

            return Unauthorized();
        }
    }
}