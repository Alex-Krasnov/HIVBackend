using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HIVBackend.Models.FormModels
{
    public class LoginForm
    {
        public string username { get; set; }
        public string password { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
