using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BewerbungAPP.Models; // مدل User
using BewerbungAPP.Data;   // ApplicationDbContext
using BCrypt.Net;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BewerbungAPP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        public class LoginRequest
        {
            public string BenutzernameOderEmail { get; set; }
            public string Passwort { get; set; }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.BenutzernameOderEmail) || string.IsNullOrWhiteSpace(request.Passwort))
                return BadRequest("Ungültige Eingaben");

            var user = await _context.Users
                .Where(u => u.Name == request.BenutzernameOderEmail || u.Email == request.BenutzernameOderEmail)
                .FirstOrDefaultAsync();

            if (user == null || !user.Status)
                return Unauthorized("Benutzer nicht gefunden oder nicht aktiv");

            // Passwort überprüfen
            if (!BCrypt.Net.BCrypt.Verify(request.Passwort, user.Password))
                return Unauthorized("Falsches Passwort");

            // Token erzeugen
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("DiesIstEinSehrGeheimerJWTKey123456!"); 
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // حذف رمز
            user.Password = null;

            // همراه با user، توکن رو هم بفرست
            return Ok(new { benutzer = user, token = tokenString });
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> GetAktuellerBenutzer()
        {
            var userIdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdStr))
                return Unauthorized("Kein Benutzer-Token gefunden");

            if (!int.TryParse(userIdStr, out var userId))
                return Unauthorized("Ungültiger Benutzer-Token");

            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                return NotFound("Benutzer nicht gefunden");

            // Passwort nicht senden
            user.Password = null;

            return Ok(user);
        }
    }
}
