using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using HIVBackend.Models.DBModuls;
using HIVBackend.Data;
using HIVBackend.Services;
using HIVBackend.Models;
using HIVBackend.Models.FormModels;

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
                new Claim(ClaimTypes.Name, user.UserName)
            };
            claims.Add(new Claim(ClaimTypes.Role, "User"));
            claims.Add(new Claim(ClaimTypes.Role, "User1"));

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

            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddHours(6);
            //Console.WriteLine(DateTime.UtcNow.AddMinutes(-14));

            _context.SaveChanges();

            return Ok(new AuthenticatedResponse
            {
                Token = accessToken,
                RefreshToken = refreshToken
            });
        }
    }
}
