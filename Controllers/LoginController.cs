using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using HIVBackend.Models.DBModuls;
using HIVBackend.Data;
using HIVBackend.Services;
using HIVBackend.Models;

namespace HIVBackend.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly HivContext _context;
        private readonly ITokenService _tokenService;
        public LoginController(HivContext context, ITokenService tokenService)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Post(string login, string password)
        {
            if (login is null || password is null) return BadRequest("Invalid client request");

            TblUser? user = _context.TblUsers.FirstOrDefault(e => e.Uid == login && e.Pwd == password);

            if (user is null) return Unauthorized();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName)
            };

            if (user.Write1 == -1)
                claims.Add(new Claim(ClaimTypes.Role, "Writer"));
            if (user.Delete1 == -1)
                claims.Add(new Claim(ClaimTypes.Role, "Deleter"));
            if (user.Admin1 == -1)
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            if (user.Excel1 == -1)
                claims.Add(new Claim(ClaimTypes.Role, "Excel"));
            if (user.Klassif1 == -1)
                claims.Add(new Claim(ClaimTypes.Role, "Klassif"));

            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(1);

            _context.SaveChanges();

            return Ok(new AuthenticatedResponse
            {
                Token = accessToken,
                RefreshToken = refreshToken
            });
        }
    }
}
