using Microsoft.AspNetCore.Mvc;
using ApiComercial.Entities;
using ApiComercial.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using ApiComercial.Models.Request;

namespace ApiComercial.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {

        private readonly ApiComercial.interfaces.IAuthService _authService;

        public AuthController(ApiComercial.interfaces.IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _authService.ValidateUserAsync(request);
            if (user == null)
                return Unauthorized(new { message = "Usuario o contraseña incorrectos" });

            var token = _authService.GenerateJwtToken(user);
            return Ok(new { token });
        }
    }

    // Clase LoginRequest movida a Models/Request/LoginRequest.cs
}
