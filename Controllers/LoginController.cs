using HIVBackend.Data;
using HIVBackend.Models;
using HIVBackend.Models.DBModuls;
using HIVBackend.Models.FormModels;
using HIVBackend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        public IActionResult Post(LoginForm userLog)
        {
            if (userLog.username is null || userLog.password is null)
                return BadRequest("Invalid client request");

            TblUser? user = _context.TblUsers.FirstOrDefault(e => e.Uid == userLog.username && e.Pwd == userLog.password);

            if (user is null) return Unauthorized();

            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, user.UserName),
                new (ClaimTypes.Role, "User")
            };

            if (user.Write1 == true)
                claims.Add(new Claim(ClaimTypes.Role, "Writer"));
            if (user.Delete1 == true)
                claims.Add(new Claim(ClaimTypes.Role, "Deleter"));
            if (user.Admin1 == true)
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            if (user.Excel1 == true)
                claims.Add(new Claim(ClaimTypes.Role, "Excel"));
            if (user.Klassif1 == true)
                claims.Add(new Claim(ClaimTypes.Role, "Klassif"));
            if (user.Lab == true)
                claims.Add(new Claim(ClaimTypes.Role, "Lab"));

            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddHours(6);

            _context.SaveChanges();

            return Ok(new AuthenticatedResponse
            {
                Token = accessToken,
                RefreshToken = refreshToken
            });
        }
    }
}
