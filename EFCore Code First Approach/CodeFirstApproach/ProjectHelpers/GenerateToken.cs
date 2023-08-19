using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjectHelpers
{
    public class GenerateToken
    {
        private string _userName { get; set; }
        private string _role { get; set; }
        public GenerateToken(string userName, string role)
        {
            _userName = userName;
            _role = role;
        }

        public string GetJWTToken()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secretKey = Encoding.ASCII.GetBytes("ThisIsSecretKeyForTokenValidation"); // can be configurable 
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, _userName),
                    new Claim(ClaimTypes.Role, _role)
                }),
                Audience = "https://localhost:44310", // who or what the token intended for (UI in most of the seenario)
                Issuer = "https://localhost:44310",  // who created and signed this token (Same API domain in this case if we move auth service out of the project it will the project domain)
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}